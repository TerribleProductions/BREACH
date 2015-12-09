using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class AbilityHelper {

	
    public static IEnumerable<T> objectsInArea<T>(Vector3 pos, float radius)
    {
        return from collider in Physics.OverlapSphere(pos, radius)
               select collider.gameObject into go
               select go.GetComponent<T>() into comp
               where comp != null
               select comp;
    }

    public static IEnumerable<T> objectsInAreaExceptOwner<T>(Vector3 pos, float radius, int playerNumber) 
    {
        return from c in objectsInArea<Character>(pos, radius)
               where c.playerNumber != playerNumber
               select c.gameObject.GetComponent<T>();
    }




}
