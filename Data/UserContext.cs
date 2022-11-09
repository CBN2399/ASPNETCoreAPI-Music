#nullable disable
using System;
using System.Collections.Generic;
using ApiProyect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiProyect.Data
{
    public partial class UserContext :IdentityDbContext<AppUser>
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Excluir las tables de chinook
            modelBuilder.Entity<Album>().ToTable(nameof(Album), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Artist>().ToTable(nameof(Artist), t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Track>().ToTable(nameof(Track), t => t.ExcludeFromMigrations());

            //Personalizar la tabla predefinida
            modelBuilder.Entity<AppUser>(confTable =>
            {
                confTable.ToTable(nameof(AppUser));

                confTable.Property(u => u.nombre).HasMaxLength(20);

                confTable.Property(u => u.apellidos).HasMaxLength(40);

                confTable.Property(u => u.CodPostal).HasDefaultValue(0000);
            });

            //Hacer los seeders

            //Lista de roles
            List<IdentityRole> roles = new List<IdentityRole>();
            roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            roles.Add(new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" });
            roles.Add(new IdentityRole { Name = "default", NormalizedName = "DEFAULT" });
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            //Lista de usuarios
            List<AppUser> users = new List<AppUser>();

            users.Add(new AppUser //Usuario administrador
            {
                nombre = "Cesar",
                apellidos = "Bartolome Navarro",
                CodPostal = 38007,
                UserName = "Admin@disquera.com",
                NormalizedUserName = "ADMIN@DISQUERA.COM",
                Email = "Admin@disquera.com",
                NormalizedEmail = "ADMIN@DISQUERA.COM",
                EmailConfirmed = true
            });

            users.Add(new AppUser //Usuario manager
            {
                nombre = "Pepe",
                apellidos = "Gomez Gil",
                CodPostal = 38010,
                UserName = "Manager@disquera.com",
                NormalizedUserName = "MANAGER@DISQUERA.COM",
                Email = "Manager@disquera.com",
                NormalizedEmail = "MANAGER@DISQUERA.COM",
                EmailConfirmed = true
            });

            users.Add(new AppUser //Usuario normal
            {
                nombre = "Manolo",
                apellidos = "Martin Hernandez",
                CodPostal = 38010,
                UserName = "User1@disquera.com",
                NormalizedUserName = "USER1@DISQUERA.COM",
                Email = "User1@disquera.com",
                NormalizedEmail = "USER1@DISQUERA.COM",
                EmailConfirmed = true
            });
        
            modelBuilder.Entity<AppUser>().HasData(users);
            var passwordHasher = new PasswordHasher<AppUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "AdminPassword");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "ManagerPassword");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "User1Password");

            //Lista de usuarios y roles
            List<IdentityUserRole<string>> userRole = new List<IdentityUserRole<string>>();
            userRole.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.Find(r => r.Name == "Admin").Id
            });
            userRole.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.Find(r => r.Name == "Manager").Id
            });
            userRole.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.Find(r => r.Name == "default").Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
