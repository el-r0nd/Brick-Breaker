using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health { get; private set; }
    public Sprite[] states;
    public bool unbreakable;
    public int points = 100;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (!unbreakable)
        {
            health = states.Length;
            spriteRenderer.sprite = states[health - 1];
        }
    

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }

    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = states[health - 1];
        }
        FindObjectOfType<GameManager>().Hit(this);

    }

}
