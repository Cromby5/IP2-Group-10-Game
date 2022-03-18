using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfig playerConfig;
    private PlayerMove move;
    [SerializeField]
    private MeshRenderer playerMesh;

    private PlayerControl controls;

    private void Awake()
    {
        move = GetComponent<PlayerMove>();
        controls = new PlayerControl();

    }
    public void InitializePlayer(PlayerConfig pc)
    {
        playerConfig = pc;
        playerMesh.material = pc.PlayerMat;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.PlayerMove.Movement.name)
        {
            OnMove(obj);
        }
        else if (obj.action.name == controls.PlayerMove.Jump.name)
        {
            OnInteract(obj);
        }
        else if (obj.action.name == controls.PlayerMove.Dash.name)
        {
            OnDash(obj);
        }
        else if (obj.action.name == controls.PlayerMove.PlaceTrap.name)
        {
            OnPlace(obj);
        }
        else if (obj.action.name == controls.PlayerMove.Reset.name)
        {
            OnReset(obj);
        }
    }
    public void OnMove(CallbackContext context)
    {
        if (move != null)
            move.OnMove(context.ReadValue<Vector2>());
    }

    public void OnInteract(CallbackContext context)
    {
        if (move != null)
            move.OnInteract();
    }

    public void OnDash(CallbackContext context)
    {
        if (move != null)
            move.OnDash();
    }

    public void OnPlace(CallbackContext context)
    {
        if (move != null)
            move.OnPlace();
    }

    public void OnReset(CallbackContext context)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
