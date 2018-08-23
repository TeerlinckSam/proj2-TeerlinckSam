using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using BlizzPetApp.View;
using BlizzPetApp.Repositories;
using BlizzPetApp.Models;

namespace BlizzPetApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {

        public PetRepository _petRepo { get; set; }

        public List<Pet> _pets { get; set; }

        public string Family { get; set; }

        public Master (string family)
        {
            InitializeComponent();
            Family = family;
            lblFamily.Text = family;
            _petRepo = new PetRepository();
            GetPets();
        }

        private async void GetPets()
        {
            if (Family == "Magic")
            {
                Family = "Magical";
            }
            else if (Family == "Aquatic")
            {
                Family = "Water";
            }
            _pets = await _petRepo.GetAllPets(Family.ToLower());
            lvwPets.ItemsSource = _pets;
        }

        void lvwPets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Pet pet = lvwPets.SelectedItem as Pet;
            Navigation.PushAsync(new Detail(pet));
        }
    }
}