using UnityEngine;
using System.Collections;
using System;

public abstract class MeleeAbility : Ability {

    public float area;
    public Vector3 range;


    public Collider[] GetCollidersInRange(float range, Vector3 offset)
    {
        //Ignore own player.
        int layerMask = ~(1 << gameObject.layer);
        return Physics.OverlapSphere(transform.position + offset, range, layerMask);
    }

    /// <summary>
    /// Returns the unit closest within some range and offset of self
    /// </summary>
    /// <param name="range"></param>
    /// <returns></returns>
    public GameObject GetClosestUnitInRange(float range, Vector3 offset)
    {
        var colliders = GetCollidersInRange(range, offset);
        GameObject closestUnit = null;
        float shortestDistanceSqr = Mathf.Infinity;
        foreach (var collider in colliders)
        {
            Debug.Log(shortestDistanceSqr);
            var distanceToSelfSqr = (collider.transform.position - transform.position).sqrMagnitude;
            if (distanceToSelfSqr < shortestDistanceSqr)
            {
                shortestDistanceSqr = distanceToSelfSqr;
                closestUnit = collider.gameObject;
            }
        }
        return closestUnit;
    }

}
