using OCAirLines.Passagem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.Services.Interfaces
{
    public interface IPassagemServices
    {
        Task<List<Lugar>> BuscaPorLocal();
        Task<List<Lugar>> BuscaPorData(BuscaPassagem buscaPassagem);
    }
}
