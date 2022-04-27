using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ���� UI �ڵ�
public class Make_Slimes : MonoBehaviour
{
    public GameObject MakeSlimeButtonObj; //������ ���� ��ư
    public GameObject DefaultSlimesButtonObj; //���� ������ ���
    public GameObject PromoteSlimesButtonObj; //���� ������ ���

    public void ClickMakeSlimeButton()//������ ���� ��ư Ŭ��
    {
        MakeSlimeButtonObj.SetActive(false);
        DefaultSlimesButtonObj.SetActive(true);
        //���� ������ ��� Ȱ��ȭ
    }

    public void ClickDefalutSlimesButton()//���� ������ ��ư Ŭ��
    {
        DefaultSlimesButtonObj.SetActive(true);
        PromoteSlimesButtonObj.SetActive(false);
        //���� ������ ��� Ȱ��ȭ
    }

    public void ClickPromoteSlimesButton()//���� ������ ��ư Ŭ��
    {
        DefaultSlimesButtonObj.SetActive(false);
        PromoteSlimesButtonObj.SetActive(true);
        //���� ������ ��� Ȱ��ȭ
    }

    public void ClickExit()//�ݱ��ư Ŭ��
    {
        DefaultSlimesButtonObj.SetActive(false);
        PromoteSlimesButtonObj.SetActive(false);
        MakeSlimeButtonObj.SetActive(true);
    }
}
