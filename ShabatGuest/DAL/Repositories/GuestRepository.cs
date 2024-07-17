using Shabat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShabatGuest.DAL.Models;

namespace ShabatGuest.DAL.Repositories
{
    internal class GuestRepository
    {
        private readonly DBconnections DBconnections;

        public GuestRepository(DBconnections dBconnections)
        {
            DBconnections = dBconnections;
        }

        public List<GuestModel> FindAll()
        {
            var categories = new List<GuestModel>();
            string query = "select * from Guest";
            DataTable ressult = DBconnections.ExecuteQuery(query, null);
            foreach (DataRow dr in ressult.Rows)
            {
                categories.Add(new GuestModel(dr));
            }
            return categories;
        }

        public GuestModel FindByName(string Name)
        {
            string query = "select * from Guest c where c.Name = @Name";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Name", Name)
            };
            DataTable ressult = DBconnections.ExecuteQuery(query, sqlParameters);
            if (ressult.Rows.Count <= 0)
            {
                throw new Exception("invalid Name");
            }
            return new GuestModel(ressult.Rows[0]);
        }

        public bool insert(string guest)
        {
            string query = "insert into Guest(Name) values (@Name)";
            SqlParameter[] sqlParameters = { new SqlParameter("@Name", guest) }; ;
            int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
            return rowsAffected > 0;
        }

        //public bool update(CategoryModel categoty)
        //{
        //    string query = "update Guest set Name = @Name where ID = @ID";
        //    SqlParameter[] sqlParameters = { new SqlParameter("@Name", categoty.CategoryName), new SqlParameter("@ID", categoty.CategoryID) }; ;
        //    int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
        //    return rowsAffected > 0;
        //}
        //public bool delete(CategoryModel categoty)
        //{
        //    string query = "delete from Guest where ID = @ID";
        //    SqlParameter[] sqlParameters = { new SqlParameter("@ID", categoty.CategoryID) }; ;
        //    int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
        //    return rowsAffected > 0;
        //}
    }
}
