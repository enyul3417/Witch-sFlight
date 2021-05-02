using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayGame() // 게임 시작
    {
        SceneManager.LoadScene("Stage1"); // Stage1씬 불러오기
    }
}
