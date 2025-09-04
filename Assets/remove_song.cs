using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove_song : MonoBehaviour
{

    public GameObject song;
    public GameObject songTitle;
    public Collider trashCollider;
    public AudioClip clipToPlay;
    public float delay = 5;
    public float timer;
    private AudioSource source;
    public Rigidbody rb;

    public bool inRecordArea = false;
    public bool inMenuArea = true;
    public bool exitedRecordArea = false;
    public bool hasFallen = false;
    public bool inTrashArea = false;

    private gravity_on_release gravity_script;

    // private void OnCollisionEnter(Collision other)
    // {
    //
    //     if (other.gameObject.name == "Trash Area")
    //     {
    //         Debug.Log("am i here");
    //         Destroy(gameObject);
    //     }
    //     
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        gravity_script = song.GetComponent<gravity_on_release>();
        // StartCoroutine(ExampleCoroutine());
    }

    // public IEnumerator ExampleCoroutine()
    // {
    //     yield return new WaitForSeconds(4);
    //     Debug.Log("Coroutine testing");
    // }

    public void destroyObject()
    {
        Destroy(gameObject);
        Destroy(songTitle);
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     throw new NotImplementedException();
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trash Area")
        {
            // timer += Time.deltaTime;
            // if (timer > delay)
            // {
            //     Destroy(gameObject);
            //     Debug.Log("Time Elapsed: " + timer);
            // }
            
            inTrashArea = true;
            
            rb.useGravity = false;
            rb.isKinematic = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            
            Invoke("destroyObject", 3);
            
            // Destroy(gameObject);
            Debug.Log("Am I here?");    
        } else if (other.gameObject.name == "Record Area")
        {
            // if (gameObject.name == "[BuildingBlock] R&B Song 1")
            // {
                gravity_script.globalRecordPosition = gravity_script.record.transform.localPosition;
                Debug.Log("GLOBAL POSITION" + gravity_script.globalRecordPosition);
                
                Debug.Log("Song 1");
                
                source.clip = clipToPlay;
                source.Play();
                
                inRecordArea = true;
                
                rb.useGravity = false;
                rb.isKinematic = true;
                // source.PlayOneShot(clip);
            // }
            Debug.Log("Play a song");
            // rb.useGravity = false;
        } else if (other.gameObject.name == "Floor Area")
        {
            Debug.Log("FALLEN");

            hasFallen = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            Debug.Log("POSITION" + gravity_script.recordPosition);
            
            gameObject.transform.localPosition = gravity_script.recordPosition;
            
            hasFallen = false;

        } else if (other.gameObject.name == "Menu Area")
        {
            inMenuArea = true;
            Debug.Log("IN MENU");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Record Area")
        {
            gameObject.transform.position = gravity_script.playingRecordPosition;
            gameObject.transform.Rotate(Vector3.left);
            gameObject.transform.Rotate(Vector3.forward);
            gameObject.transform.Rotate(Vector3.down);
            inRecordArea = true;
            // Debug.Log("PLEASE WORK");
        }
        else if (other.gameObject.name == "Menu Area")
        {
            inMenuArea = true;
            // Debug.Log("IN MENU");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Record Area")
        {
            // if (gameObject.name == "[BuildingBlock] R&B Song 1")
            // {
                source.Stop();
                exitedRecordArea = true;
                inRecordArea = false;
                Debug.Log("Stop Song");
            // }
        } else if (other.gameObject.name == "Menu Area")
        {
            inMenuArea = false;
            // rb.useGravity = true;
            // rb.isKinematic = false;
            Debug.Log("EXITED MENU");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
