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
using ATM.Controller;
using ATM.Model;

namespace ATM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ATMController _atm = new ATMController();
        public MainWindow() 
        {
            InitializeComponent();
            _atm.Start();
            //var temp = Convert.ToInt32(ComboMoney.SelectedValue.ToString());
            MakingMoney.Visibility = Visibility.Hidden;
            WithdrawMoney.Visibility = Visibility.Hidden;

        }

        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            _atm._atm.SetAnswer("");
            result.Text = "";
            WithdrawMoney.Visibility = Visibility.Visible;
            MakingMoney.Visibility = Visibility.Hidden;
        }

        private void Make_Click(object sender, RoutedEventArgs e)
        {
            _atm._atm.SetAnswer("");
            result.Text = "";
            MakingMoney.Visibility = Visibility.Visible;
            WithdrawMoney.Visibility = Visibility.Hidden;
        }

        private void DoMake_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(MakeCount.Text);
                _atm._atm.SetMoney(count);
                result.Text = _atm._atm.GetAnswer();
                MakingMoney.Visibility = Visibility.Hidden;
            }
            catch(Exception ex)
            {
                MakingMoney.Visibility = Visibility.Hidden;
                result.Text = ex.Message;
            }
            

        }
        private void ShowMoney_Click(object sender, RoutedEventArgs e)
        {
            result.Text = _atm._atm.ShowMoney();
            MakingMoney.Visibility = Visibility.Hidden;
            WithdrawMoney.Visibility = Visibility.Hidden;
        }

        private void DoWithdraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(WithDrawCount.Text);
                if(ComboMoney.SelectedIndex == 7)
                {
                    _atm._atm.GetMoney(count);
                }
                else
                {
                    int cost = Convert.ToInt32(ComboMoney.Text);
                    _atm._atm.GetMoney(count, cost);
                }
                result.Text = _atm._atm.GetAnswer();
                WithdrawMoney.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                WithdrawMoney.Visibility = Visibility.Hidden;
                result.Text = ex.Message;
            }
        }
    }
}
