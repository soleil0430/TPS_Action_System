using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace GameMessage
{
    [System.Serializable]
    public class DamageMessage : BoundMessage
    {
        public bool isIncludeMe;
        public float invincibleTime;
        public float damage;

        public DamageMessage(GameObject _receiveCreator,
                            GameObject _sender, GameObject _receiver,
                            Vector3 _hitPoint, Vector3 _hitNormal,
                            bool _isIncludeMe, float _invincibleTime, float _damage)
            : base(_receiveCreator, _sender, _receiver, _hitPoint, _hitNormal)
        {
            isIncludeMe = _isIncludeMe;
            invincibleTime = _invincibleTime;
            damage = _damage;
        }

        public override object Clone()
        {
            DamageMessage msg = new DamageMessage(receiveCreator,
                                                  sender, receiver,
                                                  hitPoint, hitNormal,
                                                  isIncludeMe, invincibleTime, damage);

            return msg;
        }
    }

    public interface IDamage
    {
        void GetDamage(DamageMessage msg);
    }
}