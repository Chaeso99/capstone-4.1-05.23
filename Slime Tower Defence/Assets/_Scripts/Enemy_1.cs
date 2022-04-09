using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public float speed = 10f;//���� �ӵ�
    public float destroy_time = 0.1f;//���������� ���� ���� �ð�

    private Transform target;//Transform
    private int wavepointIndex = 0;//OneWaypoints�� �ε���

    void Start()
    {
        target = OneWaypoints.opoints[0];//ù��° OneWaypoint ����
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;// ������ ������ ���ϴ� ��
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//�̵����� �Լ�

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)//Vector3 a(transform.position)�� Vector3 b(target.position)�� ������ �Ÿ��� 0.4f���� ������...
        {
            GetNextWaypoint();//���� ������ Ž���ϴ� �Լ�
        }
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= OneWaypoints.opoints.Length - 1)//���� ������(wavepointIndex)�� ������ ������(Waypoints.points.Length -1)�̶��
        {
            Destroy(gameObject, destroy_time);//�� ��ũ��Ʈ�� ������ �ִ� ���� ��ü�� �ı�
            return;
        }

        wavepointIndex++;
        target = OneWaypoints.opoints[wavepointIndex];//�������� ���� �������� ����

    }
}