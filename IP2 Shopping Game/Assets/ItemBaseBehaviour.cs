using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBaseBehaviour : MonoBehaviour
{
    private bool canInteract;
    private bool hasGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("Trigger");

        PlayerInventory I = other.transform.gameObject.GetComponent<PlayerInventory>();

        if (I != null && other.transform.gameObject.CompareTag(gameObject.tag))
        {       
            Debug.Log("Found");
            I.ItemAdd();
            Destroy(gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }

}
