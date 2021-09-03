using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameMessage
{
    public enum EAttackDirection
    {
        Forward,
        
        Direction,
        FromCenter,
    }

    [System.Serializable]
    public struct AttackDirection
    {
        public EAttackDirection directionType;

        public Transform behaviour;
        public Vector3 direction;

        private Vector3 GetDirection()
        {
            switch (directionType)
            {
                case EAttackDirection.Forward:
                    return behaviour.forward;
                case EAttackDirection.Direction:
                    return direction;
                default:
                    return Vector3.zero;
            }
        }

        public Vector3 GetDirection(Transform me)
        {
            switch (directionType)
            {
                case EAttackDirection.FromCenter:
                    return me.position - behaviour.forward;
                default:
                    return GetDirection();
            }
        }
    }


    [System.Serializable]
    public class BoundMessage : ICloneable
    {
        public GameObject receiveCreator;

        public GameObject sender;
        public GameObject receiver;

        public Vector3 hitPoint;
        public Vector3 hitNormal;

        public AttackDirection attackDirection;

        public BoundMessage(GameObject _receiveCreator,
                            GameObject _sender, GameObject _receiver,
                            Vector3 _hitPoint, Vector3 _hitNormal,
                            AttackDirection _attackDirection)
        {
            receiveCreator = _receiveCreator;

            sender = _sender;
            receiver = _receiver;

            hitPoint = _hitPoint;
            hitNormal = _hitNormal;

            attackDirection = _attackDirection;
        }

        public virtual object Clone()
        {
            BoundMessage msg = new BoundMessage(receiveCreator,
                                                sender, receiver,
                                                hitPoint, hitNormal,
                                                attackDirection);

            return msg;
        }
    }
}