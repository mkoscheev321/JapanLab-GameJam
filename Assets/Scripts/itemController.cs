using UnityEngine;
using UnityEngine.UI;

public class itemController : MonoBehaviour
{
    public GameObject E;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(false);
        }
    }
}
