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

    [SerializeField] private Animator StunVisual;

    [Header("Trap")]
    [SerializeField] GameObject trapPrefab;
    public Transform trapPlacePoint;
    [SerializeField] private int trapCount;
    private int maxTrapCount;
    [SerializeField] private float trapTimer;
    private float trapTimerStore;
    public TextMeshProUGUI trapTXT;

    [SerializeField] private ParticleSystem stunPart;

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [Header("Speed")]
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;

    public bool hasInteract;
    private bool canmove;
    private bool hasHit;

    [Header("Dash")]
    [SerializeField] private float timeForDashRecharge;
    private float DashRechargeStore;

    [SerializeField] private float dashTime;
    [SerializeField] private int dashSpeed;
    [SerializeField] private int dashCount;
    [SerializeField] private bool isDashing;

    [SerializeField] private Image Trap;

    public TextMeshProUGUI Timer_Display;

    public AudioSource audioSource;
    public AudioClip powerUp;
    public AudioClip stunSound;
    public AudioClip dashSound;
    public AudioClip trapSound;

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
            audioSource.PlayOneShot(trapSound);
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
        audioSource.PlayOneShot(powerUp);
        float temp = playerSpeed;
        playerSpeed += i;
        // Start Timer
        StartCoroutine(SpeedTime(temp));
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        audioSource.PlayOneShot(dashSound);
        isDashing = true;
        hasHit = false;
        canmove = false;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(transform.forward * dashSpeed * Time.deltaTime);
            // or transform.Translate(Vector3.forward * dashSpeed * Time.deltaTime);
            yield return null; // this will make Unity stop here and continue next frame
        }
        isDashing = false;
        canmove = true;
        StunVisual.SetTrigger("Stun");
        timeForDashRecharge = DashRechargeStore;
    }

    private IEnumerator SpeedTime(float temp)
    {
        yield return new WaitForSeconds(3f);
        playerSpeed = temp;
    }

    private IEnumerator DisableTime()
    {
        audioSource.PlayOneShot(stunSound);
        canmove = false;
        stunPart.Play();
        anim.SetTrigger("Stun");
        yield return new WaitForSeconds(2f);
        stunPart.Stop();
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
        PlayerMove M = other.gameObject.GetComponent<PlayerMove>();
        PlayerInventory I = other.gameObject.GetComponent<PlayerInventory>();

        if (M != null && !M.CompareTag(gameObject.tag) && isDashing && !hasHit)
        {
            hasHit = true;
            M.DisableMove();
            I.PlayerHit();
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
