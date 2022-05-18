using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;              // ���� ���������� ��� ���̺� ����
    [SerializeField]
    private WaveSpawner waveSpawner;

    public Text CurrentWaves;

    public int currentWaveIndex = -1; // ���� ���̺� �ε���

    public void StartWave()
    {
        if(currentWaveIndex < waves.Length - 1)
        {
            currentWaveIndex++;
            waveSpawner.StartWave(waves[currentWaveIndex]);
            CurrentWaves.text = (currentWaveIndex + 1) + " WAVE";
            //Debug.Log((currentWaveIndex + 1) + " WAVE");
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