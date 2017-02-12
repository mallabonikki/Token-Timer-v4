using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RawInput_dll
{
    public class RawInput : NativeWindow  
    {
        static RawKeyboard _keyboardDriver;
        readonly IntPtr _devNotifyHandle;
        static readonly Guid DeviceInterfaceHid = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");
        private PreMessageFilter _filter;

        public  event RawKeyboard.DeviceEventHandler KeyPressed
        {
            add { _keyboardDriver.KeyPressed += value; }
            remove { _keyboardDriver.KeyPressed -= value;}
        }

        public int NumberOfKeyboards
        {
            get { return _keyboardDriver.NumberOfKeyboards; } 
        }
        
        public void AddMessageFilter()
        {
            if (null != _filter) return;
            
            _filter = new PreMessageFilter();
            Application.AddMessageFilter(_filter);
        }

        private void RemoveMessageFilter()
        {
            if (null == _filter) return;

            Application.RemoveMessageFilter(_filter);
        }

        public RawInput(IntPtr parentHandle, bool captureOnlyInForeground)
        {
            AssignHandle(parentHandle);

            _keyboardDriver = new RawKeyboard(parentHandle, captureOnlyInForeground);
            _keyboardDriver.EnumerateDevices();
            _devNotifyHandle = RegisterForDeviceNotifications(parentHandle);
        }

        static IntPtr RegisterForDeviceNotifications(IntPtr parent)
        {
            var usbNotifyHandle = IntPtr.Zero;
            var bdi = new BroadcastDeviceInterface();
            bdi.DbccSize = Marshal.SizeOf(bdi);
            bdi.BroadcastDeviceType = BroadcastDeviceType.DBT_DEVTYP_DEVICEINTERFACE;
            bdi.DbccClassguid = DeviceInterfaceHid;

            var mem = IntPtr.Zero;
            try
            {
                mem = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BroadcastDeviceInterface)));
                Marshal.StructureToPtr(bdi, mem, false);
                usbNotifyHandle = Win32.RegisterDeviceNotification(parent, mem, DeviceNotification.DEVICE_NOTIFY_WINDOW_HANDLE);
            }
            catch (Exception e)
            {
                Debug.Print("Registration for device notifications Failed. Error: {0}", Marshal.GetLastWin32Error());
                Debug.Print(e.StackTrace);
            }
            finally
            {
                Marshal.FreeHGlobal(mem);
            }

            if (usbNotifyHandle == IntPtr.Zero)
            {
                Debug.Print("Registration for device notifications Failed. Error: {0}", Marshal.GetLastWin32Error());
            }
            
            return usbNotifyHandle;
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case Win32.WM_INPUT:
                    {
                        _keyboardDriver.ProcessRawInput(message.LParam);
                    }
                    break;

                case Win32.WM_USB_DEVICECHANGE:
                    {
                        //Debug.WriteLine("USB Device Arrival / Removal");
                        ErrorLogToText(" USB Device Arrival / Removal ", "WndProc");
                        _keyboardDriver.EnumerateDevices();
                    }
                    break;
            }

            base.WndProc(ref message);
        }

        public static void ErrorLogToText(string eventname, string exp)
        {
            bool pathIslocal = true;
            for (int i = 1; i <= 2; i++)
            {
                string path = (pathIslocal == true) ? Application.StartupPath : @"\\PC-99\e$\TokenData\";
                if (!System.IO.Directory.Exists(path)) return;
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path + @"\Errors_" + System.Environment.MachineName + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now + eventname + exp.ToString());
                }
                pathIslocal = false;
            }
        }

        ~RawInput()
        {
            Win32.UnregisterDeviceNotification(_devNotifyHandle);
            RemoveMessageFilter();
        }
    }
}
