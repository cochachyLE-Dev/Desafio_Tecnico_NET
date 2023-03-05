using API.Domain.Entities;

using System.Collections.Generic;

namespace API.Persistence.Seeds
{
    public static class DefaultServices
    {
        public static List<Service> ServiceList()
        {
            return new List<Service>
            {
                new Service{
                    Id = 1,
                    Name = "Servicio de Consultoría Empresarial y Contable",
                    Unidad = "Hora",
                    Moneda = "S/",
                    Price = 400
                },
                new Service{
                    Id = 2,
                    Name = "Servico de Asesoría y Consultoría Legal Corporativa",
                    Unidad = "Hora",
                    Moneda = "S/",
                    Price = 420
                },
                new Service{
                    Id = 3,
                    Name = "Servicio de Consultoría Financiera y Valorizaciones",
                    Unidad = "Hora",
                    Moneda = "S/",
                    Price = 450
                }
            };
        }
    }
}
