using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� �ִ��� Ȯ���ϴ� �ڵ�
public class EnemyDetect : MonoBehaviour
{
    public List<GameObject> enemyList; // �� ����Ʈ
    public Slime parentTower; // �θ��� Ÿ��
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // ���� ������ ������ ���� �߰�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            enemyList.Add(other.gameObject);
        }
    }

    // ���� �������� ������ ���� ����
    private void OnTriggerExit(Collider other)
    {

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
