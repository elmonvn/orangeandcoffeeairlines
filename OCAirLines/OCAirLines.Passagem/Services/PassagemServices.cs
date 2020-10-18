using OCAirLines.Passagem.Services.Interfaces;
using OCAirLines.Passagem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.Passagem.Services
{
    public class PassagemServices : IPassagemServices
    {
        public Task<List<Lugar>> BuscaPorData(BuscaPassagem buscaPassagem)
        {
            throw new NotImplementedException();
        }

        public Task BuscaPorLocal()
        {
            throw new NotImplementedException();
        }

        Task<List<Lugar>> IPassagemServices.BuscaPorLocal()
        {
            throw new NotImplementedException();
        }
    }
}
