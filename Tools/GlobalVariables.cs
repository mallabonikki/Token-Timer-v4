

namespace TokenTimerV4
{
    public static class GlobalVariables
    {
        //public static bool IsErrorDB { get; set; }
        static GlobalVariables()
        {
            fisttimeIsload = true;
            errorIsnone = false;
        } 
        public static bool fisttimeIsload { get; set; }
        public static bool errorIsnone { get; set; }
    }

}
