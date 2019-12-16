using Common.Utilities;
using Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medyana.Extensions;
using Medyana.Models;

namespace Medyana.Controllers
{
    public class EquipmentController : Controller
    {
        Medyana.Manager.Resource resource = new Medyana.Manager.Resource();

        // GET: Equipment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<EquipmentViewModel> EquipmentList()
        {
            List<Equipment> result;
            try
            {
                using (MedyanaEntities context = new MedyanaEntities())
                {
                    result = context.Equipment?.ToList();
                };
                Logger.WriteDebug("EquipmentEntities fetched from db. rows: " + result.Count());
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred while fetching equipment error is: " + ex.ToString());
                throw;
            }

            return result.ToViewModelList();
        }

        /// <summary>
        /// Creates new equipment instance
        /// </summary>
        /// <param name="model"></param>
        /// <returns>newly created entity id. -1 if not successful</returns>
        [HttpPost]
        public int Create(EquipmentViewModel model)
        {
            int result = -1;
            try
            {
                if (!Validation.Validation.ValidateEquipment(model))
                {
                    throw new Exception(resource.GetResource("EquipmentCrudError"));
                }

                using (MedyanaEntities context = new MedyanaEntities())
                {
                    Equipment equipment = new Equipment();
                    equipment.Name = model.Name;
                    equipment.ProcureDate = DateTime.Parse(model.ProcureDate);
                    equipment.Quantity = model.Quantity;
                    equipment.UnitPrice = model.Price;
                    equipment.ClinicId = model.ClinicId;

                    context.Equipment.Add(equipment);
                    context.SaveChangesAsync();
                    result = equipment.Id;
                };
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred while creating equipment error is: " + ex.ToString());

                throw;
            }

            return result;
        }

        /// <summary>
        /// update equipment model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(EquipmentViewModel model)
        {
            int result = -1;
            try
            {
                if (!Validation.Validation.ValidateEquipment(model)
                    || !Validation.Validation.IsEquipmentExists(model.Id))
                {
                    throw new Exception(resource.GetResource("EquipmentCrudError"));
                }

                using (MedyanaEntities context = new MedyanaEntities())
                {
                    Equipment equipment = context.Equipment.FirstOrDefault(t=> t.Id == model.Id);
                    equipment.Name = model.Name;
                    equipment.ProcureDate = DateTime.Parse(model.ProcureDate);
                    equipment.Quantity = model.Quantity;
                    equipment.UnitPrice = model.Price;
                    equipment.ClinicId = model.ClinicId;

                    context.SaveChangesAsync();
                    result = equipment.Id;
                };
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred while creating equipment error is: " + ex.ToString());

                throw;
            }

            return result;
        }
        
        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                if (!Validation.Validation.IsEquipmentExists(id))
                {
                    throw new Exception(resource.GetResource("EquipmentNotFoundError"));
                }

                using (MedyanaEntities context = new MedyanaEntities())
                {
                    Equipment equipment = context.Equipment?.FirstOrDefault(t => t.Id == id);
                    context.Equipment.Attach(equipment);
                    context.Equipment?.Remove(equipment);
                    context.SaveChangesAsync();
                };
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred when deleting. error is: " + ex.ToString());
                throw;
            }

            Logger.WriteWarning("Successfully deleted item with id: " + id);
            return true;
        }
    }
}