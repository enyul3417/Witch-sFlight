using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private int bestScore; // 최고 점수
    public Text resultScore; 
    public Text highScore;
    public GameObject resultUI;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore")) // 해당 키가 존재한다면
        {
            bestScore = PlayerPrefs.GetInt("HighScore"); // 최고 점수는 저장되어 있던 HighScore
        }
        else // 존재하지 않는다면
        {
            bestScore = 0; // 최고 점수는 0
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.over == true) // 게임이 오버되면
        {
            resultUI.SetActive(true); // 결과 UI가 나타남
            int result = GameManager.score; // 내 점수
            resultScore.text = "My Score: " + result; // 내 점수 나타내기
            highScore.text = "High Score: " + bestScore; // 최고 점수 나타내기

            if (bestScore < result) // 최고 점수보다 현재 내 점수가 더 높다면
                PlayerPrefs.SetInt("HighScore", result); // 최고 점수 변경
        }
    }

    public void onRestry() // 다시 시작 함수
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goMain() // 메인 메뉴로 가는 함수
    {
        SceneManager.LoadScene("Main");
    }
}
