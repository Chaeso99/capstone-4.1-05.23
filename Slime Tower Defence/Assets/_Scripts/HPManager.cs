using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public int damage = 1; //몬스터 통과 시 데미지
    static public int CurrentHP; //플레이어 현재 체력
    public int MaxHP = 20; //플레이어 최대 체력

    public GameObject GameOverobj;
    public Text PlayerHP;

    private void Awake()
    {
        CurrentHP = MaxHP; //현재체력을 최대체력으로 초기화
    }

    void Update()
    {
        PlayerHP.text = "HP: " + CurrentHP;
        //화면에 현재체력 표시
    }

    void CheckGameOver() //플레이어 체력이 0 이하로 내려가면 게임오버
    {
        if (CurrentHP <= 0)
        {
            GameOverobj.SetActive(true);//게임오버 버튼 및 텍스트 활성화
        }
    }

    void OnTriggerEnter(Collider other) //몬스터와 충돌 감지, 몬스터 파괴 및 플레이어 체력 감소
    {
        if (other.tag == "Monster" || HPManager.CurrentHP > 0)
        {
            CurrentHP = CurrentHP - damage; //플레이어 체력감소
            Destroy(other.gameObject); //몬스터 파괴
            CheckGameOver();//게임오버 판별

            return;
        }
    }
}
