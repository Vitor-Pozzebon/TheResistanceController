using System;
using TheResistanceController.Entities;

namespace TheResistanceController
{
    class Program
    {
        public static void seePlayers(List<string> p)
        {
            Console.Clear();

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("JOGADORES ATIVOS: ");
            foreach (string player in p)
            {
                Console.WriteLine(player);
            }
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("Pressione Enter para voltar...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // Lista de jogadores
            List<string> players = new List<string>();

            // Lista de rouds
            List<Round> rounds = new List<Round>();

            // Número de jogadores
            Console.Write("Digite o número de jogadores: ");
            int numPlayers = int.Parse(Console.ReadLine());

            if (numPlayers <= 0 || numPlayers > 10)
            {
                Console.WriteLine("\n----------------------------------------------------------------------");
                while (numPlayers <= 0 || numPlayers > 10)
                {
                    Console.Write("Número de jogadores inválido. Digite outro número: ");
                    numPlayers = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n----------------------------------------------------------------------");

            // Coletando os nomes dos jogadores
            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"\nDigite o nome do jogador {i + 1}: ");
                string name = Console.ReadLine();
                players.Add(name);
                Console.WriteLine("JOGADOR ADICIONADO COM SUCESSO!!!");
            }

            Console.WriteLine("\n----------------------------------------------------------------------");
            Console.WriteLine("\nJOGADORES ATIVOS:");
            foreach (string name in players)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n----------------------------------------------------------------------");

            // Limpando o console
            Thread.Sleep(3000);

            // Criando e usando o menu de opções
            Round round = new Round();      // Instanciamento da classe Round
            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("MENU DE OPÇÕES - THE RESISTANCE");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO: ");
                Console.WriteLine("1. VER RODADAS ANTERIORES");
                Console.WriteLine("2. VER JOGADORES ATIVOS");
                Console.WriteLine("3. CADASTRAR UMA NOVA RODADA");
                Console.WriteLine("0. SAIR DO CONTROLADOR DE THE RESISTANCE");
                Console.Write("\nOPÇÃO: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1: 
                        round.seeRounds(rounds);
                        break;

                    case 2:
                        seePlayers(players);
                        break;

                    case 3: 
                        Round newRound = round.createRound();
                        rounds.Add(newRound);
                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("SAINDO DO CONTROLADOR...");
                        Thread.Sleep(1000);
                        break;

                    default:
                        Console.WriteLine("-------------------------------------------------");
                        Console.Write("OPÇÃO INVÁLIDA. DIGITE UMA NOVA OPÇÃO: ");
                        op = int.Parse(Console.ReadLine());
                        break;
                }
            }
        }
    }
}