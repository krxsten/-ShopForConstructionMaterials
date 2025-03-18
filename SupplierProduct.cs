using System;
using System.Collections.Generic;

namespace ConstructionMaterials.Data.Models;

public partial class SupplierProduct
{
    public int Id { get; set; }

    public int? SupplierId { get; set; }

    public int? ProductId { get; set; }

    public decimal? SupplyPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
