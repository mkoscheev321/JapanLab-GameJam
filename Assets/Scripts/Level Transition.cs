using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LevelTransition : Entity
{
    [SerializeField] private GameObject gameController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.GetComponent<PlayerController>().ToNextLevel();
            Destroy(gameObject);
        }
    }
}
