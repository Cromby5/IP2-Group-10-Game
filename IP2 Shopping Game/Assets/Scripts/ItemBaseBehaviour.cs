using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBaseBehaviour : MonoBehaviour
{
    private bool hasGrabbed;

    [SerializeField] private GameObject[] Items;
    [SerializeField] private PlayerMove M;
    private PlayerInventory I;

    public GameObject i1;
    public GameObject i2;

    private void Start()
    {
        hasGrabbed = false;
        int i = Random.Range(0,Items.Length);
        Items[i].SetActive(true);

       switch (i)
       {
            case 0:
                if (CompareTag("Player 1"))
                {
                    i1 = GameObject.FindGameObjectWithTag("Jar");
                    i2 = GameObject.FindGameObjectWithTag("Worms");
                    Image Image1 = i1.GetComponentInChildren<Image>();
                    Image Image2 = i2.GetComponentInChildren<Image>();
                    Image1.enabled = true;
                    Image2.enabled = false;
                }
                if (CompareTag("Player 2"))
                {
                    i1 = GameObject.FindGameObjectWithTag("Milk");
                    i2 = GameObject.FindGameObjectWithTag("Bottle");
                    Image Image1 = i1.GetComponentInChildren<Image>();
                    Image Image2 = i2.GetComponentInChildren<Image>();
                    Image1.enabled = true;
                    Image2.enabled = false;
                }
                break;
            case 1:
                if (CompareTag("Player 1"))
                {
                    i1 = GameObject.FindGameObjectWithTag("Jar");
                    i2 = GameObject.FindGameObjectWithTag("Worms");

                    Image Image1 = i1.GetComponentInChildren<Image>();
                    Image Image2 = i2.GetComponentInChildren<Image>();
                    Image1.enabled = false;
                    Image2.enabled = true;
                }
                if (CompareTag("Player 2"))
                {
                    i1 = GameObject.FindGameObjectWithTag("Milk");
                    i2 = GameObject.FindGameObjectWithTag("Bottle");

                    Image Image1 = i1.GetComponentInChildren<Image>();
                    Image Image2 = i2.GetComponentInChildren<Image>();
                    Image1.enabled = false;
                    Image2.enabled = true;
                }
                break;
       }
            
    }

    private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("Trigger");

        I = other.transform.gameObject.GetComponent<PlayerInventory>();
        M = other.transform.gameObject.GetComponent<PlayerMove>();

        /*
        if (I != null && other.transform.gameObject.CompareTag(gameObject.tag))
        {       
            Debug.Log("Found");
            I.ItemAdd();
            Destroy(gameObject);
        }
        */

    }

    private void OnTriggerStay(Collider other)
    {
        if (M != null && M.hasInteract == true && hasGrabbed == false && other.transform.gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Found2");
            hasGrabbed = true;
            I.ItemAdd();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        I = null;
        M = null;
    }

}
