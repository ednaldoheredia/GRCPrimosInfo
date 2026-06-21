using Clientes.Dominio.Model;
using GRC.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRC.Dominio.Interfaces
{
    public interface IClienteService: IDisposable
    {
        Task<bool> Adicionar(Cliente cliente);
    }
}
