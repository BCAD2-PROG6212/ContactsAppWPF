using ContactsAppWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsAppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactsDbContext db = new ContactsDbContext();
        public MainWindow()
        {
            InitializeComponent();
            Contact c = new Contact();
            c.FirstName = "Awesome";
            c.Surname = "Lecturer";
            c.Phone = "0311234567";
            c.Email = "awesome@lecturer.com";
            c.UserId = 1;

            db.Contacts.Add(c);
            db.SaveChanges();

            List<Contact> filteredContacts =
                db.Contacts.Where(x => x.UserId == 1).ToList();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Models.Contact c = new Models.Contact();
            c.FirstName = txbName.Text;
            c.Surname = txbSurname.Text;
            c.Phone = txbPhone.Text;
            c.Email = txbEmail.Text;
            c.UserId = 1;
            db.Contacts.Add(c);
            db.SaveChanges();
            
            // ListWorker.contacts.Add(c);
            
            clearFields();
            refreshList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // ListWorker.contacts.Add(new Contact(0, "EB", "Adam", "0315732038", "eadam@varsitycollege.co.za", 0));
            // ListWorker.contacts.Add(new Contact(1, "Trent", "Hill", "0315732038", "thill@varsitycollege.co.za", 0));

            foreach (User u in db.Users)
            {
                drpCurrentUser.Items.Add(u.Username);
            }
            refreshList();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        public void refreshList()
        {
            lstContacts.Items.Clear();
            foreach (Models.Contact c in db.Contacts)
            {
                lstContacts.Items.Add(c.FirstName + " " + c.Surname + 
                    " - " + c.Phone + " & " + c.Email);
            }
        }
        public void clearFields()
        {
            txbName.Text = "";
            txbSurname.Text = "";
            txbPhone.Text = "";
            txbEmail.Text = "";
        }

        private void drpCurrentUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Models.Contact> filteredContacts = db.Contacts.Where(x => 
                    x.User.Username.Equals(drpCurrentUser.SelectedValue)).ToList();
            lstContacts.Items.Clear();
            foreach (Models.Contact c in filteredContacts)
            {
                lstContacts.Items.Add(c.FirstName + " " + c.Surname + " - " 
                    + c.Phone + " & " + c.Email);
            }
        }
    }
}
