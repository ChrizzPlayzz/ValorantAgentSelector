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

    public class Agent : IComparable<Agent>
    {
        public Rollen Rolle { get; set; }
        public string Name { get; set; }

        public Agent(Rollen rolle, string name)
        {
            Rolle = rolle;
            Name = name;
        }

        public int CompareTo(Agent other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }


    public class Program
    {
        public static List<Agent> controllers, initiators, duelists, sentinels, allAgents;
        static void Main(string[] args)
        {
            Console.Write("Choose your language (EN/DE/FR): ");
            string language = Console.ReadLine();
            language = language.ToUpper();
            Console.Clear();


            LoadAgentsFromFile(out controllers, out initiators, out duelists, out sentinels, out allAgents);

            while (true)
            {
                SortLists();

                if (language == "EN")
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
                            Console.WriteLine("Your random " + initiators[r.Next(0, initiators.Count)].Rolle + " is: " + initiators[r.Next(0, initiators.Count)].Name);
                        }
                        else if (userinput == "duelist" || userinput == "d")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Your random " + duelists[r.Next(0, duelists.Count)].Rolle + " is: " + duelists[r.Next(0, duelists.Count)].Name);
                        }
                        else if (userinput == "sentinel" || userinput == "s")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Your random " + sentinels[r.Next(0, sentinels.Count)].Rolle + " is: " + sentinels[r.Next(0, sentinels.Count)].Name);
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
                    else if (userinp == "4")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please provide role and agent name");
                        Console.WriteLine("Roles: [C]ontroller, [I]nitiator, [D]uelist, [S]entinel");

                        string userRole = Console.ReadLine();
                        userRole = userRole.ToLower();

                        string userName = Console.ReadLine();

                        if (userRole == "controller" || userRole == "c")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Controller, userName, language);
                        }
                        else if (userRole == "initiator" || userRole == "i")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Initiator, userName, language);
                        }
                        else if (userRole == "duelist" || userRole == "d")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Duelist, userName, language);
                        }
                        else if (userRole == "sentinel" || userRole == "s")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Sentinel, userName, language);
                        }
                    }
                }
                else if (language == "DE")
                {
                    OverlayDE();

                    string userinp = Console.ReadLine();

                    if (userinp == "1")
                    {
                        Console.WriteLine();
                        Console.Write("Welche Rolle? ([C]ontroller, [I]nitiator, [D]uelist, [S]entinel): ");
                        string userinput = Console.ReadLine();
                        userinput = userinput.ToLower();

                        if (userinput == "controller" || userinput == "c")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Dein zufälliger " + controllers[r.Next(0, controllers.Count)].Rolle + " ist: " + controllers[r.Next(0, controllers.Count)].Name);
                        }
                        else if (userinput == "initiator" || userinput == "i")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Dein zufälliger " + initiators[r.Next(0, initiators.Count)].Rolle + " ist: " + initiators[r.Next(0, initiators.Count)].Name);
                        }
                        else if (userinput == "duelist" || userinput == "d")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Dein zufälliger " + duelists[r.Next(0, duelists.Count)].Rolle + " ist: " + duelists[r.Next(0, duelists.Count)].Name);
                        }
                        else if (userinput == "sentinel" || userinput == "s")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Dein zufälliger " + sentinels[r.Next(0, sentinels.Count)].Rolle + " ist: " + sentinels[r.Next(0, sentinels.Count)].Name);
                        }
                    }
                    else if (userinp == "2")
                    {
                        Random r = new Random();
                        Console.WriteLine();
                        Console.WriteLine("Dein zufälliger Agent ist: " + allAgents[r.Next(0, allAgents.Count)].Name);
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
                    else if (userinp == "4")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Bitte gebe die Rolle und Namen des Agenten an");
                        Console.WriteLine("Rollen: [C]ontroller, [I]nitiator, [D]uelist, [S]entinel");

                        string userRole = Console.ReadLine();
                        userRole = userRole.ToLower();

                        string userName = Console.ReadLine();

                        if (userRole == "controller" || userRole == "c")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Controller, userName, language);
                        }
                        else if (userRole == "initiator" || userRole == "i")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Initiator, userName, language);
                        }
                        else if (userRole == "duelist" || userRole == "d")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Duelist, userName, language);
                        }
                        else if (userRole == "sentinel" || userRole == "s")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Sentinel, userName, language);
                        }
                    }
                }
                else if (language == "FR")
                {
                    OverlayFR();

                    string userinp = Console.ReadLine();

                    if (userinp == "1")
                    {
                        Console.WriteLine();
                        Console.Write("Quel rôle? ([C]ontroller, [I]nitiator, [D]uelist, [S]entinel): ");
                        string userinput = Console.ReadLine();
                        userinput = userinput.ToLower();

                        if (userinput == "controller" || userinput == "c")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Votre " + controllers[r.Next(0, controllers.Count)].Rolle + " aléatoire est : " + controllers[r.Next(0, controllers.Count)].Name);
                        }
                        else if (userinput == "initiator" || userinput == "i")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Votre " + initiators[r.Next(0, initiators.Count)].Rolle + " aléatoire est: " + initiators[r.Next(0, initiators.Count)].Name);
                        }
                        else if (userinput == "duelist" || userinput == "d")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Votre " + duelists[r.Next(0, duelists.Count)].Rolle + " aléatoire est: " + duelists[r.Next(0, duelists.Count)].Name);
                        }
                        else if (userinput == "sentinel" || userinput == "s")
                        {
                            Random r = new Random();

                            Console.WriteLine();
                            Console.WriteLine("Votre " + sentinels[r.Next(0, sentinels.Count)].Rolle + " aléatoire est: " + sentinels[r.Next(0, sentinels.Count)].Name);
                        }
                    }
                    else if (userinp == "2")
                    {
                        Random r = new Random();
                        Console.WriteLine();
                        Console.WriteLine("Votre agent aléatoire est: " + allAgents[r.Next(0, allAgents.Count)].Name);
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
                    else if (userinp == "4")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Veuillez fournir le rôle et le nom de l'agent");
                        Console.WriteLine("Les rôles: [C]ontroller, [I]nitiator, [D]uelist, [S]entinel");

                        string userRole = Console.ReadLine();
                        userRole = userRole.ToLower();

                        string userName = Console.ReadLine();

                        if (userRole == "controller" || userRole == "c")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Controller, userName, language);
                        }
                        else if (userRole == "initiator" || userRole == "i")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Initiator, userName, language);
                        }
                        else if (userRole == "duelist" || userRole == "d")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Duelist, userName, language);
                        }
                        else if (userRole == "sentinel" || userRole == "s")
                        {
                            Console.WriteLine();
                            AddNewAgent(Rollen.Sentinel, userName, language);
                        }
                    }
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void SortLists()
        {
            controllers.Sort();
            initiators.Sort();
            duelists.Sort();
            sentinels.Sort();
            allAgents.Sort();
        }

        public static void AddNewAgent(Rollen rolle, string name, string language)
        {
            try
            {
                string filePath = "Agents.txt";

                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine($"{rolle} {name}");
                }

                if (language == "EN")
                {
                    Console.WriteLine("Agent successfully added and written to the file.");
                }
                else if (language == "DE")
                {
                    Console.WriteLine("Agent erfolgreich hinzugefügt und in die Datei geschrieben.");
                }
                else if (language == "FR")
                {
                    Console.WriteLine("Agent ajouté avec succès et écrit dans le fichier.");
                }
            }
            catch (Exception ex)
            {
                if (language == "EN")
                {
                    Console.WriteLine($"Error adding agent: {ex.Message}");
                }
                else if (language == "DE")
                {
                    Console.WriteLine($"Fehler beim Hinzufügen des Agenten: {ex.Message}");
                }
                else if (language == "FR")
                {
                    Console.WriteLine($"Erreur lors de l'ajout de l'agent: {ex.Message}");
                }
            }

            if (rolle == Rollen.Sentinel)
            {
                sentinels.Add(new Agent(rolle, name));
                allAgents.Add(new Agent(rolle, name));
            }
            else if (rolle == Rollen.Controller)
            {
                controllers.Add(new Agent(rolle, name));
                allAgents.Add(new Agent(rolle, name));
            }
            else if (rolle == Rollen.Duelist)
            {
                duelists.Add(new Agent(rolle, name));
                allAgents.Add(new Agent(rolle, name));
            }
            else if (rolle == Rollen.Initiator)
            {
                initiators.Add(new Agent(rolle, name));
                allAgents.Add(new Agent(rolle, name));
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
            Console.WriteLine("Add new Agent \t\t\t [4]");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Please select one \t\t [_]");
            Console.SetCursorPosition(34, 8);
        }
        private static void OverlayDE()
        {
            Console.WriteLine();
            Console.WriteLine("\t---RANDOM AGENT SELECTOR---");
            Console.WriteLine();
            Console.WriteLine("Random Agent nach Rolle auswählen\t [1]");
            Console.WriteLine("Full Random Agent auswählen\t\t [2]");
            Console.WriteLine("Alle Agents anzeigen \t\t\t [3]");
            Console.WriteLine("Neuen Agenten hinzufügen \t\t [4]");
            Console.WriteLine("--------------------------------------------");
            Console.Write("Deine Auswahl \t\t\t\t [_]");
            Console.SetCursorPosition(42, 8);
        }
        private static void OverlayFR()
        {
            Console.WriteLine();
            Console.WriteLine("\t---RANDOM AGENT SELECTOR---");
            Console.WriteLine();
            Console.WriteLine("Choisissez un agent aléatoire par rôle\t [1]");
            Console.WriteLine("Agent aléatoire complet\t\t\t [2]");
            Console.WriteLine("Afficher tous les agents \t\t [3]");
            Console.WriteLine("Ajouter un nouvel agent \t\t [4]");
            Console.WriteLine("--------------------------------------------");
            Console.Write("S'il vous plait sélectionner en un \t [_]");
            Console.SetCursorPosition(42, 8);
        }
    }


}
