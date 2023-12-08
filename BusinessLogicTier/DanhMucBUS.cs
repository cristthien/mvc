using DataAcessTier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTier
{
    public class DanhMucBUS
    {


        DanhMucDAO objDM = new DanhMucDAO();
        public DataTable GetDanhMuc()
        {
            return objDM.GetAllDanhMuc();
        }
        public bool DeleteDanhMuc(string madm)
        {
            if (objDM.CheckDanhMucByID(madm))
                return objDM.DeleteDanhMuc(madm);
            else
                return false;
        }

    }
}
