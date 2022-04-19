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

    public float attackSpeed = 2f; // ���� �ӵ�

    float timer = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        // ���� �����ȿ� �ִ����� �Ź� üũ
        if (enemyDetect.EnemyDetectCheck())
        {
            targetEnemy = enemyDetect.GetTarget(); // ���� �����ȿ� ������ �߰�
            if (targetEnemy != null)
            {
                // ���� �ٶ�
                RotateToTarget(targetEnemy);

                
                if (timer > attackSpeed)
                {
                    Attack(targetEnemy);
                    timer = 0;
                }
            }
        }
    }

    IEnumerator AttackCheck()
    {
        yield return new WaitForSeconds(attackSpeed);

    }

    // ������ ���� �Լ�
    void Attack(GameObject target)
    {
        if (isAttack) // ������ �������� Ȯ��
        {
            //isAttack = false; // ������ �̹� ���� ���̹Ƿ� ����

            //RotateToTarget(target); // �� �ٶ󺸱�
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x,
                transform.position.y, transform.position.z), Quaternion.identity); // ���� ������ ����

            bullet.GetComponent<Bullet>().SetTarget(target); // ���� �����տ� �� ���� ����

            //isAttack = true; // ���� ����
        }

    }

    // ���� �ٶ󺸴� �Լ�
    void RotateToTarget(GameObject target)
    {
        transform.LookAt(target.transform);
    }
}
