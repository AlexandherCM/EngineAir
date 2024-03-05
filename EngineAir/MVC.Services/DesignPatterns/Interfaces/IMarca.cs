using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.ViewModels;
using MVC.Services.Classes;

namespace MVC.Services.DesignPatterns.Interfaces
{
    public interface IMarca<T> where T : class 
    {
        //public List<T> GetAll();
        //public T GetById(int id);
        public AlertaEstado Insert(MarcaTipoDTO marca, DbSet<T> model);
        //public void Update(T entity);
        //public void Delete(int id);
    } 
}               