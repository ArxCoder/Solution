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
using System.Windows.Shapes;

namespace Solution
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        double cash;
        int days;
        int percent;
        Database database = new Database();
        public Authorization(double cash, int days, int percent)
        {
            InitializeComponent();
            this.cash = cash;
            this.days = days;
            this.percent = percent;
        }

        private void openContrib_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.Text.Equals(String.Empty) || Password.Text.Equals(String.Empty)) MessageBox.Show("Все поля должны быть заполнены");
                else
                {
                double currentLogin = Convert.ToDouble(Login.Text);
                    User_ current = database.User_.Where(u=>u.Login == currentLogin).FirstOrDefault();
                    if (current == null) { MessageBox.Show("Введенного пользователя не существует"); }
                    else
                    {
                        if (!current.Password.Equals(Password.Text)) MessageBox.Show("Неверный логин или пароль");
                        else
                        {
                            Random rnd = new Random();
                            double numberAccount = rnd.Next(100000000, 999999999);
                            BankAccount_ newAccount = new BankAccount_
                            {
                                NumberAccount = numberAccount,
                                DateOpen = DateTime.Now,
                                Balance = cash,
                                Type = 4
                            };

                            Contract_ newContract = new Contract_
                            {
                                NumberAccount = newAccount.NumberAccount,
                                IDUser = current.IDUser,
                                Amount = cash,
                                Period = days,
                                ExpirationDate = DateTime.Now,
                                Percet = percent
                            };

                            database.BankAccount_.Add(newAccount);
                            database.Contract_.Add(newContract);
                            database.SaveChanges();

                            MessageBox.Show($"{current.Name} {current.Surname} вклад открыт, спасибо, что пользуетесь нашими услугами.");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
