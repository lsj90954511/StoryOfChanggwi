using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// 인벤토리 UI : 인벤토리에 아이템 추가시 UI 화면 변경
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        // UI_Canvas 내 itemSlotContainer와 itemSlotTemplate 찾기
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        Debug.Log("슬롯컨테이너 : " + itemSlotContainer);
        Debug.Log("슬롯템플릿 : " + itemSlotTemplate);
    }

    // UIInventory set
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems();
    }

    // EventHandler
    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    // UIInventory
    private void RefreshInventoryItems()
    {
        // itemSlotContainer의 자식(Clone) 제거
        //////////////////if문 원래 없었음
        if (itemSlotContainer != null)
        {
            foreach (Transform child in itemSlotContainer)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }
        }
        

        int x = 0; // x위치
        float itemSlotCellSize = 160f; // itemSlotCell 크기
        // itemList 내에 있는 item
        foreach (Item item in inventory.GetItemList())
        {
            // x 좌표 위치에 ItemSlot Clone 추가
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, 0);

            // 아이템 종류에 따라 Sprite 변경

            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            // 인벤토리 내에 있는 아이템 개수에 따라 Text 변경
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1) // item amount 가 1보다 클 경우
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }

            x++;
        }
    }
}
