using Datalagring.Contexts;
using Datalagring.Models;
using Datalagring.Services;
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

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
