using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.ViewModels;
using System.Linq.Expressions;

namespace MVC.Services.DesignPatterns.Interfaces
{
    public interface IModelVariant<T> where T : class
    {
        public ResponseJS Insert(ModeloVarianteViewModel ModeloVariante, DbSet<T> table);
        public Task<List<T>> GetList(DbSet<T> table, params Expression<Func<T, object>>[] includes);
    }
}
