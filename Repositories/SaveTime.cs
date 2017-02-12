using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokenTimerV4
{
    internal class SaveTime
    {
        int stfID;
        public int StID
        {
            get { return stfID; }
            set { stfID = value; }
        }

        int stfTime;
        public int StTime
        {
            get { return stfTime; }
            set { stfTime = value; }
        }

        DateTime stfSaveDate;
        public DateTime StSaveDate
        {
            get { return stfSaveDate; }
            set { stfSaveDate = value; }
        }

        DateTime stfUseDate;
        public DateTime StUseDate
        {
            get { return stfUseDate; }
            set { stfUseDate = value; }
        }

        string stfPassword;
        public string StPassword
        {
            get { return stfPassword; }
            set { stfPassword = value; }
        }

        string stfUsePassword;
        public string StUsePassword
        {
            get { return stfUsePassword; }
            set { stfUsePassword = value; }
        }

        string stfPasswordw;
        public string StPasswordw
        {
            get { return stfPasswordw; }
            set { stfPasswordw = value; }
        }

    }
}
