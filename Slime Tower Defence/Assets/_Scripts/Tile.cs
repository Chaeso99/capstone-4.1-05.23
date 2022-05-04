using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isRoad;
    public bool isSlime = false; // �������� �ִ��� Ȯ��
    public Tower attachSlime; // ��ġ�� ������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Ÿ���� ��ġ���� ����, Drag �̺�Ʈ�� ���
    public Vector3 GetPosition()
    {
        Vector3 tilePosition = this.gameObject.transform.position;
        return tilePosition;
    }

    // �������� �ִ��� üũ
    public bool SlimeCheck()
    {
        return isSlime;
    }
}
