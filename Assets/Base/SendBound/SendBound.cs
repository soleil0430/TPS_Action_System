using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class SendBound : MonoBehaviour
{
    public GameObject actor;

    protected Vector3 GetHitPoint(Collider other) => (other.ClosestPoint(transform.position));
    protected Vector3 GetHitNormal(Collider other) => ((GetHitPoint(other) - other.transform.position).normalized);
}
