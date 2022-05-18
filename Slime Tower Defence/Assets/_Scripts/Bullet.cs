using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject attackTarget; // �����ؾ��� �� ����
    public float destroyTime = 10f; // ������ �������� ��� ���
    public float speed;
    public int damage;

    public bool isSplash = false;

    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (attackTarget == null)
        {
            Destroy(this.gameObject, 0.1f);
        }
        else
        {
            MoveToTarget();
        }
    }

    // ���� ������ �����ϴ� �Լ�
    public void SetTarget(GameObject target, float bulletSpeed, int bulletDamage)
    {
        attackTarget = target;
        speed = bulletSpeed;
        damage = bulletDamage;
    }

    // ���� ���� ���󰡴� �Լ�
    void MoveToTarget()
    {
        if (attackTarget == null)
        {
            return;
        }

        if (speed <= 0)
        {
            return;
        }

        // �� ��ġ�� ����
        transform.position =
            Vector3.MoveTowards(this.transform.position, attackTarget.transform.position, speed);

    }

    // ���� �ε��� �� ������� �Լ�
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            // ���÷��� ������ ����
            Collider[] hitCol = Physics.OverlapSphere(transform.position, 10.0f);

            foreach (Collider hit in hitCol)
            {
                if (hit.gameObject.tag != "Monster")
                {
                    continue;
                }

                hit.gameObject.GetComponent<Enemy_1>().Damage(damage);

            }

            // ���÷��� ������ ��

            Destroy(this.gameObject, 0.1f);
        }
    }
}
