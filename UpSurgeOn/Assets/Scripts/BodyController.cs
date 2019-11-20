using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    public Camera mainCamera;
    public Transform gameobject;

    private void Update()
    {
        /*if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Enter");
            mainCamera.transform.LookAt(gameobject);
        }*/
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse");
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Enter");
            mainCamera.transform.LookAt(gameobject);
        }
    }
}
