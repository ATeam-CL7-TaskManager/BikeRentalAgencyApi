using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRentalAgencyUI.Areas.Identity.Data
{
    public class MyIdentityRole: IdentityUser
    {
        public string Description { get; set; }
    }
}
