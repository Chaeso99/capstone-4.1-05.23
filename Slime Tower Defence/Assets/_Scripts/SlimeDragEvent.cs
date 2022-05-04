using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlimeDragEvent : DragEvent
{
    public Slime dragSlime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public new void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("new Drag!");

        if (dragObject == null)
        {
            return;
        }

        dragObject.SetActive(true);

        isDragging = true;

        // ī�޶󿡼� ������ ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // ī�޶󿡼� ������ ���� �ε��� ������Ʈ ��� ���
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in raycastHits) // �ε��� ��ü��� �ݺ��� ����
        {
            //gameObject hitTarget = hit.collider

            if (hit.collider.tag != "Slime")
            {
                Debug.Log("this is not Slime");
                continue;
            }

            dragSlime = hit.collider.GetComponent<Slime>();
        }
    }

    public new void OnDrag(PointerEventData eventData)
    {
            // Debug.Log("Drag");

            // �巡�� ���� �� �ű�� �̹����� ���콺�� ���󰡵��� ����
        if (isDragging)
        {
            Vector3 dragSlimePosition = new Vector3(eventData.position.x, 5f, 
                eventData.position.y);

            dragSlime.gameObject.transform.position = dragSlimePosition;
        }


    }

    public new void OnEndDrag(PointerEventData eventData)
    {

    }
}
