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
    public partial class Detail : ContentPage
    {
        public Detail(Pet pet)
        {
            InitializeComponent();

            ShowDetails(pet);
        }

        private void ShowDetails(Pet pet)
        {
            lblName.Text = pet.name;
            if (pet.canBattle == true)
            {
                lblBattle.Text = "Can Battle:" + System.Environment.NewLine + System.Environment.NewLine + "Yes";
            }
            else
            {
                lblBattle.Text = "Can Battle:" + System.Environment.NewLine + System.Environment.NewLine + "No";
            }
            lblFamily.Text = "Family:" + System.Environment.NewLine + System.Environment.NewLine + ToUpperFirstLetter(pet.family);
            lblSpeed.Text = "Speed:" + System.Environment.NewLine + System.Environment.NewLine + pet.stats.speed.ToString();
            imgPet.Source = "https://wow.zamimg.com/images/wow/icons/large/"+ pet.icon +".jpg";
        }



        private string ToUpperFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }



        private void btnFeedback_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Feedback());
        }
    }
}