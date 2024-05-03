using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Constants
{
    public enum Category
    {
        [Display(Name = "Fast Food")]
        FastFood,
        Pizzeria
    }
}
