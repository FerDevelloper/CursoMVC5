using CursoMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC5.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<Bus_CLS> listaBus = null;
            using(var bd = new BDPasajeEntities())
            {
                listaBus = (from bus in bd.Bus
                            join Sucursal in bd.Sucursal
                            on bus.IIDSUCURSAL equals Sucursal.IIDSUCURSAL
                            join TipoBus in bd.TipoBus
                            on bus.IIDTIPOBUS equals TipoBus.IIDTIPOBUS
                            join tipoModelo in bd.Modelo
                            on bus.IIDMODELO equals tipoModelo.IIDMODELO
                            where bus.BHABILITADO ==1

                            select new Bus_CLS
                            {
                                IidBus = bus.IIDBUS,
                                placa = bus.PLACA,
                                NombreModelo = tipoModelo.NOMBRE,
                                NombreSucursal = Sucursal.NOMBRE,
                                NombreTipoBus = TipoBus.NOMBRE

                            }).ToList();
            }
            return View(listaBus);
        }

        public ActionResult Agregar()
        {
			Llenar_Combos();
            return View();
        }

		[HttpPost]

		public ActionResult Agregar(Bus_CLS Bus_cls)
		{

			if(!ModelState.IsValid)
			{
				Llenar_Combos();
				return View(Bus_cls);
			}

			using(var bd= new BDPasajeEntities())
			{
				Bus oBus= new Bus();
				oBus.BHABILITADO = 1;
				oBus.IIDSUCURSAL = Bus_cls.IidSucursal;
				oBus.IIDTIPOBUS = Bus_cls.IidTipoBus;
				oBus.PLACA = Bus_cls.placa;
				oBus.FECHACOMPRA = Bus_cls.FechaCompra;
				oBus.IIDMODELO = Bus_cls.IidModelo;
				oBus.NUMEROFILAS = Bus_cls.NumeroFilas;
				oBus.NUMEROCOLUMNAS = Bus_cls.NumeroColumnas;
				oBus.DESCRIPCION = Bus_cls.Descripcion;
				oBus.OBSERVACION = Bus_cls.Observacion;
				oBus.IIDMARCA = Bus_cls.IidMarca;

				bd.Bus.Add(oBus);
				bd.SaveChanges();
			}
			return RedirectToAction("Index",Bus_cls);
		}


		public void Llenar_Combos()
		{
			listarMarca();
			listarModelo();
			listarSucursal();
			listarTipoBus();
		}


		public void listarTipoBus()
		{
			List<SelectListItem> lista;
			using (var bd = new BDPasajeEntities())
			{
				lista = (from TipoContrato in bd.TipoBus
						 where TipoContrato.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = TipoContrato.NOMBRE,
							 Value = TipoContrato.IIDTIPOBUS.ToString(),

						 }).ToList();

				lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
				ViewBag.listarTipoBus = lista;
			}
		}

		public void listarMarca()
		{
			List<SelectListItem> lista;
			using (var bd = new BDPasajeEntities())
			{
				lista = (from TipoContrato in bd.Marca
						 where TipoContrato.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = TipoContrato.NOMBRE,
							 Value = TipoContrato.IIDMARCA.ToString(),

						 }).ToList();

				lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
				ViewBag.listarMarca = lista;
			}
		}

		public void listarModelo()
		{
			List<SelectListItem> lista;
			using (var bd = new BDPasajeEntities())
			{
				lista = (from TipoContrato in bd.Modelo
						 where TipoContrato.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = TipoContrato.NOMBRE,
							 Value = TipoContrato.IIDMODELO.ToString(),

						 }).ToList();

				lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
				ViewBag.listarModelo = lista;
			}
		}

		public void listarSucursal()
		{
			List<SelectListItem> lista;
			using (var bd = new BDPasajeEntities())
			{
				lista = (from TipoContrato in bd.Sucursal
						 where TipoContrato.BHABILITADO == 1
						 select new SelectListItem
						 {
							 Text = TipoContrato.NOMBRE,
							 Value = TipoContrato.IIDSUCURSAL.ToString(),

						 }).ToList();

				lista.Insert(0, new SelectListItem { Text = "--Selecione--", Value = "" });
				ViewBag.listarSucursal = lista;
			}
		}

		[HttpGet]
		public ActionResult Editar(int IidBus)
		{
			Bus_CLS bus_CLS = new Bus_CLS();
						
			using (var bd = new BDPasajeEntities())
			{
				Bus bus = bd.Bus.Where(p => p.IIDBUS.Equals(IidBus)).First();			

				bus_CLS.IidSucursal = (int)bus.IIDSUCURSAL;
				bus_CLS.placa = bus.PLACA;
				bus_CLS.FechaCompra = (DateTime)bus.FECHACOMPRA;
				bus_CLS.IidModelo = (int)bus.IIDMODELO;
				bus_CLS.NumeroColumnas = (int)bus.NUMEROCOLUMNAS;
				bus_CLS.NumeroFilas = (int)bus.NUMEROFILAS;
				bus_CLS.Descripcion = bus.DESCRIPCION;
				bus_CLS.Observacion = bus.OBSERVACION;
				bus_CLS.IidMarca = (int)bus.IIDMARCA;
				
			}
			Llenar_Combos();
			return View(bus_CLS);
		}

		[HttpPost]
		public ActionResult Editar(Bus_CLS obus)
		{
			if (!ModelState.IsValid)
			{
				return View(obus);
			}

			int id = obus.IidBus;
			using(var bd = new BDPasajeEntities())
			{
				Bus bus = bd.Bus.Where(p => p.Equals(id)).First();

				bus.IIDSUCURSAL = obus.IidSucursal;
				bus.PLACA = obus.placa;
				bus.FECHACOMPRA = obus.FechaCompra;
				bus.IIDMODELO = obus.IidModelo;
				bus.NUMEROCOLUMNAS = obus.NumeroColumnas;
				bus.NUMEROFILAS = obus.NumeroFilas;
				bus.DESCRIPCION = obus.Descripcion;
				bus.OBSERVACION = obus.Observacion;
				bus.IIDMARCA = obus.IidMarca;

				bd.SaveChanges();
			}
			return RedirectToAction("Index");
		}


	}
}