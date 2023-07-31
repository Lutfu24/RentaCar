using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RentaCar.Entities.Concrete.Common;

namespace RentaCar.DataAccessLayer.Persistance.Interceptors;

public class BaseAuditableEntityInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BaseAuditableEntityInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        UpdateEntity(eventData.Context);
        return base.SavedChanges(eventData, result);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    void UpdateEntity(DbContext context)
    {
        if (context is null) return;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State==EntityState.Added)
            {
                entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.CreatedAt = DateTime.Now;
            }
            else if (entry.State==EntityState.Modified)
            {
                entry.Entity.UpdateBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.UpdateAt = DateTime.Now;
            }
        }
    }
}
