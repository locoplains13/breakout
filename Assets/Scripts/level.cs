using System.Linq;
using UnityEngine;

public class level : MonoBehaviour
{
    public GameObject brick;
    public int bricks;

    byte[] colors = new byte[] { 234, 56, 56 };

    public Gradient gradient;

    void Start()
    {
        float height = 2f;
        float length = 10f;
        GenerateLevel(height, length);
    }

    public void GenerateLevel(float height, float length)
    {
        bricks = 0;
        float vertical_separation = (float)(brick.transform.localScale.y + 0.2);
        float horizontal_separation = (float)(brick.transform.localScale.x + 0.1);

        SpriteRenderer sprite = brick.GetComponent<SpriteRenderer>();

        for (float h = 4.5f; h > height; h -= vertical_separation)
        {
            for (int j = 0; j < colors.Length; j += 1)
            {
                colors[j] = (byte)Random.Range(0, 255);
            }
            for (float i = -9.75f; i < length; i += horizontal_separation)
            {
                bricks++;

                // sprite.color = gradient.Evaluate((float)h / (length - 1));
                sprite.color = new Color32(colors[0], colors[1], colors[2], 255);
                Instantiate(brick, new Vector3(i, h, 0), Quaternion.identity);
            }
        }
    }
}
