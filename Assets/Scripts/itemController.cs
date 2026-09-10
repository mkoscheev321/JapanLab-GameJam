using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    public GameObject E;
    public PlayerMovement playerMovement;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.canInteract = true;
            E.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement.canInteract = false;
            E.SetActive(false);
        }
    }
}
