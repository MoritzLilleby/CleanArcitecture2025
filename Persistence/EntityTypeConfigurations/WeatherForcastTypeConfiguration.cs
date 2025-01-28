using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityTypeConfigurations
{
    internal class WeatherForcastTypeConfiguration : IEntityTypeConfiguration<WeatherForcastEntity>
    {
        public void Configure(EntityTypeBuilder<WeatherForcastEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Summary).IsRequired(false);

            builder.ToTable("WeatherForCast");
        }
    }
}
