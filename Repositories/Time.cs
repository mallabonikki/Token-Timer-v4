using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TokenTimerV4
{
    internal class Time
    {
        int intfID;

        public int fID
        {
            get { return intfID; }
            set { intfID = value; }
        }

        int intfTime;

        public int fTime
        {
            get { return intfTime; }
            set { intfTime = value; }
        }

        int intfToken;

        public int fToken
        {
            get { return intfToken; }
            set { intfToken = value; }
        }

        DateTime dtefInDate;

        public DateTime fInDate
        {
            get { return dtefInDate; }
            set { dtefInDate = value; }
        }

        DateTime dtefOutDate;

        public DateTime fOutDate
        {
            get { return dtefOutDate; }
            set { dtefOutDate = value; }
        }
    }
}
