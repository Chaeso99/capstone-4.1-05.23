using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawnManager : MonoBehaviour
{
    List<Slime> slimePrefabList;

    List<Slime> slimeOnTile;

    Slime firstSlime;
    Slime secondSlime;

    SlimeState firstSlimeState;
    SlimeState secondSlimeState;

    static public SlimeSpawnManager slimeSpawnManager;

    private void Awake()
    {
        slimeSpawnManager = this;
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

    void AddSlimeAtList(Slime slime)
    {
        slimeOnTile.Add(slime);
    }

    // ���� �������� ���� ������ �Ǵ��� Ȯ��
    public int CheckCanBulidPromoteSlime(SlimeState firstSlimeState_, SlimeState secondSlimeState_)
    {
        firstSlime = null;
        secondSlime = null;

        firstSlimeState = firstSlimeState_;
        secondSlimeState = secondSlimeState_;

        FindSlimeStateAtList();

        if (firstSlime == null || secondSlime == null)
        {
            Debug.Log("no have correct Slime in Game");
            return -1;
        }

        Destroy(firstSlime);
        Destroy(secondSlime);

        return 1;
    }

    // ���� �������� ���� �� ����
    void FindSlimeStateAtList()
    {
        foreach (Slime slime in slimeOnTile)
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
    }
}
