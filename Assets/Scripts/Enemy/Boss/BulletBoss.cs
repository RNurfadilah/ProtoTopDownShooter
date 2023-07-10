using System.Collections;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    public float lifespan = 2f;
    public float damage = 1;

    private void Start()
    {
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Enemy"))
        {
            var component = collision.collider.GetComponent<PlayerProperties>();

            if (component != null)
            {
                component.TakeHit(damage);
            }
        }

        Destroy(gameObject);
    }
}
