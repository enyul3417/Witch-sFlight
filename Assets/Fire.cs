using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private const float moveSpeed = 5.0f; // 이동 속도
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90); // 그림이 돌아가 있는 관계로 오브젝트 방향 회전함
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0); // 불 이동
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy") // 부딪힌 객체가 적이라면
        {
            Instantiate(explosionPrefab, this.transform.position, Quaternion.identity); // 폭발 이펙트 생성
            SoundManager.instance.PlayExplosionSound(); // 폭발음 재생
            Destroy(other.gameObject);// 부딪힌 적 파괴
            GameManager.instance.AddScore(50); // 점수 획득
            Destroy(this.gameObject);// 자신을 파괴 
        }
    }

    void OnBecameInvisible() // 화면 밖으로 나가면
    {
        Destroy(this.gameObject); // 자기 자신 삭제
    }
}
