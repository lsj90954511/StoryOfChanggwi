using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 옆 발판들로 이동할 수 있게 해주는 버튼 생성 Generator
public class MoveButtonGenerator : MonoBehaviour
{
    // 대각선 방향 벡터
    private static readonly Vector2 leftUp = new Vector2(-1f, 1f);     // 왼쪽 위 대각선
    private static readonly Vector2 rightUp = new Vector2(1f, 1f);     // 오른쪽 위 대각선
    private static readonly Vector2 leftDown = new Vector2(-1f, -1f);  // 왼쪽 아래 대각선
    private static readonly Vector2 rightDown = new Vector2(1f, -1f);  // 오른쪽 아래 대각선

    // 각 발판 위치에서 갈 수 있는 방향들을 저장한 배열
    /**
     * 첫 번째 인덱스 == 해당 발판
     * 두 번째 인덱스 == 해당 발판에서 갈 수 있는 방향들
     * 상하좌우, 대각선 방향 벡터로 표현할 수 없는 방향은 따로 값을 넣음
    **/
    public Vector3[][] possibleDirections = {
        new Vector3[] { leftUp, rightUp, Vector2.left, Vector2.right, Vector2.down },                           // 발판 1
        new Vector3[] { new Vector2(-1f, 0.2f), new Vector2(1f, 0.2f)},                                         // 발판 2
        new Vector3[] { new Vector2(-1f, -0.3f), new Vector2(1f, -0.3f)},                                       // 발판 3
        new Vector3[] { Vector2.down},                                                                          // 발판 4
        new Vector3[] { rightDown},                                                                             // 발판 5
        new Vector3[] { leftUp, rightDown},                                                                     // 발판 6
        new Vector3[] { leftDown, Vector2.right},                                                               // 발판 7
        new Vector3[] { Vector2.right},                                                                         // 발판 8
        new Vector3[] { new Vector2(-1f, 0.6f), rightDown},                                                     // 발판 9
        new Vector3[] { leftUp, Vector2.down},                                                                  // 발판 10
        new Vector3[] { Vector2.up, Vector2.left},                                                              // 발판 11
        new Vector3[] { new Vector2(1f, 0.6f), leftDown, rightDown},                                            // 발판 12
        new Vector3[] { rightUp, Vector2.down},                                                                 // 발판 13
        new Vector3[] { Vector2.up, new Vector2(-1f, 0.4f), new Vector2(-1f, -0.4f), new Vector2(1f, -0.4f)},   // 발판 14
        new Vector3[] { leftUp, Vector2.up, new Vector2(1f, -0.3f), new Vector2(0.3f, -1f)},                    // 발판 15
        new Vector3[] { new Vector2(-0.4f, 1f), new Vector2(1f, 0.4f), new Vector2(1f, -0.3f)},                 // 발판 16
        new Vector3[] { new Vector2(-1f, -0.3f), new Vector2(-1f, 0.5f), rightUp},                              // 발판 17
        new Vector3[] { leftDown, Vector2.up}                                                                   // 발판 18
    };

    void Start()
    {
        
    }

    // 방향 확인(디버그)용
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        foreach (var direction in possibleDirections[0])
        {
            Vector3 playerPos = transform.position + new Vector3(0f, -2f, 0f);
            Gizmos.DrawLine(playerPos, playerPos + direction);
        }
    }
}
