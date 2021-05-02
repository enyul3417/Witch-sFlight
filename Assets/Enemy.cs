using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float flightSpeed = 1.3f; // 이동 속도
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.over == false) // 게임 오버 상태가 아니라면
        {
            transform.Translate(-1 * flightSpeed * Time.deltaTime, 0, 0); // -x의 방향으로 적을 계속 이동
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // 부딪힌 객체의 태그를 비교해서 플레이어인지 판단
        { 
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity); // 폭발 이펙트 생성
            SoundManager.instance.PlayExplosionSound(); // 폭발음 재생
            Destroy(this.gameObject); // 자신을 파괴 
        }
    }

    void OnBecameInvisible() // 화면 밖으로 나가면
    {
        Destroy(this.gameObject); // 자기 자신 삭제
    }
}
