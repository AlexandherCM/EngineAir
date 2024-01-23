using EngineAir.Models;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Classes.AbstractClasses;
using MVC.Services.Interfaces;

namespace MVC.Services.Classes.Models
{
    public class ModelAircraft : CrudModels
    {
        public ModelAircraft(Context context) : base(context) { }
        public override bool Insert(object myObject)
        {
            try
            {
                viewModel = (ModelViewModel)myObject;
                ModeloAeronave newModel = new()
                {
                    Nombre = viewModel.Name,
                    MarcaID= viewModel.BrandID,
                };

                _context.ModeloAeronave.Add(newModel);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
