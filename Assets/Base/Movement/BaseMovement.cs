using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        [GetComponent] protected Rigidbody rigidbody;

        [HideInInspector] public Transform target;
        [HideInInspector] public Vector3 targetPoint;
        public Vector3 targetPosition
        {
            get
            {
                if (target)
                    return target.position;
                else
                    return targetPoint;
            }
        }

        [HideInInspector] public float speed;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public Vector3 velocity;

        protected virtual void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        }
    }


}