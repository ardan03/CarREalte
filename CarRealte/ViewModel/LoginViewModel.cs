
using CarRealte.DB;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarRealte.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public ICommand LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(LogIN);
        }

       

        private void LogIN(object obj)
        {
            using (RetailAutoContext db = new RetailAutoContext())
            {
                var userExists = db.Пользователиs
         .Where(us => us.Логин == _username && us.Пароль == _password)
         .Join(
             db.Сотрудникs, // Другая таблица, в которой проверяем наличие логина
             пользователь => пользователь.IdПользователя,
             other => other.IdПользователя,
             (пользователь, other) => new { пользователь = other }
         )
         .Any();
                if (userExists)
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    Application.Current.Windows[0].Close();
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
        }
    }
}
