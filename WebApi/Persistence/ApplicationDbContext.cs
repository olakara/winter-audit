using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using Z.EntityFramework.Plus;

namespace WebApi.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    static ApplicationDbContext()
    {
        AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
            (context as ApplicationDbContext).AuditEntries.AddRange(audit.Entries);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<AuditEntry> AuditEntries { get; set; }
    public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
    
    public override int SaveChanges()
    {
        SetCreateAndUpdateInfo();
        var audit = new Audit();
        audit.PreSaveChanges(this);
        var rowAffecteds = base.SaveChanges();
        audit.PostSaveChanges();

        if (audit.Configuration.AutoSavePreAction != null)
        {
            audit.Configuration.AutoSavePreAction(this, audit);
            base.SaveChanges();
        }

        return rowAffecteds;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        SetCreateAndUpdateInfo();
        var audit = new Audit();
        audit.PreSaveChanges(this);
        var rowAffecteds = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        audit.PostSaveChanges();

        if (audit.Configuration.AutoSavePreAction != null)
        {
            audit.Configuration.AutoSavePreAction(this, audit);
            await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        return rowAffecteds;
    }

    private void SetCreateAndUpdateInfo()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

        foreach (var entity in entries)
        {
            switch (entity.State)
            {
                    case EntityState.Added:
                    {
                        ((IEntity)entity.Entity).CreatedAt = DateTime.Now;
                        //((IEntity)entity.Entity).CreatedBy =  Get the user;
                        break;
                    }

                    case EntityState.Modified:
                    {
                        ((IEntity)entity.Entity).ModifiedAt = DateTime.Now;
                        //((IEntity)entity.Entity).ModifiedBy =  Get the user;
                        break;
                    }
            }
        }
    }
}