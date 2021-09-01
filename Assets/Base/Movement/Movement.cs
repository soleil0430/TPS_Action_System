using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move
{
    public class Movement : MonoBehaviour
    {
        [GetComponent] Rigidbody rigidbody;

        public StraightMover straightMover;
        public DecidedMover decidedMover;
        public Bezier3Mover bezier3Mover;

        public EMover eMover;
        public IMover iMover;


        private void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);

            rigidbody.useGravity = false;
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            SetIMover();
        }

        private void Update()
        {
            iMover?.Move(rigidbody);
        }

        public void SetIMover()
        {
            switch (eMover)
            {
                case EMover.None:
                    break;
                case EMover.Straight:
                    iMover = straightMover;
                    break;
                case EMover.Decided:
                    iMover = decidedMover;
                    break;
                case EMover.Bezier3:
                    iMover = bezier3Mover;
                    break;
                default:
                    break;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            iMover?.DrawGizmos();
        }
#endif
    }
}