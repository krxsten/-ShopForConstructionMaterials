using ConstructionMaterials.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;


Console.OutputEncoding = System.Text.Encoding.UTF8;
List<string> commands = new List<string>()
{
    "Category",
    "Customer",
    "Employee",
    "Order",
    "OrderDetails",
    "Product",
    "Supplier",
    "SupplierProduct",
};
Console.WriteLine("Commands: ");
foreach (var item in commands)
{
    Console.WriteLine(item);
}
Console.Write("Command: ");
var cmd = ReadLineWithKeywordExpansion(commands);
Console.Write("Press Enter to Quit");
Console.ReadLine();


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



static string ReadLineWithKeywordExpansion(List<string> commands)
{
    int top = Console.CursorTop;
    int left = Console.CursorLeft;

    var sb = new StringBuilder();
    while (true)
    {
        var k = Console.ReadKey(true);
        if (k.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            return sb.ToString();
        }
        else if (k.Key == ConsoleKey.Backspace)
        {
            if (sb.Length > 0)
            {
                --sb.Length;
                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString() + " ");
                Console.SetCursorPosition(left + sb.Length, top);
            }
        }
        else if (k.Key == ConsoleKey.Tab)
        {
            int index = 0;
            string candidate = sb.ToString();
            for (int i = (sb.Length - 1); i >= 0; i--)
            {
                if (sb[i] == ' ')
                {
                    index = i + 1;
                    candidate = sb.ToString().Substring(index);
                    break;
                }
            }
            if (candidate != "")
            {
                List<string> command = commands.Where(cmd => cmd.StartsWith(candidate)).ToList();
                if (command.Count == 1)
                {
                    sb.Length = index;
                    sb.Append(command[0]);
                    Console.SetCursorPosition(left, top);
                    Console.Write(sb.ToString());
                }
                else if (command.Count > 1)
                {
                    top = top + 1;
                    Console.SetCursorPosition(0, top);
                    Console.WriteLine("Available Commands: " + string.Join(" ", command));
                    Console.Write("Command: ");
                    top = top + 1;
                    Console.SetCursorPosition(left, top);
                    Console.Write(sb.ToString());
                }
                else
                {
                    top = top + 1;
                    Console.SetCursorPosition(0, top);
                    Console.WriteLine("No Available Commands ");
                    Console.Write("Command: ");
                    top = top + 1;
                    Console.SetCursorPosition(left, top);
                    Console.Write(sb.ToString());
                }
            }
        }
        else if (k.KeyChar != '\0') 
        {
            sb.Append(k.KeyChar);
            Console.SetCursorPosition(left, top);
            Console.Write(sb.ToString());
        }
    }
}
