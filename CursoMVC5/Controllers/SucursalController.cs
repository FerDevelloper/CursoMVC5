﻿using System;
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
            int num_registros = 0;
            string nom = oSucursalCLS.Nombre;
            using(var bd = new BDPasajeEntities())
            {
                num_registros = bd.Sucursal.Where(p=>p.NOMBRE.Equals(nom)).Count();
            }

            if (ModelState.IsValid || num_registros !=0)
            {
                oSucursalCLS.Msg_error = "la sucursal que deceas agregar ya existe ";
                return View(oSucursalCLS);
            }

            using (var bd = new BDPasajeEntities())
            {
				Sucursal oSucursal = new Sucursal
				{
					NOMBRE = oSucursalCLS.Nombre,
					DIRECCION = oSucursalCLS.Direccion,
					TELEFONO = oSucursalCLS.Telefono,
					EMAIL = oSucursalCLS.Email,
					FECHAAPERTURA = oSucursalCLS.FechaApertura
			    };
				
                oSucursal.BHABILITADO = 1;
                bd.Sucursal.Add(oSucursal);
                bd.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            Sucursal_CLS sucursalCLS = new Sucursal_CLS();

            using(var bd = new BDPasajeEntities())
            {
                Sucursal osucursal = bd.Sucursal.Where( p=> p.IIDSUCURSAL.Equals(id)).First();
				sucursalCLS.Iidsucursal = osucursal.IIDSUCURSAL;
				sucursalCLS.Nombre = osucursal.NOMBRE;
				sucursalCLS.Direccion = osucursal.DIRECCION;
				sucursalCLS.Telefono = osucursal.TELEFONO;
				sucursalCLS.Email = osucursal.EMAIL;
                sucursalCLS.FechaApertura = (DateTime)osucursal.FECHAAPERTURA;
				

			}

            return View(sucursalCLS);
        }

        [HttpPost]
        public ActionResult Editar(Sucursal_CLS oSucursal)
        {
            if (!ModelState.IsValid)
            {
                return View(oSucursal);
            }
            int id = oSucursal.Iidsucursal;

            using(var bd=new BDPasajeEntities())
            {
                Sucursal sucursal = bd.Sucursal.Where(p => p.IIDSUCURSAL.Equals(id)).First();

                sucursal.NOMBRE = oSucursal.Nombre;
				sucursal.DIRECCION = oSucursal.Direccion;
				sucursal.TELEFONO = oSucursal.Telefono;
				sucursal.EMAIL = oSucursal.Email;
				sucursal.FECHAAPERTURA = oSucursal.FechaApertura;
                
                bd.SaveChanges();
			}

            return RedirectToAction("Index");
        }


        public ActionResult Eliminar(int id)
        {
            using(var bd  = new BDPasajeEntities())
            {
                Sucursal osucursal = bd.Sucursal.Where(p=>p.Equals(id)).First();
                osucursal.BHABILITADO = 0;
                bd.SaveChanges();
            }

            return RedirectToAction("Index");

        }


	}
}