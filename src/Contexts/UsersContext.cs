using Microsoft.EntityFrameworkCore;
using UsersApi.src.Models;
using UsersApiStudy.src.Models;

namespace UsersApiStudy.src.Contexts;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<UsersContext> options) : 
        base(options)
    { 

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Contact> Contacts { get; set; } 
    public DbSet<Permissions> Permissions {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(user => user.Address)
            .WithOne(address => address.User)
            .HasForeignKey<Address>(address => address.UserId);

        modelBuilder.Entity<User>()
            .HasOne(user => user.Contact)
            .WithOne(contact => contact.User)
            .HasForeignKey<Contact>(contact => contact.UserId);

        modelBuilder.Entity<User>()
            .HasOne(user => user.Permissions)
            .WithOne(permission => permission.User)
            .HasForeignKey<Permissions>(contact => contact.UserId);
    }
}
