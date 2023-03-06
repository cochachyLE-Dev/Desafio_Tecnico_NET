using API.Domain.Entities;

using System.Collections.Generic;

namespace API.Persistence.Seeds
{
    public static class DefaultSales
    {
        public static IEnumerable<Sale> SaleList() {
            return new List<Sale> { 
                new Sale { 
                     Serie = "F001",
                     Number = "000000001",
                     VendorId = 1,
                     Total = 430,
                     DateOfIssue = System.DateTime.Now,
                     SaleDetails = new List<SaleDetail> { 
                         new SaleDetail { 
                             Serie = "F001",
                             Number = "000000001",
                             ItemId = 1,
                             ItemName = "Servicio de Consultoría Financiera y Valorizaciones",
                             Qty = 1,
                             Price = 430,
                             Total = 430,
                             ServiceId = 1
                         }
                     }
                },
                new Sale {
                     Serie = "F001",
                     Number = "000000002",
                     VendorId = 2,
                     Total = 430,
                     DateOfIssue = System.DateTime.Now,
                     SaleDetails = new List<SaleDetail> {
                         new SaleDetail {
                             Serie = "F001",
                             Number = "000000002",
                             ItemId = 1,
                             ItemName = "Servicio de Consultoría Financiera y Valorizaciones",
                             Qty = 1,
                             Price = 430,
                             Total = 430,
                             ServiceId = 3
                         }
                     }
                },
                new Sale {
                     Serie = "F001",
                     Number = "000000003",
                     VendorId = 1,
                     Total = 430,
                     DateOfIssue = System.DateTime.Now,
                     SaleDetails = new List<SaleDetail> {
                         new SaleDetail {
                             Serie = "F001",
                             Number = "000000003",
                             ItemId = 1,
                             ItemName = "Servicio de Consultoría Financiera y Valorizaciones",
                             Qty = 1,
                             Price = 430,
                             Total = 430,
                             ServiceId = 3
                         }
                     }
                },
                new Sale {
                     Serie = "F001",
                     Number = "000000004",
                     VendorId = 2,
                     Total = 430,
                     DateOfIssue = System.DateTime.Now,
                     SaleDetails = new List<SaleDetail> {
                         new SaleDetail {
                             Serie = "F001",
                             Number = "000000004",
                             ItemId = 1,
                             ItemName = "Servicio de Consultoría Financiera y Valorizaciones",
                             Qty = 1,
                             Price = 430,
                             Total = 430,
                             ServiceId = 3
                         }
                     }
                },
            };
        }
    }
}
