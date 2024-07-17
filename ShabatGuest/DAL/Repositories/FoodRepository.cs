using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shabat.DAL.Models;
using ShabatGuest.DAL.Models;

namespace ShabatGuest.DAL.Repositories
{
    internal class FoodRepository
    {
        private readonly DBconnections DBconnections;

        public FoodRepository(DBconnections dBconnections)
        {
            DBconnections = dBconnections;
        }

        public List<CategoryModel> FindAll()
        {
            var foods = new List<CategoryModel>();
            string query = "select * from Food";
            DataTable ressult = DBconnections.ExecuteQuery(query, null);
            foreach (DataRow dr in ressult.Rows)
            {
                foods.Add(new CategoryModel(dr));
            }
            return foods;
        }

        public List<FoodModel> FindByCategory(CategoryModel category)
        {
            string query = "select * from Food c join Guest g on g.ID = c.GuestID where c.CategoryID = @ID";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ID", category.CategoryID)
            };
            DataTable ressult = DBconnections.ExecuteQuery(query, sqlParameters);
            List<FoodModel> categories = new List<FoodModel>();
  
            foreach (DataRow dr in ressult.Rows)
            {
                categories.Add(new FoodModel(dr));                
            }
            return categories;
        }

        public List<FoodModel> FindByCategorymine(CategoryModel category, int GID)
        {
            string query = "select * from Food f join Guest g on g.ID = f.GuestID where f.CategoryID = @ID and f.GuestID = @GID; ";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ID", category.CategoryID),
                new SqlParameter("@GID", GID)
            };
            DataTable ressult = DBconnections.ExecuteQuery(query, sqlParameters);
            List<FoodModel> categories = new List<FoodModel>();

            foreach (DataRow dr in ressult.Rows)
            {
                categories.Add(new FoodModel(dr));
            }
            return categories;
        }

        public bool insert(FoodModel food)
        {
            string query = "insert into Food(FoodName, GuestID, CategoryID) values (@Name, @GID, @CID)";
            SqlParameter[] sqlParameters = { new SqlParameter("@Name", food.FoodName), new SqlParameter("@GID", food.guestID), new SqlParameter("@CID", food.categoryID) }; ;
            int rowsAffected = DBconnections.ExecuteNoneQuery(query, sqlParameters);
            return rowsAffected > 0;
        }
    }
}
