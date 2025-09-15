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
    //Movement method; Why is my character never reaching 20 units in speeeeeeeeeeeeeeeeeeeeeeeeeeeed

    //Jumping Multipliers
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    //Movement variables
    private Vector3 inputVector;


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
        if (rb.linearVelocityY <= 0)
        {
            //rb.linearVelocityY = unitData.jumpForce * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.linearVelocityY > 0 && !Input.GetKeyDown(KeyCode.Space));
        {
            rb.linearVelocityY = Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Dis fucky wucky. dear god please help.
    }
    public void Movement() // Dis now work, otto no touchy touchy.
    {
        float targetSpeed = inputVector.x * unitData.topSpeed;
        float speedDif = targetSpeed - rb.linearVelocityX;
        float accel = inputVector.x == 0 ? unitData.decceleration : unitData.acceleration;

        rb.linearVelocityX += speedDif * accel * Time.deltaTime;
    }
}
