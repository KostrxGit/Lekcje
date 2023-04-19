using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using ShoppingExpenses.Data;
using ShoppingExpenses.Pages;

namespace ShoppingExpenses
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            using var db = new ShoppingExpensesDbContext();
            db.Database.EnsureCreated();

            MainPage = new MainPage();
        }
    }
}
