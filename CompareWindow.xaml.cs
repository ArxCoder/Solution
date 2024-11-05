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
    /// Логика взаимодействия для CompareWindow.xaml
    /// </summary>
    public partial class CompareWindow : Window
    {
        double cashStab;
        double cashOpt;
        double cashStand;
        double Cash;
        int days;
        public CompareWindow(double cashStab, double cashOpt, double cashStand, double cash, int days)
        {
            InitializeComponent();
            this.cashStab = cashStab;
            this.cashOpt = cashOpt;
            this.cashStand = cashStand;
            this.days = days;
            Cash = cash;

            stabIncome.Text = cashStab.ToString();
            optIncome.Text = cashOpt.ToString();
            standIncome.Text = cashStand.ToString();

            stabResult.Text = (Cash + cashStab).ToString();
            optResult.Text = (Cash + cashOpt).ToString();
            standResult.Text = (Cash + cashStand).ToString();
        }

        private void stabContrib_Click(object sender, RoutedEventArgs e)
        {
            Authorization window = new Authorization(Cash, days, 8);
            window.ShowDialog();
        }

        private void optContrib_Click(object sender, RoutedEventArgs e)
        {
            Authorization window = new Authorization(Cash, days, 5);
            window.ShowDialog();
        }

        private void standContrib_Click(object sender, RoutedEventArgs e)
        {
            Authorization window = new Authorization(Cash, days, 6);
            window.ShowDialog();
        }
    }
}
