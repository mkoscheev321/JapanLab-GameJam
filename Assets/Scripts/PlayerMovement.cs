using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //-----Input
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    //-----Interact
    public bool canInteract = false;
    public GameObject item;
    public GameObject screen;
    public GameObject levelTransition;

    //-----Animation
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        levelTransition.SetActive(false);

        if (item == null || !item.activeSelf) //if item is picked up
        {
            levelTransition.SetActive(true);
        }

        if (moveInput != Vector2.zero)
        {
            animator.SetFloat("moveX", moveInput.x);
            animator.SetFloat("moveY", moveInput.y);
        }

        animator.SetBool("isMoving", moveInput != Vector2.zero);
    }

    #region CONTROLS
    public void Move(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Interact(InputAction.CallbackContext context) 
    {
        if (context.performed && canInteract)
        {
            Debug.Log("E was pressed!");
            item.SetActive(false);
            screen.SetActive(true);
        }
    }
    #endregion


}
