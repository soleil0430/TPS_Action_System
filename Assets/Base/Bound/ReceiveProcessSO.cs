using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Bound
{
    public abstract class ReceiveProcessSO : ScriptableObject
    {
        public abstract void Process(object msg, Character character);
    }
}