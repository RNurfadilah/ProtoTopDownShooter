using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (!collision.collider.CompareTag("Player"))
        {
            var component = collision.collider.GetComponent<EnemyProperties>();

            if (component != null)
            {
                component.TakeHit(damage);
                Debug.Log(damage);
            }            
        }

        Destroy(gameObject);
    }
}