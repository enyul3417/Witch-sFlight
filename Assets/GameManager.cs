using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 어디서나 접근할 수 있도록 정적 선언
    public Text scoreText; // 점수 표시하는 Text 객체를 에디터에서 받아오기
    public Text lifeText; // 남은 목숨 표시하는 Text 객체를 에디터에서 받아오기
    public static int score; // 점수
    public static int life; // 목숨
    public static bool over; // 게임 오버 여부

    void Awake()
    {
        if (!instance) // 정적으로 자신을 체크
            instance = this; // 정적으로 자신을 저장
    }

    public void AddScore(int num) // 점수 추가 함수
    {
        score += num;
        scoreText.text = "Score: " + score;
    }

    public void decreaseLife() // 생명력 감소 함수
    {
        life--;
        lifeText.text = "Life: " + life;

        if (life == 0) // 만약 생명이 0이 되면
        { 
            over = true; // 게임 오버 상태가 됨
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        life = 3;
        over = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
