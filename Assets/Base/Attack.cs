using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Attack : MonoBehaviour
{
    //[GetComponent] Collider collider;
    //[GetComponent] Rigidbody rigidbody;

    public GameObject attacker;
    public bool isIncludeMe = false;
    public float invincibleTime = 0f;
    public float damage = 0f;



    private void OnTriggerStay(Collider other)
    {
        Vector3 point = other.ClosestPoint(transform.position);
        Vector3 normal = (point - other.transform.position).normalized;

        //Sample
        IDamage iDamage = other.GetComponent<IDamage>();
        if (iDamage != null)
        {
            DamageMessage msg = new DamageMessage();
            msg.attacker = attacker;
            msg.attack = this;

            msg.isIncludeMe = isIncludeMe;
            msg.invincibleTime = invincibleTime;
            msg.damage = damage;

            msg.hitPoint = point;
            msg.hitNormal = normal;

            iDamage.GetDamage(msg);
        }
    }



}
