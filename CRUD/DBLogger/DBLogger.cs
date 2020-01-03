using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CRUD.POCO;


namespace CRUD.DBLogger
{


    public class LoggerFactory
    {
        public ILogger GetLogger(int choice)
        {
            if (choice == 1)
            {
                return FileLogger.GetLogger();
            }
            else if (choice == 2)
            {
                return DBLogger.GetLogger();
            }
            else
            {
                return ConsoleLogger.GetLogger();
            }
        }

    }
    public class DBFactory
    {
        
        public Database GetDatabase(int choice)
        {
            if (choice == 1)
            {
                
                return new SqlServer();
            }
            else if (choice == 2)
            {
                
                return new Oracle();  
            }
            else
            {
                
                return new MySQL();
            }
        }

    }
    public abstract class Database
    {
       
        private ILogger _logger;
        public ILogger logger
        {
            set { _logger = value; }
        }

        public Database() : this(ConsoleLogger.GetLogger())
        {

        }
        public Database(ILogger logger)
        {
            //if (logger == null)
            //{
            //    this._logger = new ConsoleLogger();
            //}
            this._logger = logger;
        }

        public void DML(int opchoice, string somedata)
        {
            if (opchoice == 1)
            {
                Insert(somedata);
            }
            else if (opchoice == 2)
            {
                Update(somedata);
            }
            else
            {
                Delete(somedata);
            }
        }

        public List<Emp> Select(string someData)
        {
            
            _logger.Log(GetdatabaseName() + " Select Done");
            return Select();
        }

        public void Insert(string someData)
        {
             Insert(someData);
            _logger.Log(GetdatabaseName() + " Insert Done");
        }
        public void Update(string someData)
        {
            Update(someData);
            _logger.Log(GetdatabaseName() + " Update Done");
        }
        public void Delete(string someData)
        {
            Delete(someData);
            _logger.Log(GetdatabaseName() + " Delete Done");
        }

        protected abstract string GetdatabaseName();
        protected abstract List<Emp> Select();
        protected abstract int Insert(Emp emp);
        protected abstract int Delete(Emp emp);
        protected abstract int Update(Emp emp);
        protected abstract Emp Search(int No);
    }
    public class SqlServer : Database
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConString"].ToString());
        protected override string GetdatabaseName()
        {
            return "SQL Server";
        }

