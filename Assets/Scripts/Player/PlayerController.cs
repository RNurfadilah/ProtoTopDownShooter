using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Weapon weapon;
    public GameObject autoAttackOff;
    public GameObject autoAttackOn;
    public Transform target;

    public float lineOfSite = 10f;
    public float fireRate = 1;
    public float nextFireTime;

    private PlayerProperties properties;
    private bool autoAttack = false;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private void Awake()
    {
        properties = FindObjectOfType<PlayerProperties>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = new Vector2(moveDirection.x * properties.moveSpeed, moveDirection.y * properties.moveSpeed);

        if (!autoAttack)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;

            if (Input.GetMouseButtonDown(1))
            {
                weapon.Fire(properties.upgradeCount);
            }
        }

        if (autoAttack)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;
            float distanceFromPlayer = Vector2.Distance(target.transform.position, transform.position);

            if (distanceFromPlayer <= lineOfSite && nextFireTime < Time.time)
            {
                weapon.Fire(properties.upgradeCount);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public void toggleAutoAttack()
    {
        autoAttack = !autoAttack;

        Debug.Log(autoAttack);

        if (autoAttack)
        {
            autoAttackOn.SetActive(true);
            autoAttackOff.SetActive(false);
        }

        if (!autoAttack)
        {
            autoAttackOn.SetActive(false);
            autoAttackOff.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}