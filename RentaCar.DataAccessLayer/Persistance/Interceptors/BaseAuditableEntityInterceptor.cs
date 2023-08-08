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
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChanges(eventData, result);
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntity(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    void UpdateEntity(DbContext context)
    {
        if (context is null) return;
        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State==EntityState.Added)
            {
                //entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.CreatedBy = "Lutfu";
                entry.Entity.CreatedAt = DateTime.Now;
            }
            else if (entry.State==EntityState.Modified)
            {
                //entry.Entity.UpdateBy = _httpContextAccessor.HttpContext.User.Identity.Name;
                entry.Entity.UpdateBy = "Lutvu";
                entry.Entity.UpdateAt = DateTime.Now;
            }
        }
    }
}
