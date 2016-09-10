using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDAL
{
    public class ClassDAL:IDisposable
    {
        // Connection string değişkeni tanımla
        private string m_ConStr;

        // SqlConnection veri kaynağına bağlantı hattını yapacak olan nesne.

        private SqlConnection con = null;
        // Yapıcı metod bir string parametresi alıyor
        public ClassDAL(string sConStr)
        {
            this.strConnection = sConStr;
        }

        // Sınıfa ait strConnection özelliği ile m_ConStr değişkeni
        // atanıyor ve bağlantı yaratılıyor.

        public string strConnection
        {
            get
            {
                return m_ConStr;
            }

            set
            {
                m_ConStr = value;
                try
                {
                    // SqlConnection bağlantı nesnesi yarat
                    this.con = new SqlConnection(value);
                }
                catch (Exception ex)
                {
                    // SqlConnection nesnesi yaratılırken hata oluştu
                    // Log kaydı alınacak.
                }//end try-catch
            }
        }

        // SQL sunucuyla olan bağlantı açılır.
        private void OpenDBConnection()
        {
            try
            {
                // Eğer bağlantı açık değilse
                if (con.State != ConnectionState.Open)
                    con.Open(); // Bağlantıyı aç
            }
            catch (Exception ex)
            {
                // Veritabanına bağlanırken hata oluştu.
                // Log kaydı alınacak.
            }//end try-catch
        }

        // SQL sunucuyla olan bağlantı kapatılır.
        public void CloseDBConnection()
        {
            try
            {
                if (con != null)
                    con.Close(); // Bağlantıyı kapat
            }
            catch (Exception ex)
            {
                // Log kaydı alınacak.
            }//end try-catch
        }

        // Kaynakları serbest bırak.
        public void Dispose()
        {
            // Bağlantı nesnesinin serbest bırakılması
            if (con != null)
            {
                con.Dispose();
                con = null;
            }//end if
        }
        public SqlParameter SetParameter(string sParamName, SqlDbType DbType, Int32 iSize, string sDirection, object oParamValue)
        {
            // SqlParameter nesnesi tanımla
            SqlParameter param = new SqlParameter(sParamName, DbType, iSize);

            //"sDirection" den alınan string değer, switch-case komutu 
            // ile Parametreye yön özelliği veriliyor.
            switch (sDirection)
            {
                case "Input":
                    param.Direction = ParameterDirection.Input;
                    break;
                case "Output":
                    param.Direction = ParameterDirection.Output;
                    break;
                case "ReturnValue":
                    param.Direction = ParameterDirection.ReturnValue;
                    break;
                case "InputOutput":
                    param.Direction = ParameterDirection.InputOutput;
                    break;
                default:
                    break;
            }//end switch

            // Parametere değerini ver
            param.Value = oParamValue;
            return param;
        }
        public SqlCommand GetCommand(string sProcName, SqlParameter[] prms)
{
      // SqlCommand nesnemizi oluşturuyoruz.
      SqlCommand cmd = new SqlCommand(sProcName, con);

      // Stored Procedure çağrısı
      cmd.CommandType = CommandType.StoredProcedure;

       // Parameters koleksiyonuna Add metodu ile ekleme yap.
       if (prms != null)
       {
            foreach (SqlParameter parameter in prms)
                 cmd.Parameters.Add( parameter );
       }
       //end if

       return cmd; // SqlCommand nesnesini döndür.
}

      
    
    }
}
