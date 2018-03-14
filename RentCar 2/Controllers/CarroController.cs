using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentCar_2.Models;

namespace RentCar_2.Controllers
{
    public class CarroController : Controller
    {
        RentCarDBDataContext db = new RentCarDBDataContext();
        // GET: Carro
        public ActionResult Index()
        {
            LoadDropDownsData();
            var listar = db.Carros.ToList();
            return View(listar);
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            var detalles = db.Carros.Single(x => x.IDCarro == id);
            return View(detalles);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            LoadDropDownsData();
            return View();
        }

        void LoadDropDownsData()
        {
            var modelo = db.Modelos.ToList().Select(r => new SelectListItem
            
            {
                Value = $"{r.IDModelo}",
                Text = $"{r.NombreModelo}"
            });

            ViewBag.model = modelo;

        }

        // POST: Carro/Create
        [HttpPost]
        public ActionResult Create(Carro carro)
        {
            try
            {
                db.Carros.InsertOnSubmit(carro);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            LoadDropDownsData();
           var carro = db.Carros.Single(c => c.IDCarro == id);
            return View(carro);
        }

        // POST: Carro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Carro collection)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add update logic here
                Carro carro = db.Carros.Single(c => c.IDCarro == id);
                carro.Matricula = collection.Matricula;
                carro.ModeloID = collection.ModeloID;
                carro.Color = collection.Color;
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            var ID = db.Carros.Single(x => x.IDCarro == id);
            return View(ID);
        }

        // POST: Carro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Carro collection)
        {
            try
            {

                var eliminar = db.Carros.Single(x => x.IDCarro == id);
                db.Carros.DeleteOnSubmit(eliminar);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
