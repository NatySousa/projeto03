using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Projeto03.Repositories
{
   public class FornecedorRepository
    {
        public void ExportarTxt(Fornecedor fornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{fornecedor.Id }.txt";

            using (var streamWriter = new StreamWriter(path)) 
            {
                streamWriter.WriteLine("Id do fornecedor: " + fornecedor.Id);
                streamWriter.WriteLine("Nome do fornecedor: " + fornecedor.Nome);
                streamWriter.WriteLine("Cnpj do fornecedor: " + fornecedor.Cnpj);

                foreach (var item in fornecedor.Produtos)

                {
                    streamWriter.WriteLine("\nProduto:");
                    streamWriter.WriteLine("Id do Produto: " + item.Id);
                    streamWriter.WriteLine("Nome do Produto: " + item.Nome);
                    streamWriter.WriteLine("Preço do Produto: " + item.Preco);
                    streamWriter.WriteLine("Quantidade do Produto: " + item.Quantidade);

                }
            }
        }

        public void ExportarXml(Fornecedor fornecedor) 
        {
            var path = $"c:\\temp\\fornecedor_{fornecedor.Id}.xml";

            var xmlSerializer = new XmlSerializer(fornecedor.GetType());

            using (var streamWriter = new StreamWriter(path)) 
            {
                xmlSerializer.Serialize(streamWriter, fornecedor);
            }
        }

        public void ExportarJson(Fornecedor fornecedor)
        {
            var path = $"c:\\temp\\fornecedor_{fornecedor.Id}.json";

            var json = JsonConvert.SerializeObject(fornecedor, Formatting.Indented);

            using (var streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(json);
            }

        }

        
    }
}
