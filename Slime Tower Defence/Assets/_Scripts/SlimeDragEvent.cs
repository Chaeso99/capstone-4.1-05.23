using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlimeDragEvent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ������Ʈ�� ���콺 �ٿ� �Ǿ��� ��� ����
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("SlimeDragEvent Mouse Down!");

            //ī�޶� ��ġ
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                            Input.mousePosition.y, -Camera.main.transform.position.z));

            Debug.Log("point : " + point);

            //this.gameObject.transform
        }
    }

    // ������Ʈ�� ���콺 �� �Ǿ��� ��� ����
    private void OnMouseUp()
    {
        
    }
}
