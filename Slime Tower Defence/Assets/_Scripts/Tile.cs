using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isRoad;
    public bool isSlime = false; // �������� �ִ��� Ȯ��
    public Slime attachSlime; // ��ġ�� ������
    public Vector3 towerPosition; // �������� ��ġ�� ��ġ

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tilePosition = transform.position;
        towerPosition = new Vector3(tilePosition.x, tilePosition.y + 3f,
            tilePosition.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �������� �ִ��� üũ
    public bool CheckSlime()
    {
        return isSlime;
    }

    // ������ ��ġ
    public void SetSlime(Slime slimePrefab)
    {
        // ������ ������ �ִ��� Ȯ��
        if (slimePrefab == null)
        {
            return;
        }
        isSlime = true;
        attachSlime = slimePrefab;
    }

    // ������ ���� ��������
    public Slime GetSlime()
    {
        return attachSlime;
    }

    // Ÿ�Ͽ� ��ġ�Ǿ� �ִ� ������ ����
    public void DestroySlime()
    {
        Destroy(attachSlime.gameObject);
    }

}
