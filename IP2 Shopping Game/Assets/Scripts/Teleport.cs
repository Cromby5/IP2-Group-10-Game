using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private bool active;
    [SerializeField] private float timeToActivate;

    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active == false)
        {
            timeToActivate -= Time.deltaTime;
        }

        if (timeToActivate <= 0)
        {
            active = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.GetComponent<PlayerMove>() != null && active)
        {
            other.transform.position = new Vector3(Random.Range(-6f, 6f), other.transform.position.y, Random.Range(-3f, 3.5f));
            Destroy(gameObject);
        }
    }
}
