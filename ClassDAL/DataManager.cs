using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
namespace ClassDAL
{
    public sealed class DataManager
    {
        private DbConnection dbConnection;
        private String strConnectionString;
        private DataProviderType dataProviderType;

        public DataManager(DataProviderType providerType, string connectionString)
    {
        this.strConnectionString = connectionString;
        this.dataProviderType = providerType;
        dbConnection = DBFactory.GetConnection(providerType);
        dbConnection.ConnectionString = connectionString;
    }

    public void Open()
    {
        if (dbConnection.State != ConnectionState.Open)
            dbConnection.Open();
    }

    public void Close()
    {
        if (dbConnection.State != ConnectionState.Closed)
            dbConnection.Close();
    }

    
    public DbConnection Connection
    {
        get
        {
            return dbConnection;
        }
    }

    public String ConnectionString
    {
        get
        {
            return strConnectionString;
        }
    }

    public DataProviderType DBProvider
    {
        get
        {
            return dataProviderType;
        }
    }

    public DataSet GetDataSet(String sqlString)
    {
     using (DbDataAdapter dbDataAdapter = DBFactory.GetDataAdapter(this.DBProvider))
        {
            try
            {

                dbDataAdapter.SelectCommand = DBFactory.GetCommand(this.DBProvider);
                dbDataAdapter.SelectCommand.CommandText = sqlString;
                dbDataAdapter.SelectCommand.Connection = this.Connection;

                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();
                dataTable.BeginLoadData();
                dbDataAdapter.Fill(dataTable);
                dataTable.EndLoadData();
                dataSet.EnforceConstraints = false;
                dataSet.Tables.Add(dataTable);
                return dataSet;
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
}