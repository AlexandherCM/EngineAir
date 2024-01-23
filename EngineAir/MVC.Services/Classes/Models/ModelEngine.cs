using EngineAir.Models;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Classes.AbstractClasses;

namespace MVC.Services.Classes.Models
{
    public class ModelEngine : CrudModels
    {
        public ModelEngine(Context context) : base(context) { }
        public override bool Insert(object myObject)
        {
            try
            {
                viewModel = (ModelViewModel)myObject;
                ModeloMotor newModel = new()
                {
                    MarcaID = viewModel.BrandID,
                    Nombre = viewModel.Name,
                    TiempoRemplazoHrs = viewModel.ReplaceHrs,
                    TiempoRemplazoMeses = viewModel.Months
                };

                _context.ModeloMotor.Add(newModel);
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
