using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject attackTarget; // �����ؾ��� �� ����
    public float destroyTime = 5f; // ������ �������� ��� ���

    void Start()
    {

    }

    void Update()
    {
        MoveToTarget();
    }

    // ���� ������ �����ϴ� �Լ�
    public void SetTarget(GameObject target)
    {
        attackTarget = target;
    }

    // ���� ���� ���󰡴� �Լ�
    void MoveToTarget()
    {
        if (attackTarget != null)
        {
            // �� ��ġ�� ����
            transform.position = 
                Vector3.MoveTowards(this.transform.position, attackTarget.transform.position, 0.1f);
        }
        else
        {
            Destroy(this);
        }
    }

    // ���� �ε��� �� ������� �Լ�
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Monster")
        {
            Destroy(this.gameObject);
        }
    }
}
