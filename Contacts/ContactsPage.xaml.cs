using System;
using System.Collections.Generic;
using Contacts.Classes;
using SQLite;
using Xamarin.Forms;

namespace Contacts
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();
        }

        void NewContactToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().ToList();
                ContactsListView.ItemsSource = contacts;
            }
        }
    }
}
