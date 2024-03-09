using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 PickUp : 아이템 획득 및 사용
public class PickUp : MonoBehaviour
{
    [SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;
    bool isPickUp; // 픽업 가능한 상태 여부 저장
    bool isPlayerItemExist; // 인벤토리 내에 PlayerItem 아이템 존재 여부 저장
    GameObject pickUpItem; // 픽업 한 아이템의 게임 오브젝트 저장
    PlayerItemSpawn playerItemSpawn;


    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
        playerItemSpawn = FindObjectOfType<PlayerItemSpawn>();
    }

    private void Update()
    {
        // 아이템을 픽업 가능한 상태에서 Z 키를 누르면
        if (isPickUp && Input.GetKeyDown(KeyCode.Z))
        {
            // 픽업한 아이템의 게임 오브젝트 비활성화
            pickUpItem.SetActive(false);
            if (pickUpItem.name == "PlayerItem") // 픽업한 아이템이 PlayerStone 인 경우
            {
                Debug.Log("주술 재료 획득");
                playerItemSpawn.FindStone(pickUpItem);
                inventory.AddItem(new Item { itemType = Item.ItemType.PlayerItem, amount = 1 });
            }
            /*
            if (pickUpItem.name == "PlayerPlum") // 픽업한 아이템이 PlayerPlum 인 경우
            {
                Debug.Log("매화 열매 획득");
                inventory.AddItem(new Item { itemType = Item.ItemType.PlayerPlum, amount = 1 });
            }
            */
        }

        // Space 키 (아이템 사용) 를 누르면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlayerItemExist = inventory.IsPlayerItemExist();
            if (isPlayerItemExist) // 인벤토리에 PlayerItem 아이템 있는 경우에만 RemoveItem 실행
            {
                inventory.RemoveItem(new Item { itemType = Item.ItemType.PlayerItem, amount = 1 });
                // *********************창귀 체력 감소 함수 추가*************************
            }
                
            else
                Debug.Log("아이템이 존재하지 않습니다");
        }
    }

    // 플레이어와 아이템 충돌처리
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag.Equals("Item"))
        {
            isPickUp = true;
            if(collider.gameObject.name == "PlayerItem")
            {
                pickUpItem = collider.gameObject;
            }
            /*
            if(collider.gameObject.name == "PlayerPlum")
            {
                pickUpItem = collider.gameObject;
            }
            */
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Equals("Item"))
        {
            isPickUp = false;
        }
    }

}
