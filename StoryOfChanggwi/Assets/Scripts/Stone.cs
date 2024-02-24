using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{

    // Default State
    const int maxCount = 6;
    Color activeColor = Color.blue;
    Color deactiveColor = Color.red;

    // Stone State
    [SerializeField] private int count = 0;
    [SerializeField] public bool isActive = false;

    // Component
    [SerializeField] public StoneManager sManager;
    [SerializeField] private SpriteRenderer sprite;

    // UI
    [SerializeField] private Text countText;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }

    public void ConnectUI(Transform _canvas)
    {
        countText = Instantiate(_canvas.GetChild(0).GetChild(0).gameObject, _canvas).GetComponent<Text>();
        countText.transform.position = transform.position + countText.transform.up * 1.5f;
        countText.text = count.ToString();
    }

    public void Activate(int _count)
    {
        count += _count;

        if (count >= maxCount)
        {
            // Activate
            if (!isActive)
            {
                print("활성화");

                isActive = true;
                sManager.UpdateStone(isActive);
            }

            count = maxCount;
        }
        else if (count < maxCount)
        {
            if (isActive)
            {
                print("비활성화");

                isActive = false;
                sManager.UpdateStone(isActive);
            }
            if (count <= -maxCount)
                count = -maxCount;
        }


        if (count > 0)       // Plus
        {
            sprite.color = Color.Lerp(Color.white, activeColor, 1.0f * count / maxCount);
            countText.color = activeColor;
        }
        else if(count < 0)  // Minus
        {
            sprite.color = Color.Lerp(Color.white, deactiveColor, -1.0f * count / maxCount);
            countText.color = deactiveColor;
        }
        else                // Default
        {
            sprite.color = Color.white;
            countText.color = Color.white;
        }

        sprite.color += new Color(0, 0, 0, 1);
        countText.text = count.ToString();
    }

    IEnumerator PlayerCollision(Collider2D _collision)
    {
        PlayerControl player = _collision.GetComponent<PlayerControl>();
        while (true)
        {
           player.ActivateStone(this);
            yield return null;  
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerControl>().EnterStone(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerControl>().ExitStone();
        }
    }

}
