using Shabat.DAL.Models;
using Shabat.DAL.Repositories;
using ShabatGuest.DAL;
using ShabatGuest.DAL.Models;
using ShabatGuest.DAL.Repositories;
using ShabatGuest.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatGuest.BL
{
    internal class NavigationService
    {
        public DBconnections _dbconnections { get; init; }
        public int index = 0;
        public int lenth;
        private FoodRepository foodRepository;
        private CategoryRepository categoryRepository;
        private GuestRepository guestRepository;
        public GuestModel _guestModel;
        private List<HomePage> homePages;
        public bool isnvavigate = false ;
        public NavigationService(DBconnections dBconnections, GuestModel guestModel)
        {
            foodRepository = new FoodRepository(dBconnections);
            categoryRepository = new CategoryRepository(dBconnections);
            guestRepository = new GuestRepository(dBconnections);
            _guestModel = guestModel;
            _dbconnections = dBconnections;
            homePages = new List<HomePage>();
            homePages = CreateForms(homePages);
            homePages[index].Show();
        }
        public List<HomePage> CreateForms(List<HomePage> homePages)
        {
            List<CategoryModel> categories = categoryRepository.FindAll();
            foreach (CategoryModel category in categories)
            {
                homePages.Add(new HomePage(_guestModel ,this, category, _dbconnections, foodRepository, categoryRepository,guestRepository));
            }
            return homePages;
        }
        public void ShowForm(bool next)
        {
            isnvavigate = true;
            if (next)
            {
                if (index >= homePages.Count - 1)
                {
                    index = 0;
                    homePages[index].ShowCategory();
                    homePages[index].Showmine();
                    homePages[index].Show();
                    isnvavigate = false;
                    return;
                }
                else
                {
                    index++;
                    homePages[index].ShowCategory();
                    homePages[index].Showmine();
                    homePages[index].Show();
                    isnvavigate = false;
                    return;
                }
            }
            else
            {
                if (index <= 0)
                {
                    index = homePages.Count - 1;
                    homePages[index].ShowCategory();
                    homePages[index].Showmine();
                    homePages[index].Show();
                    isnvavigate = false;
                    return;
                }
                else
                {
                    index--;
                    homePages[index].ShowCategory();
                    homePages[index].Showmine();
                    homePages[index].Show();
                    isnvavigate = false;
                    return;
                }
            }    
        }
    }
}
