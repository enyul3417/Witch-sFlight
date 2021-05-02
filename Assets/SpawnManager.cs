using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float span = 2.0f; // 스폰 시간
    float delta = 0.0f; // 측정 시간
    float level = 0.0f; // 난이도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.over == false) // 게임 오버 상태가 아니라면
        {
            this.delta += Time.deltaTime; // 시간 당 delta 증가
            if (this.delta > this.span) // 스폰 시간보다 커지면
            {
                this.delta = 0.0f; // delta 초기화
                GameObject go = Instantiate(enemyPrefab) as GameObject; // 적
                float py = Random.Range(-4.0f, 4.0f); // 랜덤한 범위 지정
                go.transform.position = new Vector3(6, py, 0); // 랜덤한 위치에 적 생성
            }
            this.level += Time.deltaTime; // 시간이 지날수록 level 증가
            if (this.level > 30.0f) // 30초 마다 스폰 속도 빨라짐 -> 난이도 상승
            {
                this.level = 0.0f; // level 시간 초기화
                this.span = this.span / 2.0f; // 속도가 2배로 빨라짐
            }  
        }
    }
}
