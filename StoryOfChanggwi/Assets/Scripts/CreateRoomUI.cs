using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField]
    private List<Button> changgwiCountButtons;

    [SerializeField]
    private List<Button> personCountButtons;

    [SerializeField]
    private List<Button> stoneCountButtons;

    private CreateGameRoomData roomData;

    void Start()
    {
        //�� ������ �⺻ ����
        roomData = new CreateGameRoomData() { changgwiCount = 2, personCount = 5, stoneCount = 5 };
    }

    //â�� �� ���� ��
    public void UpdateChanggwiCount(int count)
    {
        roomData.changgwiCount = count;

        //�ش� ��ư�� �׵θ� ���̰� ��.(���� �׵θ� �̹��� �߰��ؾ���)
        for(int i = 0; i < changgwiCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                changgwiCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                changgwiCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    //�ֹ� �� ���� ��
    public void UpdatePersonCount(int count)
    {
        roomData.personCount = count;

        //�ش� ��ư�� �׵θ� ���̰� ��.(���� �׵θ� �̹��� �߰��ؾ���)
        for (int i = 0; i < personCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                personCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                personCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    //���μ� �� ���� ��
    public void UpdateStoneCount(int count)
    {
        roomData.stoneCount = count;

        //�ش� ��ư�� �׵θ� ���̰� ��.(���� �׵θ� �̹��� �߰��ؾ���)
        for (int i = 0; i < stoneCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                stoneCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                stoneCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    public void CreateRoom()
    {
        var manager = RoomManager.singleton;

        //�� ����


        //���� ���� + ���� ����
        manager.StartHost();
    }
}

//���� ����� ���� ������ ����, ��������� �濡 ������ ����
public class CreateGameRoomData
{
    public int changgwiCount; //â�� ��
    public int personCount; //�ֹ� ��
    public int stoneCount; //���μ� ��
}