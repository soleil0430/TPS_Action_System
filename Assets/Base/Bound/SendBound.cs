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

        private void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);

            ((DamageSendSO)processSOs[0]).rMsg.damage = 0;
        }


        private void OnTriggerEnter(Collider other)
        {
            ReceiveBound rBound = other.GetComponent<ReceiveBound>();
            if (rBound)
            {
                Debug.Log("name: " + other.name);
                foreach (var process in processSOs)
                {
                    process.Process(creator, collider, other);
                }
            }
        }
    }
}