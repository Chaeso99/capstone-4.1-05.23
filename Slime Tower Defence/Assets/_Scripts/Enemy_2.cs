using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    private static int fruitsindex = 3;
    private Transform target;//Transform
    private int wavepointIndex = 0;//TwoWaypoints�� �ε���

    public int enemy_hp = 10;
    public float speed = 10f;//���� �ӵ�
    public float destroy_time = 0.1f;//���������� ���� ���� �ð�
    public Transform[] fruits = new Transform[fruitsindex];//
    public int spawnrandom = 20;

    void Start()
    {
        target = TwoWaypoints.tpoints[0];//ù��° OneWaypoint ����
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;// ������ ������ ���ϴ� ��
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//�̵����� �Լ�

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)//Vector3 a(transform.position)�� Vector3 b(target.position)�� ������ �Ÿ��� 0.4f���� ������...
        {
            GetNextWaypoint();//���� ������ Ž���ϴ� �Լ�
        }

        destroy_time += Time.deltaTime;

        if (destroy_time >= 3)
        {
            SpawnFruit();
            Destroy(gameObject);
        }
    }

    private void GetNextWaypoint()
    {
        if (wavepointIndex >= TwoWaypoints.tpoints.Length - 1)//���� ������(wavepointIndex)�� ������ ������(Waypoints.points.Length -1)�̶��
        {
            Destroy(gameObject, destroy_time);//�� ��ũ��Ʈ�� ������ �ִ� ���� ��ü�� �ı�
            return;
        }

        wavepointIndex++;
        target = TwoWaypoints.tpoints[wavepointIndex];//�������� ���� �������� ����

    }


    private void SpawnFruit()
    {
        int random = UnityEngine.Random.Range(0, 100);

        if (random < spawnrandom)
        {
            int fruit_random = UnityEngine.Random.Range(0, 2);

            Instantiate(fruits[fruit_random], transform.position, transform.rotation);
        }
    }
}