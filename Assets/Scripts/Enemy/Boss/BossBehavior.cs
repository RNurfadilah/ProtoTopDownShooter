using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject player;
    public WeaponBoss weaponBoss;
    public EnemyProperties enemyProperties;
    public GameManagerScript gameManager;

    public float fireRate = 1;
    public float nextFireTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!enemyProperties.isAlive)
        {
            Destroy(gameObject);
            gameManager.gameOverBoss();
        }

        if (nextFireTime < Time.time)
        {
            weaponBoss.Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
}
