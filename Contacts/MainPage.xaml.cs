using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Classes;
using SQLite;
using Xamarin.Forms;

namespace Contacts
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void SaveButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameEntry.Text,
                LastName = lastnameEntry.Text,
                Email = emailEntry.Text,
                PhoneNumber = phoneEntry.Text,
                Address = addressEntry.Text
            };

            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                int rowAdded = conn.Insert(contact);
            }
        }
    }
}
