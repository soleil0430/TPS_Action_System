using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMessage
{

    public struct SlowMessage
    {
        public GameObject actor;
        public SendBound sendBound;

        public Vector3 hitPoint;
        public Vector3 hitNormal;

        public float slow;
    }

    public interface ISlow
    {
        void GetSlow(SlowMessage msg);
    }


}