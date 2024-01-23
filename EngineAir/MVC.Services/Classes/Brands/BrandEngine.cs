using EngineAir.Models;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Interfaces;

namespace MVC.Services.Classes.Brands
{
    public class BrandEngine : BrandAircraft
    {
        public BrandEngine(Context context) : base(context) { }
        public override bool Insert(object myObject)
        {
            try
            {
                viewModel = (BrandViewModel)myObject;
                MarcaMotor marcaMotor = new()
                {
                    Nombre = viewModel.Nombre
                };

                _context.MarcaMotor.Add(marcaMotor);
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
        //    List<MarcaMotor> brands = await _context.MarcaMotor.ToListAsync();
        //    return JsonConvert.SerializeObject(brands);
        //}
    }
}
