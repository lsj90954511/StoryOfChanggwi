using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 에셋(Sprite) 관리
public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite playerStoneSprite;
    public Sprite playerPlumSprite;
    public Sprite monsterStoneSprite;
}
