using System.Linq;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class level : MonoBehaviour
{
    public GameObject brick;

    byte[] colors = new byte[] { 234, 56, 56 };

    void Start()
    {

        float vertical_separation = (float)(brick.transform.localScale.y + 0.2);
        float horizontal_separation = (float)(brick.transform.localScale.x + 0.1);

        SpriteRenderer sprite = brick.GetComponent<SpriteRenderer>();

        for (float h = 4.5f; h > 2; h -= vertical_separation)
        {
            for (int j = 0; j < colors.Length; j += 1)
            {
                colors[j] = (byte)Random.Range(0, 255);
            }
            for (float i = -9.75f; i < 11; i += horizontal_separation)
            {
                sprite.color = new Color32(colors[0], colors[1], colors[2], 255);
                Instantiate(brick, new Vector3(i, h, 0), Quaternion.identity);
            }
        }
        Debug.Log(sprite.color.a);
    }
}
