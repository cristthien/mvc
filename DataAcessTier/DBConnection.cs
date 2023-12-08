using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb; 
using System.Threading.Tasks;

namespace DataAcessTier
{
    public class DBConnection
    {
        protected  OleDbConnection conn; 
        public DBConnection ()
        {
            try {
                conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\\Users\\thien\\Documents\\dbSanPham.mdb;Persist Security Info=True");
            }
            catch (Exception) {

                throw;
            }
        }
    
    }
}
