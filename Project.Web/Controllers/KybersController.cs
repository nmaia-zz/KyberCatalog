using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class KybersController : Controller
    {
        private readonly IKyberRepository _kyberRepository;

        public KybersController(IKyberRepository kyberRepository)
            => _kyberRepository = kyberRepository;

        // GET: Kybers
        public async Task<IActionResult> Index()
            => View(await _kyberRepository.GetAllAsync());

        // GET: Kybers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var kyber = await _kyberRepository.GetByIdAsync(id);

            if (kyber == null)
                return NotFound();

            return View(kyber);
        }

        // GET: Kybers/Create
        public IActionResult Create()
            => View();

        // POST: Kybers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Color,Planet,Meaning")] Kyber kyber)
        {
            if (ModelState.IsValid)
            {
                await _kyberRepository.AddAsync(kyber);

                return RedirectToAction(nameof(Index));
            }

            return View(kyber);
        }

        // GET: Kybers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var kyber = await _kyberRepository.GetByIdAsync(id);

            if (kyber == null)
                return NotFound();

            return View(kyber);
        }

        // POST: Kybers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Color,Planet,Meaning")] Kyber kyber)
        {
            if (id != kyber.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _kyberRepository.UpdateAsync(kyber);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KyberExists(kyber.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(kyber);
        }

        // GET: Kybers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var kyber = await _kyberRepository.GetByIdAsync(id);

            if (kyber == null)
                return NotFound();

            return View(kyber);
        }

        // POST: Kybers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kyber = await _kyberRepository.GetByIdAsync(id);
            await _kyberRepository.RemoveAsync(kyber);

            return RedirectToAction(nameof(Index));
        }

        private bool KyberExists(int id)
            => _kyberRepository.GetByIdAsync(id) != null;
    }
}
