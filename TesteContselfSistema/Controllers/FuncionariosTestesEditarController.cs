using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteContselfSistema.Models;
using System.ComponentModel.DataAnnotations;

namespace TesteContselfSistema.Controllers
{
    public class FuncionariosTestesEditarController : Controller
    {
        private FuncionariosTesteEntities db = new FuncionariosTesteEntities();

        // GET: FuncionariosTestesEditar
        public ActionResult Index()
        {
            return View(db.FuncionariosTestes.ToList());
        }
        public ActionResult Pesquisa(string searching)
        {
            return View(db.FuncionariosTestes.Where(x => x.Nome.Contains(searching) || searching == null).ToList());
        }
        // GET: FuncionariosTestesEditar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionariosTeste funcionariosTeste = db.FuncionariosTestes.Find(id);
            if (funcionariosTeste == null)
            {
                return HttpNotFound();
            }
            return View(funcionariosTeste);
        }

        // GET: FuncionariosTestesEditar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncionariosTestesEditar/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodFuncionario,Nome,DataNascimento,Salario,Atividades")] FuncionariosTeste funcionariosTeste)
        {
            if (ModelState.IsValid)
            {
                db.FuncionariosTestes.Add(funcionariosTeste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionariosTeste);
        }

        // GET: FuncionariosTestesEditar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionariosTeste funcionariosTeste = db.FuncionariosTestes.Find(id);
            if (funcionariosTeste == null)
            {
                return HttpNotFound();
            }
            return View(funcionariosTeste);
        }

        // POST: FuncionariosTestesEditar/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodFuncionario,Nome,DataNascimento,Salario,Atividades")] FuncionariosTeste funcionariosTeste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionariosTeste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionariosTeste);
        }

        // GET: FuncionariosTestesEditar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionariosTeste funcionariosTeste = db.FuncionariosTestes.Find(id);
            if (funcionariosTeste == null)
            {
                return HttpNotFound();
            }
            return View(funcionariosTeste);
        }

        // POST: FuncionariosTestesEditar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FuncionariosTeste funcionariosTeste = db.FuncionariosTestes.Find(id);
            db.FuncionariosTestes.Remove(funcionariosTeste);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
