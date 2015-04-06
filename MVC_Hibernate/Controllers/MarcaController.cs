using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidade;
using MVC_Hibernate.Models;
using Negocio;
using Newtonsoft.Json;

namespace MVC_Hibernate.Controllers
{
    public class MarcaController : Controller
    {
        //
        // GET: /Marca/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarMarca()
        {
            var marca = new MarcaView();
            return View(marca);
        }

        public ActionResult ListarMarcas()
        {
            var bus = new BusMarca();
            ViewBag.Marcas = bus.Listar();
            return View();
        }

        public ActionResult Cadastrar(MarcaView marca)
        {
            var bus = new BusMarca();

            if (ModelState.IsValid)
            {
                bus.Salvar(ConverterObjeto(marca));
                return RedirectToAction("ListarMarcas","Marca");
            }

            return View("CadastrarMarca", marca);
        }

        public ActionResult EditarMarca(int idmarca)
        {
            var bus = new BusMarca();
            Marca marca = bus.Buscar(idmarca);

            return View("CadastrarMarca", ConverterObjeto(marca));
        }

        public ActionResult ExcluirMarca(int idmarca)
        {
            var bus = new BusMarca();
            bus.Excluir(idmarca);
            return RedirectToAction("ListarMarcas", "Marca");
        }

        #region Metodos

        public Marca ConverterObjeto(MarcaView marcaView)
        {
            return JsonConvert.DeserializeObject<Marca>(JsonConvert.SerializeObject(marcaView));
        }

        public MarcaView ConverterObjeto(Marca marca)
        {
            return JsonConvert.DeserializeObject<MarcaView>(JsonConvert.SerializeObject(marca));
        }

        #endregion
    }
}
