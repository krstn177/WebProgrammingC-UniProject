using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProjectBackend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBackend.Infrastructure.DataSeeders
{
    public static class DataSeeder
    {
        public static async Task SeedAdminBankAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<BankUser>>();
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            const string bankEmail = "bank@mybank.com";
            const string bankPassword = "Bank@1234";

            var bankUser = await userManager.FindByEmailAsync(bankEmail);
            if (bankUser == null)
            {
                bankUser = new BankUser
                {
                    UserName = "MainBank",
                    Email = bankEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(bankUser, bankPassword);
                await userManager.AddToRoleAsync(bankUser, "Bank");
            }

            var existingAccount = db.BankAccounts.FirstOrDefault(a => a.BankUserId == bankUser.Id);
            if (existingAccount == null)
            {
                var bankAccount = new BankAccount
                {
                    BankUserId = bankUser.Id,
                    IBAN = "BANK0000000001",
                    Balance = 1_000_000m // initial capital
                };

                db.BankAccounts.Add(bankAccount);
                await db.SaveChangesAsync();
            }
        }
    }
}
