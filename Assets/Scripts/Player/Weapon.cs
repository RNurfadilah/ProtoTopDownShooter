using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public void Fire(int bulletLevel)
    {
        GameObject bullet = Instantiate(bulletPrefab[bulletLevel], firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}