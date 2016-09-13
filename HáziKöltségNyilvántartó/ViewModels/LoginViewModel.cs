using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HáziKöltségNyilvántartó.Exceptions;
using HáziKöltségNyilvántartó.HelperClasses;

namespace HáziKöltségNyilvántartó.ViewModels
{
    public class LoginViewModel
    {
        private ISampleContext _context;
        public LoginViewModel(ISampleContext context)
        {
            _context = context;
        }

        public string GetCorrectPasswordHash(string username)
        {
            return _context.Users.Where(entry => entry.UserName == username).Select(entry => entry.Password).FirstOrDefault();
        }

        public void Login(string username, string password, string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                throw new LoginException("Nem szerepel az adatbázisban, kérem, regisztráljon!");
            }
            else if (!PasswordHelper.CheckPassword(password, hash))
            {
                throw new LoginException("Helytelen jelszót adott meg.");
            }
            else
            {
                LoggedInUser.UserID = _context.Users.Where(entry => entry.UserName == username).Select(entry => entry.Id).First();
            }
        }

        public void Registration(string username, string password, string hash)
        {
            if (!string.IsNullOrEmpty(hash))
            {
                throw new RegistrationException("A felhasználó már szerepel az adatbázisban!");
            }
            else if (PasswordHelper.StringChecker(password))
            {
                User user = new User { UserName = username, Password = PasswordHelper.EncryptPassword(password) };
                _context.Users.Add(user);
                _context.SaveChanges();
                MessageBox.Show("Regisztráció sikeres.");
            }
            else
                throw new RegistrationException("Adjon meg egy helyes jelszót! A jelszónak tartalmaznia kell kisbetűt, nagybetűt és számot, és legalább 8 karakter hosszúnak kell lennie.");
        }

       
    }
}
