using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public int damage = 1; //���� ��� �� ������
    static public int CurrentHP; //�÷��̾� ���� ü��
    public int MaxHP = 20; //�÷��̾� �ִ� ü��

    public GameObject GameOverobj;
    public Text PlayerHP;

    private void Awake()
    {
        CurrentHP = MaxHP; //����ü���� �ִ�ü������ �ʱ�ȭ
    }

    void Update()
    {
        PlayerHP.text = "HP: " + CurrentHP;
        //ȭ�鿡 ����ü�� ǥ��
    }

    void CheckGameOver() //�÷��̾� ü���� 0 ���Ϸ� �������� ���ӿ���
    {
        if (CurrentHP <= 0)
        {
            GameOverobj.SetActive(true);//���ӿ��� ��ư �� �ؽ�Ʈ Ȱ��ȭ
        }
    }

    void OnTriggerEnter(Collider other) //���Ϳ� �浹 ����, ���� �ı� �� �÷��̾� ü�� ����
    {
        if (other.tag == "Monster" || HPManager.CurrentHP > 0)
        {
            CurrentHP = CurrentHP - damage; //�÷��̾� ü�°���
            Destroy(other.gameObject); //���� �ı�
            CheckGameOver();//���ӿ��� �Ǻ�

            return;
        }
    }
}
