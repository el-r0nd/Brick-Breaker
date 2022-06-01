using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb { get; private set; }
    public float speed=500;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
     Invoke("RandomBallStart",1); 
    }


    private void RandomBallStart()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1, 1);
        force.y = -1;
        rb.AddForce(force.normalized * speed);
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;

        Invoke("RandomBallStart", 1);

    }
}
