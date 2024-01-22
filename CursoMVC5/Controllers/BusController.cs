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
    }
}