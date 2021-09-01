using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move;

public class Shooter : MonoBehaviour
{
    public GameObject wayPoint;
    public Transform muzzle;

    public Transform target;

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            muzzle.LookAt(target);

            GameObject instance = Instantiate(wayPoint, muzzle.position, muzzle.rotation);
            Movement movement = instance.GetComponent<Movement>();
            movement.startPoint = muzzle.position;
            movement.target = target;
            movement.targetPoint = target.position;
        }

    }

}
