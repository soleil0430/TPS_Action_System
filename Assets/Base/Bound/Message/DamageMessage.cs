using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bound
{
    [Serializable]
    public class DamageMessage : BoundMessage
    {
        public bool isIncludeMe;
        public float invincibleDuration;
        public float damage;

        public DamageMessage()
        {
            boundType = EBoundType.Damage;
        }
    }
}