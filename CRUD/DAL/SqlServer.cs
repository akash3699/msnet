using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.POCO;
using System.Configuration;
using System.Data.SqlClient;
using CRUD.DBLogger;

namespace CRUD.DAL
{
    public interface IDatabase
    {
        int Insert(Emp emp);
        List<Emp> Select();
        Emp Search(int No);
        int Delete(Emp emp);
        int Update(Emp emp);


    }


    public class SqlServer :IDatabase
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConString"].ToString());
        

        
        public int Insert(Emp emp)
        {
            #region Insert Proc
            
            conn.Open();
            String query = String.Format("Insert into Emp values({0},'{1}','{2}')", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        

        public List<Emp> Select()
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
            return emps;
            #endregion
        }

        public Emp Search(int No)
        {
            List<Emp> emps = this.Select();
            Emp e1 = null;

            var result = from e in emps
                       where e.No == No
                       select e;
            if(result != null)
            {
                if(result.Count() >0)
                e1 = result.First();
                return e1;
            }
            return null;
        }

        public int Delete(Emp emp)
        {
            #region Delete Proc

            conn.Open();
            String query = String.Format("Delete From Emp where No= {0}", emp.No);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        public int Update(Emp emp)
        {
            #region update Proc

            conn.Open();
            String query = String.Format("update Emp set Name='{1}', Address ='{2}' where No= {0}", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }
    }

    public class MySQL : IDatabase
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConString"].ToString());



        public int Insert(Emp emp)
        {
            #region Insert Proc

            conn.Open();
            String query = String.Format("Insert into Emp values({0},'{1}','{2}')", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        public List<Emp> Select()
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
            return emps;
            #endregion
        }

        public Emp Search(int No)
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

        public int Delete(Emp emp)
        {
            #region Delete Proc

            conn.Open();
            String query = String.Format("Delete From Emp where No= {0}", emp.No);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        public int Update(Emp emp)
        {
            #region update Proc

            conn.Open();
            String query = String.Format("update Emp set Name='{1}', Address ='{2}' where No= {0}", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }
    }

    public class Oracle : IDatabase
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConString"].ToString());



        public int Insert(Emp emp)
        {
            #region Insert Proc

            conn.Open();
            String query = String.Format("Insert into Emp values({0},'{1}','{2}')", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        public List<Emp> Select()
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
            return emps;
            #endregion
        }

        public Emp Search(int No)
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

        public int Delete(Emp emp)
        {
            #region Delete Proc

            conn.Open();
            String query = String.Format("Delete From Emp where No= {0}", emp.No);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        public int Update(Emp emp)
        {
            #region update Proc

            conn.Open();
            String query = String.Format("update Emp set Name='{1}', Address ='{2}' where No= {0}", emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(query, conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;

            #endregion
        }

        
    }
}
