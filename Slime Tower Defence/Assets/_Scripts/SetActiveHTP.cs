using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HowToPlay ������Ʈ Ȱ��ȭ/ ��Ȱ��ȭ
public class SetActiveHTP : MonoBehaviour
{
    public GameObject HowToPlayobj;

    public void ClickHTPButton()//HowToPlayButton Ŭ����
    {
        HowToPlayobj.SetActive(true); 
        //HowToPlayDiscribe������Ʈ Ȱ��ȭ
    }

    public void ClickHTP()//HowToPlayDescribe Ŭ����
    {
        HowToPlayobj.SetActive(false);
        //HowToPlayDiscribe������Ʈ ��Ȱ��ȭ
    }
}
