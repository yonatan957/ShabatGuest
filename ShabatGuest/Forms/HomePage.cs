using Shabat.DAL.Models;
using Shabat.DAL.Repositories;
using ShabatGuest.BL;
using ShabatGuest.DAL;
using ShabatGuest.DAL.Models;
using ShabatGuest.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShabatGuest.Forms
{
    internal partial class HomePage : Form
    {
        public DBconnections dbconnection;
        private FoodRepository foodRepository;
        private CategoryRepository categoryRepository;
        private GuestRepository guestRepository;
        private CategoryModel categoryModel;
        private NavigationService navigationService;
        private GuestModel _guestModel;

        public HomePage(GuestModel guestModel, NavigationService navigationService, CategoryModel categoryModel, DBconnections dbconnection, FoodRepository foodRepository, CategoryRepository categoryRepository, GuestRepository guestRepository)
        {
            InitializeComponent();
            this._guestModel = guestModel;
            this.dbconnection = dbconnection;
            this.foodRepository = foodRepository;
            this.categoryRepository = categoryRepository;
            this.guestRepository = guestRepository;
            this.categoryModel = categoryModel;
            this.navigationService = navigationService;
            ShowCategory();
            Showmine();
            label1.Text = categoryModel.CategoryName;
        }

        public void ShowCategory()
        {
            List<FoodModel> foods = foodRepository.FindByCategory(categoryModel);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Food");
            foreach (FoodModel food in foods)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["Name"] = food.guestName;
                dataRow["Food"] = food.FoodName;
                dt.Rows.Add(dataRow);
            }
            dataGridView1.DataSource = dt;
        }
        public void Showmine()
        {            
            List<FoodModel> foods = foodRepository.FindByCategorymine(categoryModel, _guestModel.guestID);
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Food");
            foreach (FoodModel food in foods)
            {                
                DataRow dataRow = dt.NewRow();
                dataRow["Name"] = food.guestName;
                dataRow["Food"] = food.FoodName;
                dt.Rows.Add(dataRow);
            }      
            dataGridView2.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            this.Hide();
            navigationService.ShowForm(true);
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            this.Hide();
            navigationService.ShowForm(false);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string FoodName = textBox_chois.Text;
            if (string.IsNullOrEmpty(FoodName))
            {
                MessageBox.Show("plesae enter chois");
                return;
            }
            bool rowsaffected = foodRepository.insert(new FoodModel(_guestModel.guestName, _guestModel.guestID, categoryModel.CategoryID, FoodName));
            if (!rowsaffected)
            {
                MessageBox.Show("you allready choos this item");
            }
            textBox_chois.Clear();
            ShowCategory();
            Showmine();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!navigationService.isnvavigate)
            {
                Application.Exit();
            }
        }
    }
}
