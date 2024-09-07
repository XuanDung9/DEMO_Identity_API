using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_DEMO.Models
{
    [Table("Product")]
    public class Products
    {
        [Key]
        public long Id { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }
    }
}
