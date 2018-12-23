using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using Project.Web.Models;
using System;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class KybersController : Controller
    {
        private readonly IKyberRepository _kyberRepository;
        private readonly IMapper _mapper;

        public KybersController(IKyberRepository kyberRepository, IMapper mapper)
        {
            _kyberRepository = kyberRepository;
            _mapper = mapper;
        }            

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

        // POST: Kybers/CreateKyber
        public async Task<JsonResult> CreateKyber(KyberViewMdel model)
        {
            try
            {
                var kyber = _mapper.Map<Kyber>(model);

                await _kyberRepository.AddAsync(kyber);

                return Json($"Kyber successful created.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: Kybers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var kyber = await _kyberRepository.GetByIdAsync(id);

            var model = _mapper.Map<KyberViewMdel>(kyber);

            if (kyber == null)
                return NotFound();

            return View(model);
        }

        // POST: Kybers/EditKyber/5
        public async Task<JsonResult> EditKyber(KyberViewMdel model)
        {
            try
            {
                var kyber = _mapper.Map<Kyber>(model);

                await _kyberRepository.UpdateAsync(kyber);

                return Json($"Kyber successful updated.");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
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
