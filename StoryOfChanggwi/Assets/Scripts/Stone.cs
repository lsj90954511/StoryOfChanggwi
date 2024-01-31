using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    const int maxCount = 6;
    Color activeColor = Color.blue;
    Color deactiveColor = Color.red;

    [SerializeField] private int count = 0;
    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Activate(5);
    }

    public void Activate(int _count)
    {
        count += _count;

        if(count > 0)
        {
            sprite.color = activeColor * (float)(count / maxCount);
        }
        else if(count < 0)
        {
            sprite.color = deactiveColor * (float)( -1 * count / maxCount);
        }
    }

}
