using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{
    public int enemy_hp = 10;
    public float speed = 10f;//���� �ӵ�
    public float destroy_time = 0.1f;//���������� ���� ���� �ð�
    public Transform[] fruits = new Transform[fruitsindex];//
    public int fruitspawnrandom = 20;

    Rigidbody E2_rigidbody; //Rigidbody�� �����ϴ� ����
    public int rotatespeed = 5; //ȸ���ӵ�

    private static int fruitsindex = 3;
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
        /*
        destroy_time += Time.deltaTime;

        if (destroy_time >= 3)
        {
            SpawnFruit();

            Destroy(gameObject);
        }
        */
    }

    private void FixedUpdate()
    {
        /*Quaternion newRotation = target.rotation;
        E2_rigidbody.rotation = Quaternion.Slerp(E2_rigidbody.rotation, newRotation,
            rotatespeed * Time.deltaTime);
        //���Ͱ� �̵��ϴ� �������� ȸ��(�ٶ�)
        */
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