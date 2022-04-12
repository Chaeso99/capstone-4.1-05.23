using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour//�� �����ϴ� �ڵ�
{
    public Transform[] enemyPrefab_1 = new Transform[5];//Monster_1Prefab�� Transform
    public Transform[] enemyPrefab_2 = new Transform[5];//Monster_2Prefab�� Transform
    public Transform spawnPoint;//MonsterSpawnWaypoint(�� ���� GameObject)�� Transform
    public float timeBetweenWaves = 5f;//������ �����Ǵ� �ð� ����

    private float countdown = 2f;//�ð�
    private int waveIndex = 0;//�������� ��ȣ 

    private void Update()//5�ʸ��� SpawnWave() �Լ��� ȣ��
    {
        if (countdown <= 0f)//countdown�� 0�� ��� SpawnWave()�� ȣ���ϰ� countdown�� ���� ������  5f�� �ʱ�ȭ
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
    }

    IEnumerator SpawnWave()// waveIndex ��ŭ  0.3�ʸ��� SpawnEnemy_1()�� SpawnEnemy_2�� ȣ��
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy_1();
            SpawnEnemy_2();
            yield return new WaitForSeconds(0.5f);//0.5f���� ��ٸ��� �Լ�
        }

    }

    private void SpawnEnemy_1()//Monster_1Prefab ����
    {
        int enemy_random = UnityEngine.Random.Range(0, 5);
        Instantiate(enemyPrefab_1[enemy_random], spawnPoint.position, spawnPoint.rotation);
    }
    private void SpawnEnemy_2()//Monster_2Prefab ����
    {
        int enemy_random = UnityEngine.Random.Range(0, 5);
        Instantiate(enemyPrefab_2[enemy_random], spawnPoint.position, spawnPoint.rotation);
    }
}
