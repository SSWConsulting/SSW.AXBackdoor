using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    public class Voucher
    {
        private readonly DAL.Voucher dal = new DAL.Voucher();
        public Voucher()
        { }

        public Model.Voucher GetModel(int category, string voucher)
        {

            return dal.GetModel(category, voucher);
        }

        public int Update(int category, Model.Voucher model)
        {
            return dal.Update(category, model);
        }

        public DataSet GetGVList(int category, string strWhere, string order, ref int totalRowCount)
        {
            return dal.GetGVList(category, strWhere, order, ref totalRowCount);
        }
    }
}