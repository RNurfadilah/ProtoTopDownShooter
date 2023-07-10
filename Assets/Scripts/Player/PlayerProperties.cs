using UnityEngine;
using TMPro;

public class PlayerProperties : MonoBehaviour
{
    public float hitPoint;
    public float maxHitPoint = 5;
    public float moveSpeed = 5f;
    public TMP_Text healthNumber;
    public TMP_Text upgradeNumber;
    public GameManagerScript gameManager;
    public GameObject moveScreen;

    [SerializeField] private AudioSource playerBGM;

    public bool isAlive = true;
    public int upgradeCount = 0;

    void Start()
    {
        playerBGM.Play();
        hitPoint = maxHitPoint;
        healthNumber.text = hitPoint.ToString();
        upgradeNumber.text = upgradeCount.ToString();
    }

    private void Update()
    {
        if (!isAlive)
        {
            moveScreen.SetActive(false);
            playerBGM.Stop();            
        }
    }

    public void TakeHit(float Damage)
    {
        hitPoint -= Damage;
        healthNumber.text = hitPoint.ToString();

        if (hitPoint <= 0 & isAlive)
        {
            isAlive = false;
            Destroy(gameObject);
            gameManager.gameOverPlayer();
        }
    }

    public void UpgradePlusOne(float up)
    {
        upgradeCount++;
        upgradeNumber.text = upgradeCount.ToString();
    }

    public void HealPlusOne(float up)
    {
        if (hitPoint <= maxHitPoint)
        {
            hitPoint++;
            healthNumber.text = hitPoint.ToString();
        }
    }
}
