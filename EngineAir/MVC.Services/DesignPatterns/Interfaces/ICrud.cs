using EngineAir.Models;
using MVC.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.DesignPatterns.Interfaces
{
    public interface ICrud<T>
    {
        //public List<T> GetAll();
        //public T GetById(int id);
        public Task<AlertaEstado> Insert(T entity);
        //public void Update(T entity);
        //public void Delete(int id);
    }
}               