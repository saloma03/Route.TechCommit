using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.TechSummit.Domain.Common;
using Route.TechSummit.Infrastructure.Presistence.Data.Config.Base;

namespace Route.TechSummit.Infrastructure.Persistence.Data.Config.Base
{
    public class BaseAuditableConfigurations<TEntity, TKey> : BaseEntityConfigurations<TEntity, TKey>
        where TEntity : BaseAuditableEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder); // Important: Keep this to apply base configurations

            // Configure audit properties
            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(128); // Adjust length as needed

            builder.Property(e => e.CreatedOn)
                .IsRequired();

            builder.Property(e => e.LastUpdatedBy)
                .IsRequired()
                .HasMaxLength(128); // Adjust length as needed

            builder.Property(e => e.LastUpdatedOn)
                .IsRequired();
        }
    }
}