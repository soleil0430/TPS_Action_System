using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility 
{
    public static Vector3 GetHitPoint(Collider me, Collider other) => (other.ClosestPoint(me.transform.position));
    public static Vector3 GetHitNormal(Collider me, Collider other) => (GetHitPoint(me, other));

}
