using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragExample : MonoBehaviour, IDropHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //Transform defultTransform;

    //public Image data;
    //public Sprite data2;
    //public DragContainer dragContainer;

    public GameObject dragObject; // �巡�׿� �� ������Ʈ
    // �巡�׿� �� ������Ʈ�� ��� GameScene_UI�� �̸� ��ġ�� �� SetActive�� false�� ������ ��

    public GameObject slimePrefab; // ��ġ�� ������

    public bool isDragging = true; // �巡�� ������ Ȯ��
    public bool isFruit = false; // �������� Ȯ��
    

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
        Debug.Log("Drop");
        // throw new System.NotImplementedException();
    }

    // �巡�� ���� �� ���
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Start");

        if (dragObject == null)
        {
            return;
        }

        dragObject.SetActive(true);

        /*
        if (data.sprite == null)
        {
            return;
        }
        */

        /*
        dragContainer.dragObject.SetActive(true);
        dragContainer.image.sprite = data2;
        */

        isDragging = true;

        
        
    }

    // �巡�� �� ������ ������ ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Drag");

        // �巡�� ���� �� �ű�� �̹����� ���콺�� ���󰡵��� ����
        if (isDragging)
        {
            //dragContainer.transform.position = eventData.position;
            dragObject.transform.position = eventData.position;
            
        }
    }

    // �巡�� ���� �� ����
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag End");

        
        // �巡�� ������ Ȯ��
        if (!isDragging)
        {
            Debug.Log("OnEndDrag : is not Dragging");
            return;
        }

        if (dragObject == null)
        {
            Debug.Log("OnEndDrag : is not Dragging");
            return;
        }

        dragObject.SetActive(false);
        isDragging = false;

        /*
        dragContainer.image.sprite = null;
        dragContainer.dragObject.SetActive(false);
        */

        // test
        //RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� ������ ��

        RaycastHit[] raycastHits = Physics.RaycastAll(ray); // ī�޶󿡼� ������ ���� �ε��� ������Ʈ ��� ���

        foreach (RaycastHit hit in raycastHits) // �ε��� ��ü��� �ݺ��� ����
        {
            string objectName = hit.collider.gameObject.name; // �׽�Ʈ�� ������Ʈ �̸� ���
            //Debug.Log(objectName);

            if (hit.collider.tag != "Tile") // �ε��� ��ü�� Ÿ������ Ȯ��
            {
                // Ÿ���� �ƴҰ�� ���� RaycastHit Ȯ��
                Debug.Log("this is not tile");
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

            // ������ ����
            Tile targetTile = hit.collider.gameObject.GetComponent<Tile>();
            SpawnSlime(targetTile, slimePrefab);
            return;
        }
    }

    // ������ ���� �Լ�
    public void SpawnSlime(Tile tile, GameObject tower)
    {
        // Ÿ�� ������ �ִ��� Ȯ��
        if (tile == null)
        {
            Debug.LogError("SpawnTowerError : tile Component error");
            return;
        }

        // ��ġ�� Ÿ�� ������ �ִ��� Ȯ��
        if (tower == null)
        {
            Debug.LogError("SpawnTowerError : tower is not setting");
            return;
        }

        // ��ġ�� Ÿ�Ͽ� Ÿ���� �ִ��� Ȯ��
        if (tile.SlimeCheck())
        {
            Debug.LogWarning("SpawnTowerError : already tile have tower");
            return;
        }

        tile.isSlime = true;
        Vector3 towerPosition = tile.GetPosition();

        Instantiate(slimePrefab, new Vector3(towerPosition.x, towerPosition.y + 3f,
            towerPosition.z), Quaternion.identity);
        Debug.Log("tower Set");
    }

    // ���ŷ� ������ ü����
    public void ChangeSlime(Tile tile, GameObject tower)
    {
        // Ÿ�� ������ �ִ��� Ȯ��
        if (tile == null)
        {
            Debug.LogError("SpawnTowerError : tile Component error");
            return;
        }

        // ��ġ�� Ÿ�� ������ �ִ��� Ȯ��
        if (tower == null)
        {
            Debug.LogError("SpawnTowerError : tower is not setting");
            return;
        }

        // ��ġ�� Ÿ�Ͽ� Ÿ���� �ִ��� Ȯ��
        if (!tile.SlimeCheck())
        {
            Debug.LogWarning("SpawnTowerError : already tile have tower");
            return;
        }

        // ��ġ�� Ÿ�Ͽ� Ÿ���� �ִ��� Ȯ��
        if (tile.SlimeCheck())
        {
            Debug.LogWarning("SpawnTowerError : already tile have tower");
            return;
        }

        tile.isSlime = true;
        Vector3 towerPosition = tile.GetPosition();

        Instantiate(slimePrefab, new Vector3(towerPosition.x, towerPosition.y + 3f,
            towerPosition.z), Quaternion.identity);
        Debug.Log("tower Set");
    }
}
