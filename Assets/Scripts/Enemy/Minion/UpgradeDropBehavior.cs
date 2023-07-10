using UnityEngine;

public class UpgradeDropBehavior : MonoBehaviour
{
    public float upgradeValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var component = collision.collider.GetComponent<PlayerProperties>();

            if (component != null)
            {
                component.UpgradePlusOne(upgradeValue);
                Destroy(gameObject);
            }
        }
    }
}
