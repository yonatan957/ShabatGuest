using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatGuest.DAL.Models
{
    internal class FoodModel
    {
        
        public FoodModel(string guestName)
        {
            this.guestName = guestName;

        }
        public FoodModel(DataRow row)
        {
            if (row == null || row["FoodName"] == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            guestName = row["name"].ToString()!;
            foodID = (int)row["ID"];
            guestID = (int)row["GuestID"];
            categoryID = (int)row["CategoryID"];
            FoodName = row["Foodname"].ToString()!;
        }
        public FoodModel(string guestName, int guestID, int categoryID, string foodName)
        {
            this.guestName = guestName;
            this.guestID = guestID;
            this.categoryID = categoryID;
            FoodName = foodName;
        }

        public FoodModel(string guestName, int? foodID, int guestID, int categoryID, string foodName)
        {
            this.guestName = guestName;
            this.foodID = foodID;
            this.guestID = guestID;
            this.categoryID = categoryID;
            FoodName = foodName;
        }



        public string guestName { get; set; }
        public int? foodID { get; set; }
        public int guestID { get; set; }
        public int categoryID { get; set; }
        public string FoodName { get; set; }
    }
}
