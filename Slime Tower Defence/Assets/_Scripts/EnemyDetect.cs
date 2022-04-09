using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� �ִ��� Ȯ���ϴ� �ڵ�
public class EnemyDetect : MonoBehaviour
{
    public List<GameObject> enemyList; // �� ����Ʈ
    public Tower parentTower; // �θ��� Ÿ��
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
        return FindEnemyClosestToTower();
    }

    // ���� �ִ��� Ȯ��
    public bool EnemyDetectCheck()
    {

        if (enemyList.Count <= 0)
        {
            return false;
        }

        return true;
    }

    // Ÿ���� ���� ����� �� ã��
    public GameObject FindEnemyClosestToTower()
    {
        GameObject target = null;
        float minDir = -1;

        foreach (GameObject enemy in enemyList)
        {
            // �������� ����ִ� ����Ʈ���� �����۰� �÷��̾��� �Ÿ��� ���
            float dir = Vector3.Distance(transform.position, enemy.transform.position);

            // ù ��� �Ǵ� �ּ� �Ÿ����� ������ �ش� ���������� ����
            if (minDir > dir || minDir == -1)
            {
                minDir = dir;
                target = enemy;
            }
        }

        return target;
    }
}
