using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace GameMessage
{


    public struct DamageMessage
    {
        public GameObject actor;
        public SendBound sendBound;
        
        public Vector3 hitPoint;
        public Vector3 hitNormal;

        public bool isIncludeMe;
        public float invincibleTime;
        public float damage;
    }

    public interface IDamage
    {
        void GetDamage(DamageMessage msg);
    }
}