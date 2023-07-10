using UnityEngine;

public class HealDropBehavior : MonoBehaviour
{
    public float healValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var component = collision.collider.GetComponent<PlayerProperties>();

            if (component != null)
            {
                component.HealPlusOne(healValue);
                Destroy(gameObject);
            }
        }
    }
}
