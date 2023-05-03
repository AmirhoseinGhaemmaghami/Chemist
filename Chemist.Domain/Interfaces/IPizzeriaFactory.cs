using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chemist.Domain.Models;

namespace Chemist.Domain.Interfaces
{
    public interface IPizzeriaFactory
    {
        Pizzeria CreatePizzeria(string location);
    }
}
