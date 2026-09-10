using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool canInteract = false;
    public GameObject item;
    public GameObject screen;
    public GameObject levelTransition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        if (!item.activeSelf) //if item is picked up
        {
            levelTransition.SetActive(true);
        }
        else
        {
            levelTransition.SetActive(false);
        }
    }

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
}
