using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface ICrud
    {
        public bool Insert(object myObject);
    }
}
