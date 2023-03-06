using API.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistence.Seeds
{
    public class DefaultVendors
    {
        public static List<Vendor> VendorList()
        {
            return new List<Vendor>
            {
                new Vendor{ 
                    Id = 1,
                    Name = "Peter Pearson Consulting",                    
                    Role = "Asesor comercial",
                    OutSourced = true,
                    Active = true
                },
                new Vendor{
                    Id = 2,
                    Name = "Luis Eduardo Cochachi Chamorro",                    
                    Role = "Asesor comercial",
                    OutSourced = true,
                    Active = true
                },
                new Vendor{
                    Id = 3,
                    Name = "Maria Augusta Lopez Aliaga Petrozzi",                    
                    Role = "Asesor comercial",
                    OutSourced = true,
                    Active = true,
                }
            };
        }
    }
}
