using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Rendering;

public class ball : MonoBehaviour
{
    public float speed = 5.0f;
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    public GameObject target;
    Rigidbody2D rigid_body;
    float center;
    Vector2 direction;
    bool ballShot = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
        // rigid_body.linearVelocity = speed * Time.deltaTime * new Vector2(0, 1);
    }

    void Update()
    {
        if (!ballShot)
        {
            transform.position = target.transform.position;
            transform.position += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !ballShot)
        {
            Debug.Log("pressed space");
            rigid_body.linearVelocity = speed * Time.deltaTime * new Vector2(1, 1);
            ballShot = true;
        }

        direction = rigid_body.linearVelocity.normalized;
        rigid_body.linearVelocity = speed * direction;

        if (transform.position.y < minY)
        {
            transform.position = Vector2.zero;
        }
        if (rigid_body.linearVelocity.magnitude > maxVelocity)
        {
            rigid_body.linearVelocity = Vector2.ClampMagnitude(rigid_body.linearVelocity, maxVelocity);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 hit = collision.GetContact(0).normal;
        rigid_body.linearVelocity = Vector2.Reflect(rigid_body.linearVelocity, hit) * Time.deltaTime;
    }
}
