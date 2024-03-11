using CursoMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC5.Controllers
{
    public class ListaController : Controller
    {
		// GET: Lista
		public ActionResult Index()
		{
			// Crear una lista de objetos Item con datos ficticios
			var items = new List<Lista_CLS>
		{
			new Lista_CLS { act = true, nom = "Item 1" },
			new Lista_CLS { act = false, nom = "Item 2" },
			new Lista_CLS { act = true, nom = "Item 3" },
			new Lista_CLS { act = false, nom = "Item 4" },
			new Lista_CLS { act = true, nom = "Item 5" }
		};

			Lista2_CLS listaC = new Lista2_CLS();
			listaC.lista = items;

			return View(listaC);
		}

		[HttpPost]
		public ActionResult Fer(Lista2_CLS items)
		{
			// 'items' contendrá una lista de objetos Item con las propiedades Activo y Nombre
			// Puedes hacer lo que necesites con estos objetos aquí
			return View();
		}




	}
}