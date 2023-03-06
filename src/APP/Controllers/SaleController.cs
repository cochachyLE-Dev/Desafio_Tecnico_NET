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
        [HttpGet]        
        public async Task<ActionResult> GetDetail(string serie, string number)
        {
            var sale = await _context.Sales!.FirstOrDefaultAsync(serie, number);
            return PartialView("~/Views/Sale/Partials/_SaleDetail_List.cshtml", sale.List!.First().SaleDetails);
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public async Task<ActionResult> Create()
        {
            var vendors = await _context.Vendors!.GetAllAsync();
            //await _context.Sales!.RegisterAsync(sale);
            return View(new SaleViewModelCreate
            {
                Currencies = new SelectList(SaleViewModelCreate.GetCurrencies()),
                Vendors = new SelectList(vendors.List!, dataValueField: nameof(Vendor.Name), dataTextField: nameof(Vendor.Name)),
                SaleDetails = new List<SaleDetail>()
            }); ;
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

        // GET: SaleController/Delete/5
        public async Task<ActionResult> Delete(string serie, string number)
        {
            await _context.Sales!.DeleteAsync(serie, number);
            return RedirectToAction("Index");
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
