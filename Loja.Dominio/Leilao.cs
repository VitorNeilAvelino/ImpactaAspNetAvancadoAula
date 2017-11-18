using System.Collections.Generic;
using System.Linq;

namespace Loja.Dominio
{
    public class Leilao
    {
        public const decimal DescontoMaximo = 0.1m;
        public int Id { get; set; }
        public string NomeLote { get; set; }
        public decimal Preco { get; set; }
        public List<Produto> Produtos { get; set; }

        public List<string> Validar()
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(NomeLote?.Trim()))// || 
                //string.IsNullOrWhiteSpace(NomeLote))
            {
                erros.Add("Nome do Lote é obrigatório.");
            }

            var somaProdutos = Produtos.Sum(p => p.Preco);

            if (somaProdutos - Preco > somaProdutos * DescontoMaximo)
            {
                erros.Add("Desconto máximo excedido.");
            }

            return erros;
        }
    }
}