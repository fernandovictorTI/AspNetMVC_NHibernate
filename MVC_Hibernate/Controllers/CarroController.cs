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
    public class CarroController : Controller
    {
        //
        // GET: /Carro/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarCarro()
        {
            BusMarca busMarca = new BusMarca();

            ViewBag.Marcas = busMarca.Listar();
            CarroView carro = new CarroView();
            return View(carro);
        }

        public ActionResult ListarCarros()
        {
            BusCarro bus = new BusCarro();
            var lst = bus.Listar();

            ViewBag.Carros = bus.Listar();

            return View();
        }

        public ActionResult Cadastrar(CarroView carroView)
        {
            BusCarro bus = new BusCarro();

            if (ModelState.IsValid)
            {
                bus.Salvar(ConverterObjeto(carroView));
                return RedirectToAction("ListarCarros", "Carro");
            }

            BusMarca busMarca = new BusMarca();

            ViewBag.Marcas = busMarca.Listar();
            return View("CadastrarCarro", carroView);
        }

        public ActionResult EditarCarro(int idCarro)
        {
            BusCarro bus = new BusCarro();
            BusMarca busMarca = new BusMarca();

            var carroView = bus.Buscar(idCarro);
            carroView.MarcaCarro = busMarca.Buscar(carroView.MarcaCarro.Id);
            carroView.IdMarca = carroView.MarcaCarro.Id;

            ViewBag.Marcas = busMarca.Listar();

            return View("CadastrarCarro", ConverterObjeto(carroView));
        }

        public ActionResult ExcluirCarro(int idCarro)
        {
            BusCarro bus = new BusCarro();
            bus.Excluir(idCarro);
            return RedirectToAction("ListarCarros", "Carro");
        }

        #region Metodos

        public Carro ConverterObjeto(CarroView carroView)
        {
            return JsonConvert.DeserializeObject<Carro>(JsonConvert.SerializeObject(carroView));
        }

        public CarroView ConverterObjeto(Carro carro)
        {
            return JsonConvert.DeserializeObject<CarroView>(JsonConvert.SerializeObject(carro));
        }

        #endregion
    }
}
