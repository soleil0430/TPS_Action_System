using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move
{
    public class Movement : MonoBehaviour
    {
        [GetComponent] Rigidbody rigidbody;

        public MoverSO moverSO;

        private void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        }

        private void FixedUpdate()
        {
            moverSO?.Move(rigidbody);
        }

        private void OnDrawGizmos()
        {
            moverSO?.DrawGizmos();
        }
    }
}