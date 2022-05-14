using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BanknoteBuying).IsRequired(false);
            builder.Property(x => x.BanknoteSelling).IsRequired(false);
            builder.Property(x => x.CrossRateUsd).IsRequired(false);
            builder.Property(x => x.CurrencyCode).IsRequired(false);
            builder.Property(x => x.Name).IsRequired(false);
        }
    }
}
