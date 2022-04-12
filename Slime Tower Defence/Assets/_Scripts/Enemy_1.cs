using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    private Transform target;//Transform
    private int wavepointIndex = 0;//OneWaypoints�� �ε���
    private static int fruitsindex = 3;

    public int enemy_hp = 10;
    public float speed = 10f;//���� �ӵ�
    public float destroy_time = 0f;//���������� ���� ���� �ð�
    public Transform[] fruits = new Transform[fruitsindex];//���ŵ�
    public int spawnrandom = 20;//���� �����

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

        destroy_time += Time.deltaTime;

        if (destroy_time >= 3)
        {
            SpawnFruit();

            Destroy(gameObject);
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

    private void SpawnFruit()
    {
        int random = UnityEngine.Random.Range(0, 100);//1~100���� �������� ���� �̱�

        if (random < spawnrandom)//���� ������ ��������� ������
        {
            int fruit_random = UnityEngine.Random.Range(0, 2);//���� 3������ �� �ε��� �̱�

            Instantiate(fruits[fruit_random], transform.position, transform.rotation);//�ش� �ε����� �ִ� ���Ÿ� ���� ��ǥ�� ��ȯ
        }
    }
}