﻿using EQTool.ViewModels;
using System.Diagnostics;

namespace EQTool.Services.Spells.Log
{
    public class LevelLogParse
    {
        private readonly ActivePlayer activePlayer;
        private readonly string YouHaveGainedALevel = "You have gained a level! Welcome to level";

        public LevelLogParse(ActivePlayer activePlayer)
        {
            this.activePlayer = activePlayer;
        }

        public void MatchLevel(string linelog)
        {
            var message = linelog.Substring(27);
            Debug.WriteLine($"LevelLogParse: " + message);
            if (message.StartsWith(YouHaveGainedALevel))
            {
                var levelstring = message.Replace(YouHaveGainedALevel, string.Empty).Trim().TrimEnd('!');
                if (int.TryParse(levelstring, out var level))
                {
                    var player = activePlayer.Player;
                    if (player != null)
                    {
                        player.Level = level;
                    }
                }
            }
        }
    }
}
