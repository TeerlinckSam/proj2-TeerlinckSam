using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BlizzPetApp.View;
using BlizzPetApp.Repositories;
using BlizzPetApp.Models;

namespace BlizzPetApp
{
    public partial class MainPage : ContentPage
    {

        public PetRepository _petRepo { get; set; }

        public List<Pet> _pets { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void pickFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            string family = pickFamily.SelectedItem as string;

            if (family == null)
                return;

            Master master = new Master(family);
            Navigation.PushAsync(master);
        }
    }
}