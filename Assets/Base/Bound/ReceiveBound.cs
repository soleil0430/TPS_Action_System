using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

namespace Bound
{
    [RequireComponent(typeof(Collider))]
    public class ReceiveBound : MonoBehaviour
    {
        [GetComponentInParent, DisableField] protected Character character;
        [SerializeField] List<ReceiveProcessSO> processSOs;


        protected virtual void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        }

        public void Receive(BoundMessage msg)
        {
            foreach (var process in processSOs)
            {
                process.Process(msg, character);
            }
        }

    }
}