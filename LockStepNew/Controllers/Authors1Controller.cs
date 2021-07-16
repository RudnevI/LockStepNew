using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using LockStep.Library.Domain;

namespace LockStepNew.Controllers
{
    public class Authors1Controller : Controller
    {
        private readonly IAuthorRepository _repo;

        public Authors1Controller(IAuthorRepository repo)
        {
            this._repo = repo;
        }



        // GET: Authors1
        public async Task<ActionResult> Index()
        {
            return View(await _repo.Get());
        }

        // GET: Authors1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await _repo.GetById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
                await _repo.Insert(author);
              
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await _repo.GetById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors1/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Author author)
        {
            if (ModelState.IsValid)
            {
               await _repo.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = await _repo.GetById(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Author author = await _repo.GetById(id);
            await _repo.Delete(author);
           
            return RedirectToAction("Index");
        }

       
    }
}
