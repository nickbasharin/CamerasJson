using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float rotSpeed = 3;
    public float scaleSpeed = 3;
    public GameObject scaleObj;
    float scaleO;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }

    void OnGUI()
    {
        scaleO = scaleObj.transform.localScale.x;
        scaleO += Input.mouseScrollDelta.y * scaleSpeed * Time.deltaTime * scaleO;
        if (scaleO < 0.03) scaleO = 0.03f;
        if (scaleO > 2) scaleO = 2f;
        scaleObj.transform.localScale = new Vector3(scaleO, scaleO, scaleO);
    }
}

