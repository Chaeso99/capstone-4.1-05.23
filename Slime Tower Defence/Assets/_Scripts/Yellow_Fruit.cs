using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Yellow_Fruit : MonoBehaviour
{
    private float spawntime;

    void Start()
    {
    }

    void Update()
    {
        spawntime += Time.deltaTime;//ī��Ʈ �ٿ�

        DestroyFruits();
    }

    private void DestroyFruits()
    {
        if (spawntime >= 1)//1�� �Ѱ� �ȴٸ� �����
        {
            Destroy(gameObject);      
        }
    }
}
