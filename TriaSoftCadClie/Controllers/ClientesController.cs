using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TriaSoftCadClie.Models;

namespace TriaSoftCadClie.Controllers
{
    public class ClientesController : Controller
    {
        private TriaSoftCadClieContext db = new TriaSoftCadClieContext();

        // GET: Clientes
        public ActionResult Index(string ordenacaoOrdem, string filtroCliente, string filtroEmpresa)
        {
            var clientes = db.Clientes.Include(c => c.ProdServ);

            ViewBag.DataCadastroOrdenacaoParm = String.IsNullOrEmpty(ordenacaoOrdem) ? "DataCadastro_desc" : "";
            ViewBag.NomeClienteOrdenacaoParm = ordenacaoOrdem == "NomeCliente" ? "NomeCliente_desc" : "NomeCliente";

            if (!string.IsNullOrEmpty(filtroCliente))
            {
                clientes = clientes.Where(c => c.NomeCliente.Contains(filtroCliente));
            }

            if (!string.IsNullOrEmpty(filtroEmpresa))
            {
                clientes = clientes.Where(c => c.NomeEmpresa.Contains(filtroEmpresa));
            }

            switch (ordenacaoOrdem)
            {
                case "NomeCliente":
                    clientes = clientes.AsQueryable().OrderBy(c => c.NomeCliente);
                    break;

                case "NomeCliente_desc":
                    clientes = clientes.AsQueryable().OrderByDescending(c => c.NomeCliente);
                    break;

                case "DataCadastro":
                    clientes.AsQueryable().OrderBy(c => c.DataCadastro);
                    break;

                case "DataCadastro_desc":
                    clientes.AsQueryable().OrderByDescending(c => c.DataCadastro);
                    break;

                default:
                    clientes = clientes.AsQueryable().OrderBy(c => c.DataCadastro);
                    break;
            }
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            Cliente cliente = new Cliente();
            cliente.DataAtend = DateTime.Now;
            cliente.DataCadastro = DateTime.Now;

            ViewBag.ProdServID = new SelectList(db.ProdServs, "ProdServID", "NomeProdServ");
            return View(cliente);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomeEmpresa,NomeCliente,Telefone,Email,Atendimento,DataCadastro,DataAtend,ProdServID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.DataCadastro = DateTime.Now;
                cliente.DataAtend = DateTime.Now;

                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdServID = new SelectList(db.ProdServs, "ProdServID", "NomeProdServ", cliente.ProdServID);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdServID = new SelectList(db.ProdServs, "ProdServID", "NomeProdServ", cliente.ProdServID);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomeEmpresa,NomeCliente,Telefone,Email,Atendimento,DataCadastro,DataAtend,ProdServID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.DataAtend = DateTime.Now;

                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdServID = new SelectList(db.ProdServs, "ProdServID", "NomeProdServ", cliente.ProdServID);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
