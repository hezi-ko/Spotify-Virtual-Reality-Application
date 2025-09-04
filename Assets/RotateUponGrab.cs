using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUponGrab : MonoBehaviour
{

    public GameObject rotatingCube;
    private bool isSpinning = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isSpinning)
        {
            rotatingCube.transform.Rotate(Vector3.up);
        }
        
    }

    public void WhenGrabbing()
    {
        isSpinning = true;
    }

    public void UnGrabbing()
    {
        isSpinning = false;
    }
}
