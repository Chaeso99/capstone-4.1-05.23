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

    public void OnCollisionEnter(Collision collision) //���Ϳ� �浹 ����, �÷��̾� ü�� ����
  {
     if (collision.collider.gameObject.CompareTag("Monster"))
     {
          HPManager.CurrentHP=HPManager.CurrentHP - 1;
          Debug.Log("CurrentHP= " + HPManager.CurrentHP);
     }
  }
}
