using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.ViewModels;

namespace MVC.Services.DesignPatterns.Interfaces
{
    public interface IMarca<T> where T : class 
    {
        //public List<T> GetAll();
        //public T GetById(int id);
        public ResponseJS Insert(MarcaTipo marca, DbSet<T> table); 
        public Task<List<T>> GetList(DbSet<T> table); 
        //public void Update(T entity); 
        //public void Delete(int id);
    } 
}               