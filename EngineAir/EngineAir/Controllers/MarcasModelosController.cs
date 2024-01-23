using EngineAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models.ViewModels;
using MVC.Services.Classes.Brands;
using MVC.Services.Classes.Models;
using Newtonsoft.Json;

namespace EngineAir.Controllers
{
    public class MarcasModelosController : Controller
    {
        private readonly Context _context;
        private readonly Brand _brand;
        private readonly Model _model;
        public MarcasModelosController(Context context)
        {
            _context = context;
            _brand = new(_context);
            _model = new(_context);
        }

        public async Task<IActionResult> MarcasModelosView()
        {
            return View(await _brand.ListModelRecords());
        }

        public IActionResult NewBrand(BrandModelViewModel model)
        {
            //Manipular el estado para mandar alerta ¡PDT!

            bool state = _brand.InsertToEntity(model.BrandRecord);
            return RedirectToAction(nameof(MarcasModelosView));
        }

        public IActionResult NewModel(BrandModelViewModel model)
        {
            //Manipular el estado para mandar alerta ¡PDT!

            bool state = _model.InsertToEntity(model.ModelRecord);
            return RedirectToAction(nameof(MarcasModelosView));
        }

    }
}
