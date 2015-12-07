using UnityEngine;
using System.Collections.Generic;

public class ScoreManager {

    Dictionary<Character, int> scores;

	public ScoreManager(List<Character> players)
    {
        foreach(var player in players)
        {
            player.CharacterDeath += addScore;
        }
    }

    private void addScore(Character player)
    {
        scores[player] += 1;
    }


}
