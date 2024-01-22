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
                listaViaje =(from Viaje in bd.Viaje
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
    }
}