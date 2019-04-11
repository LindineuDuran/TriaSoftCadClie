using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TriaSoftCadClie.Models;

namespace TriaSoftCadClie.Controllers
{
    public class ProdServsController : Controller
    {
        private TriaSoftCadClieContext db = new TriaSoftCadClieContext();

        // GET: ProdServs
        public ActionResult Index()
        {
            return View(db.ProdServs.ToList());
        }

        // GET: ProdServs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdServ prodServ = db.ProdServs.Find(id);
            if (prodServ == null)
            {
                return HttpNotFound();
            }
            return View(prodServ);
        }

        // GET: ProdServs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdServs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdServID,NomeProdServ")] ProdServ prodServ)
        {
            if (ModelState.IsValid)
            {
                db.ProdServs.Add(prodServ);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prodServ);
        }

        // GET: ProdServs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdServ prodServ = db.ProdServs.Find(id);
            if (prodServ == null)
            {
                return HttpNotFound();
            }
            return View(prodServ);
        }

        // POST: ProdServs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdServID,NomeProdServ")] ProdServ prodServ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prodServ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodServ);
        }

        // GET: ProdServs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdServ prodServ = db.ProdServs.Find(id);
            if (prodServ == null)
            {
                return HttpNotFound();
            }
            return View(prodServ);
        }

        // POST: ProdServs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdServ prodServ = db.ProdServs.Find(id);
            db.ProdServs.Remove(prodServ);
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
