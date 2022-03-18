using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehaviour : MonoBehaviour
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

        PlayerMove Player = other.gameObject.GetComponent<PlayerMove>();
        if (Player != null && active)
        {
            Player.DisableMove();
            Destroy(gameObject);
        }
    }
}
