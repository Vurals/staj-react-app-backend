using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    [Table("Product")]
    public class Product
    {
        public long Id { get; set; }
        public  string? Title { get; set; }
        public string? ImagePath { get; set; }

        public string? Price { get; set; }
    }
}
