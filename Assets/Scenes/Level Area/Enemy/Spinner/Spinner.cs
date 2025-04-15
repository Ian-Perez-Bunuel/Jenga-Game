using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    //rotation of the Z axis
    private float rotZ;
    public float rotationSpeed;
    public bool ClockwiseRotation;



    // Update is called once per frame
    void Update()
    {
        //checks if it will rotate clockwise or anti-clockwise
        if (ClockwiseRotation == false)
        {
            rotZ += Time.deltaTime * rotationSpeed;
        }
        else
        {
            rotZ += -Time.deltaTime * rotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
