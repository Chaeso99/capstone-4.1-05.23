using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveTexts : MonoBehaviour
{
    string CurrentWaveString = WaveSpawner.waveIndex.ToString();
    public Text CurrentWave;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentWaveString = WaveSpawner.waveIndex.ToString();
        CurrentWave.text = CurrentWaveString + " Wave";
        //ȭ�鿡 ���� ���̺� ǥ��
    }
}
