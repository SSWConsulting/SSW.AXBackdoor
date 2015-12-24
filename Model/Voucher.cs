using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Voucher
    {
        public Voucher()
        { }

        private DateTime _transDate;
        private string _voucher;
        private string _txt;
        /// <summary>
        /// 
        /// </summary>
        public string VOUCHER
        {
            set { _voucher = value; }
            get { return _voucher; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TRANSDATE
        {
            set { _transDate = value; }
            get { return _transDate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TXT
        {
            set { _txt = value; }
            get { return _txt; }
        }
    }
}
