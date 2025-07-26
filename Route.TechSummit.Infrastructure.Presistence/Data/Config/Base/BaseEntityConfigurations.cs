﻿using Route.TechSummit.Domain.Common;

namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.Base
{
    public class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {


            builder.Property(e => e.Id).ValueGeneratedOnAdd();

        }
    }
}
