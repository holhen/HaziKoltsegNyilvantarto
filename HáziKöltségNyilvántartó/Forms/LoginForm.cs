using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HáziKöltségNyilvántartó.Forms
{
    public partial class LoginForm : Form
    {
        private ISampleContext _context;
        public LoginForm(ISampleContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void belépés_Click(object sender, EventArgs e)
        {
            string password = _context.Users.Where(entry => entry.UserName == usernameBox.Text).Select(entry => entry.Password).FirstOrDefault();
            if (string.IsNullOrEmpty(password))
                MessageBox.Show("Nem szerepel az adatbázisban, kérem, regisztráljon!");
            else if (password != passwordBox.Text)
            {
                MessageBox.Show("Helytelen jelszót adott meg.");
            }
            else
            {
                Close();
            }
        }

        private void regisztráció_Click(object sender, EventArgs e)
        {
            User user = new User { UserName = usernameBox.Text, Password = passwordBox.Text };
            _context.Users.Add(user);
            _context.SaveChanges();
            MessageBox.Show("Regisztráció sikeres.");
        }
    }
}
