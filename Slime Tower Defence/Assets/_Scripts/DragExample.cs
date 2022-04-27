using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragExample : MonoBehaviour, IDropHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Transform defultTransform;

    //public Image data;
    //public Sprite data2;
    //public DragContainer dragContainer;

    public GameObject gameObject; // �巡�׿� �� ������Ʈ

    public bool isDragging = true; // �巡�� ������ Ȯ��
    

    // Start is called before the first frame update
    void Start()
    {

        defultTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            string objectName = hit.collider.gameObject.name;
            Debug.Log(objectName);
        }
        */

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

        /*
        if (data.sprite == null)
        {
            return;
        }
        */

        /*
        dragContainer.gameObject.SetActive(true);
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
            gameObject.transform.position = eventData.position;
            
        }

        // test
        //RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ī�޶󿡼� ������ ��

        RaycastHit[] raycastHits = Physics.RaycastAll(ray); // ī�޶󿡼� ������ ���� �ε��� ������Ʈ ��� ���

        foreach (RaycastHit hit in raycastHits) // �ε��� ��ü��� �ݺ��� ����
        {
            string objectName = hit.collider.gameObject.name; // �׽�Ʈ�� ������Ʈ �̸� ���
            //Debug.Log(objectName);

            if (hit.collider.tag == "Tile") // �ε��� ��ü�� Ÿ������ Ȯ��
            {
                GameObject hitTile = hit.collider.gameObject;
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
            }
        }
    }

    // �巡�� ���� �� ����
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag End");

        
        if (isDragging)
        {
            /*
            if (dragContainer.image.sprite != null)
            {
                //data.sprite = dragContainer.image.sprite;
            }
            else
            {
                //data.sprite = null;
            }
            */

            //dragObject.transform.position = defultTransform.position;
        }

        isDragging = false;

        /*
        dragContainer.image.sprite = null;
        dragContainer.gameObject.SetActive(false);
        */
        
    }
}
