using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class EventSystem : MonoBehaviour {

    private SpawnManager spawnManager;
    private ScoreManager scoreManager;

	public Text playerOneScore;
	public Text playerTwoScore;

    public GameObject breacher;
    public GameObject sniper;

    // Use this for initialization
    void Awake () {
        var ps = new List<GameObject>();
        ps.Add(breacher);
        ps.Add(sniper);
        spawnManager = new SpawnManager(ps);

        var cs = new List<Character>(ps.Select(x =>
        {
            return x.GetComponent<Character>();
        }));
        foreach (var p in cs)
        {
            Debug.Log(p.playerNumber);
        }
        scoreManager = new ScoreManager(cs, playerOneScore, playerTwoScore);
	}	
}
