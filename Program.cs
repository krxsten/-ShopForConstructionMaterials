using ConstructionMaterials.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

var context = new ShopForConstructionMaterialsContext();
var category = await context.Categories.ToListAsync<Category>();
foreach (var c in category)
{
    Console.WriteLine($"{c.Id} {c.Name}");
}
Console.Read();
var customer = await context.Customers.ToListAsync<Customer>();
foreach (var c in customer)
{
    Console.WriteLine($"{c.Id} {c.Name} {c.Phone}");
}
Console.Read();
var employees = await context.Employees.ToListAsync<Employee>();
foreach (var c in employees)
{
    Console.WriteLine($"{c.Id} {c.Name} {c.Position}");
}
Console.Read();
var order = await context.Orders.ToListAsync<Order>();
foreach (var c in order)
{
    Console.WriteLine($"{c.Id} {c.CustomerId} {c.OrderDate} {c.TotalPrice}");
}
Console.Read();
var orderDetails = await context.OrderDetails.ToListAsync<OrderDetail>();
foreach (var c in orderDetails)
{
    Console.WriteLine($"{c.Id} {c.OrderId} {c.ProductId} {c.Quantity}");
}
Console.Read();
var product = await context.Products.ToListAsync<Product>();
foreach (var c in product)
{
    Console.WriteLine($"{c.Id} {c.Name} {c.Price} {c.CategoriesId}");
}
Console.Read();
var supplier = await context.Suppliers.ToListAsync<Supplier>();
foreach (var c in supplier)
{
    Console.WriteLine($"{c.Id} {c.Name} {c.ContactInfo}");
}
Console.Read();
var supplierProduct = await context.SupplierProducts.ToListAsync<SupplierProduct>();
foreach (var c in supplierProduct)
{
    Console.WriteLine($"{c.Id} {c.SupplierId} {c.ProductId} {c.SupplyPrice}");
}
Console.Read();
}
