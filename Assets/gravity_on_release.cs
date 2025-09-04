using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

// Reference:
// https://discussions.unity.com/t/best-way-to-get-variable-from-another-script-c-unity/720634

public class gravity_on_release : MonoBehaviour
{

    public GameObject record;
    public GameObject player;
    public GameObject playingRecord;
    public Vector3 playingRecordPosition;
    
    public Vector3 recordPosition;
    private remove_song remove_script;
    public Rigidbody rb;
    public bool isReleased = false;
    public bool isReset = false;
    private ConstantForce cForce;
    private Vector3 forceDirection;

    public Vector3 globalRecordPosition;
    private int positionSwitch = 1;

    // Start is called before the first frame update
    void Start()
    {
        // cForce = GetComponent<ConstantForce>();
        // forceDirection = new Vector3(-1,-1,-1);
        // cForce.force = forceDirection;
        rb = record.GetComponent<Rigidbody>();
        remove_script = player.GetComponent<remove_song>();
        recordPosition = record.transform.localPosition;
        // recordPosition = record.transform.position;
        playingRecordPosition = playingRecord.transform.position;
        
        Debug.Log(recordPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (remove_script.inMenuArea)
        {
            // Debug.Log("Yoyo");
        }
        else if (remove_script.exitedRecordArea)
        {
            // record.transform.position = globalRecordPosition;
        }
        else if (isReleased && 
            !remove_script.inRecordArea && 
            !remove_script.hasFallen &&
            !remove_script.inTrashArea)
        {
            // record.transform.position += Vector3.down * 0.05f * Time.deltaTime;
            
            // forceDirection.z -= 1;
            // cForce.force = forceDirection
            Debug.Log("GRAVITY ON");
            // rb.useGravity = true;
        } else if (isReleased && remove_script.inRecordArea)
        {
            if (positionSwitch == 1)
            {
                globalRecordPosition = record.transform.localPosition;
                positionSwitch = 0;
            }
            else
            {
                // record.transform.position = playingRecordPosition;
                // rb.useGravity = false;
                // record.transform.Rotate(Vector3.down);
                // record.transform.Rotate(Vector3.left);
                // record.transform.Rotate(Vector3.right);
            }
            
        } else if (remove_script.hasFallen) {
            // record.transform.localPosition = recordPosition;
            // rb.useGravity = false;
            // remove_script.hasFallen = false;
            // isReleased = false;
            // Debug.Log("GRAVITY OFF");
            // record.transform.localPosition = recordPosition;
        }
    
    }

    public void WhenReleased()
    {
        // isReleased = true;

        if (!remove_script.inRecordArea &&
            !remove_script.hasFallen &&
            !remove_script.inTrashArea &&
            !remove_script.inMenuArea)
        {
            rb.useGravity = true;
        }
        
    }

    public void WhenGrabbed()
    {
        // recordPosition = record.transform.position;
        if (remove_script.inRecordArea)
        {
            recordPosition = new Vector3(1, 1, 1);
        }
        else
        {
            recordPosition = record.transform.localPosition;
        }
        rb.isKinematic = false;
    }
    
}
