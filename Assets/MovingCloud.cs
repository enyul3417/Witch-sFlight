using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public float movingSpeed = 0.005f; // 이동 속도
    public bool moveLeft = true; // 왼쪽으로 이동한다는 뜻

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.over == false) // 게임 오버 상태가 아니라면
        {
            // x축으로 이동할 위치
            Vector3 newPosition = transform.position;

            if (newPosition.x < -7.5f) // 만약 x 좌표가 -7.5 보다 작아지면
            {
                newPosition.x = 7.5f; // x좌표를 7.5로 변경
            }

            newPosition.x = newPosition.x - movingSpeed; // 이동 속도에 맞춰 이동

            // 구름의 위치 변경
            transform.SetPositionAndRotation(newPosition, Quaternion.identity);
        }
    }
}
