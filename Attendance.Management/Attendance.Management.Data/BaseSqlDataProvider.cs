using Attendance.Management.Common;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Attendance.Management.Data
{
    public class BaseSqlDataProvider
    {
        protected string dbName;
        public BaseSqlDataProvider(string dbName)
        {
            this.dbName = dbName;
        }
        protected void Execute(string procedure, object parameters)
        {
            var connection = new SqlConnection(getConnectionString());
            if(parameters == null)
            {
                connection.Execute(procedure, commandType: CommandType.StoredProcedure);
            }
            else
            {
                connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        protected IEnumerable<TResult> Query<TResult>(string procedure, object parameters)
        {
            if (parameters == null)
            {
                return Query<TResult>(procedure);
            }
            return Execute(c => c.Query<TResult>(procedure, parameters, commandType: CommandType.StoredProcedure));
        }
        private IEnumerable<TResult> Query<TResult>(string procedure)
        {
            return Execute(c => c.Query<TResult>(procedure, commandType: CommandType.StoredProcedure));
        }
        private TResult Execute<TResult>(Func<IDbConnection, TResult> query)
        {
            using (var connection = new SqlConnection(getConnectionString()))
            {
                return query(connection);
            }
        }
        protected string getConnectionString()
        {
            var connStrings = AppSettings.Instance.ConnectionStrings;
            string connString;
            switch (dbName)
            {
                case DatabaseNames.AttendanceSystem:
                    connString = connStrings.AttendanceSystem;
                    break;
                default:
                    throw new ArgumentException("Connection for Database named " + dbName + "was not found!");
            }
            return connString;
        }
    }
}