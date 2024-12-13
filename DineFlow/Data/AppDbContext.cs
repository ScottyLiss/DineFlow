using DineFlow.Models.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace DineFlow.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Virtual is applied for Moq-testing, as Moq needs to be explicitly told that these DbSets are virtual by nature
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.Id);

                entity.HasOne(user => user.Role)
                .WithMany()
                .HasForeignKey(user => user.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(role => role.Id);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(permission => permission.Id);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(rolePermission => new { rolePermission.RoleId, rolePermission.PermissionId });

                entity.HasOne(rolePermission => rolePermission.Role)
                .WithMany()
                .HasForeignKey(rolePermission => rolePermission.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rolePermission => rolePermission.Permission)
                .WithMany()
                .HasForeignKey(rolePermission => rolePermission.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(location => location.Id);
            });

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = RoleName.Guest },
                new Role { Id = 2, Name = RoleName.User },
                new Role { Id = 3, Name = RoleName.Staff },
                new Role { Id = 4, Name = RoleName.Manager },
                new Role { Id = 5, Name = RoleName.Admin }
                );

            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Name = "Manage Users" },
                new Permission { Id = 2, Name = "Manage Inventory" },
                new Permission { Id = 3, Name = "Edit Reservations" },
                new Permission { Id = 4, Name = "View Schedules" }
                );
        }
    }
}
