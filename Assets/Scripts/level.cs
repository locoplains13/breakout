using UnityEditor.ShaderGraph;
using UnityEngine;

public class level : MonoBehaviour
{
    public GameObject brick;


    void Start()
    {
        float vertical_separation = (float)(brick.transform.localScale.y + 0.2);
        float horizontal_separation = (float)(brick.transform.localScale.x + 0.1);


        for (float h = 4; h > 2; h -= vertical_separation)
        {
            for (float i = (float)-9.75; i < 11; i += horizontal_separation)
            {
                Instantiate(brick, new Vector3(i, h, 0), Quaternion.identity);
            }
        }
        SpriteRenderer sprite = brick.GetComponent<SpriteRenderer>();
        Debug.Log(sprite.color.a);
    }
}
