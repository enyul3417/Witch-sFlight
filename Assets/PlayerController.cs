using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const float flightSpeed = 5.0f; // 플레이어가 날아다니는 속도
    public GameObject laserPrefab; // 발사할 레이저를 저장
    const float shootDelay = 0.3f; // 레이저를 쏘는 주기
    float shootTimer = 0; // 레이저 쿨타임 타이머
    public float moveableRangeX = 4.5f; // x축 이동 가능 범위
    public float moveableRangeY = 4.15f; // y축 이동 가능 범위

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.over == false) // 게임 오버 상태가 아니라면
        {
            // 캐릭터를 움직이는 함수를 프레임마다 호출
            moveControl();
            ShootControl();
        }
    }

    void moveControl()
    {
        // 좌우 이동(키보드 좌우 화살표 또는 a, d키)
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * flightSpeed;

        // 상하 이동(키보드 위 아래 화살표 또는 w, s 키
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * flightSpeed;

        // 이동량을 실제로 반영
        this.gameObject.transform.Translate(distanceX, distanceY, 0);

        // 이동 범위 지정
        this.gameObject.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRangeX, moveableRangeX),
            Mathf.Clamp(transform.position.y, -moveableRangeY, moveableRangeY));
    }

    // rigidBody가 무언가와 충돌할때 호출되는 함수
    // Collider2D other로 부딪힌 객체를 받아옴
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") // 부딪힌 객체의 태그를 비교해서 적인지 판단
        {
            GameManager.instance.decreaseLife(); // 적과 부딪혔으면 체력 감소
        }
    }

    void ShootControl()
    {
        if (shootTimer > shootDelay && Input.GetKey(KeyCode.Space)) // 레이저를 쏠 수 있는 시간인지, 스페이스바를 눌렀는지
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity); // 레이저 생성
            SoundManager.instance.PlayFireSound(); // 공격 효과음
            shootTimer = 0; // 쿨타임 다시 카운트
        }
        shootTimer += Time.deltaTime; // 쿨타임 카운트 증가
    }
}
