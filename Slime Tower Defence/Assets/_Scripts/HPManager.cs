using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    static public int CurrentHP; //�÷��̾� ���� ü��
    public int MaxHP = 20; //�÷��̾� �ִ� ü��
    string CurrentHPString = CurrentHP.ToString();

    public Text PlayerHP;

   void Start()
    {
        CurrentHP = MaxHP; //����ü���� �ִ�ü������ �ʱ�ȭ
    }

    void Update()
    {
        CurrentHPString = CurrentHP.ToString();
        PlayerHP.text = "HP: " + CurrentHPString;
        //ȭ�鿡 ����ü�� ǥ��
    }
}
