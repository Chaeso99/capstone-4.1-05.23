using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    static public HPManager hPManager;

    static public int CurrentHP; //�÷��̾� ���� ü��
    public int MaxHP = 20; //�÷��̾� �ִ� ü��
    string CurrentHPString = CurrentHP.ToString();

    public GameObject GameOverobj;
    public Text PlayerHP;

    private void Awake()
    {
        hPManager = this;
    }

    void Start()
    {
        CurrentHP = MaxHP; //����ü���� �ִ�ü������ �ʱ�ȭ
    }

    void Update()
    {
        CurrentHPString = CurrentHP.ToString();
        PlayerHP.text = "HP: " + CurrentHPString;
        //ȭ�鿡 ����ü�� ǥ��
        CheckGameOver();//���ӿ��� �Ǻ�
    }

    void CheckGameOver() //�÷��̾� ü���� 0 ���Ϸ� �������� ���ӿ���
    {
        if (CurrentHP < 0)
        {
            GameOverobj.SetActive(true);//���ӿ��� ��ư �� �ؽ�Ʈ Ȱ��ȭ
        }
    }
}
