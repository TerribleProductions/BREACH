using UnityEngine;
using System.Collections.Generic;

public class ScoreManager {

    Dictionary<Character, int> scores;

	public ScoreManager(List<Character> players)
    {
        scores = new Dictionary<Character, int>();
        foreach(var player in players)
        {
            player.CharacterDeath += addScore;
            scores[player] = 0;
        }
    }

    private void addScore(Character player)
    {
        scores[player] += 1;
        Debug.Log(scores[player]);
    }


}
