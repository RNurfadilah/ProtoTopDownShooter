using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float yOffSet = 1f;
    public Transform player;
    public PlayerProperties playerStatus;

    private void Awake()
    {
        playerStatus = FindAnyObjectByType<PlayerProperties>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerStatus.isAlive)
        {
            Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y + yOffSet, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, moveSpeed * Time.deltaTime);
        }
    }
}
