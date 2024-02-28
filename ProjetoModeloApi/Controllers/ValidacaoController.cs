using Microsoft.AspNetCore.Mvc;
using ProjetoModelo.Domain.Interfaces.Services;
using System.Runtime.ConstrainedExecution;

namespace ProjetoModeloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacaoController : ControllerBase
    {
        /// <summary>
        /// Valida uma senha com base nos parametros 
        /// Nove ou mais caracteres
        /// - Ao menos 1 dígito
        /// - Ao mnos 1 letra minúscula
        /// - Ao menos 1 letra maiúscula
        /// - Ao menos 1 caractere especial
        /// - Considere como especial os seguintes caracteres: !@#$%^&*()-+
        /// - Não possuir caracteres repetidos dentro do conjunto
        /// - Espaços em branco não devem ser considerados como caracteres válidos
        /// </summary>
        /// <param name="senha">A senha que passará pela validação</param>
        /// <returns>JSON
        /// {
        ///     Sucesso: bool,
        ///     Erros: string[]
        /// }
        /// </returns>
        [HttpGet("ValidarSenha")]
        public async Task<IActionResult> ValidarSenha(string senha, [FromServices] IValidacaoService validacaoService)
            => Ok(await validacaoService.ValidarSenha(senha));
    }
}
