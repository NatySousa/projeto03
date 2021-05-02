using System;
using Projeto03.Entities;
using System.Collections.Generic;
using Projeto03.Repositories;

namespace Projeto03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCONTROLE DE FORNECEDORES E PRODUTOS\n");

            var fornecedor = new Fornecedor();
            fornecedor.Produtos = new List<Produto>();

            fornecedor.Id = Guid.NewGuid();

            Console.WriteLine("Informe o nome do fornecedor:");
            fornecedor.Nome = Console.ReadLine();

            Console.WriteLine("Informe o cnpj do fornecedor:");
            fornecedor.Cnpj = Console.ReadLine();

            Console.WriteLine("Informe a quantidade de produtos:");
            var qtd = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine("\nAdicione o produto do fornecedor:\n");
              
                var produto = new Produto();
                produto.Id = Guid.NewGuid();

                Console.WriteLine("Informe o nome do produto: ");
                produto.Nome = Console.ReadLine();

                Console.WriteLine("Informe o Preco do produto: ");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Informe a quantidade do produto: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                fornecedor.Produtos.Add(produto);

                Console.WriteLine("\nProduto adicionado no fornecedor com sucesso.");

            }

            try
            {
                var fornecedorRepository = new FornecedorRepository();

                fornecedorRepository.ExportarTxt(fornecedor);
                fornecedorRepository.ExportarXml(fornecedor);
                fornecedorRepository.ExportarJson(fornecedor);
 


                Console.WriteLine("\nDados gravados com sucesso! ");

            }
            catch (Exception e) 
            {
                Console.WriteLine("\nOcorreu um erro: " + e.Message);
            }




            Console.ReadKey();

        }
    }
}
