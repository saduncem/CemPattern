using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public abstract class DataAccessBase
    {
        #region Exec SQL
        protected void ExecuteNonQuery(string storedProcedure, params SqlParam[] parameters)
        {
            try
            {
                using (SqlConnection cnx = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx) { CommandType = CommandType.StoredProcedure })
                    {
                        FillParameters(cmd, parameters);
                        cnx.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected object ExecuteScalar(string storedProcedure, params SqlParam[] parameters)
        {
            try
            {
                object toReturn = null;
                using (SqlConnection cnx = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx) { CommandType = CommandType.StoredProcedure })
                    {
                        FillParameters(cmd, parameters);
                        cnx.Open();
                        toReturn = cmd.ExecuteScalar();
                    }
                }
                return toReturn;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected DataSet ExecuteDataSet(string storedProcedure, params SqlParam[] parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection cnx = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx) { CommandType = CommandType.StoredProcedure })
                    {
                        FillParameters(cmd, parameters);
                        cnx.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(ds);
                    }
                }
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected SqlDataReader ExecuteDataReader(string storedProcedure, params SqlParam[] parameters)
        {
            SqlConnection cnx = GetConnection();
            try
            {
                SqlDataReader rtnReader;
                using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx) { CommandType = CommandType.StoredProcedure })
                {
                    FillParameters(cmd, parameters);
                    cnx.Open();
                    rtnReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                return rtnReader;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected DataTable ExecuteDataTable(string storedProcedure, params SqlParam[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnx = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, cnx) { CommandType = CommandType.StoredProcedure })
                    {
                        FillParameters(cmd, parameters);
                        cnx.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected object GetValue(DataRow row, string fieldName)
        {
            if (row[fieldName] != DBNull.Value)
            {
                return row[fieldName];
            }
            return null;
        }
        protected string GetValueToString(DataRow row, string fieldName)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                string s = (o as string);
                if (!string.IsNullOrEmpty(s))
                {
                    s = s.Trim();
                }
                return s;
            }
            return string.Empty;
        }
        protected int GetValueToInt(DataRow row, string fieldName, int defaultValue)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as int? ?? defaultValue;
            }
            return defaultValue;
        }
        protected int? GetValueToIntNull(DataRow row, string fieldName, int? defaultValue = null)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as int? ?? defaultValue;
            }
            return defaultValue;
        }
        protected decimal GetValueToDecimal(DataRow row, string fieldName, decimal defaultValue)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as decimal? ?? defaultValue;
            }
            return defaultValue;
        }
        protected decimal? GetValueToDecimalNull(DataRow row, string fieldName, decimal? defaultValue = null)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as decimal? ?? defaultValue;
            }
            return defaultValue;
        }
        protected bool GetValueToBool(DataRow row, string fieldName, bool defaultValue)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as bool? ?? defaultValue;
            }
            return defaultValue;
        }
        protected bool? GetValueToBoolNull(DataRow row, string fieldName, bool? defaultValue = null)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as bool? ?? defaultValue;
            }
            return defaultValue;
        }
        protected DateTime GetValueToDateTime(DataRow row, string fieldName, DateTime defaultValue)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as DateTime? ?? defaultValue;
            }
            return defaultValue;
        }
        protected DateTime? GetValueToDateTimeNull(DataRow row, string fieldName, DateTime? defaultValue = null)
        {
            object o = GetValue(row, fieldName);
            if (o != null)
            {
                return o as DateTime? ?? defaultValue;
            }
            return defaultValue;
        }
        protected object ToDbNullValue(string str)
        {
            return string.IsNullOrEmpty(str) ? (object)DBNull.Value : str;
        }
        protected object ToDbNullValue(int? val)
        {
            return val.HasValue ? val.Value : (object)DBNull.Value;
        }
        protected object ToDbNullValue(bool? val)
        {
            return val.HasValue ? val.Value : (object)DBNull.Value;
        }
        protected object ToDbNullValue(DateTime? val)
        {
            return val.HasValue ? val.Value : (object)DBNull.Value;
        }
        protected object ToDbNullValue(decimal? val)
        {
            return val.HasValue ? val.Value : (object)DBNull.Value;
        }
        protected object ToDbNullValue(float? val)
        {
            return val.HasValue ? val.Value : (object)DBNull.Value;
        }
        private void FillParameters(SqlCommand cmd, SqlParam[] parameters)
        {
            foreach (SqlParam param in parameters)
            {
                SqlParameter sqlParam = new SqlParameter(param.ParamName, param.ParamType.DbType);
                if (param.ParamType.Size.HasValue)
                {
                    sqlParam.Size = param.ParamType.Size.Value;
                }
                sqlParam.Direction = (ParameterDirection)((int)param.Direction);
                if (param.Value != null)
                {
                    sqlParam.Value = param.Value;
                }
                else
                {
                    sqlParam.Value = DBNull.Value;
                }
                cmd.Parameters.Add(sqlParam);
            }
        }
        protected void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
        private SqlConnection GetConnection()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings.Count == 0)
            {
                throw new Exception("No connection to the database is defined.");
            }
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
        #endregion
    }

    public class SqlParam
    {
        public SqlParam()
        {
            Direction = ParameterDirection.Input;
        }
        public string ParamName { get; set; }
        public SqlParamType ParamType { get; set; }
        public object Value { get; set; }
        public ParameterDirection Direction { get; set; }
    }

    public class SqlParamType
    {
        public SqlParamType(SqlDbType dbType)
        {
            this.DbType = dbType;
        }
        public SqlParamType(SqlDbType dbType, int size)
        {
            this.DbType = dbType;
            this.Size = size;
        }
        public SqlDbType DbType { get; set; }
        public int? Size { get; set; }
    }

    public static class DataReaderExtensions
    {
        public static string GetStringNullable(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }
        public static int? GetInt32Nullable(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? (int?)null : reader.GetInt32(ordinal);
        }
        public static DateTime? GetDateTimeNullable(this IDataReader reader, int ordinal)
        {
            return reader.IsDBNull(ordinal) ? (DateTime?)null : reader.GetDateTime(ordinal);
        }
    }
}
