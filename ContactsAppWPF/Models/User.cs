using System;
using System.Collections.Generic;

#nullable disable

namespace ContactsAppWPF.Models
{
    public partial class User
    {
        public User()
        {
            Contacts = new HashSet<Contact>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
