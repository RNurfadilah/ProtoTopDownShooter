using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public float HitPoint;
    public float MaxHitPoint = 5;
    public bool isAlive = true;

    void Start()
    {
        HitPoint = MaxHitPoint;
    }

    public void TakeHit(float Damage)
    {
        HitPoint -= Damage;

        if (HitPoint <= 0)
        {
            isAlive = false;
        }   
    }
}
