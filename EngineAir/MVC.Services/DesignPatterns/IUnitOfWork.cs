using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.DesignPatterns
{
    public interface IUnitOfWork : IDisposable
    {

        public Task Save();
    }
}
