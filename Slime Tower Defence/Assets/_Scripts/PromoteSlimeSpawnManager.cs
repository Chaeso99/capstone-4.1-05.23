using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ ��ȯ�� ���� �ʿ� ��ġ�� ������ ������ �����ϴ� �Ŵ��� Ŭ����
public class PromoteSlimeSpawnManager : MonoBehaviour
{
    List<GameObject> slimeOnTile; // �ʿ� ��ġ�� ������ ����Ʈ

    static public PromoteSlimeSpawnManager promoteSlimeSpawnManager;

    private void Awake()
    {
        promoteSlimeSpawnManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        slimeOnTile = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddSlimeAtList(GameObject slime)
    {
        slimeOnTile.Add(slime);
    }

    public void RemoveSlimeAtList(GameObject slime)
    {
        slimeOnTile.Remove(slime);
    }

    // ��ġ�� ���� �����ӿ� �ʿ��� ������ ���� 
    public int CheckPromoteSlime(SlimeState buildSlimeState)
    {
        int checkNum; // �Լ��� �����ߴ��� Ȯ���� ���� ����

        switch (buildSlimeState) // ��ȯ�� �����ӿ� �´� �Լ� ����
        {
            case SlimeState.VINE: // ���� ������ : ���� �����Ӱ� ���� ������
                checkNum = CheckCanBulidPromoteSlime(SlimeState.ICE, SlimeState.THUNDER);
                break;
            case SlimeState.WATER: // �� ������ : �� �����Ӱ� ���� ������
                checkNum = CheckCanBulidPromoteSlime(SlimeState.FIRE, SlimeState.WATER);
                break;
            case SlimeState.WIND: // �ٶ� ������ : �� �����Ӱ� ���� ������
                checkNum = CheckCanBulidPromoteSlime(SlimeState.FIRE, SlimeState.THUNDER);
                break;
            default: // ������ ���� ���� �������� ���� ���
                Debug.Log("no information from PromoreSime");
                checkNum = -2;
                break;
        }

        return checkNum;
    }

    // ���� �������� ���� ������ �Ǵ��� Ȯ��
    public int CheckCanBulidPromoteSlime(SlimeState firstSlimeState, SlimeState secondSlimeState)
    {
        GameObject firstSlime = null; // ��� ������ 1
        GameObject secondSlime = null; // ��� ������ 2

        Debug.Log(slimeOnTile.Count);

        foreach (GameObject slime in slimeOnTile) // ����Ʈ���� ��ȯ�� �ʿ��� ������ �˻�
        {

            Slime slime_ = slime.GetComponent<Slime>();
            SlimeState slimeState = slime_.state;

            Debug.Log(slimeState);

            if (slimeState == firstSlimeState)
            {
                firstSlime = slime;
                continue;
            }

            if (slimeState == secondSlimeState)
            {
                secondSlime = slime;
                continue;
            }
        }

        if (firstSlime == null || secondSlime == null) // ��� �������� �ϳ��� ���� ���
        {
            Debug.Log("no have correct Slime in Game");
            return -1;
        }
        // ������ ��ȯ ���� ����

        firstSlime.GetComponent<Slime>().ChangeTileCheckInfomation();
        RemoveSlimeAtList(firstSlime);
        Destroy(firstSlime);

        secondSlime.GetComponent<Slime>().ChangeTileCheckInfomation();
        RemoveSlimeAtList(secondSlime);
        Destroy(secondSlime);

        Debug.Log("Promote Slime in Game");
        return 1;
    }
}
