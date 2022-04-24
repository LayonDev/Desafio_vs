using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Desafio_vs.Models;

namespace Desafio_vs.Controllers
{
    public class CrearEventoController : Controller
    {
        // GET: CrearEvento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Grabar(string user, string titulo_r, string descripcion_r, DateTime fecha)
        {
            try
            {
                using (DesafioDBEntities db = new DesafioDBEntities())
                {
                    Reunion re = new Reunion
                    {
                        titulo = titulo_r,
                        descripción = descripcion_r,
                        Fecha = fecha
                    };
                    db.Reunion.Add(re);
                    db.SaveChanges();
                }
                return Content("Reunion agregada");

            }
            catch(Exception ex)
            {
                return Content("Error reunion" +ex.Message);
            }
            
        }
    }
}