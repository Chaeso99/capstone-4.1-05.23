using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public float speed = 10f;//���� �ӵ�
    public float destroy_time = 0.1f;//���������� ���� ���� �ð�

    private Transform target;//Transform
    private int wavepointIndex = 0;//TwoWaypoints�� �ε���

    void Start()
    {
        target = TwoWaypoints.tpoints[0];//ù��° TwoWaypoint ����
    }
    //�� ���Ĵ� OneWaypoints��� scrpit �����Ͻø� ��
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= TwoWaypoints.tpoints.Length - 1)
        {
            Destroy(gameObject, destroy_time);
            return;
        }

        wavepointIndex++;
        target = TwoWaypoints.tpoints[wavepointIndex];

    }
}