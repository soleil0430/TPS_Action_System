using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

public class SlowReceiveBound : ReceiveBound, ISlow
{
    public float slowMultiple;

    void ISlow.GetSlow(SlowMessage msg)
    {
        if (isReceive)
        {
            msg.slow *= slowMultiple;
            character.GetSlow(msg, this);
        }
    }
}