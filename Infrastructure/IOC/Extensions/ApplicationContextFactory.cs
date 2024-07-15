using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IOC.Extensions
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionsBuilder.UseSqlServer("data source=(localdb)\\mssqllocaldb;initial catalog=customer_onboarding; integrated security=true; connect timeout=30;encrypt=false;trustservercertificate=false;applicationintent=readwrite;multisubnetfailover=false");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
