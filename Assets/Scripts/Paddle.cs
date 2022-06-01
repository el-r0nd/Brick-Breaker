using UnityEngine;

public class Paddle : MonoBehaviour
{
    bool isActive = false;

    public Rigidbody2D rb { get; private set; }
    public Vector2 direction;
    public float speed = 30;
    public float maxBounceAngle = 75;
    public float timeForOpposite = 7;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
        collision.gameObject.SetActive(false);
    }

    private void Update()
    {
        Movement();
        OppositeDirection();
    }



    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            rb.AddForce(direction * speed);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;


            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rb.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude;

        }
    }

    public void ResetPaddle()
    {
        transform.position = new Vector2(0, transform.position.y);
        rb.velocity = Vector2.zero;
    }

    private void OppositeDirection()
    {
        if (isActive)
        {
            if (timeForOpposite > 0)
            {
                timeForOpposite -= Time.deltaTime;
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    direction = Vector2.right;
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    direction = Vector2.left;
                }
                else
                {
                    direction = Vector2.zero;
                }

            }
        }



    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.zero;
        }

    }




}


