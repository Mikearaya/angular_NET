using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using angularNet.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace angularNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var account = new AccountCategory();
            account.Name = "Asset";
            using(var context = new smart_financeContext())
            {
                context.AccountCategory.Add(account);
                context.SaveChanges();
            }
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
