using ProjetoModelo.Domain.Models;

namespace ProjetoModelo.Domain.Interfaces.Services
{
    public interface IValidacaoService 
    {
        public Task<ValidacaoModel> ValidarSenha(string senha);
    }
}
