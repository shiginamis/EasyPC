using System;
using System.Formats.Asn1;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

public class ProductsController(DataContext context): BaseApiController
{
    [HttpGet]
    public  List<Products> GetProducts()
    {
        var products =  context.Products.ToList();
        
        return products;
    }
}
