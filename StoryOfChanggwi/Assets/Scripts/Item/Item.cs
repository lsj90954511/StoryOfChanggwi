using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 아이템 : ItemType, Sprite, IsStackable 관리
[Serializable]
public class Item
{
    public enum ItemType
    {
        PlayerStone,
        PlayerPlum,
        MonsterStone
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.PlayerStone: return ItemAssets.Instance.playerStoneSprite;
            case ItemType.PlayerPlum: return ItemAssets.Instance.playerPlumSprite;
            case ItemType.MonsterStone: return ItemAssets.Instance.monsterStoneSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default :
                case ItemType.PlayerStone:
                case ItemType.PlayerPlum:
                case ItemType.MonsterStone:
                return true;
        }
    }
}
