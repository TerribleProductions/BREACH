using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreManager {

	public Text playerOneScore;
	public Text playerTwoScore;

    Dictionary<Character, int> scores;

	public ScoreManager(List<Character> players, Text p1, Text p2)
    {
        scores = new Dictionary<Character, int>();
        foreach(var player in players)
        {
            player.CharacterDeath += addScore;
            scores[player] = 0;
        }

		playerOneScore = p1;
		playerTwoScore = p2;
    }

    private void addScore(Character player)
    {
        scores[player] += 1;

		string score = "" + scores[player];

		if (player.playerNumber == 2) {
			playerOneScore.text = score;
		} else if (player.playerNumber == 1) {
			playerTwoScore.text = score;
		}
    }


}