        protected override List<Emp> Select()
        {
            #region Select Proc

            List<Emp> emps = new List<Emp>();
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Emp", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Emp emp = new Emp()
                {
                    No = Convert.ToInt32(reader["No"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                };
                emps.Add(emp);
            }
            conn.Close();
            foreach (var emp in emps)
            {
                Console.WriteLine("No: {0} Name: {1}  Address: {2}", emp.No, emp.Name, emp.Address);
            }
            return emps;
            #endregion
        }

        protected override int Insert(Emp emp)
        {
            #region Insert Proc

            conn.Open();
            String query = String.Format("Insert into Emp values({0},'{1}','{2}')", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Affected " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }
        protected override Emp Search(int No)
        {
            List<Emp> emps = this.Select();
            Emp e1 = null;

            var result = from e in emps
                         where e.No == No
                         select e;
            if (result != null)
            {
                if (result.Count() > 0)
                    e1 = result.First();
                return e1;
            }
            return null;
        }

        protected override int Update(Emp emp)
        {
            #region update Proc

            conn.Open();
            String query = String.Format("update Emp set Name='{1}', Address ='{2}' where No= {0}", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Updated " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }

        protected override int Delete(Emp emp)
        {
            #region Delete Proc

            conn.Open();
            String query = String.Format("Delete From Emp where No= {0}", emp.No);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Updated " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }
    }
    public class Oracle : Database
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConString"].ToString());
        protected override string GetdatabaseName()
        {
            return "Oracle Server";
        }

        protected override List<Emp> Select()
        {
            #region Select Proc

            List<Emp> emps = new List<Emp>();
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Emp", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Emp emp = new Emp()
                {
                    No = Convert.ToInt32(reader["No"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                };
                emps.Add(emp);
            }
            conn.Close();
            foreach (var emp in emps)
            {
                Console.WriteLine("No: {0} Name: {1}  Address: {2}", emp.No, emp.Name, emp.Address);
            }
            return emps;
            #endregion
        }

        protected override int Insert(Emp emp)
        {
            #region Insert Proc

            conn.Open();
            String query = String.Format("Insert into Emp values({0},'{1}','{2}')", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Affected " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }
        protected override Emp Search(int No)
        {
            List<Emp> emps = this.Select();
            Emp e1 = null;

            var result = from e in emps
                         where e.No == No
                         select e;
            if (result != null)
            {
                if (result.Count() > 0)
                    e1 = result.First();
                return e1;
            }
            return null;
        }

        protected override int Update(Emp emp)
        {
            #region update Proc

            conn.Open();
            String query = String.Format("update Emp set Name='{1}', Address ='{2}' where No= {0}", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Updated " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }

        protected override int Delete(Emp emp)
        {
            #region Delete Proc

            conn.Open();
            String query = String.Format("Delete From Emp where No= {0}", emp.No);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Deleted " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }
    }
    public class MySQL : Database
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConString"].ToString());
        protected override string GetdatabaseName()
        {
            return "MySQL Server";
        }

        protected override List<Emp> Select()
        {
            #region Select Proc

            List<Emp> emps = new List<Emp>();
            conn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Emp", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Emp emp = new Emp()
                {
                    No = Convert.ToInt32(reader["No"]),
                    Name = reader["Name"].ToString(),
                    Address = reader["Address"].ToString(),
                };
                emps.Add(emp);
            }
            conn.Close();
            foreach (var emp in emps)
            {
                Console.WriteLine("No: {0} Name: {1}  Address: {2}", emp.No, emp.Name, emp.Address);
            }
            return emps;
            #endregion
        }

        protected override int Insert(Emp emp)
        {
            #region Insert Proc

            conn.Open();
            String query = String.Format("Insert into Emp values({0},'{1}','{2}')", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Inserted " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }
        protected override Emp Search(int No)
        {
            List<Emp> emps = this.Select();
            Emp e1 = null;

            var result = from e in emps
                         where e.No == No
                         select e;
            if (result != null)
            {
                if (result.Count() > 0)
                    e1 = result.First();
                return e1;
            }

            return null;
        }

        protected override int Update(Emp emp)
        {
            #region update Proc

            conn.Open();
            String query = String.Format("update Emp set Name='{1}', Address ='{2}' where No= {0}", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Updated " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }

        protected override int Delete(Emp emp)
        {
            #region Delete Proc

            conn.Open();
            String query = String.Format("Delete From Emp where No= {0}", emp.No);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowsAffected > 0)
            {
                Console.WriteLine("rows Deleted " + rowsAffected);
            }
            return rowsAffected;

            #endregion
        }
    }
    public interface ILogger
    {
        void Log(string msg);
    }
    public class ConsoleLogger : ILogger
    {
        private static ConsoleLogger clogger = new ConsoleLogger();
        private ConsoleLogger()
        {
            Console.WriteLine("Console Logger Object Created");
        }

        public static ConsoleLogger GetLogger()
        {
            return clogger;
        }
        public void Log(string msg)
        {
            Console.WriteLine("Console Logged: " + msg);
        }
    }
    public class FileLogger : ILogger
    {

        private static FileLogger flogger = new FileLogger();
        private FileLogger()
        {
            Console.WriteLine("File Logger Object Created");
        }

        public static FileLogger GetLogger()
        {
            return flogger;
        }
        public void Log(string msg)
        {
            Console.WriteLine("File Logged: " + msg);
        }
    }
    public class DBLogger : ILogger
    {
        private static DBLogger dblogger = new DBLogger();
        private DBLogger()
        {
            Console.WriteLine("DB Logger Object Created");
        }

        public static DBLogger GetLogger()
        {
            return dblogger;
        }
        public void Log(string msg)
        {
            Console.WriteLine("DB Logged: " + msg);
        }
    }
}
