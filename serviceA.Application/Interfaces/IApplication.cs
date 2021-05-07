using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace serviceA.Application.Interfaces
{
    public interface IApplication
    {
        Task<string> GetResponse();
    }
}
