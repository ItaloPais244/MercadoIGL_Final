using MercadoIGL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadoIGL.Controllers
{
    [Authorize]
    public class DadosController : Controller
    {
        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Gerar()
        {
            contexto.Database.ExecuteSqlRaw("delete from clientes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('clientes', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Italo Pais Diniz Costa", "Gabriel Policant", "Alecsandro Junior da Silva", "Gabriel Laiola Gonçalves", "Adriano de Mello Ferreira" };
            string[] vNomeFem = { "Fabiana Aparecida Fiuza", "Ana Clara Teodoro de Oliveira", "Maria Vitoria Sofia", "Julia Costa Neto", "Giovanna Nascimento da Silva" };
            string[] vEndereco = { "Assis, Rua Cornelio Procopio, 269", "Candido Mota, Rua João de Barros, 450", "Taruma, Rua Pedro La Selva, 35", "Paraguaçu Paulista, Rua Dom Lazaro Neves, 1654", "Palmital, Rua Lima de Souza, 421", "Pedrinhas Paulista, Rua Felipe dos Santos, 781", "Maracai, Av. da Juventude, 655", "Cruzalia, Rua Vinicius Roberto, 1247" };

            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente();

                cliente.cpf = randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(10, 99);
                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.endereco = vEndereco[randNum.Next() % 8];
                contexto.Clientes.Add(cliente);
            }

            contexto.Database.ExecuteSqlRaw("delete from funcionarios");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('funcionarios', RESEED, 0)");

            string[] vNomeFuncionario = { "Ricardo Ribeiro da Silva","Gustavo José dos Santos","Rafael Henrique Soares","Arthur Henrique Soares","Kaue Felipe Santos da Silva","Natacia Pratta"};
            string[] vCargo = { "Vendedor", "Gerente", "Estoquista" };

            for (int i = 0; i < 6; i++)
            {
                Funcionario funcionario = new Funcionario();

                funcionario.cpf = randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(10, 99);
                funcionario.nome = vNomeFuncionario[i];
                funcionario.cargo = vCargo[randNum.Next() % 3];
                contexto.Funcionarios.Add(funcionario);
            }

            contexto.Database.ExecuteSqlRaw("delete from fornecedores");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('fornecedores', RESEED, 0)");

            string[] vEmpresa = { "AC Comercio LTDA", "F&T Ferreira e Tangeli", "Electrolux Do Brasil S.A", "Samsung Eletrônica Da Amazônia LTDA", "Mococa S/A Produtos Alimenticios", "Pepsico do Brasil LTDA", "Grupo Boticário LTDA", "Coca Cola Indústrias LTDA", "LG Electronics do Brasil LTDA", "Colgate-Palmolive Comercial LTDA" };
            string[] vEnderecoEmpresa = { "Av. Tocantins, 54 - V. Jd. Rio Claro - Jataí - GO", "Rua dos Carijós, 942 - Centro - Belo Horizonte - MG", "Rua Frederico Moura, 149 - Cidade Nova - Franca - SP", "Rua Barão da Vitória, 427 - Casa Grande - Diadema - SP", "Rua Domingos Olímpio, 33 - Centro - Sobral - CE", "Av Rio Branco, 747 - Centro - Rio de Janeiro - RJ", "Rua Cristiano Olsen, 541 - Jd. Sumaré - Araçatuba - SP", "Rua Paracatu, 421 - Pq. Imperial - São Paulo - SP", "Rod. Raposo Tavares, 322KM - Lageadinho - Cotia - SP", "Trav. Antônio Ferrira, 378 - Igrejinha - Capanema - PA" };

            for (int i = 0; i < 10; i++)
            {
                Fornecedor fornecedor = new Fornecedor();

                fornecedor.cnpj = randNum.Next(10, 99).ToString() + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "/000" + randNum.Next(1,9).ToString() + "-" + randNum.Next(10, 99);
                fornecedor.empresa = vEmpresa[i];
                fornecedor.telefone = "(" + randNum.Next(10, 99).ToString() + ") 99" + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1000, 9999);
                fornecedor.endereco = vEnderecoEmpresa[i];

                contexto.Fornecedores.Add(fornecedor);
            }

            contexto.SaveChanges();

            return View();
        }
    }
}
