using ProjetoModelo.Domain.Interfaces.Services;
using ProjetoModelo.Domain.Models;

namespace ProjetoModelo.Services.AppServices
{
    public class ValidacaoService : IValidacaoService
    {
        public async Task<ValidacaoModel> ValidarSenha(string senha)
        {
            try
            {
                //determina os caracteres especiais para a validacao
                char[] caracteresEspeciais = ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+'];

                //inicializa a lista de erros
                List<string> lstErros = new List<string>();

                //remove os espaços em branco da string
                if (senha.Contains(" "))
                {
                    lstErros.Add("A senha não deve conter espaços em branco.");
                }

                //valida tamanho da senha, devendo ser maior que 1, e  maior que 9
                if (senha.Length < 1 || senha.Length < 9)
                {
                    lstErros.Add("O tamanho da senha deve ser entre 1 e 9 caracteres.");
                }

                //roda os caracteres da string e valida se contem 1 maiusculo
                if (!senha.Any(c => char.IsUpper(c)))
                {
                    lstErros.Add("A senha deve conter ao menos 1 caracter maiúsculo.");
                }

                //roda os caracteres da string e valida se contem 1 minusculo
                if (!senha.Any(c => char.IsLower(c)))
                {
                    lstErros.Add("A senha deve conter ao menos 1 caracter minúsculo.");
                }

                //roda os caracteres da string e valida se contem 1 dos caracteres especiais
                if (senha.Where(c => caracteresEspeciais.Contains(c)).ToList().Count == 0)
                {
                    lstErros.Add("A senha deve conter ao menos 1 caracter especial '!@#$%^&*()-+'.");
                }

                //cria o dictonary para armazenar <caracter, contagem>
                Dictionary<char, int> contagemRepetidos = new Dictionary<char, int>();

                //roda os registros do dictionary
                foreach (char c in senha)
                {
                    //se o caractere ja está na lista, adiciona +1 ao contador
                    if (contagemRepetidos.ContainsKey(c))
                    {
                        contagemRepetidos[c]++;
                    }
                    //se o caractere não está na lista, adiciona à lista com contador = 1
                    else
                    {
                        contagemRepetidos[c] = 1;
                    }
                }

                //roda o dictionary verificando se algum tem contagem > 1
                if (contagemRepetidos.Any(c => c.Value > 1))
                {
                    lstErros.Add("A senha não pode conter caracteres repetidos.");
                }

                return new ValidacaoModel
                {
                    Sucesso = lstErros.Count == 0,
                    Erros = lstErros
                };
            }
            catch (Exception ex)
            {
                return new ValidacaoModel
                {
                    Sucesso = false,
                    Erros = new List<string> { $"Houve um erro ao validar a senha, {ex.Message}" }
                };
            }
        }
    }
}
