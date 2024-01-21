using CursoMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC5.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<Empleado_CLS> listaEmpleado = null;
            using(var bd = new BDPasajeEntities())
            {
                listaEmpleado =(from Empleado in bd.Empleado
                                join TipoUsuario in bd.TipoUsuario
                                on Empleado.IIDTIPOUSUARIO equals TipoUsuario.IIDTIPOUSUARIO
                                join TipoContrato in bd.TipoContrato
                                on Empleado.IIDTIPOCONTRATO equals TipoContrato.IIDTIPOCONTRATO
                                select new Empleado_CLS
                                {
                                    IidEmpleado = Empleado.IIDEMPLEADO,
                                    Nombre = Empleado.NOMBRE,
                                    ApPaterno = Empleado.APPATERNO,
                                    NombreTipoContrato = TipoContrato.NOMBRE,
                                    NombreTipoUsuario = TipoUsuario.NOMBRE

                                }).ToList();
            }

            return View(listaEmpleado);
        }
    }
}