using EngineAir.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Services.Classes.Brands
{
    public class Brand : IBrandModelComponent
    {
        protected readonly Context _context;
        protected BrandViewModel viewModel = new();
        public Brand(Context context)
        {
            _context = context;
        }
        public virtual bool InsertToEntity(object myObject)
        {
            viewModel = (BrandViewModel)myObject;

            switch (viewModel.Entidad)
            {
                case "Aeronave":
                    BrandAircraft brandAirplane = new(_context);

                    return brandAirplane.Insert(viewModel);
                case "Motor":
                    BrandEngine brandEngine = new(_context);

                    return brandEngine.Insert(viewModel);
                case "Helice":
                    BrandPropeller brandPropeller = new(_context);

                    return brandPropeller.Insert(viewModel);
                default:
                    return false;
            }
        }

        #pragma warning disable IDE0074 
        #pragma warning disable CS8625 // Tipo de error que invalída un valor nulo
        public async Task<BrandModelViewModel> ListModelRecords(BrandModelViewModel myObject = null)
        {
            if (myObject == null)
            {
                myObject = new();
            }

            myObject.MarcasMotor = new SelectList(await _context.MarcaMotor.ToListAsync(), "ID", "Nombre");
            myObject.MarcasAeronave = new SelectList(await _context.MarcaAeronave.ToListAsync(), "ID", "Nombre");
            myObject.MarcasHelice = new SelectList(await _context.MarcaHelice.ToListAsync(), "ID", "Nombre");

            return myObject;
        }
    }
}
