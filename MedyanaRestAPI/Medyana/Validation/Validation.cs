using Integration;
using Medyana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medyana.Validation
{
    /// <summary>
    /// Use to validate view model's data integrity
    /// </summary>
    public static class Validation
    {
        public static bool ValidateEquipment(EquipmentViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return false;
            }

            if (model.Quantity < 1)
            {
                return false;
            }

            if (model.ClinicId < 0 || !IsClinicExists(model.ClinicId))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateClinic(ClinicViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return false;
            }
            
            return true;
        }

        public static bool IsEquipmentExists(int id)
        {
            using (MedyanaEntities context = new MedyanaEntities())
            {
                var equipment = context.Equipment.FirstOrDefault(t => t.Id == id);
                if (equipment != null)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsClinicExists(int id)
        {
            using (MedyanaEntities context = new MedyanaEntities())
            {
                var clinic = context.Clinic.FirstOrDefault(t => t.Id == id);
                if (clinic != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}