using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //Mapping de entidades
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    //Mapping de relaciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //1 Persona - N Ordenes
        modelBuilder.Entity<Person>()
        .HasMany(p => p.Orders)
        .WithOne(o => o.Person)
        .HasForeignKey(o => o.PersonId); // La FK está en Order.PersonId
        // 1 Orden - N OrderDetails
        modelBuilder.Entity<Order>()
        .HasMany(o => o.OrderDetails)
        .WithOne(od => od.Order)
        .HasForeignKey(od => od.OrderId); // La FK está en OrderDetail.OrderId
        //1 Item  - N OrderDetails
        modelBuilder.Entity<Item>()
        .HasMany(t => t.OrderDetails)
        .WithOne(t => t.Item)
        .HasForeignKey(t => t.ItemId);
    }

}
