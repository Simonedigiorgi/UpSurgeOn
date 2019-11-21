using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;

    void Update()
    {
        /*if (Input.touchCount > 0)
        {
            // Character rotation WITH RAYCAST
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if(hit.transform.tag == "HumanAnatomy")
                    {
                        rotationY = Quaternion.Euler(0f, -Input.GetTouch(0).deltaPosition.x * 0.2f, 0f);
                        transform.rotation = rotationY * transform.rotation;

                    }
                }
            }
        }*/

        if (Input.touchCount > 0)
        {
            // Character rotation
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(0f, -Input.GetTouch(0).deltaPosition.x * 0.2f, 0f);
                transform.rotation = rotationY * transform.rotation;
            }
        }

    }
}
