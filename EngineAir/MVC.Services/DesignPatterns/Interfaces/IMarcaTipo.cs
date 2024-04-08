using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.ViewModels;

namespace MVC.Services.DesignPatterns.Interfaces
{ 
    public interface IMarcaTipo<T> where T : class 
    {
        //public List<T> GetAll();
        //public T GetById(int id);
        public ResponseJS Insert(MarcaTipoViewModel marca, DbSet<T> table);  
        public Task<(bool, bool)> UpdateStatus(int ID, DbSet<T> table); 
        public Task<List<T>> GetList(DbSet<T> table); 
        //public void Update(T entity); 
        //public void Delete(int id);
    } 
}               