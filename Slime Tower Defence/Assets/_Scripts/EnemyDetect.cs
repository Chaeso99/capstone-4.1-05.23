using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� �ִ��� Ȯ���ϴ� �ڵ�
public class EnemyDetect : MonoBehaviour
{
    public List<GameObject> enemyList; // �� ����Ʈ

    void Start()
    {
        Renderer renderer;
        renderer = GetComponent<Renderer>();
        Color color = renderer.material.color;
        color.a = 0.3f;
        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ���� ������ ������ ���� �߰�
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other enter tag : " + other.tag);

        if (other.tag == "Monster")
        {
            enemyList.Add(other.gameObject);
        }
    }

    // ���� �������� ������ ���� ����
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("other exit tag : " + other.tag);

        if (other.tag == "Monster")
        {
            enemyList.Remove(other.gameObject);
        }
    }

    // ���� ���� ���� �� ���� ��������
    public GameObject GetTarget()
    {
        return enemyList[0];
    }

    // ���� �ִ��� Ȯ��
    public bool EnemyDetectCheck()
    {
        Debug.Log(enemyList.Count);

        if (enemyList.Count <= 0)
        {
            return false;
        }

        return true;
    }
}
