using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip explosionSound; // 폭발 소리
    public AudioClip fireSound; // 공격 소리
    AudioSource myAudio; // AudioSource 컴포넌트를 변수로 담기
    public static SoundManager instance; // 자기 자신을 변수로 담기

    void Awake() //Start보다도 먼저, 객체가 생성될때 호출됩니다
    {
        if (SoundManager.instance == null) //instance가 비어있는지 검사합니다.
        {
            SoundManager.instance = this; //자기자신을 담습니다.
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();  // AudioSource 오브젝트를 변수로 담음

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExplosionSound() // 폭발 시 재생
    {
        myAudio.PlayOneShot(explosionSound);
    }
    
    public void PlayFireSound() // 공격 시 재생
    {
        myAudio.PlayOneShot(fireSound);
    }
}
