﻿using Payments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Payments.Infrastructure.Contexts
{
    public class PaymentsDbContext : DbContext
    {
        public DbSet<Payment> Payment { get; set; }

        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(typeof(PaymentsDbContext).Assembly);
            base.OnModelCreating(mb);
        }
    }
}