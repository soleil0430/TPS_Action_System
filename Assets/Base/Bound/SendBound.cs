using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bound
{
    [RequireComponent(typeof(Collider))]
    public class SendBound : MonoBehaviour
    {
        [GetComponent, DisableField] public Collider collider;
        public GameObject creator;
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
                    process.Process(creator, collider, other);
                }
            }
        }
    }
}