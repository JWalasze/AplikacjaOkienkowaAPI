using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Basic_cities
    {
        [Key]
        public string CityName { get; set; }
    }
}
