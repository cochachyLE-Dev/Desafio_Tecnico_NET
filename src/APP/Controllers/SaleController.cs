using APP.Data;
using APP.Models;
using APP.Models.ViewModels;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APP.Controllers
{
    public class SaleController : Controller
    {
        private readonly IApiContext _context;
        public SaleController(IApiContext context)
        {
            _context = context;
        }

        // GET: SaleController
        public async Task<ActionResult> Index()
        {
            var sales = await _context.Sales!.GetAllAsync();
            var sellers = await _context.Vendors!.GetAllAsync();

            return View(new SaleViewModel()
            {
                Sales = sales.List!,
                Vendors = new SelectList(sellers.List!, dataValueField: nameof(Vendor.Name), dataTextField: nameof(Vendor.Name))
            });
        }
        [HttpPost]
        public async Task<ActionResult> Index(string vendorName, string searchString) 
        {
            var sales = await _context.Sales!.SearchAsync(filter: vendorName ?? searchString);
            var vendors = await _context.Vendors!.GetAllAsync();

            return View(new SaleViewModel()
            {
                Sales = sales.List!,
                VendorName = vendorName,
                Vendors = new SelectList(vendors.List!, dataValueField: nameof(Vendor.Name), dataTextField: nameof(Vendor.Name))
            });
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public async Task<ActionResult> Create([FromBody] Sale sale)
        {
            await _context.Sales!.RegisterAsync(sale);
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
