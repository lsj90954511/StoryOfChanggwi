using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    bool isPickUp;
    bool isPlayerPlumExist;
    GameObject pickUpItem;

    // Start is called before the first frame update
    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        if (isPickUp && Input.GetKeyDown(KeyCode.Z))
        {
            pickUpItem.SetActive(false);
            if (pickUpItem.name == "PlayerStone")
            {
                Debug.Log("봉인석 조각 획득");
                inventory.AddItem(new Item { itemType = Item.ItemType.PlayerStone, amount = 1 });
            }
            if (pickUpItem.name == "PlayerPlum")
            {
                Debug.Log("매화 열매 획득");
                inventory.AddItem(new Item { itemType = Item.ItemType.PlayerPlum, amount = 1 });
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            isPlayerPlumExist = inventory.IsPlayerPlumExist();
            if (isPlayerPlumExist)
                inventory.RemoveItem(new Item { itemType = Item.ItemType.PlayerPlum, amount = 1 });
            else
                Debug.Log("아이템이 존재하지 않습니다");
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("PlayerItem"))
        {
            isPickUp = true;
            if(collider.gameObject.name == "PlayerStone")
            {
                pickUpItem = collider.gameObject;
            }
            if(collider.gameObject.name == "PlayerPlum")
            {
                pickUpItem = collider.gameObject;
            }
        }
    }

}
