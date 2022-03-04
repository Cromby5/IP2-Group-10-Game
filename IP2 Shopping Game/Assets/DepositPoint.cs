using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositPoint : MonoBehaviour
{
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

        if (I != null)
        {
            Debug.Log("Found");
            I.ItemRemove();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
    }
}
