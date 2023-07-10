using UnityEngine;

public class MinionBehavior : MonoBehaviour
{
    public GameObject player;
    public float damage = 1;
    public EnemyProperties enemyProperties;
    public GameManagerScript gameManager;
    public GameObject upgradeDrop;
    public GameObject healDrop;

    public float healChance = 0.5f;
    public float upgradeChance = 0.3f;
    public int itemDropLimit = 5;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!enemyProperties.isAlive)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var component = collision.collider.GetComponent<PlayerProperties>();

            if (component != null)
            {
                component.TakeHit(damage);
            }

            int randomDrop = Random.Range(1, 3);

            if (randomDrop == 1)
            {
                DropItem();
            }

            if (randomDrop == 2)
            {
                DropHeal();
            }

            Destroy(gameObject);
        }
    }

    public void DropItem()
    {
        float dropRandomize = Random.value;

        if (dropRandomize < upgradeChance && itemDropLimit > 0)
        {
            Instantiate(upgradeDrop, transform.position, Quaternion.identity);
            itemDropLimit--;
        }
    }

    public void DropHeal()
    {
        float dropRandomize = Random.value;

        if (dropRandomize < healChance)
        {
            Instantiate(healDrop, transform.position, Quaternion.identity);
        }
    }
}
