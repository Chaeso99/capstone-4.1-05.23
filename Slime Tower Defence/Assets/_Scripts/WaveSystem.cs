using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;              // ���� ���������� ��� ���̺� ����
    [SerializeField]
    private WaveSpawner waveSpawner;
    [SerializeField]
    private float countdown = 2f;
    [SerializeField]
    private float timeBetweenWaves = 20f;

    private CurrentWave currentWave;

    public int currentWaveIndex = -1; // ���� ���̺� �ε���

    public void Start()
    {
        currentWave = GameObject.Find("CurrentWave_UI").GetComponent<CurrentWave>();
        waveSpawner = GetComponent<WaveSpawner>();
    }

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartWave();
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    public void StartWave()
    {
        if (currentWaveIndex < waves.Length - 1)
        {
            currentWaveIndex++;
            waveSpawner.StartWave(waves[currentWaveIndex]);
            currentWave.GetAddWave();
        }
    }
}

[System.Serializable]
public struct Wave
{
    public float spawnTime;            // ���� ���̺� �� ���� �ֱ�
    public int maxEnemyCount;          // ���� ���̺� �� ���� ����
    public GameObject[] enemyPrefabs;  // ���� ���̺� �� ���� ����
    public int[] enemyPrefabnumbers;   // ���� ���̺� ���� �� ���� ��
}