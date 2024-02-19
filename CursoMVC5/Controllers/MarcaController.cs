
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                              where marca.BHABILITADO == 1
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
            int num_registros = 0;
            string nom_marca = marca.nombre;
            using(var bd = new BDPasajeEntities())
            {
                num_registros= bd.Marca.Where(p=>p.NOMBRE.Equals(nom_marca)).Count();
            }

			if (!ModelState.IsValid || num_registros != 0 )
			{
                if (num_registros != 0) marca.mensaje_error = $"El nombre {marca.nombre} ya existe";
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

            Marca_CLS oMarca_CLS = new Marca_CLS();
            using(var bd = new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p =>p.IIDMARCA.Equals(id)).First();
				oMarca_CLS.iidMarca = oMarca.IIDMARCA;
				oMarca_CLS.nombre = oMarca.NOMBRE;
				oMarca_CLS.descripcion = oMarca.DESCRIPCION;
			}

            return View(oMarca_CLS);
        }

        [HttpPost]
        public ActionResult Editar(Marca_CLS oMarca_CLS)
        {
			int num_registros = 0;
			string nom_marca = oMarca_CLS.nombre;
            int id = oMarca_CLS.iidMarca;
			using (var bd = new BDPasajeEntities())
			{
				num_registros = bd.Marca.Where(p => p.NOMBRE.Equals(nom_marca) && !p.IIDMARCA.Equals(id)).Count();
			}


            if (!ModelState.IsValid || num_registros >= 1) oMarca_CLS.mensaje_error = "ya se emcuentra registrada la marca";
            {
                if(num_registros >=1)
                return View(oMarca_CLS);
            }

            int idMarca = oMarca_CLS.iidMarca;
            using (var bd = new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(idMarca)).First();
                oMarca.NOMBRE = oMarca_CLS.nombre;
				oMarca.DESCRIPCION = oMarca_CLS.descripcion;
                bd.SaveChanges();
			}

            return RedirectToAction("Index");

        }

        
        public ActionResult Eliminar(int id)
        {
            using(var bd = new BDPasajeEntities())
            {
                Marca oMarca = bd.Marca.Where(p => p.IIDMARCA.Equals(id)).First();
                oMarca.BHABILITADO = 0;
                bd.SaveChanges();
            }

            return RedirectToAction("Index");

        }
	}
}