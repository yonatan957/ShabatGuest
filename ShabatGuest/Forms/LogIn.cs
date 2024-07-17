using ShabatGuest.DAL.Models;
using ShabatGuest.DAL.Repositories;
using ShabatGuest.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShabatGuest.BL;

namespace ShabatGuest.Forms
{
    internal partial class LogIn : Form
    {
        public DBconnections dbconnection;
        public GuestRepository _guestRepository;
        public LogIn(DBconnections dBconnections)
        {
            InitializeComponent();
            dbconnection = dBconnections;
            _guestRepository = new GuestRepository(dbconnection);
            LoadNames();
        }

        public void LoadNames()
        {
            List<GuestModel> guests = _guestRepository.FindAll();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");

            foreach (GuestModel guest in guests)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["Name"] = guest.guestName;
                dt.Rows.Add(dataRow);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string Name = textBoxName.Text.Trim();
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("you need to write name");
                return;
            }
            Log(Name);
        }
        private void Log(string Name)
        {    
            _guestRepository.insert(Name);
            LoadNames();
            GuestRepository guestRepository = new GuestRepository(dbconnection);
            GuestModel guestModel = guestRepository.FindByName(Name);
            this.Hide();
            NavigationService navigationService = new NavigationService(dbconnection, guestModel);
        }

     
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell cell = dgv.CurrentCell;
            string name = cell.Value.ToString().Trim();
            Log(name);
        }
    }
}
