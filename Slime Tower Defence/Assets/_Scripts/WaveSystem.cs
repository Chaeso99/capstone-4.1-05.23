using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;              // ���� ���������� ��� ���̺� ����
    [SerializeField]
    private WaveSpawner waveSpawner;

    public int currentWaveIndex = -1; // ���� ���̺� �ε���

    public void StartWave()
    {
        if(currentWaveIndex < waves.Length - 1)
        {
            currentWaveIndex++;
            waveSpawner.StartWave(waves[currentWaveIndex]);
            Debug.Log("Wave: " + currentWaveIndex);
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