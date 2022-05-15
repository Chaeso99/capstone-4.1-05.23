using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlimeState
{
    DEFAULT,
    ICE,
    FIRE,
    THUNDER,
    VINE,
    WATER,
    WIND
};

public class Slime : MonoBehaviour
{
    bool isAttack = true; // ������ �������� Ȯ��

    public EnemyDetect enemyDetect; // �� Ȯ���� ���� ������Ʈ
    public List<GameObject> enemyList; // �� ����Ʈ
    public GameObject bulletPrefab; // ���� ������

    GameObject targetEnemy = null; // ��ǥ �� ����

    public float attackSpeed; // ���� �ӵ�
    public float bulletSpeed; // ����ü �ӵ�

    float timer = 0; // ���� �ӵ� ������ ���� ���

    public SlimeState state; // �������� ���� Ȯ��
    Tile tile; // ������ ��ȯ�� Ÿ�� ����

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime; // ���ݼӵ��� ���� ���

        if (enemyList.Count > 0)
        {
            if (targetEnemy == null)
            {
                targetEnemy = FindEnemyClosestToTower();
            }

            RotateToTarget(targetEnemy);

            if (timer > attackSpeed)
            {
                Attack(targetEnemy);
                timer = 0;
            }
        }
    }

    // ������ ���� �Լ�
    void Attack(GameObject target)
    {
        if (isAttack) // ������ �������� Ȯ��
        {
            //isAttack = false; // ������ �̹� ���� ���̹Ƿ� ����

            //RotateToTarget(target); // �� �ٶ󺸱�
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x,
                transform.position.y, transform.position.z), Quaternion.identity); // ���� ������ ����

            bullet.GetComponent<Bullet>().SetTarget(target, bulletSpeed); // ���� �����տ� �� ���� ����

            //isAttack = true; // ���� ����
        }

    }

    // ���� �ٶ󺸴� �Լ�
    void RotateToTarget(GameObject target)
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, 
            target.transform.position.z);

        transform.LookAt(targetPosition);
    }

    // ������  ��ġ�� Ÿ���� ������ ����
    public void AttachTileInfomation(Tile tile_)
    {
        if (tile_ == null)
        {
            Debug.Log("no tile infomation");
            return;
        }

        tile = tile_;
    }

    public void ChangeTileCheckInfomation()
    {
        tile.isSlime = false;
    }

    // ���� ������ ������ ���� �߰�
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            enemyList.Add(other.gameObject);
        }
    }

    // ���� �������� ������ ���� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
        { 
            foreach (GameObject go in enemyList)
            {
                if (go == other.gameObject)
                {
                    if (other.gameObject == targetEnemy)
                    {
                        targetEnemy = null;
                    }
                    enemyList.Remove(other.gameObject);
                    break;
                }
            }
        }
    }

    public GameObject FindEnemyClosestToTower()
    {
        GameObject target_ = null;
        float minDir = -1;

        foreach (GameObject enemy in enemyList)
        {
            // �������� ����ִ� ����Ʈ���� �����۰� �÷��̾��� �Ÿ��� ���
            float dir = Vector3.Distance(transform.position, enemy.transform.position);

            // ù ��� �Ǵ� �ּ� �Ÿ����� ������ �ش� ���������� ����
            if (minDir > dir || minDir == -1)
            {
                minDir = dir;
                target_ = enemy;
            }
        }

        return target_;
    }
}
