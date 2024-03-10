using System;

namespace InventoryControl
{
    class Inventory
    {
        static List<Produto> estoque = new List<Produto>();
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("\nMenu de Controle de Estoque:");
            Console.WriteLine("\n1. Adicionar Produto");
            Console.WriteLine("2. Remover Produto");
            Console.WriteLine("3. Exibir Estoque");
            Console.WriteLine("4. Sair");
            Console.Write("\nEscolha uma opção: ");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.KeyChar)
            {
                case '1': AdicionarProduto(); break;
                case '2': RemoverProduto(); break;
                case '3': VerificarEstoque(); break;
                case '4': Environment.Exit(0); break;
            }

        }

        static void AdicionarProduto()
        {
            string? nomeDoProduto;
            Console.Clear();
            Console.WriteLine("Nome do produto para adicionar ao estoque");
            while (true)
            {
                nomeDoProduto = Console.ReadLine();

                if (nomeDoProduto?.Length > 3)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Digite um nome válido");
                }
            }


            int idProduto;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Informe o ID: ");
                string? ProdutoId = Console.ReadLine();
                if (int.TryParse(ProdutoId, out idProduto) && idProduto > 0)
                {
                    break;
                }

            }


            Produto produto = new Produto(idProduto, nomeDoProduto);

            Console.WriteLine($"\nProduto adicionado ao estoque '{produto.Nome}' ID: {idProduto}");
            Console.WriteLine("\nPressione 'P' Para adicionar outro Produto"); ;
            Console.WriteLine("Pressione 'E' para visualizar o estoque");
            Console.WriteLine("Pressione 'X' para remover um produto do estoque");
            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao Menu ");
            Console.WriteLine("Pressione ESC para sair do programa. ");

            Produto produto1 = new Produto(idProduto, nomeDoProduto);
            estoque.Add(produto);


            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);

            }
            else if (keyInfo.KeyChar == 'P' || keyInfo.KeyChar == 'p')
            {
                AdicionarProduto();

            }
            else if (keyInfo.KeyChar == 'E' || keyInfo.KeyChar == 'e')
            {
                VerificarEstoque();
            }
            else if (keyInfo.KeyChar == 'X' || keyInfo.KeyChar == 'x')
            {
                RemoverProduto();
            }
            else
            {
                Console.Clear();
                Menu();
            }



        }

        static void RemoverProduto()
        {
            Console.Clear();
            Console.WriteLine("Informe o ID do produto a ser removido:");

            string? produtoId = Console.ReadLine();
            int idProduto;

            if (int.TryParse(produtoId, out idProduto))
            {
                Produto produtoRemover = estoque.FirstOrDefault(p => p.Id == idProduto);

                if (produtoRemover.Id != 0)
                {
                    estoque.Remove(produtoRemover);
                    Console.WriteLine($"\nO Produto {produtoRemover.Nome} foi retirado do estoque");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado no estoque.");
                    RemoverProduto();
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Certifique-se de inserir um número inteiro.");
            }

            Console.WriteLine("\nPressione 'X' para remover outro produto");
            Console.WriteLine("Pressione 'E' para exibir o estoque ");
            Console.WriteLine("Pressione 'A' para adicionar outro produto");
            Console.WriteLine("Pressione qualquer tecla para fechar o programa.");


            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.KeyChar == 'X' || keyInfo.KeyChar == 'x')
            {
                RemoverProduto();

            }
            else if (keyInfo.KeyChar == 'E' || keyInfo.KeyChar == 'e')
            {
                VerificarEstoque();

            }
            else if (keyInfo.KeyChar == 'A' || keyInfo.KeyChar == 'a')
            {
                AdicionarProduto();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        static void VerificarEstoque()
        {
            Console.Clear();
            Console.WriteLine("\nEstoque atual:");

            int quantidadeProtudos = estoque.Count;

            if (estoque.Count > 0)
            {
                foreach (Produto produto in estoque)
                {

                    Console.WriteLine($"\nNome: \t{produto.Nome} \tID: \t{produto.Id}");
                }
            }
            else
            {
                Console.WriteLine("Estoque vazio");
            }

            Console.WriteLine("\nPressione 'P' para Adicionar outros produtos");
            Console.WriteLine("Pressione 'X' para remover um produto");
            Console.WriteLine("Pressione 'M' para voltar ao menu");
            Console.WriteLine("Pressione qualquer outra tecla para fechar o programa");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.KeyChar == 'p' || keyInfo.KeyChar == 'P')
            {
                AdicionarProduto();
            }
            else if (keyInfo.KeyChar == 'M' || keyInfo.KeyChar == 'm')
            {
                Menu();
            }
            else if (keyInfo.KeyChar == 'X' || keyInfo.KeyChar == 'x')
            {
                RemoverProduto();
            }
            else
            {
                Environment.Exit(0);
            }



        }

        struct Produto
        {
            public Produto(int id, string nome)
            {
                Id = id;
                Nome = nome;

            }

            public int Id { get; set; }
            public string Nome { get; set; }

        }
    }


}