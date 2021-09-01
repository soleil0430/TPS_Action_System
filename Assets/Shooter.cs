using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;
    public Transform muzzle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instance = Instantiate(prefab, muzzle.position, muzzle.rotation);
            //Movement move = instance.GetComponent<Movement>();

        }

    }

}
