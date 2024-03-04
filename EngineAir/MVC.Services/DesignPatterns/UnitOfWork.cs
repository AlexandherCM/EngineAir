using EngineAir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.DesignPatterns
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context; 
        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public async Task Save()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
