using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace GameMessage
{
    public struct DamageMessage
    {
        public GameObject attacker;
        public Attack attack;

        public bool isIncludeMe;
        public float invincibleTime;
        public float damage;

        public Vector3 hitPoint;
        public Vector3 hitNormal;
    }

    public interface IDamage
    {
        void GetDamage(DamageMessage msg);
    }
}