using UnityEngine;

public class MinionSpriteRandomizer : MonoBehaviour
{
    public Sprite[] sprites;

    private void Start()
    {
        // Get a random sprite from the array
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];

        // Set the sprite on the Sprite Renderer component
        GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
