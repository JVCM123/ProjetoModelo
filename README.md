# Projeto Modelo

Uma Web API RESTFul com método para validação de uma senha com base nos parametros pré-definidos.

## Especificação

O projeto foi estruturado com alguns conceitos de arquitetura/organização de API's, como:

- Implementação de Interfaces Uniformes;
- Injeção de Dependências entre os Projetos;
- Utilização de Camada de Serviços para Processamento de Dados, utilizando a Controller da API apenas como Endpoint;
- Utilização de Camada de Domínio para centralização de Classes (Models);

## Utilização

- Através do EndPoint "ValidarSenha", é recebido uma string que será a senha a ser validada;
- A Controller da API faz uma chamada para a Camada de Serviço, através da classe "ValidacaoServices", que implementa uma Interface;
- Dentro da Camada de Serviços, é onde ocorrerá, de fato, a validação da senha com os parâmetros:
1. Nove ou mais caracteres
2. Ao menos 1 dígito
3. Ao menos 1 letra minúscula
4. Ao menos 1 letra maiúscula
5. Ao menos 1 caractere especial
6. Considere como especial os seguintes caracteres: !@#$%^&*()-+
7. Não possuir caracteres repetidos dentro do conjunto
8. Espaços em branco não devem ser considerados como caracteres válidos

- O retorno esperado da API consiste em um JSON com formato:
```json
{
    Sucesso: booleano,
    Erros: string[]
}
```
Caso a senha tenha passado com sucesso pela validação, o campo "Sucesso" terá "true" como valor, e o campo "Erros" como "[]". <br> Caso a validação encontre alguma discrepância em relação à senha, "Sucesso" será "false", e "Erros" contará com uma lista de motivos para o bloqueio.
