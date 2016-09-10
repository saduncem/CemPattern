using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDAL
{
      public  class Program
    
      
      {

          public void GetData()
          {

              DataManager dbManager = new DataManager(DataProviderType.SqlServer,ConfigurationSettings.AppSettings["MSSQL"].ToString());
                   

                    try
                    {
                      dbManager.Open();
                      var data = dbManager.GetDataSet("select * from edefter");
                      
                    }
 
                    catch (Exception ex)
                    {
                      throw;
                    }
 
                    finally
                    {
                      dbManager.Close();
                    }
          }
     

       }



}
