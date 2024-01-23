using EngineAir.Models;
using MVC.Models.ViewModels;
using MVC.Services.Classes.Brands;
using MVC.Services.Interfaces;
using MVC.Services.Services;

namespace MVC.Services.Classes.Models
{
    public class Model : IBrandModelComponent
    {
        protected readonly Context _context;
        protected ModelViewModel viewModel = new();
        public Model(Context context)
        {
            //_convert = new OpMonths();
            _context = context;
        }
        public bool InsertToEntity(object myObject)
        {
            viewModel = (ModelViewModel)myObject;

            switch (viewModel.Entity)
            {
                case "Aeronave":
                    ModelAircraft modelAirplane = new(_context);

                    return modelAirplane.Insert(viewModel);
                case "Motor":
                    ModelEngine modelEngine = new(_context);

                    viewModel.Months = OpMonths.YearsToMonths(viewModel.Years);
                    return modelEngine.Insert(viewModel);
                case "Helice":
                    ModelPropeller modelPropeller = new(_context);

                    viewModel.Months = OpMonths.YearsToMonths(viewModel.Years);
                    return modelPropeller.Insert(viewModel);
                default:
                    return false;
            }
        }

        #pragma warning disable CS8625
        public Task<BrandModelViewModel> ListModelRecords(BrandModelViewModel myObject = null)
        {
            throw new NotImplementedException();
        }
    }
}
