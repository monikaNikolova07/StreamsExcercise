namespace StreamsTask
{

    public class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Enter a command:");
                string command = Console.ReadLine();

                string[] parts = command.Split(" ");
                switch (parts[0])
                {
                    case "create_team":
                        CreateTeam(parts, teams);
                        break;
                    case "create_player":
                        CreatePlayer(parts);
                        break;
                    case "add_player":
                        AddPlayer(parts, teams);
                        break;
                    case "remove_player":
                        RemovePlayer(parts, teams);
                        break;
                    case "exit":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        private static void CreateTeam(string[] parts, Dictionary<string, Team> teams)
        {
            string teamName = parts[1];
            if (!teams.ContainsKey(teamName))
            {
                teams[teamName] = new Team(teamName);
                Console.WriteLine($"Team '{teamName}' created.");
            }
            else
            {
                Console.WriteLine("Team already exists.");
            }
        }

        private static void CreatePlayer(string[] parts)
        {
            string playerName = parts[1];
            string position = parts[2];
            var player = new Player(playerName, position);
            Console.WriteLine($"Player '{playerName}' created at position '{position}'.");
        }

        private static void AddPlayer(string[] parts, Dictionary<string, Team> teams)
        {
            string teamName = parts[1];
            string playerName = parts[2];
            string position = parts[3];

            if (teams.ContainsKey(teamName))
            {
                var player = new Player(playerName, position);
                teams[teamName].AddPlayer(player);
                Console.WriteLine($"Player '{playerName}' added to team '{teamName}'.");
            }
            else
            {
                Console.WriteLine("Team not found.");
            }
        }

        private static void RemovePlayer(string[] parts, Dictionary<string, Team> teams)
        {
            string teamName = parts[1];
            string playerName = parts[2];

            if (teams.ContainsKey(teamName))
            {
                teams[teamName].RemovePlayer(playerName);
                Console.WriteLine($"Player '{playerName}' removed from team '{teamName}'.");
            }
            else
            {
                Console.WriteLine("Team not found.");
            }
        }
       

    }
}

    


