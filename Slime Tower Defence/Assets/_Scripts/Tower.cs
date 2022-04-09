using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    float attackTimer;

    bool isAttack = true; // ������ �������� Ȯ��

    public EnemyDetect enemyDetect; // �� Ȯ���� ���� ������Ʈ
    public GameObject bulletPrefab; // ���� ������

    GameObject targetEnemy = null; // �� ����

    public float attackSpeed = 10f; // ���� �ӵ�

    void Start()
    {

    }

    void Update()
    {
        // ���� �����ȿ� �ִ����� �Ź� üũ
        if (enemyDetect.EnemyDetectCheck())
        {
            targetEnemy = enemyDetect.GetTarget();
            if (targetEnemy != null)
            {
                Attack(targetEnemy);
            }
        }
    }

    // ������ ���� �Լ�
    void Attack(GameObject target)
    {
        Debug.Log("Attacking"); // ���� �׽�Ʈ

        if (isAttack) // ������ �������� Ȯ��
        {
            isAttack = false; // ������ �̹� ���� ���̹Ƿ� ����

            RotateToTarget(target); // �� �ٶ󺸱�
            GameObject bullet = Instantiate(bulletPrefab); // ���� ������ ����
            bullet.GetComponent<Bullet>().SetTarget(target); // ���� �����տ� �� ���� ����

            isAttack = true; // ���� ����
        }

    }

    // ���� �ٶ󺸴� �Լ�
    void RotateToTarget(GameObject target)
    {
        transform.LookAt(target.transform);
    }
}
