using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CemPattern;
using DenemeFactory;
using ConsoleTest.localhost;
using ConsoleTest.PatternMain.Model;
using ConsoleTest.PatternMain.Interface;
using ClassDAL;
using System.Configuration;
using Dal;
using System.Data;

namespace ConsoleTest
{
    class Program
    {

        static void Main(string[] args)
        {
             
            IDBManager dbManager = new DBManager(DataProvider.Odbc);
            dbManager.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            try
            {
                dbManager.Open();
                dbManager.ExecuteReader(CommandType.StoredProcedure,"List");
                while (dbManager.DataReader.Read())
                {
                    Console.Write(dbManager.DataReader["name"].ToString());
                }
            }

            catch (Exception ex)
            {
                //Usual Code
            }

            finally
            {
                dbManager.Dispose();
            }


        }
     static   void InsertData(int id, string name)
        {
            IDBManager dbManager = new DBManager(DataProvider.SqlServer);
            dbManager.ConnectionString = ConfigurationSettings.AppSettings["ConnectionString "].ToString();
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@id",id);
                dbManager.AddParameters(1, "@name", name);
                dbManager.ExecuteNonQuery(CommandType.StoredProcedure,
                 "Customer_Insert");
            }
            catch (Exception)
            {
                //Usual code              
            }
            finally
            {
                dbManager.Dispose();
            }
        }
    }
 
}
