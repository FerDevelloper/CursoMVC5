﻿using CursoMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
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
                                where Empleado.BHABILITADO == 1

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

        public void listarcombosexo()
        {
            List<SelectListItem> lista;
            using(var bd = new BDPasajeEntities())
            {
                lista =(from sexo in bd.Sexo
                        where sexo.BHABILITADO == 1
                        select new SelectListItem
                        {
                            Text = sexo.NOMBRE,
                            Value = sexo.IIDSEXO.ToString(),

                        }).ToList();

                lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
                ViewBag.ListaSexo = lista;
            }
        }

		public void listarTipoContrato()
		{
			List<SelectListItem> lista;
			using (var bd = new BDPasajeEntities())
			{
				lista = (from TipoContrato in bd.TipoContrato
						 where TipoContrato.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = TipoContrato.NOMBRE,
							 Value = TipoContrato.IIDTIPOCONTRATO.ToString(),

						 }).ToList();

				lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
				ViewBag.ListaTipoContrato = lista;
			}
		}

		public void listarTipoUsuario()
		{
			List<SelectListItem> lista;
			using (var bd = new BDPasajeEntities())
			{
				lista = (from item in bd.TipoUsuario
						 where item.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = item.NOMBRE,
							 Value = item.IIDTIPOUSUARIO.ToString(),

						 }).ToList();

				lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
				ViewBag.ListaTipoUsuario = lista;
			}
		}

        public void ListarCombos()
        {
            listarcombosexo();
            listarTipoContrato();
            listarTipoUsuario();
        }
                
		public ActionResult Agregar()
        {
			ListarCombos();
			return View();
        }

        [HttpPost]
		public ActionResult Agregar(Empleado_CLS empleado)
		{
            if (!ModelState.IsValid)
            {
                ListarCombos();
                return View(empleado);
            }
            using(var bd = new BDPasajeEntities())
            {
                Empleado oEmpleado = new Empleado();
                oEmpleado.NOMBRE = empleado.Nombre;
				oEmpleado.APPATERNO = empleado.ApPaterno;
				oEmpleado.APMATERNO = empleado.ApMaterno;
				oEmpleado.SUELDO = empleado.Sueldo;
				oEmpleado.FECHACONTRATO = empleado.FechaContrato;
				oEmpleado.IIDTIPOCONTRATO = empleado.IidTipoContrato;
				oEmpleado.IIDTIPOUSUARIO = empleado.IidTipoUsuario;
				oEmpleado.IIDSEXO = empleado.IidSexo;
                oEmpleado.BHABILITADO = 1;

                bd.Empleado.Add(oEmpleado);
                bd.SaveChanges();
			}

			return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult Editar(int id)
        {
			ListarCombos();

			Empleado_CLS empleado_CLS = new Empleado_CLS();
            using(var bd = new BDPasajeEntities())
            {
                Empleado oempleado = bd.Empleado.Where(p => p.IIDEMPLEADO.Equals(id)).First();

                empleado_CLS.IidEmpleado = oempleado.IIDEMPLEADO;
				empleado_CLS.Nombre = oempleado.NOMBRE;
				empleado_CLS.ApPaterno = oempleado.APPATERNO;
				empleado_CLS.ApMaterno = oempleado.APMATERNO;
				empleado_CLS.FechaContrato = (DateTime)oempleado.FECHACONTRATO;
				empleado_CLS.Sueldo = (decimal)oempleado.SUELDO;
				empleado_CLS.IidTipoUsuario = (int)oempleado.IIDTIPOUSUARIO;
				empleado_CLS.IidTipoContrato = (int)oempleado.IIDTIPOCONTRATO;
				empleado_CLS.IidSexo = (int)oempleado.IIDSEXO;
			}

            return View(empleado_CLS);
        }

		[HttpPost]
		public ActionResult Editar(Empleado_CLS oEmpleado)
		{
			if (!ModelState.IsValid)
			{
				return View(oEmpleado);
			}

			int id = oEmpleado.IidEmpleado;
			using (var bd = new BDPasajeEntities())
			{
				Empleado oempleado = bd.Empleado.Where(p => p.IIDEMPLEADO.Equals(id)).First();

				oempleado.IIDEMPLEADO = oEmpleado.IidEmpleado;
				oempleado.NOMBRE = oEmpleado.Nombre;
				oempleado.APPATERNO = oEmpleado.ApPaterno;
				oempleado.APMATERNO = oEmpleado.ApMaterno;
				oempleado.FECHACONTRATO = oEmpleado.FechaContrato;
				oempleado.SUELDO = oEmpleado.Sueldo;
				oempleado.IIDTIPOUSUARIO = oEmpleado.IidTipoUsuario;
				oempleado.IIDTIPOCONTRATO = oEmpleado.IidTipoContrato;
				oempleado.IIDSEXO = oEmpleado.IidSexo;

				bd.SaveChanges();
				
			}

			return RedirectToAction("Index");
		}


	}
}