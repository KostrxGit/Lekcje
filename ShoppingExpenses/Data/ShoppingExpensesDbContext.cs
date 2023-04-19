using Microsoft.EntityFrameworkCore;
using ShoppingExpenses.Models;

namespace ShoppingExpenses.Data
{
    public class ShoppingExpensesDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=shoppingexpenses.db");
    }
}
