using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsTask
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; private set; }
        private List<string> history;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
            history = new List<string>();
            history.Add($"Team {name} created at {DateTime.Now}");
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            history.Add($"Player {player.Name} joined at {DateTime.Now}");
        }

        public void RemovePlayer(string playerName)
        {
            var player = Players.Find(p => p.Name == playerName);
            if (player != null)
            {
                Players.Remove(player);
                history.Add($"Player {player.Name} left at {DateTime.Now}");
            }
        }

        public void PrintHistory(ILog log)
        {
            foreach (var record in history)
            {
                log.Log(record);
            }
        }
    }
}
