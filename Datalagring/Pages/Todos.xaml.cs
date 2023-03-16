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

namespace Datalagring.Pages;

public partial class Todos : Page 
{
    private DataContext _context = new DataContext();
    public Todos()
    {
        InitializeComponent();
    }


    private async void btn_Add_Click(object sender, RoutedEventArgs e)
    {
        var _task = new TaskModel
        {
            Title = tb_Title.Text,
            Text = tb_Text.Text,
            FirstName = tb_FirstName.Text,
            LastName = tb_LastName.Text,
            Email = tb_Email.Text,
        };

        await PageServices.SaveAsync(_task);

        tb_FirstName.Text = "";
        tb_LastName.Text = "";
        tb_Email.Text = "";
        tb_Title.Text = "";
        tb_Text.Text = "";
    }
}
