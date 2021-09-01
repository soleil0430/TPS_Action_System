using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ReceiveBound : MonoBehaviour
{
    [GetComponentInParent, SerializeField] protected Character character;
    public bool isReceive = true;

    protected virtual void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
    }
}
