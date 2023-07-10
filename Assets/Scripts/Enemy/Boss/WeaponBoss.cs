using UnityEngine;

public class WeaponBoss : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    private int attack;

    public void Fire()
    {
        float bulletChance = Random.value;

        if(bulletChance < 0.3f)
        {
            attack = 0;
        }
        else
        {
            attack = 1;
        }

        GameObject bullet = Instantiate(bulletPrefab[attack], firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}