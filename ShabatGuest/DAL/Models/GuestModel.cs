using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatGuest.DAL.Models
{
    internal class GuestModel
    {
        public GuestModel(string guestName, int guestID)
        {
            this.guestName = guestName;
            this.guestID = guestID;
        }
        public GuestModel(string guestName)
        {
            this.guestName = guestName;
        }
        public GuestModel(DataRow row)
        {
            if (row == null || row["Name"] == null)
            {
                throw new ArgumentNullException(nameof(row));
            }
            guestName = row["name"].ToString()!;
            guestID = (int)row["ID"];
        }

        public string guestName { get; set; }
        public int guestID { get; set; }
    }
}
