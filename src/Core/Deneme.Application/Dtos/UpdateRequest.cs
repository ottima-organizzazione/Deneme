using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Application.Dtos
{
    public class UpdateRequest
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
