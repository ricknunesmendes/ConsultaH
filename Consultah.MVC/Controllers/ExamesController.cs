﻿using AutoMapper;
using ConsultaH.Application.Interface;
using ConsultaH.Domain.Entities;
using ConsultaH.MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ConsultaH.MVC.Controllers
{
    public class ExamesController : Controller
    {
        private readonly IExameAppService _exameApp;
        private readonly ITipoExameAppService _tipoExameApp;
        private readonly IConsultaAppService _consultaApp;
        
        public ExamesController(IExameAppService exameApp, ITipoExameAppService tipoExameApp, IConsultaAppService consultaApp)
        {
            _exameApp = exameApp;
            _tipoExameApp = tipoExameApp;
            _consultaApp = consultaApp;
        }

        // GET: Exames
        public ActionResult Index()
        {
            var exames = _exameApp.GetAll();
            var exameViewModel = Mapper.Map<IEnumerable<Exame>, IEnumerable<ExameViewModel>>(exames);            

            return View(exameViewModel);
        }

        // GET: Exame/Details/5
        public ActionResult Details(int id)
        {
            var exame = _exameApp.GetById(id);
            var exameViewModel = Mapper.Map<Exame, ExameViewModel>(exame);

            return View(exameViewModel);
        }

        // GET: Exame/Create
        public ActionResult Create()
        {
            var tipoExames = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExames);
            ViewBag.TipoExameID = new SelectList(tipoExamesViewModel, "ID", "Nome");
            
            return View();
        }

        // POST: Exame/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Observacoes,TipoExameID")] ExameViewModel exame)
        {
            var tipoExames = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExames);

            if(exame.TipoExameID == 0)
            {
                ModelState.AddModelError("TipoExameID", "Por favor, selecione um tipo de exame.");
            }
            

            if (ModelState.IsValid)
            {
                var exameDomain = Mapper.Map<ExameViewModel, Exame>(exame);
                _exameApp.Add(exameDomain);

                return RedirectToAction("Index");
            }

            var selectList = new SelectList(tipoExamesViewModel, "ID", "Nome", exame.TipoExameID);
            
            ViewBag.TipoExameID = selectList;            

            return View(exame);
        }

        // GET: Exame/Edit/5
        public ActionResult Edit(int? id)
        {
            var tipoExames = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExames);            
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var exame = _exameApp.GetById(id.Value);
            var exameViewModel = Mapper.Map<Exame, ExameViewModel>(exame);

            if (exame == null)
            {
                return HttpNotFound();
            }

            ViewBag.TipoExameID = new SelectList(tipoExamesViewModel, "ID", "Nome", exame.TipoExameID);

            return View(exameViewModel);
        }

        // POST: Exame/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "ID,Nome,Observacoes,TipoExameID")] ExameViewModel exame)
        {            
            var tipoExames = _tipoExameApp.GetAll();
            var tipoExamesViewModel = Mapper.Map<IEnumerable<TipoExame>, IEnumerable<TipoExameViewModel>>(tipoExames);                       

            if(exame.TipoExameID == 0)
            {
                ModelState.AddModelError("TipoExameID", "Por favor, selecione um tipo de exame.");
            }

            if (ModelState.IsValid)
            {                
                var exameDomain = Mapper.Map<ExameViewModel, Exame>(exame);
                _exameApp.Update(exameDomain);

                return RedirectToAction("Index");
            }

            ViewBag.TipoExameID = new SelectList(tipoExamesViewModel, "ID", "Nome", exame.TipoExameID);

            return View(exame);
        }

        // GET: Exame/Delete/5
        public ActionResult Delete(int id)
        {
            var canDelete = _exameApp.CanDelete(id);
            var exame = _exameApp.GetById(id);
            var exameViewModel = Mapper.Map<Exame, ExameViewModel>(exame);

            ViewBag.CanDelete = canDelete;

            return View(exameViewModel);
        }

        // POST: Exame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var canDelete = _exameApp.CanDelete(id);

            if (canDelete)
            {
                var exame = _exameApp.GetById(id);
                _exameApp.Remove(exame);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
