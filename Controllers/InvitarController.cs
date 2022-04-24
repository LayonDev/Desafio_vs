using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Desafio_vs.Models;
using Desafio_vs.Models.ViewModel;
using System.Net.Mail;
using System.Net;

namespace Desafio_vs.Controllers
{
    public class InvitarController : Controller
    {
        // GET: Invitar
        public ActionResult Index()
        {
            List<VistaReuniones> lista = null;
            using (DesafioDBEntities db = new DesafioDBEntities())
            {
                lista = (from d in db.Reunion
                         select new VistaReuniones
                         {
                             id = d.id_reunion,
                             titulo = d.titulo,
                             descripcion = d.descripción,
                             fecha = d.Fecha
                         }).ToList();
            }
            return View(lista);
        }
        public ActionResult Grabar(int id_, string correo)
        {
            try
            {
                using (DesafioDBEntities db = new DesafioDBEntities())
                {
                    var lista_u = (from d in db.Usuario
                                   where d.correo == correo
                                   select d).ToList();
                    if (lista_u.Count()>0)
                    {
                        var lista_r = (from d in db.Reunion
                                       where d.id_reunion == id_
                                       select d).ToList();
                        if (lista_r.Count()>0)
                        {
                            Invitados inv = new Invitados
                            {
                                id_usuario_e = lista_u[0].id_usuario,
                                id_reunion_e = lista_r[0].id_reunion,
                                id_estado_inv = 1

                            };
                            db.Invitados.Add(inv);
                            db.SaveChanges();
                            EnviarCorreo(correo);
                        }
                        else
                        {
                            return Content("La reunion no existe");
                        }
                    }
                    else
                    {
                        return Content("El correo no existe");
                    }
                }
                return Content("Invitación agregada");

            }
            catch (Exception ex)
            {
                return Content("Error invitacion" +ex.Message);
            }
        }
        public static string EnviarCorreo(string correo)
        {
            var cuerpo = "<address>"+
            "<strong>Support:</strong>   <a href='https://localhost:44359/Responder'>Support@example.com</a>"+
            "</address>";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("layon.ortega@gmail.com","************"); //Desactive aplicaciones menos seguras pero aun asi no me permitia enviar correos
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("layon.ortega@gmail.com","Invitación a reunión");
            mail.To.Add(new MailAddress("layon.ortega@gmail.com"));
            mail.Subject = "Esta es una invitación a reunión";
            mail.IsBodyHtml = true;
            mail.Body = cuerpo;

            smtp.Send(mail);

            return "correcto";
        }
    }
    
}