using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Company.Extensions
{
    public static class EntityFrameworkExtension
    {
		public static TEntity AsNoTrackedEntity<TEntity>(this EntityEntry<TEntity> entityEntry) where TEntity : class
		{
			entityEntry.State = EntityState.Detached;
			return entityEntry.Entity;
		}
	}
}
