using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector2 movementInput = Vector2.zero;


    public LayerMask ItemMask;
    public LayerMask DepositMask;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(Vector2 direction)
    {
        movementInput = direction;
    }

    public void OnMoveUnity()
    {

    }
    public void OnInteract()
    {
        Debug.Log("Press");
        if (Physics.CheckSphere(transform.position,1f,ItemMask))
        {
            Debug.Log("Found Item");
        }

        if (Physics.CheckSphere(transform.position, 1f, DepositMask))
        {
            Debug.Log("Found Deposit");
        }
    }
    void Update()
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
    }

    public void ChangeSpeed(float i)
    {
        float temp = playerSpeed;
        playerSpeed += i;
        // Start Timer
        StartCoroutine(SpeedTime(temp));
    }

    private IEnumerator SpeedTime(float temp)
    {
        yield return new WaitForSeconds(3f);
        playerSpeed = temp;
    }

}
