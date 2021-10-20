using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteContselfSistema.Models;

namespace TesteContselfSistema.Controllers
{
    public class HomeController : Controller
    {
        FuncionariosTesteEntities db = new FuncionariosTesteEntities();

        public ActionResult Index(string searching)
        {
            return View(db.FuncionariosTestes.Where(x => x.Nome.Contains(searching) || searching == null).ToList());
        }
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FuncionariosTeste funcionariosTeste = db.FuncionariosTestes.Find(id);
            db.FuncionariosTestes.Remove(funcionariosTeste);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}
