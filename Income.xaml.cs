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
    /// Логика взаимодействия для Income.xaml
    /// </summary>
    public partial class Income : Window
    {
        double Cash = 0;
        double Days = 0;
        double Refill = 0;
        double cashOptimal;
        double cashStab;
        double cashStand;
        public Income()
        {
            InitializeComponent();
            UpdateIncomeInfo();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Money.Text = Math.Round(Money_slider.Value).ToString();
            Cash = Convert.ToInt32(Math.Round(Money_slider.Value));
            UpdateIncomeInfo();
        }

        private void Money_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Money.Text.Equals(String.Empty))
                {
                    Money.Text = "0";
                }
                double value = (double)Convert.ToInt32(Money.Text);
                Money_slider.Value = value;
                Cash = Math.Round(value);
                UpdateIncomeInfo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); Money.Text = "0"; }
        }

        private void Term_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Term.Text = Math.Round(Term_slider.Value).ToString();
            Days = Math.Round(Term_slider.Value);
            UpdateIncomeInfo();
        }

        private void Replenishment_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Replenishment.Text = Math.Round(Replenishment_slider.Value).ToString();
            Refill = Math.Round(Replenishment_slider.Value);
            UpdateIncomeInfo();
        }

        private void Term_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Term.Text.Equals(String.Empty))
                {
                    Term.Text = "0";
                }
                double value = (double)Convert.ToInt32(Term.Text);
                Term_slider.Value = value;
                Days = Math.Round(value);
                UpdateIncomeInfo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); Term.Text = "0"; }
        }

        private void Replenishment_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Replenishment.Text.Equals(String.Empty))
                {
                    Replenishment.Text = "0";
                }
                double value = (double)Convert.ToInt32(Replenishment.Text);
                Replenishment_slider.Value = value;
                Refill = Math.Round(value);
                UpdateIncomeInfo();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); Replenishment.Text = "0"; }
        }

        private void UpdateIncomeInfo()
        {
            double stabilityIncome = Math.Round((Cash * 0.08 * Days)/365, 2);

            if (Refill == 0) { }
            else
            {
                double firstMonthIncome = (Cash * 0.08 / 365) * 30;
                double optimalIncome = (Cash + Refill + (firstMonthIncome * (Days / 30))) * (0.08 / 365) * 30;
                optimal_income.Text = Math.Round(optimalIncome, 2).ToString();
                cashOptimal = Math.Round(optimalIncome, 2);

                double standartIncome = (Cash + Refill) * 0.08 * Days / 365;
                stanadrt_income.Text = Math.Round(standartIncome, 2).ToString();
                cashStand = Math.Round(standartIncome, 2);
            }
            stable_income.Text = Math.Round(stabilityIncome, 2).ToString();
            cashStab = stabilityIncome;
        }

        private void Compare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CompareWindow window = new CompareWindow(cashStab, cashOptimal, cashStand, Cash, (int)Days);
                window.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
