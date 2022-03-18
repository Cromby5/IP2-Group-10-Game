using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInventory inventory;

    [SerializeField] private Animator anim;

    [Header("Trap")]
    [SerializeField] GameObject trapPrefab;
    public Transform trapPlacePoint;
    [SerializeField] private int trapCount;
    private int maxTrapCount;
    [SerializeField] private float trapTimer;
    private float trapTimerStore;
    public TextMeshProUGUI trapTXT;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Speed")]
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;

    public bool hasInteract;
    private bool canmove;

    [Header("Dash")]
    [SerializeField] private float timeForDashRecharge;
    private float DashRechargeStore;

    [SerializeField] private float dashTime;
    [SerializeField] private int dashSpeed;
    [SerializeField] private int dashCount;
    [SerializeField] private bool isDashing;

    [SerializeField] private Image Trap;
    [SerializeField] private Image Stun;

    public TextMeshProUGUI Timer_Display;
    private void Start()
    {
        canmove = true;
        isDashing = false;

        trapTimerStore = trapTimer;
        DashRechargeStore = timeForDashRecharge;
        maxTrapCount = trapCount;

        trapTXT.text = trapCount.ToString() + " / " + maxTrapCount;

        controller = gameObject.GetComponent<CharacterController>();
        inventory = gameObject.GetComponent<PlayerInventory>();
    }

    public void OnMove(Vector2 direction)
    {
        if (canmove)
        {
            movementInput = direction;
        }
        else
        {
            movementInput = new Vector3(0, 0, 0);
        }
    }

    public void OnDash()
    {
        if (canmove && dashCount > 0)
        {
            dashCount -= 1;
            StartCoroutine(DashCoroutine());
        }
    }

    public void OnInteract()
    {
        if (hasInteract == false)
        {
            Debug.Log("Press");
            StartCoroutine(HasInteract());
        }
    }

    public void OnPlace()
    {
        if (trapCount > 0 && trapTimer <= 0)
        {
            trapCount -= 1;
            trapTXT.text = trapCount.ToString() + " / " + maxTrapCount;
            if (trapCount == 0)
            {
                Trap.enabled = false;
                trapTXT.enabled = false;
            }
            trapTimer = trapTimerStore;
            Instantiate(trapPrefab, trapPlacePoint.transform.position, trapPlacePoint.transform.rotation);
        }
    }

    void Update()
    {
        if (canmove)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
            anim.SetFloat("Speed", move.magnitude);
        }

        if (trapTimer > 0)
        {
            trapTimer -= Time.deltaTime;
        }
        if (dashCount == 0 && timeForDashRecharge > 0 )
        {
            timeForDashRecharge -= Time.deltaTime;
            DisplayTime(timeForDashRecharge);
            if (timeForDashRecharge <= 0)
            {
                dashCount += 1;
                Timer_Display.text = "Ready";
            }
        }
    }

    public void DisableMove()
    {
        Debug.Log("Disabled");
        StartCoroutine(DisableTime());
    }

    public void AddTrap()
    {
        if (trapCount < maxTrapCount)
        {
            trapCount += 1;
        }
    }

    public void ChangeSpeed(float i)
    {
        float temp = playerSpeed;
        playerSpeed += i;
        // Start Timer
        StartCoroutine(SpeedTime(temp));
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        isDashing = true;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
            // or transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
            yield return null; // this will make Unity stop here and continue next frame
        }
        isDashing = false;
        timeForDashRecharge = DashRechargeStore;
    }

    private IEnumerator SpeedTime(float temp)
    {
        yield return new WaitForSeconds(3f);
        playerSpeed = temp;
    }

    private IEnumerator DisableTime()
    {
        canmove = false;
        anim.SetTrigger("Stun");
        yield return new WaitForSeconds(2f);
        canmove = true;
        anim.ResetTrigger("Stun");
    }

    private IEnumerator HasInteract()
    {
        hasInteract = true;
        yield return new WaitForSeconds(0.1f);
        hasInteract = !hasInteract;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerMove I = other.gameObject.GetComponent<PlayerMove>();

        if (I != null && !I.CompareTag(gameObject.tag) && isDashing)
        {
            I.DisableMove();
            
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        //Allows for accurate display of minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Format for the display of the time (00:00)
        Timer_Display.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
