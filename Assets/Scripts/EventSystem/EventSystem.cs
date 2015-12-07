using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EventSystem : MonoBehaviour {

    private SpawnManager spawnManager;
    private ScoreManager scoreManager;

    public GameObject breacher;
    public GameObject sniper;
    // Use this for initialization
    void Awake () {
        var ps = new List<GameObject>();
        ps.Add(breacher);
        ps.Add(sniper);
        spawnManager = new SpawnManager(ps);
        //scoreManager = new ScoreManager(spawnManager.players.Select(p => { return p.GetComponent<Character>(); }) as List<Character>);
	}
	
}
