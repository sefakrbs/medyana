using Integration;
using Medyana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medyana.Extensions
{
    public static class ModelConverter
    {
        /// <summary>
        /// Converts Clinic lst to view model list
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<ClinicViewModel> ToViewModelList(this IEnumerable<Clinic> source)
        {
            List<ClinicViewModel> list = new List<ClinicViewModel>();
            foreach (var item in source)
            {
                list.Add(item.ToViewModel());
            }

            return list;
        }

        /// <summary>
        /// Converts Clinic entity to view model object
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ClinicViewModel ToViewModel(this Clinic source)
        {
            return new ClinicViewModel()
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        /// <summary>
        /// Converts Equipment entity to view model object list
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<EquipmentViewModel> ToViewModelList(this IEnumerable<Equipment> source)
        {
            List<EquipmentViewModel> list = new List<EquipmentViewModel>();
            foreach (var item in source)
            {
                list.Add(item.ToViewModel());
            }

            return list;
        }

        /// <summary>
        /// Converts Equipment entity to view model object
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static EquipmentViewModel ToViewModel(this Equipment source)
        {
            return new EquipmentViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                ProcureDate = source.ProcureDate?.ToString("ddMMyyyy"),
                Quantity = source.Quantity,
                Price = source.UnitPrice,
                UsageRatio = source.UsageRatio,
                ClinicId = source.ClinicId
            };
        }
    }
}