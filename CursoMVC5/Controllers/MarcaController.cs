using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC5.Models;

namespace CursoMVC5.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<Marca_CLS> listaMarca = null;

			using (var bd = new BDPasajeEntities())
            {
                listaMarca =( from marca in bd.Marca
                                             select new Marca_CLS
                                             {
                                                 iidMarca=marca.IIDMARCA,
                                                 nombre=marca.NOMBRE,
                                                 descripcion=marca.DESCRIPCION

                                             }).ToList();
            }

            return View(listaMarca);
        }
        [HttpGet]

        public ActionResult Agregar()
        {
			
			return View();
		}
        [HttpPost]

		public ActionResult Agregar(Marca_CLS marca)
		{
			if (!ModelState.IsValid)
			{
				return View(marca);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
					Marca oMarca = new Marca();
                    oMarca.NOMBRE = marca.nombre;
                    oMarca.DESCRIPCION = marca.descripcion;
                    oMarca.BHABILITADO = 1;
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                    
				}
                    
            }
			return RedirectToAction("Index");
		}


        public ActionResult Editar(int id)
        {
            return View();
        }
	}
}