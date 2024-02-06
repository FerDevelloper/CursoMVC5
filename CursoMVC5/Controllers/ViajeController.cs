using CursoMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC5.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<Viaje_CLS> listaViaje = null;

            using (var bd = new BDPasajeEntities())
            {
                listaViaje = (from Viaje in bd.Viaje
                              join lugarOrigen in bd.Lugar
                              on Viaje.IIDLUGARORIGEN equals lugarOrigen.IIDLUGAR
                              join LugarDestino in bd.Lugar
                              on Viaje.IIDLUGARDESTINO equals LugarDestino.IIDLUGAR
                              join bus in bd.Bus
                              on Viaje.IIDBUS equals bus.IIDBUS
                              select new Viaje_CLS
                              {
                                  iidviaje = Viaje.IIDVIAJE,
                                  nombreBus = bus.PLACA,
                                  nombreLugarOrigen = lugarOrigen.NOMBRE,
                                  nombreLugarDestino = LugarDestino.NOMBRE

                              }).ToList();
            }

            return View(listaViaje);
        }

        public void llenarCombos()
        {
            ListarBus();
            ListarLugar();
        }

        public void ListarLugar()
        {
            List<SelectListItem> list;
            using (var bd = new BDPasajeEntities())
            {
                list = (from item in bd.Lugar
                        where item.BHABILITADO == 1
                        select new  SelectListItem
                        {
                            Text = item.NOMBRE,
                            Value = item.IIDLUGAR.ToString()
                        }).ToList();
                list.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaLugar = list;
            }
        }

		public void ListarBus()
		{
			List<SelectListItem> list;
			using (var bd = new BDPasajeEntities())
			{
				list = (from item in bd.Bus
						where item.BHABILITADO == 1
						select new SelectListItem
						{
							Text = item.PLACA,
							Value = item.IIDBUS.ToString()
						}).ToList();
				list.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
				ViewBag.listaBus = list;
			}
		}

		public ActionResult Agregar(Viaje_CLS oViaje)
        {
            llenarCombos();
            return View();

        }
        
    }
}