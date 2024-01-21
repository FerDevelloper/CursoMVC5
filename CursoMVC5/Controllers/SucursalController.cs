using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC5.Models;

namespace CursoMVC5.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<Sucursal_CLS> listaSucursal = new List<Sucursal_CLS>();
            using (var bd = new BDPasajeEntities())
            {
                listaSucursal = (from Sucursal in bd.Sucursal
                                 where Sucursal.BHABILITADO == 1
                                 select new Sucursal_CLS
                                 {
                                     Iidsucursal = Sucursal.IIDSUCURSAL,
                                     Nombre = Sucursal.NOMBRE,
                                     Telefono = Sucursal.TELEFONO,
                                     Email = Sucursal.EMAIL

                                 }).ToList();
            }
            return View(listaSucursal);
        }

        [HttpGet]
        public ActionResult Agregar()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Agregar(Sucursal_CLS oSucursalCLS)
        {
            if (ModelState.IsValid)
            {
                return View(oSucursalCLS);
            }

            using (var bd = new BDPasajeEntities())
            {
				Sucursal oSucursal = new Sucursal
				{
					NOMBRE = oSucursalCLS.Nombre,
					DIRECCION = oSucursalCLS.Direccion,
					TELEFONO = oSucursalCLS.Telefono,
					EMAIL = oSucursalCLS.Email
				};

				oSucursal.FECHAAPERTURA = oSucursal.FECHAAPERTURA;
                oSucursal.BHABILITADO = 1;
                bd.Sucursal.Add(oSucursal);
                bd.SaveChanges();
            }

            return RedirectToAction("Index");
        }


	}
}