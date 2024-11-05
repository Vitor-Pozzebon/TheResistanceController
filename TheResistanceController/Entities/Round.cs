using System;

namespace TheResistanceController.Entities
{
    internal class Round
    {
        public int Number { get; set; }
        public string Leader { get; set; }
        public List<string> Crew { get; set; } = new List<string>();
        public int Approvals { get; set; }
        public int Reproaches { get; set; }
        public int successVotes { get; set; }
        public int failureVotes { get; set; }

        public Round(int number, string leader, int approvals, int reproaches, int successVotes, int failureVotes)
        {
            Number = number;
            Leader = leader;
            Approvals = approvals;
            Reproaches = reproaches;
            this.successVotes = successVotes;
            this.failureVotes = failureVotes;
        }

        public Round() { }

        public Round createRound()
        {
            Console.Clear();
            Round newRound = new Round();
            
            Console.Write("Digite o número da rodada: ");
            newRound.Number = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do líder da rodada: ");
            newRound.Leader = (Console.ReadLine());
            Console.Write("Digite o número de escolhidos: ");
            int crewNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < crewNumber; i++)
            {
                Console.Write($"Digite o nome do escolhido {i + 1}: ");
                string name = Console.ReadLine();
                newRound.Crew.Add(name);
            }
            Console.Write("Digite o número de votos aprovados: ");
            newRound.Approvals = int.Parse(Console.ReadLine());
            Console.Write("Digite o número de votos reprovados: ");
            newRound.Reproaches = int.Parse(Console.ReadLine());
            if (newRound.Approvals > newRound.Reproaches)
            {
                Console.Write("Digite o número de sucessos: ");
                newRound.successVotes = int.Parse(Console.ReadLine());
                Console.Write("Digite o número de fracassos: ");
                newRound.failureVotes = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("RODADA INSERIDA COM SUCESSO!!!");
            Thread.Sleep(1000);
            return newRound;
        }

        public void seeRounds(List<Round> rounds)
        {
            Console.Clear();
            if(rounds.Count == 0)
            {
                Console.WriteLine("Nenhuma rodada cadastrada no momento.");
            }
            foreach (Round r in rounds)
            {
                Console.WriteLine(r.ToString());
            }
            Console.WriteLine("\nAperte Enter para voltar.");
            Console.ReadLine();
        }

        public override string ToString()
        {
            string crewFormated = string.Join(", ", Crew);
            if (Approvals > Reproaches)
            {
                return "-----------------------------------" +
                $"\nNÚMERO DA RODADA: {Number}" +
                $"\nLÍDER DA RODADA: {Leader}" +
                $"\nESCOLHIDOS: {crewFormated}" +
                $"\nVOTOS APROVADOS: {Approvals}" +
                $"\nVOTOS REPROVADOS: {Reproaches}" +
                $"\nVOTOS DE SUCESSO: {successVotes}" +
                $"\nVOTOS DE FRACASSO: {failureVotes}" +
                "\n---------------------------------------" +
                "\nMISSÃO CONCLUÍDA E APROVADA!!!" +
                "\n---------------------------------------";
            }
            else
            {
                return "\n-----------------------------------" +
                $"\nNÚMERO DA RODADA: {Number}" +
                $"\nLÍDER DA RODADA: {Leader}" +
                $"\nESCOLHIDOS: {crewFormated}" +
                $"\nVOTOS APROVADOS: {Approvals}" +
                $"\nVOTOS REPROVADOS: {Reproaches}" +
                "\n-----------------------------------------------" +
                "\nMISSÃO NÃO INICIADA (REPROVADA)!!!" +
                "\n-----------------------------------------------";
            }
        }
    }
}
