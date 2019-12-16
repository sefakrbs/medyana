using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medyana.Models
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProcureDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal UsageRatio { get; set; }
        public int ClinicId { get; set; }
    }
}