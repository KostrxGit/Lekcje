using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using ShoppingExpenses.Data;
using ShoppingExpenses.Models;

namespace ShoppingExpenses.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var expense = new Expense
            {
                Date = datePicker.Date,
                ItemName = itemNameEntry.Text,
                Price = decimal.Parse(priceEntry.Text)
            };

            using var db = new ShoppingExpensesDbContext();
            db.Expenses.Add(expense);
            await db.SaveChangesAsync();

            ClearFields();
        }

        private void ClearFields()
        {
            datePicker.Date = DateTime.Today;
            itemNameEntry.Text = "";
            priceEntry.Text = "";
        }

        private async void ShowAllButton_Clicked(object sender, EventArgs e)
        {
            using var db = new ShoppingExpensesDbContext();
            var expenses = await db.Expenses.ToListAsync();
            expenseList.ItemsSource = expenses;
        }

        private async void ShowByDateButton_Clicked(object sender, EventArgs e)
        {
            using var db = new ShoppingExpensesDbContext();
            var selectedDate = datePicker.Date;
            var expenses = await db.Expenses.Where(e => e.Date == selectedDate).ToListAsync();
            expenseList.ItemsSource = expenses;
        }

        /*private async void ShowByRangeButton_Clicked(object sender, EventArgs e)
        {
            using var db = new ShoppingExpensesDbContext();
            var startDate = datePicker.Date;
            var endDate = datePickerEnd.Date;
            var expenses = await db.Expenses.Where(e => e.Date >= startDate && e.Date <= endDate).ToListAsync();
            expenseList.ItemsSource = expenses;
        }*/

    }
}
