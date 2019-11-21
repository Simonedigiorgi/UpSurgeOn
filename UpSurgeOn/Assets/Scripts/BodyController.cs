using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyController : MonoBehaviour
{
    public BodyParts bodyPart;
    public Transform humanAnatomy;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == bodyPart.bodyPartName && UIManager.Instance.skinsButton.GetComponent<Image>().color == UIManager.Instance.disableColor && UIManager.Instance.musclesButton.GetComponent<Image>().color == UIManager.Instance.disableColor)
                {
                    UIManager.Instance.text.text = bodyPart.bodyPartName;
                    humanAnatomy.GetComponent<Animator>().Play("BodyMoveRight");
                    UIManager.Instance.informativePanel.Play("InformativeRight");
                    UIManager.Instance.cameraSlide.Play("SlideRight");

                    GetComponent<Renderer>().material.color = bodyPart.enableColor;
                    //UpdatePosition();
                }
            }
        }
    }

    public void UpdatePosition()
    {
        Vector3 newPosition = Vector3.Lerp(CameraController.Instance.transform.position, new Vector3(0, transform.GetChild(0).transform.position.y, -5f), 1f);
        CameraController.Instance.transform.position = newPosition;

        // Slider
        //CameraController.Instance.slider.
    }
}
