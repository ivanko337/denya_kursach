using Kursach.Infrastructure.BL;
using Kursach.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursach.ViewModel
{
    public class AuthWindowViewModel : ViewModelBase
    {
        public string Login { get; set; }

        public ICommand AuthCommand
        {
            get
            {
                return new BaseCommand(Auth);
            }
        }

        private void Auth(object param)
        {
            object[] prms = param as object[];
            PasswordBox passwordBox = prms[0] as PasswordBox;
            string passwd = passwordBox.Password;
            Window wnd = prms[1] as Window;

            string str = Login + ":" + passwd;
            string hash = MD5.Create(str); // "d2abaa37a7c3db1137d385e1d8c15fd2"

            using (var context = new KursachDBContext())
            {
                bool isExists = context.Users.FirstOrDefault(u => u.Hash.Equals(hash)) != null;
                if (isExists)
                {
                    wnd.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("User does not exists.");
                }
            }
        }
    }
}
