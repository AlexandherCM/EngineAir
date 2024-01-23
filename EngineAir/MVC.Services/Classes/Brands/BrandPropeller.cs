using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Classes.Brands
{
    public class BrandPropeller : BrandAircraft
    {
        public BrandPropeller(Context context) : base(context) { }
        public override bool Insert(object myObject)
        {
            try
            {
                viewModel = (BrandViewModel)myObject;
                MarcaHelice marcaHelice = new()
                {
                    Nombre = viewModel.Nombre
                };

                _context.MarcaHelice.Add(marcaHelice);
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
        //    List<MarcaHelice> brands = await _context.MarcaHelice.ToListAsync();
        //    return JsonConvert.SerializeObject(brands);
        //}
    }
}
