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
using Plugin.Messaging;
using System.Text.RegularExpressions;

namespace BlizzPetApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Feedback : ContentPage
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void btnSend_Clicked(object sender, EventArgs e)
        {
            if (entEmail.Text == "" || IsValidEmail(entEmail.Text) == false)
            {
                DisplayAlert("Empty/incorrect box!", "Please fill in your email address and make sure it is valid.", "OK");
            }
            else if (edtFeedback.Text == "" || edtFeedback.Text == "Feedback:")
            {
                DisplayAlert("Empty box!", "Please fill in your feedback.", "OK");
            }
            else
            {
                var email = new EmailMessageBuilder()
                    .To("sam.teerlinck@student.howest.be")
                    .Subject("Feedback from " + entEmail.Text)
                    .Body(edtFeedback.Text)
                    .Build();
                DisplayAlert("Feedback sent!", "Your feedback has been sent. Thank you!", "OK");
                Navigation.PopAsync();
            }
        }

        private bool IsValidEmail(string email)
        {
            bool isEmail = System.Text.RegularExpressions.Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
    }
}