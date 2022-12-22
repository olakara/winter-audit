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

}