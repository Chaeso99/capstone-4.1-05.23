using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragEvent : MonoBehaviour, IDropHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //Transform defultTransform;

    //public Image data;
    //public Sprite data2;
    //public DragContainer dragContainer;

    public GameObject dragObject; // �巡�׿� �� ������Ʈ
    // �巡�׿� �� ������Ʈ�� ��� GameScene_UI�� �̸� ��ġ�� �� SetActive�� false�� ������ ��

    public Slime slimePrefab; // ��ġ�� ������

    public bool isDragging = false; // �巡�� ������ Ȯ��
    public bool isFruit = false; // �������� Ȯ��
    public bool isPromote = false; // ���� ���������� Ȯ��


    // Start is called before the first frame update
    void Start()
    {

        //defultTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // �巡�� ���� ��� �̺�Ʈ �� ���
    public void OnDrop(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    // �巡�� ���� �� ���
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragObject == null)
        {
            return;
        }

        dragObject.SetActive(true);

        isDragging = true;
    }

    // �巡�� �� ������ ������ ȣ��
    public void OnDrag(PointerEventData eventData)
    {

        // �巡�� ���� �� �ű�� �̹����� ���콺�� ���󰡵��� ����
        if (isDragging)
        {
            dragObject.transform.position = eventData.position;

        }
    }

    // �巡�� ���� �� ����
    public void OnEndDrag(PointerEventData eventData)
    {

        // �巡�� ������ Ȯ��
        if (!isDragging)
        {
            Debug.Log("OnEndDrag : is not Dragging");
            return;
        }

        // �巡�� ������Ʈ�� �����Ǿ� �ִ��� Ȯ��
        if (dragObject == null)
        {
            Debug.Log("OnEndDrag : is not Dragging");
            return;
        }

        dragObject.SetActive(false); // �̸� ��ġ�� dragObject Ȱ��ȭ
        isDragging = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� ������ ��

        RaycastHit[] raycastHits = Physics.RaycastAll(ray); // ī�޶󿡼� ������ ���� �ε��� ������Ʈ ��� ���

        foreach (RaycastHit hit in raycastHits) // �ε��� ��ü��� �ݺ��� ����
        {
            if (hit.collider.tag != "Tile") // �ε��� ��ü�� Ÿ������ Ȯ��
            {
                // Ÿ���� �ƴҰ�� ���� RaycastHit Ȯ��
                continue;
            }


            // ����Ų Ÿ���� �������� ����
            // �̶� Ÿ���� Materials�� RenderingMode�� ������ �ʿ䰡 ����
            /*
            GameObject hitTile = hit.collider.gameObject; // ���� �̹����� �ִ� Ÿ��

            Renderer renderer = hitTile.GetComponentInChildren<Renderer>();

            if (renderer == null)
            {
                Debug.Log("renderer null");
            }

            MeshRenderer mesh = hitTile.GetComponent<MeshRenderer>();

            if (mesh == null)
            {
                Debug.Log("mesh null");
            }

            Material material = renderer.material;
            Color color = material.color;

            Debug.Log(color.a);

            color.a = 0.1f;
            material.color = color;
            */

            // ��ġ�� ������ ������ �����Ǿ� �ִ��� Ȯ��
            if (slimePrefab == null)
            {
                Debug.Log("Slime Prefab is not setting");
            }

            // raycast�� �΋H�� ������Ʈ�� Tile ���� ������
            Tile targetTile = hit.collider.gameObject.GetComponent<Tile>();

            // ������ ���� �� Ȯ��
            if (isFruit)
            {
                ChangeDefultSlime(targetTile, slimePrefab);
            }
            else if (isPromote)
            {
                ChangeFruitSlime(targetTile, slimePrefab);
            }
            else
            {
                SpawnDefultSlime(targetTile, slimePrefab);
            }

            return;
        }
    }

    // �⺻ ������ ��ġ
    public void SpawnDefultSlime(Tile tile, Slime slimePrefab)
    {
        // ������ ������ �ִ��� Ȯ��
        if (slimePrefab == null)
        {
            return;
        }

        // ��ġ�� Ÿ�Ͽ� Ÿ���� �ִ��� Ȯ��
        if (tile.CheckSlime())
        {
            Debug.LogWarning("Tile.SetSlime : already tile have tower");
            return;
        }

        // �������� ����
        Slime attachSlime = Instantiate(slimePrefab, tile.towerPosition, Quaternion.identity);
        Debug.Log("tower Set");

        // ������ ���� üũ
        if (attachSlime == null)
        {
            return;
        }

        // Ÿ�Ͽ� ��ġ�� Ÿ�� ���� ����
        tile.SetSlime(attachSlime);
        PromoteSlimeSpawnManager.promoteSlimeSpawnManager.AddSlimeAtList(attachSlime);
    }

    // ���� ������ ����
    public void ChangeDefultSlime(Tile tile, Slime slimePrefab)
    {

        // ��ġ�� ������ ������ �ִ��� Ȯ��
        if (slimePrefab == null)
        {
            Debug.LogError("Tile.ChangeSlime : slime is not setting");
            return;
        }

        Slime pastSlime = tile.GetSlime();

        // ��ġ�� Ÿ�Ͽ� Ÿ���� �ִ��� Ȯ��
        if (pastSlime == null)
        {
            Debug.LogWarning("Tile.ChangeSlime : no have target");
            return;
        }

        // Ÿ���� �⺻�� �´��� Ȯ��
        if (pastSlime.state != SlimeState.DEFAULT)
        {
            Debug.LogWarning("Tile.ChangeSlime : slime is not default");
            return;
        }

        tile.DestroySlime();

        Slime attachSlime = Instantiate(slimePrefab, tile.towerPosition, Quaternion.identity);
        Debug.Log("tower Set");

        // ������ ���� üũ
        if (attachSlime == null)
        {
            return;
        }

        // Ÿ�Ͽ� ��ġ�� Ÿ�� ���� ����
        tile.SetSlime(attachSlime);
        PromoteSlimeSpawnManager.promoteSlimeSpawnManager.AddSlimeAtList(attachSlime);
    }

    // ���� ������ ����
    public void ChangeFruitSlime(Tile tile, Slime slimePrefab)
    {

        // ��ġ�� ������ ������ �ִ��� Ȯ��
        if (slimePrefab == null)
        {
            Debug.LogError("Tile.ChangeSlime : slime is not setting");
            return;
        }

        int checkNum = PromoteSlimeSpawnManager.promoteSlimeSpawnManager.CheckPromoteSlime(slimePrefab.state);

        if (checkNum != 1)
        {
            Debug.LogError("PromoteSlimeSpawnManager Error");
            Debug.Log(checkNum);
            return;
        }

        // ��ġ�� Ÿ�Ͽ� Ÿ���� �ִ��� Ȯ��
        if (tile.CheckSlime())
        {
            Debug.LogWarning("Tile.SetSlime : already tile have tower");
            return;
        }

        Slime attachSlime = Instantiate(slimePrefab, tile.towerPosition, Quaternion.identity);
        Debug.Log("tower Set");

        // ������ ���� üũ
        if (attachSlime == null)
        {
            Debug.LogError("Slime is not Attaching");
            return;
        }

        // Ÿ�Ͽ� ��ġ�� Ÿ�� ���� ����
        tile.SetSlime(attachSlime);
        PromoteSlimeSpawnManager.promoteSlimeSpawnManager.AddSlimeAtList(attachSlime);
    }

}