using Datalagring.Contexts;
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

public partial class Information : Page
{
    private static DataContext _context = new DataContext();
    public Information()
    {
        InitializeComponent();
        var persons = _context.Persons.ToList();
        var tasks = _context.Tasks.ToList();

        

        lv_Tasks.ItemsSource = tasks;
    }
}
