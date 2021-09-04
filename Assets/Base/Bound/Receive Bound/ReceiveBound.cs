using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Bound
{
    public class ReceiveBound : MonoBehaviour
    {
        [GetComponentInParent, DisableField] public Character character;

        private void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        }

        public bool ReceiveBoundMessage(BoundMessage msg)
        {
            switch (msg.boundType)
            {
                case EBoundType.Damage:
                    return character.GetDamage(msg as DamageMessage);
                case EBoundType.Direction:
                    return character.GetDirection(msg as DirectionMessage);
                case EBoundType.None:
                case EBoundType.Slow:
                default:
                    return false;
            }
        }
    }
}