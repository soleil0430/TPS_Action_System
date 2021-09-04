using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Bound
{
    public enum EBoundType
    {
        None = -1,
        Damage = 0,
        Slow,
        Direction,
    }


    [Serializable]
    public abstract class BoundMessage
    {
        [DisableField] public Transform sender;
        [DisableField] public Transform receiver;
        [DisableField] public EBoundType boundType;

        [DisableField] public GameObject sendBound;
        [DisableField] public GameObject receiveBound;

        [DisableField] public Vector3 hitPoint;
        [DisableField] public Vector3 hitNormal;

        public BoundMessage()
        {
            boundType = EBoundType.None;
        }

        
    }
}