using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

namespace Bound
{
    public abstract class SendProcessSO : ScriptableObject
    {
        public abstract void Process(GameObject senderCreator, Collider sender, Collider receiver, AttackDirection attackDirection);

        protected Vector3 GetHitPoint(Collider sender, Collider other)
        {
            return (other.ClosestPoint(sender.transform.position));
        }

        protected Vector3 GetHitNormal(Collider sender, Collider other)
        {
            return (GetHitPoint(sender, other) - other.transform.position).normalized;
        }
    }
}