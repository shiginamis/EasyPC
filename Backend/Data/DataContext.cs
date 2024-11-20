using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users {get;set;}
    public DbSet<RAM> RAMs {get;set;}
    public DbSet<Motherboard> Motherboards {get;set;}
    public DbSet<Graphics_Card> Graphics_Cards {get;set;}
    public DbSet<Processor> Processors {get;set;}
    public DbSet<PSU> PSUs {get;set;}
    public DbSet<Case> Cases {get;set;}
    public DbSet<Admin> Admins {get;set;}
    public DbSet<Reviews> Reviews {get;set;}
    public DbSet<Questions> Questions   {get;set;}
    public DbSet<QuantityInStock> QuantityInStocks {get;set;}
    public DbSet<Prebuilt_PC> Prebuilt_PCs {get;set;}
    public DbSet<Order_Items> Order_Items {get;set;}
    public DbSet<Orders> Orders {get;set;}
    public DbSet<Custom_PC> Custom_PCs {get;set;}
    public DbSet<Configuration_Recommendations> Configuration_Recommendations {get;set;}
    public DbSet<Category> Categories {get;set;}
}
