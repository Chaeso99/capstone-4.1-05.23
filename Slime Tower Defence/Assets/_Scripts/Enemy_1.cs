using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : MonoBehaviour
{
    public int enemy_hp = 10;
    public float speed = 10f;//���� �ӵ�
    public float destroy_time = 0.1f;//���������� ���� ���� �ð�
    public Transform[] fruits = new Transform[fruitsindex];//
    public int fruitspawnrandom = 20;

    Rigidbody E1_rigidbody; //Rigidbody�� �����ϴ� ����
    public int rotatespeed = 5; //ȸ���ӵ�

    private static int fruitsindex = 3;
    private Transform target;//Transform
    private int wavepointIndex = 0;//OneWaypoints�� �ε���

    void Start()
    {
        target = OneWaypoints.opoints[0];//ù��° OneWaypoint ����
        E1_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;// ������ ������ ���ϴ� ��
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//�̵����� �Լ�

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)//Vector3 a(transform.position)�� Vector3 b(target.position)�� ������ �Ÿ��� 0.4f���� ������...
        {
            GetNextWaypoint();//���� ������ Ž���ϴ� �Լ�
        }

        Quaternion newRotation = target.rotation;
        E1_rigidbody.rotation = Quaternion.Slerp(E1_rigidbody.rotation, newRotation,
            rotatespeed * Time.deltaTime);
        //���Ͱ� �̵��ϴ� �������� ȸ��(�ٶ�)
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
        int random = UnityEngine.Random.Range(0, 100);

        if (random < fruitspawnrandom)
        {
            int fruit_random = UnityEngine.Random.Range(0, 2);

            Instantiate(fruits[fruit_random], transform.position, transform.rotation);
        }
    }
}