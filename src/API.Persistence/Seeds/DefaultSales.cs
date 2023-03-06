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
                             Price = 450,
                             Total = 450,
                             ServiceId = 3
                         },
                         new SaleDetail {
                             Serie = "F001",
                             Number = "000000001",
                             ItemId = 2,
                             ItemName = "Servico de Asesoría y Consultoría Legal Corporativa",
                             Qty = 1,
                             Price = 420,
                             Total = 420,
                             ServiceId = 2
                         },
                         new SaleDetail {
                             Serie = "F001",
                             Number = "000000001",
                             ItemId = 3,
                             ItemName = "Servicio de Consultoría Empresarial y Contable",
                             Qty = 1,
                             Price = 400,
                             Total = 400,
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
                         },
                         new SaleDetail {
                             Serie = "F001",
                             Number = "000000003",
                             ItemId = 2,
                             ItemName = "Servicio de Consultoría Empresarial y Contable",
                             Qty = 1,
                             Price = 400,
                             Total = 400,
                             ServiceId = 1
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
