using API.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Persistence.Seeds
{
    public class DefaultSellers
    {
        public static List<Seller> SellerList()
        {
            return new List<Seller>
            {
                new Seller{ 
                    Id = 1,
                    Name = "Peter Pearson Consulting",                    
                    Role = "Asesor comercial",
                    OutSourced = true,
                    Active = true
                },
                new Seller{
                    Id = 2,
                    Name = "Luis Eduardo Cochachi Chamorro",                    
                    Role = "Asesor comercial",
                    OutSourced = true,
                    Active = true
                },
                new Seller{
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
