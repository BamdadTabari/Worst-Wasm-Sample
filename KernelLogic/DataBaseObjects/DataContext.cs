using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            var assembly = typeof(IBaseEntity).Assembly;
            //dbset entities
            modelBuilder.RegisterAllEntities<IBaseEntity>(assembly);

            //config entities (config shiits like IEntityTypeConfiguration,.....)
            modelBuilder.RegisterEntityTypeConfiguration(assembly);

        }
    }
}
