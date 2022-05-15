using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ������ ��ȯ�� ���� �ʿ� ��ġ�� ������ ������ �����ϴ� �Ŵ��� Ŭ����
public class PromoteSlimeSpawnManager : MonoBehaviour
{
    List<Slime> slimeOnTile; // �ʿ� ��ġ�� ������ ����Ʈ

    static public PromoteSlimeSpawnManager promoteSlimeSpawnManager;

    private void Awake()
    {
        promoteSlimeSpawnManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        slimeOnTile = new List<Slime>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSlimeAtList(Slime slime)
    {
        slimeOnTile.Add(slime);
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
        Slime firstSlime = null; // ��� ������ 1
        Slime secondSlime = null; // ��� ������ 2

        foreach (Slime slime in slimeOnTile) // ����Ʈ���� ��ȯ�� �ʿ��� ������ �˻�
        {
            if (slime.state == firstSlimeState)
            {
                firstSlime = slime;
                continue;
            }

            if (slime.state == secondSlimeState)
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

        firstSlime.ChangeTileCheckInfomation();
        Destroy(firstSlime.gameObject);

        secondSlime.ChangeTileCheckInfomation();
        Destroy(secondSlime.gameObject);

        Debug.Log("Promote Slime in Game");
        return 1;
    }
}
