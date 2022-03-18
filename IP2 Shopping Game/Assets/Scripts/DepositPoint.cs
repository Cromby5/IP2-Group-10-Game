using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepositPoint : MonoBehaviour
{
    private PlayerMove M;
    private PlayerInventory I;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");

        I = other.transform.gameObject.GetComponent<PlayerInventory>();
        M = other.transform.gameObject.GetComponent<PlayerMove>();

        /*
        if (I != null)
        {
            Debug.Log("Found");
            I.ItemRemove();
        }
        */
    }

    private void OnTriggerStay(Collider other)
    {
        if (I != null && M.hasInteract == true)
        {
            Debug.Log("Found");
            I.ItemRemove();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        I = null;
    }
}
