using EngineAir.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Services.Classes.Brands
{
    public class BrandAircraft : Brand, ICrud
    {
        public BrandAircraft(Context context) : base(context) { }
        public virtual bool Insert(object myObject)
        {
            try
            {
                viewModel = (BrandViewModel)myObject;
                MarcaAeronave marcaAeronave = new()
                {
                    Nombre = viewModel.Nombre
                };

                _context.MarcaAeronave.Add(marcaAeronave);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //public async Task<string> Read()
        //{
        //    List<MarcaAeronave> brands = await _context.MarcaAeronave.ToListAsync();
        //    return JsonConvert.SerializeObject(brands);
        //}
    }
}
