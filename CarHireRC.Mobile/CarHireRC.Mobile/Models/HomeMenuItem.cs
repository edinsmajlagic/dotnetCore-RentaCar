using System;
using System.Collections.Generic;
using System.Text;

namespace CarHireRC.Mobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        MojeRezervacije,
        Vozila,
        Poruke,
        KorisnickiProfil
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string IconSource { get; set; }

    }
}
