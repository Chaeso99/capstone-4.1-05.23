using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject attackTarget; // �����ؾ��� �� ����
    public float destroyTime = 10f; // ������ �������� ��� ���
    public float speed;

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
        Debug.Log("Monster hit");

        if (other.tag == "Monster")
        {
            // ���÷��� ������ ����
            Collider[] hitCol = Physics.OverlapSphere(transform.position, 3.0f);
            Debug.Log("Monster out");

            foreach (Collider hit in hitCol)
            {
                if (hit.gameObject.tag != "Monster") break;

                hit.gameObject.GetComponent<Enemy_1>().Damage(5);

                Debug.Log("Monster Damage");
            }

            // ���÷��� ������ ��

            Destroy(this.gameObject, 0.1f);
        }
    }
}
