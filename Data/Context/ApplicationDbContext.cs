using ContactManagement.Data.Mappings;
using ContactManagement.Interfaces;
using ContactManagement.Model;
using EntityFramework.Exceptions.MySQL.Pomelo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContactManagement.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected readonly IUser _user;
        protected IHostEnvironment Environment { get; }
        protected IConfiguration Configuration { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUser user, IHostEnvironment environment, IConfiguration configuration) : base(options)
        {
            _user = user;
            Environment = environment;
            Configuration = configuration;
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.IsDevelopment())
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.UseExceptionProcessor();
            }

            optionsBuilder.UseMySql(connectionString: Configuration.GetConnectionString("MariaDB"),
                                    serverVersion: new MySqlServerVersion(version: new Version(major: 10, minor: 6, build: 11)))
                .LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactMap());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        private void OnBeforeSaving()
        {
            var entities = ChangeTracker.Entries()
                                        .Where(x => x.Entity is EntityAudit)
                                        .ToList();
            UpdateSoftDelete(entities);
            UpdateTimestamps(entities);
        }
        private static void UpdateSoftDelete(List<EntityEntry> entries)
        {
            var filtered = entries.Where(x => x.State == EntityState.Added || x.State == EntityState.Deleted);

            foreach (var entry in filtered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((EntityAudit)entry.Entity).IsDeleted = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        ((EntityAudit)entry.Entity).IsDeleted = true;
                        break;
                }
            }
        }
        private void UpdateTimestamps(List<EntityEntry> entries)
        {
            var filtered = entries.Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            var currentUserName = _user.Name;

            foreach (var entry in filtered)
            {
                var auditableObject = (EntityAudit)entry.Entity;
                auditableObject.UpdatedAt = DateTime.UtcNow;
                auditableObject.UpdatedBy = currentUserName;

                if (entry.State == EntityState.Added)
                {
                    auditableObject.CreatedAt = DateTime.UtcNow;
                    auditableObject.CreatedBy = currentUserName;
                }
            }
        }
    }
}
