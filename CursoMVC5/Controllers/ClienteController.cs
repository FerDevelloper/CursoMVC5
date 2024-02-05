using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC5.Models;

namespace CursoMVC5.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente_CLS> listCliente = null;

			using (var bd = new BDPasajeEntities())
            {
                listCliente = (from cliente in bd.Cliente
                              where cliente.BHABILITADO == 1
                              select new Cliente_CLS
                              {
                                  Iidcliente = cliente.IIDCLIENTE,
                                  Nombre = cliente.NOMBRE,
                                  ApePaterno = cliente.APPATERNO,
                                  ApeMaterno = cliente.APMATERNO,
                                  TelefonoFijo = cliente.TELEFONOFIJO

                              }).ToList();
                
            }

            return View(listCliente);
        }

		List<SelectListItem> lista;

		public void LlenarListaSexo()
		{
			using (var bd = new BDPasajeEntities())
			{
				lista = (from sexo in bd.Sexo
						 where sexo.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = sexo.NOMBRE,
							 Value = sexo.IIDSEXO.ToString()
						 }).ToList();
                lista.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });

			}
		}

		[HttpGet]

        public ActionResult Agregar()
        {
            LlenarListaSexo();
            ViewBag.lista = lista;
            return View();
        }

		[HttpPost]
        
		public ActionResult Agregar(Cliente_CLS oClienteCLS)
		{
            if (!ModelState.IsValid)
            {
                LlenarListaSexo();
				ViewBag.lista = lista;
				return View(oClienteCLS);
            }

            using (var bd = new BDPasajeEntities())
            {
                Cliente oCliente = new Cliente();
                oCliente.NOMBRE = oClienteCLS.Nombre;
                oCliente.APPATERNO = oClienteCLS.ApePaterno;
                oCliente.APMATERNO = oClienteCLS.ApePaterno;
                oCliente.EMAIL = oClienteCLS.Email;
                oCliente.DIRECCION = oClienteCLS.Direccion;
                oCliente.BHABILITADO = 1;
                oCliente.IIDSEXO = oClienteCLS.Iidsexo;
                oCliente.TELEFONOCELULAR = oClienteCLS.TelefonoCelular;
                oCliente.TELEFONOFIJO = oClienteCLS.TelefonoFijo;
                bd.Cliente.Add(oCliente);
                bd.SaveChanges();
            }

			return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Cliente_CLS cliente_CLS = new Cliente_CLS();

            using(var bd = new BDPasajeEntities())
            {

				LlenarListaSexo();
				ViewBag.lista = lista;

				Cliente ocliente = bd.Cliente.Where(p => p.IIDCLIENTE.Equals(id)).First();

                cliente_CLS.Iidcliente = ocliente.IIDCLIENTE;
				cliente_CLS.Nombre = ocliente.NOMBRE;
				cliente_CLS.ApePaterno = ocliente.APPATERNO;
				cliente_CLS.ApeMaterno = ocliente.APMATERNO;
				cliente_CLS.Direccion = ocliente.DIRECCION;
				cliente_CLS.Email = ocliente.EMAIL;

				cliente_CLS.Iidsexo = (int)ocliente.IIDSEXO;
				cliente_CLS.TelefonoCelular = ocliente.TELEFONOCELULAR;
				cliente_CLS.TelefonoFijo = ocliente.TELEFONOFIJO;
			}


            return View(cliente_CLS);
        }


        [HttpPost]
        public ActionResult Editar(Cliente_CLS oclienteCLS)
        {
            int id = oclienteCLS.Iidcliente;

            if (!ModelState.IsValid)
            {
                return View(oclienteCLS);
            }

            using(var bd = new BDPasajeEntities())
            {
                Cliente oCliente = bd.Cliente.Where(p=>p.IIDCLIENTE.Equals(id)).First();
				oCliente.NOMBRE = oclienteCLS.Nombre;
				oCliente.APPATERNO = oclienteCLS.ApePaterno;
				oCliente.APMATERNO = oclienteCLS.ApeMaterno;
				oCliente.EMAIL = oclienteCLS.Email;
				oCliente.DIRECCION = oclienteCLS.Direccion;
				oCliente.IIDSEXO =(int)oclienteCLS.Iidsexo;
				oCliente.TELEFONOCELULAR = oclienteCLS.TelefonoCelular;
				oCliente.TELEFONOFIJO = oclienteCLS.TelefonoFijo;

                bd.SaveChanges();
			}

            return RedirectToAction("Index");
        }

		
	}
}