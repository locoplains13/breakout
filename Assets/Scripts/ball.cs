using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering;

public class ball : MonoBehaviour
{
    public GameObject levelGenerator;
    public int score = 0;
    public float speed = 5.0f;
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    public GameObject target;
    public GameObject paddle;
    Rigidbody2D rigid_body;
    float center;
    Vector2 direction;
    int directionBall;
    public int lives = 3;
    public bool ballShot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        // rigid_body.linearVelocity = speed * Time.deltaTime * new Vector2(0, 1);
    }

    void Update()
    {
        if (lives == 0)
        {
            FindAnyObjectByType<GameOver>().showGameOver();
        }
        if (!ballShot)
        {
            transform.position = target.transform.position;
            transform.position += new Vector3(0, 1, 0);
            maxVelocity = 4.0f;

        }

        if (Input.GetKeyDown(KeyCode.Space) && !ballShot)
        {
            if (paddle.GetComponent<Paddle>().movementHorizontal > 0)
            {
                directionBall = 1;
            }
            else
            {
                directionBall = -1;
            }
            rigid_body.linearVelocity = speed * Time.deltaTime * new Vector2(directionBall * 3, 1);
            ballShot = true;
        }

        direction = rigid_body.linearVelocity.normalized;
        rigid_body.linearVelocity = speed * direction;

        if (transform.position.y < minY)
        {
            lives -= 1;
            transform.position = target.transform.position;
            transform.position += new Vector3(0, 1, 0);
            ballShot = false;
        }
        if (rigid_body.linearVelocity.magnitude > maxVelocity)
        {
            rigid_body.linearVelocity = Vector2.ClampMagnitude(rigid_body.linearVelocity, maxVelocity);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hit = collision.GetContact(0).normal;
        if (collision.gameObject.CompareTag("Brick"))
        {
            maxVelocity += 0.1f;
            score += 50;
            levelGenerator.GetComponent<level>().bricks--;
        }
    }
}