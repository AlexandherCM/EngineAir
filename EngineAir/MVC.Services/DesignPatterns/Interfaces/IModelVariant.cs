using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.ViewModels;

namespace MVC.Services.DesignPatterns.Interfaces
{
    public interface IModelVariant<T> where T : class
    {
        public ResponseJS Insert(ModeloVariante ModeloVariante, DbSet<T> table);
    }
}
