using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //-----Input
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    //-----UI
    [SerializeField] private string nextLevel;
    public Image coverImage;
    public GameObject screen;
    

    //-----Interact
    public bool canInteract = false;
    public GameObject item;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
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

    #region LEVEL
    public LTDescr FadeToBlack(float duration = 1f, System.Action callback = null)
    {
        coverImage.color = Color.clear;
        coverImage.enabled = true;
        return LeanTween.alpha(coverImage.rectTransform, 1f, duration).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            callback?.Invoke();
        });
    }

    public LTDescr FadeFromBlack(float duration = 1f, System.Action callback = null)
    {
        coverImage.color = Color.black;
        coverImage.enabled = true;
        return LeanTween.alpha(coverImage.rectTransform, 0f, duration).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            coverImage.enabled = false;
            callback?.Invoke();
        });
    }
    public void ToNextLevel()
    {
        Debug.Assert(nextLevel != null, "Next Level not assigned in GameController");
        coverImage.color = Color.black;
        coverImage.enabled = true;
       // player.isInvincible = true;
        LeanTween.delayedCall(0f, () =>
            LeanTween.alpha(coverImage.rectTransform, 0f, 1f).setEase(LeanTweenType.linear).setIgnoreTimeScale(true).setOnComplete(() =>
            {
                coverImage.enabled = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevel);
                ///player.isInvincible = false;
            })
        ).setIgnoreTimeScale(true);
        Time.timeScale = 0f;
    }
    #endregion
}
