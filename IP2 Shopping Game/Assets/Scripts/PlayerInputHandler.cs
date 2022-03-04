using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

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
}
