using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�� ��ȯ�� ���� ��ũ��Ʈ
public class SceneDirector : MonoBehaviour
{
   public void GameSceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TitleSceneChange()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
