using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bound
{
    public enum EDirectionType
    {
        SenderForward,
        SendBoundForward,

        ConstDirection,
        BloomFromSender,
        BloomFromSendBound,
    }

    [Serializable]
    public class DirectionMessage : BoundMessage
    {
        public EDirectionType directionType;


        public Vector3 direction;
        public float power;

        public DirectionMessage()
        {
            boundType = EBoundType.Direction;
        }


        public void SetDirection(Transform other)
        {
            switch (directionType)
            {
                case EDirectionType.SenderForward:
                    direction = sender.forward;
                    break;
                case EDirectionType.SendBoundForward:
                    direction = sendBound.transform.forward;
                    break;
                case EDirectionType.ConstDirection:
                    break;
                case EDirectionType.BloomFromSender:
                    direction = (other.position - sender.position).normalized;
                    break;
                case EDirectionType.BloomFromSendBound:
                    direction = (other.position - sendBound.transform.position).normalized;
                    break;
                default:
                    break;
            }
        }
    }
}