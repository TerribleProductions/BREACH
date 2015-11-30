using UnityEngine;
using System.Collections;

public class ShotgunBlastEffect : AbilityEffect {

    private float maxRangeInTime;
    private float timer;

    void Awake()
    {
        maxRangeInTime = 1f;
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= maxRangeInTime)
        {
            Destroy(gameObject);
        }
    }

}
