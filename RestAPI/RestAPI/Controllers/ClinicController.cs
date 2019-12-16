using Common.Utilities;
using Integration;
using Medyana.Manager;
using Medyana.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using Medyana.Extensions;

namespace Medyana.Controllers
{
    public class ClinicController : Controller
    {
        Medyana.Manager.Resource resource = new Medyana.Manager.Resource();

        // GET: Clinic
        public ActionResult Index()
        {
            List<Clinic> clinicList = null;
            using (MedyanaEntities context = new MedyanaEntities())
            {
                clinicList = context.Clinic?.ToList();
            }
            ViewBag.ClinicList = clinicList;
            return View();
        }

        [HttpGet]
        public List<ClinicViewModel> ClinicList()
        {
            List<Clinic> result;
            try
            {
                using (MedyanaEntities context = new MedyanaEntities())
                {
                    result = context.Clinic?.ToList();
                };
                Logger.WriteDebug("ClinicEntities fetched from db. rows: " + result.Count());
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred while fetching clinics error is: " + ex.ToString());
                throw;
            }

            return result.ToViewModelList();
        }

        [HttpPost]
        public int Create(ClinicViewModel model)
        {
            int result = -1;
            try
            {
                if (!Validation.Validation.ValidateClinic(model))
                {
                    throw new Exception(resource.GetResource("ClinicCrudError"));
                }

                using (MedyanaEntities context = new MedyanaEntities())
                {
                    Clinic clinic = new Clinic();
                    clinic.Name = model.Name;
                    context.Clinic.Add(clinic);

                    context.SaveChangesAsync();
                    result = clinic.Id;
                };
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred while creating clinic error is: " + ex.ToString());

                throw;
            }

            return result;
        }

        [HttpPost]
        public int Update(ClinicViewModel model)
        {
            int result = -1;
            try
            {
                if (!Validation.Validation.ValidateClinic(model)
                    || !Validation.Validation.IsClinicExists(model.Id))
                {
                    throw new Exception(resource.GetResource("ClinicCrudError"));
                }

                using (MedyanaEntities context = new MedyanaEntities())
                {
                    Clinic clinic = context.Clinic.FirstOrDefault(t => t.Id == model.Id);
                    clinic.Name = model.Name;

                    context.SaveChangesAsync();
                    result = clinic.Id;
                };
            }
            catch (Exception ex)
            {
                Logger.WriteError("Error occurred while creating clinic error is: " + ex.ToString());

                throw;
            }

            return result;
        }

        [HttpPost]
        public bool Delete(int id)
        {
            try
            {
                if (!Validation.Validation.IsClinicExists(id))
                {
                    throw new Exception(resource.GetResource("ClinicNotFoundError"));
                }

                using (MedyanaEntities context = new MedyanaEntities())
                {
                    Clinic clinic = context.Clinic.FirstOrDefault(t => t.Id == id);
                    context.Clinic.Attach(clinic);
                    context.Clinic.Remove(clinic);
                    context.SaveChanges();
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