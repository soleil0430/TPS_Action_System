using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

namespace Bound
{
    [RequireComponent(typeof(Collider))]
    public class SendBound : MonoBehaviour
    {
        [GetComponent, DisableField] public Collider collider;
        public GameObject creator;
        public AttackDirection attackDirection;
        public List<SendProcessSO> processSOs;

        protected virtual void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        }


        protected virtual void OnTriggerEnter(Collider other)
        {
            ReceiveBound rBound = other.GetComponent<ReceiveBound>();
            if (rBound)
            {
                foreach (var process in processSOs)
                {
                    process.Process(creator, collider, other, attackDirection);
                }
            }
        }
    }
}