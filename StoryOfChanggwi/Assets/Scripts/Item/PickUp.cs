using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 PickUp : 아이템 획득 및 사용
public class PickUp : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    bool isPickUp; // 픽업 가능한 상태 여부 저장
    bool isPlayerPlumExist; // 인벤토리 내에 PlayerPlum 아이템 존재 여부 저장
    GameObject pickUpItem; // 픽업 한 아이템의 게임 오브젝트 저장

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void Update()
    {
        // 아이템을 픽업 가능한 상태에서 Z 키를 누르면
        if (isPickUp && Input.GetKeyDown(KeyCode.Z))
        {
            // 픽업한 아이템의 게임 오브젝트 비활성화
            pickUpItem.SetActive(false);
            if (pickUpItem.name == "PlayerStone") // 픽업한 아이템이 PlayerStone 인 경우
            {
                Debug.Log("봉인석 조각 획득");
                inventory.AddItem(new Item { itemType = Item.ItemType.PlayerStone, amount = 1 });
            }
            if (pickUpItem.name == "PlayerPlum") // 픽업한 아이템이 PlayerPlum 인 경우
            {
                Debug.Log("매화 열매 획득");
                inventory.AddItem(new Item { itemType = Item.ItemType.PlayerPlum, amount = 1 });
            }
        }

        // X 키 (아이템 사용) 를 누르면
        if (Input.GetKeyDown(KeyCode.X))
        {
            isPlayerPlumExist = inventory.IsPlayerPlumExist();
            if (isPlayerPlumExist) // 인벤토리에 PlayerPlum 아이템 있는 경우에만 RemoveItem 실행
                inventory.RemoveItem(new Item { itemType = Item.ItemType.PlayerPlum, amount = 1 });
            else
                Debug.Log("아이템이 존재하지 않습니다");
        }
    }

    // 플레이어와 아이템 충돌처리
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

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Equals("PlayerItem"))
        {
            isPickUp = false;
        }
    }

}
