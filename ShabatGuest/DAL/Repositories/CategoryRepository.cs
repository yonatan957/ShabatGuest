using Shabat.DAL.Models;
using ShabatGuest.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shabat.DAL.Repositories
{
    internal class CategoryRepository
    {
        private readonly DBconnections DBconnections;

        public CategoryRepository(DBconnections dBconnections)
        {
            DBconnections = dBconnections;
        }

        public List<CategoryModel> FindAll()
        {
            var categories = new List<CategoryModel>();
            string query = "select * from Categories order by Categories.ID";
            DataTable ressult = DBconnections.ExecuteQuery(query, null);
            foreach (DataRow dr in ressult.Rows)
            {
                categories.Add(new CategoryModel(dr));
            }
            if (categories.Count <= 0)
            {
                MessageBox.Show("didn't get any categoties");
            }
            return categories;
        }

        public CategoryModel FindByName(string Name)
        {
            string query = "select * form Categories c where c.Name = @Name";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Name", Name)
            }; 
            DataTable ressult = DBconnections.ExecuteQuery(query, sqlParameters);
            if (ressult.Rows.Count <= 0)
            {
                throw new Exception("invalid Name");
            }
            return new CategoryModel(ressult.Rows[0]);
        }

        public bool insert(CategoryModel categoty)
        {
            string query = "insert into Categories(Name) values (@Name)";
            SqlParameter[] sqlParameters = { new SqlParameter("@Name", categoty.CategoryName)}; ;
            int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
            return rowsAffected > 0;
        }

        public bool update(CategoryModel categoty)
        {
            string query = "update Categoties set Name = @Name where ID = @ID";
            SqlParameter[] sqlParameters = { new SqlParameter("@Name", categoty.CategoryName), new SqlParameter("@ID", categoty.CategoryID) }; ;
            int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
            return rowsAffected > 0;
        }
        public bool delete(CategoryModel categoty)
        {
            string query = "delete from Categoties where ID = @ID";
            SqlParameter[] sqlParameters = { new SqlParameter("@ID", categoty.CategoryID) }; ;
            int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
            return rowsAffected > 0;
        }
    }
}
