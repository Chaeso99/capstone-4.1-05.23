using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneDetcet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) //���Ϳ� �浹 ����, �÷��̾� ü�� ����
    {
        Destroy(other.gameObject);
        HPManager.CurrentHP = HPManager.CurrentHP - 1;
    }
}
