using System;

using System.Collections.Generic;

namespace Lanchonete

{

    public class Produto

    {

        public string Nome { get; set; }

        public decimal PrecoBase { get; set; }

        public decimal AcrescimoSalada { get; set; }

        public decimal AcrescimoMaionese { get; set; }

        public Produto(string nome, decimal precoBase, decimal acrescimoSalada, decimal acrescimoMaionese)

        {

            Nome = nome;

            PrecoBase = precoBase;

            AcrescimoSalada = acrescimoSalada;

            AcrescimoMaionese = acrescimoMaionese;

        }

    }

    public class Pedido

    {

        private List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)

        {

            produtos.Add(produto);

        }

        public decimal CalcularTotal()

        {

            decimal total = 0;

            foreach (var produto in produtos)

            {

                total += produto.PrecoBase + produto.AcrescimoSalada + produto.AcrescimoMaionese;

            }

            return total;

        }

    }

    class Program

    {

        static void Main(string[] args)

        {

            // Produtos disponiveis no cardapio

            Produto lancheCarne = new Produto("Lanche de carne", 20, 2, 1);

            Produto lancheFrango = new Produto("Lanche de frango", 16, 2, 1);

            Produto batataFrita = new Produto("Batata frita", 6, 0, 0);

            Produto refrigerante = new Produto("Refrigerante", 4, 0, 0);

            // Novo pedido

            Pedido pedido = new Pedido();

            // Pedido do cliente

            Console.WriteLine("Insira o nome do produto desejado (ou 'finalizar' para encerrar o pedido):");

            string nomeProduto = Console.ReadLine();

            while (nomeProduto.ToLower() != "finalizar")

            {

                // Verificamos o pedido do cliente

                Produto produto = null;

                if (nomeProduto.ToLower() == "lanche de carne")

                {

                    produto = lancheCarne;

                }

                if (nomeProduto.ToLower() == "lanche de frango")

                {

                    produto = lancheFrango;

                }

                else if (nomeProduto.ToLower() == "batata frita")

                {

                    produto = batataFrita;

                }

                else if (nomeProduto.ToLower() == "refrigerante")

                {

                    produto = refrigerante;

                }

                else

                {

                    Console.WriteLine("Produto invalido. Tente novamente.");

                }

                if (produto != null)

                {

                    // Opcoes de salada e maionese

                    Console.WriteLine("Deseja adicionar salada (s/n)?");

                    string opcaoSalada = Console.ReadLine();

                    if (opcaoSalada.ToLower() == "s")

                    {

                        produto.AcrescimoSalada = 2;

                    }

                    Console.WriteLine("Deseja adicionar maionese (s/n)?");

                    string opcaoMaionese = Console.ReadLine();

                    if (opcaoMaionese.ToLower() == "s")

                    {

                        produto.AcrescimoMaionese = 1;

                    }

                    // Produto no pedido

                    pedido.AdicionarProduto(produto);

                }

                // Pedido do usuario

                Console.WriteLine("Insira algum produto desejado. (ou 'finalizar' para finalizar o pedido.):");

                nomeProduto = Console.ReadLine();

            }

            // Valor total do pedido

            decimal total = pedido.CalcularTotal();

            Console.WriteLine("Total de: R$" + total.ToString("0.00"));

        }

    }

}