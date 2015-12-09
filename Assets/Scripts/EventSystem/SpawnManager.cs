using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{

    public List<GameObject> players;

    string breacherResourcePath = "";
    string sniperResourcePath = "";


    public SpawnManager(List<GameObject> ps)
    {
        //var breacherObject = instantiateCharacter(breacherResourcePath);
        //var sniperObject = instantiateCharacter(sniperResourcePath);

        players = ps;

        foreach(var player in players)
        {
            Character c = player.GetComponent<Character>();
            c.CharacterDeath += spawnCharacter;
        }
        
    }

    private void spawnCharacter(Character c)
    {
        Debug.Log("spawning char");
        c.transform.position = c.initialPosition;
        c.RespawnCharacter();
    }


    private GameObject instantiateCharacter(string resourcePath)
    {
        var prefabObject = (Resources.Load(resourcePath) as GameObject);
        return Instantiate(prefabObject, initialSpawnPos, Quaternion.identity) as GameObject;
    }

}

