using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Business.Contracts;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using Project.Web.Models;
using System;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class KybersController : Controller
    {
        private readonly IKyberBusiness _kyberBusiness;
        private readonly IKyberRepository _kyberRepository;
        private readonly IMapper _mapper;

        public KybersController(IKyberBusiness kyberBusiness, IKyberRepository kyberRepository, IMapper mapper)
        {
            _kyberBusiness = kyberBusiness;
            _kyberRepository = kyberRepository;
            _mapper = mapper;
        }

        // GET: Kybers
        public async Task<ViewResult> Index(string currentFilter, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return View(await _kyberRepository.GetAllAsync());
            else
                currentFilter = searchString;

            ViewBag.CurrentFilter = searchString;

            var searchResult = await _kyberRepository.SearchByNameOrColor(currentFilter);

            return View(searchResult);
        }

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
        public async Task<JsonResult> CreateKyber(KyberCreateViewMdel model)
        {
            try
            {
                var kyber = _mapper.Map<Kyber>(model);

                if (_kyberBusiness.Exists(kyber).Result)
                    throw new ArgumentException($"The kyber you're trying to register, already exists in database. Please, try another one.");
                else
                {
                    await _kyberRepository.AddAsync(kyber);

                    return Json(new { status = 200, message = $"Kyber successful created." });
                }
            }
            catch (ArgumentException ex)
            {
                return Json(new { status = 400, message = ex.Message });
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

            var model = _mapper.Map<KyberEditViewMdel>(kyber);

            if (kyber == null)
                return NotFound();

            return View(model);
        }

        // POST: Kybers/EditKyber/5
        public async Task<JsonResult> EditKyber(KyberEditViewMdel model)
        {
            try
            {
                var kyber = _mapper.Map<Kyber>(model);

                await _kyberRepository.UpdateAsync(kyber);

                return Json(new { status = 200, message = $"Kyber successful updated." });
            }
            catch (DbUpdateException ex)
            {
                var exceptionInnerMessage = ex.Message;
                return Json(new { status = 400, message = "The kyber you're trying to register, already exists in database. Please, try another one." });
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

        //[HttpGet]
        //public async Task<IActionResult> FilterBy([FromQuery] string stringForSearch)
        //    => View(await _kyberRepository.GetByNameOrColor(stringForSearch));        

        private bool KyberExists(int id)
            => _kyberRepository.GetByIdAsync(id) != null;
    }
}
