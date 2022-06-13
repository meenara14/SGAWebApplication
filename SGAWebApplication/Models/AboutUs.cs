using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SGAWebApplication.Models
{
    [Table("AboutUs")]
    public class AboutUs
    {
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
