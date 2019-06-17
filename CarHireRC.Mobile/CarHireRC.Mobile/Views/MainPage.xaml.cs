using CarHireRC.Mobile.Models;
using CarHireRC.Mobile.Views.Klijenti;
using CarHireRC.Mobile.Views.Poruke;
using CarHireRC.Mobile.Views.Rezervacije;
using CarHireRC.Mobile.Views.Vozila;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarHireRC.Mobile.Views    
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public int KlijentID;
        public MainPage(int Klijent)
        {
            InitializeComponent();
            KlijentID = Klijent;
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.KorisnickiProfil:
                        MenuPages.Add(id, new NavigationPage(new UserProfilePage()));
                        break;
                    case (int)MenuItemType.Poruke:
                        MenuPages.Add(id, new NavigationPage(new MessagesPage(KlijentID)));
                        break;
                    case (int)MenuItemType.MojeRezervacije:
                        MenuPages.Add(id, new NavigationPage(new MyRidesPage(KlijentID)));
                        break;
                   
                    case (int)MenuItemType.Vozila:
                        MenuPages.Add(id, new NavigationPage(new VehiclesPage(KlijentID)));
                        break;
                   
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}