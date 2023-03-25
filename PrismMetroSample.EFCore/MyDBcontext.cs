using Microsoft.EntityFrameworkCore;
using PrismMetroSample.Infrastructure.Models;
using System;
using System.Configuration;

namespace PrismMetroSample.EFCore
{
    public class MyDBcontext : DbContext
    {
        public MyDBcontext():base()
        {
        }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> users { get; set; }
        /// <summary>
        /// 权限表
        /// </summary>
        public DbSet<Permission> permissions{ get; set; }
        /// <summary>
        /// 领单表
        /// </summary>
        public DbSet<materialRequisition> materialRequisitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string myValue = ConfigurationManager.AppSettings["strCon"];
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DB_Material;Integrated Security=True");
            //optionsBuilder.UseSqlServer(myValue);

        }
    }
}
