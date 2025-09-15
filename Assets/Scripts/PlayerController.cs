using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnitData unitData;
    [SerializeField] private Rigidbody2D rb;
    private PlayerInputActions playerInputActions;
    //Questions for Anton-sensei
    //Any difference to SerializeField and move shit in the inspector or use GetComponent<>
    //Access linear dampening in code, reduced ice effect on my character

    //Jumping Multipliers
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    //Movement variables
    private Vector3 inputVector;
    Vector2 position; // position of ball/circle/gameObject


    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.DefaultPlayer.Enable();
        playerInputActions.DefaultPlayer.Jump.performed += Jump;

    }
    void Update()
    {
        inputVector = playerInputActions.DefaultPlayer.Movement.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Jump(InputAction.CallbackContext state)
    {
        if (state.performed)
        {
            if (rb.linearVelocityY < 0)
            {
                rb.linearVelocityY += unitData.jumpForce * (-1 * Physics2D.gravity.y) * fallMultiplier * Time.deltaTime;
            }
            else if (rb.linearVelocityY > 0 && !state.performed)
            {
                rb.linearVelocityY += unitData.jumpForce * (-1 * Physics2D.gravity.y) * lowJumpMultiplier * Time.deltaTime;
            }
        }
    }
    public void Movement()
    {
        
    }
    


}
