using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public interface IVehiculosService
    {
        Task GetVehiculosName(int idVehiculos, int idVendedores);
    }
}
