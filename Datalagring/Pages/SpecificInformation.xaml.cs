using Datalagring.Contexts;
using Datalagring.Models;
using Datalagring.Models.Entities;
using Datalagring.Services;
using Microsoft.EntityFrameworkCore;
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

namespace Datalagring.Pages
{
    public partial class SpecificInformation : Page
    {

        private static DataContext _context = new DataContext();
        public SpecificInformation()
        {
            InitializeComponent();
        }

        private async void btn_showTask(object sender, RoutedEventArgs e)
        {

            var task = await PageServices.GetAsync(tb_mailAddress.Text, tb_title.Text);


            lv_Tasks.ItemsSource = task;
        }

        private async void btn_Change_NotStarted(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            var id = (int)myValue;

            var status = "NotStarted";

            var task = await PageServices.Change(id, status);
        }

        private async void btn_Change_OnGoing(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            var id = (int)myValue;

            var status = "Ongoing";

            var task = await PageServices.Change(id, status);

        }

        private async void btn_Change_Completed(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            var id = (int)myValue;

            var status = "Completed";

            var task = await PageServices.Change(id, status);
        }
    }
}
