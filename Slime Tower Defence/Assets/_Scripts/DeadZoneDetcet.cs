using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneDetcet : MonoBehaviour
{
    void OnTriggerEnter(Collider other) //���Ϳ� �浹 ����, �÷��̾� ü�� ����
    {
        if (other.tag == "Monster")
        {
            Destroy(other.gameObject);
            HPManager.CurrentHP = HPManager.CurrentHP - 1;
        }
    }
}
