using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject attackTarget; // �����ؾ��� �� ����
    public float destroyTime = 5f; // ������ �������� ��� ���
    public float speed;
    public float damage = 50f;

    void Start()
    {

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
    public void SetTarget(GameObject target, float bulletSpeed)
    {
        attackTarget = target;
        speed = bulletSpeed;
        
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
            other.GetComponent<Enemy_HP>().TakeDamage(damage);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
