using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float movementHorizontal;

    public float maxX = 10.5f;
    public float speed = 5.0f;
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        Debug.Log(movementHorizontal);
        if ((movementHorizontal < 0 && transform.position.x > -maxX) || (movementHorizontal > 0 && transform.position.x < maxX))
        {
            transform.position += movementHorizontal * speed * Time.deltaTime * Vector3.right;
        }
    }
}
