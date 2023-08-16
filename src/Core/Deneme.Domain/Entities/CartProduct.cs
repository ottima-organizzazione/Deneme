using Deneme.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Domain.Entities
{
    public class CartProduct : BaseEntity
    {
        public int Quantity { get; set; }
        public string Sku { get; set; }

    }
}