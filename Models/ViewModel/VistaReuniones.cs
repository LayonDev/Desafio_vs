using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio_vs.Models.ViewModel
{
    public class VistaReuniones
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
    }
}