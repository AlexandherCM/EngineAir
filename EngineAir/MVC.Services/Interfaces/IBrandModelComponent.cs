using MVC.Models.ViewModels;
#pragma warning disable 8625 // Tipo de error que invalída un valor nulo

namespace MVC.Services.Interfaces
{
    public interface IBrandModelComponent
    {
        public bool InsertToEntity(object myObject);
        public Task<BrandModelViewModel> ListModelRecords(BrandModelViewModel myObject = null);
    }
}
