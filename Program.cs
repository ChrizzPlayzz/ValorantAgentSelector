using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomValorantAgent
{
    public enum Rollen
    {
        Initiator,
        Duelist,
        Controller,
        Sentinel
    }
    public class Agent
    {
        public Rollen Rolle { get; set; }
        public string Name { get; set; }

        public Agent(Rollen rolle, string name)
        {
            Rolle = rolle;
            Name = name;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<Agent> controllers, initiators, duelists, sentinels, allAgents;
            LoadAgentsFromFile(out controllers, out initiators, out duelists, out sentinels, out allAgents);

            while (true)
            {
                OverlayEN();

                string userinp = Console.ReadLine();

                if (userinp == "1")
                {
                    Console.WriteLine();
                    Console.Write("Which role? ([C]ontroller, [I]nitiator, [D]uelist, [S]entinel): ");
                    string userinput = Console.ReadLine();
                    userinput = userinput.ToLower();

                    if (userinput == "controller" || userinput == "c")
                    {
                        Random r = new Random();

                        Console.WriteLine();
                        Console.WriteLine("Your random " + controllers[r.Next(0, controllers.Count)].Rolle + " is: " + controllers[r.Next(0, controllers.Count)].Name);
                    }
                    else if (userinput == "initiator" || userinput == "i")
                    {
                        Random r = new Random();

                        Console.WriteLine();
                        Console.WriteLine("Your random " + initiators[r.Next(0, controllers.Count)].Rolle + " is: " + initiators[r.Next(0, initiators.Count)].Name);
                    }
                    else if (userinput == "duelist" || userinput == "d")
                    {
                        Random r = new Random();

                        Console.WriteLine();
                        Console.WriteLine("Your random " + duelists[r.Next(0, controllers.Count)].Rolle + "  is: " + duelists[r.Next(0, duelists.Count)].Name);
                    }
                    else if (userinput == "sentinel" || userinput == "s")
                    {
                        Random r = new Random();

                        Console.WriteLine();
                        Console.WriteLine("Your random " + controllers[r.Next(0, controllers.Count)].Rolle + " is: " + sentinels[r.Next(0, sentinels.Count)].Name);
                    }
                }
                else if (userinp == "2")
                {
                    Random r = new Random();
                    Console.WriteLine();
                    Console.WriteLine("Your random Agent is: " + allAgents[r.Next(0, allAgents.Count)].Name);
                }
                else if (userinp == "3")
                {
                    Console.WriteLine();

                    Console.Write("Controllers: \t");

                    foreach (var agent in controllers)
                    {
                        if (agent == controllers[controllers.Count - 1])
                        {
                            Console.Write(agent.Name);
                        }
                        else
                        {
                            Console.Write(agent.Name + ", ");
                        }
                    }
                    Console.WriteLine();

                    Console.Write("Initiators: \t");

                    foreach (var agent in initiators)
                    {
                        if (agent == initiators[initiators.Count - 1])
                        {
                            Console.Write(agent.Name);
                        }
                        else
                        {
                            Console.Write(agent.Name + ", ");
                        }
                    }
                    Console.WriteLine();

                    Console.Write("Duelists: \t");

                    foreach (var agent in duelists)
                    {
                        if (agent == duelists[duelists.Count - 1])
                        {
                            Console.Write(agent.Name);
                        }
                        else
                        {
                            Console.Write(agent.Name + ", ");
                        }
                    }
                    Console.WriteLine();

                    Console.Write("Sentinels: \t");

                    foreach (var agent in sentinels)
                    {
                        if (agent == sentinels[sentinels.Count - 1])
                        {
                            Console.Write(agent.Name);
                        }
                        else
                        {
                            Console.Write(agent.Name + ", ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void LoadAgentsFromFile(out List<Agent> controllers, out List<Agent> initiators,
            out List<Agent> duelists, out List<Agent> sentinels, out List<Agent> allAgents)
        {
            // Definiere den Pfad zu deiner Textdatei mit den Agentendaten
            string filePath = "Agents.txt";

            // Initialisiere die Listen
            controllers = new List<Agent>();
            initiators = new List<Agent>();
            duelists = new List<Agent>();
            sentinels = new List<Agent>();
            allAgents = new List<Agent>();

            // Versuche, die Datei zu lesen
            try
            {
                string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

                // Durchlaufe jede Zeile der Datei und erstelle entsprechend die Agentenobjekte
                foreach (string line in lines)
                {
                    string[] agentData = line.Split(' '); // Trennzeichen anpassen, wenn nötig

                    if (agentData.Length == 2)
                    {
                        Rollen role;
                        if (Enum.TryParse(agentData[0], out role))
                        {
                            Agent newAgent = new Agent(role, agentData[1]);

                            // Füge den Agenten zur entsprechenden Liste hinzu
                            switch (role)
                            {
                                case Rollen.Controller:
                                    controllers.Add(newAgent);
                                    break;
                                case Rollen.Initiator:
                                    initiators.Add(newAgent);
                                    break;
                                case Rollen.Duelist:
                                    duelists.Add(newAgent);
                                    break;
                                case Rollen.Sentinel:
                                    sentinels.Add(newAgent);
                                    break;
                            }

                            // Füge den Agenten zur Gesamtliste aller Agenten hinzu
                            allAgents.Add(newAgent);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
                // Behandlung von Ausnahmen beim Lesen der Datei
            }
        }

        private static void OverlayEN()
        {
            Console.WriteLine();
            Console.WriteLine("\t---RANDOM AGENT SELECTOR---");
            Console.WriteLine();
            Console.WriteLine("Choose random Agent by role\t [1]");
            Console.WriteLine("Full Random Agent\t\t [2]");
            Console.WriteLine("Show all Agents \t\t [3]");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Please select one \t\t [_]");
            Console.SetCursorPosition(34, 7);
        }
    }


}
