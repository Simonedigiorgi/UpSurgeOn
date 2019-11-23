using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyController : MonoBehaviour
{
    public Body bodyPart;
    private Transform humanAnatomy;



    private void Start()
    {
        humanAnatomy = GameObject.FindGameObjectWithTag("HumanAnatomy").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == bodyPart.IdName && UIManager.Instance.skinsButton.GetComponent<Image>().color == UIManager.Instance.disableColor && UIManager.Instance.musclesButton.GetComponent<Image>().color == UIManager.Instance.disableColor)
                {
                    UIManager.Instance.titleText.text = bodyPart.name.ToUpper();
                    UIManager.Instance.descriptionText.text = bodyPart.description;
                    humanAnatomy.GetComponent<Animator>().Play("BodyMoveRight");
                    UIManager.Instance.informativePanel.Play("InformativeRight");
                    //UIManager.Instance.cameraSlide.Play("SlideRight");

                    foreach (GameObject g in UIManager.Instance.bodyComponents)
                    {
                        g.GetComponent<Renderer>().material.color = bodyPart.disableColor;
                    }
                    GetComponent<Renderer>().material.color = bodyPart.enableColor;
                    Camera.main.GetComponent<AudioSource>().PlayOneShot(bodyPart.clickSound);
                    //CameraController.Instance.GetComponent<Camera>().fieldOfView = 4f;
                    //UIManager.Instance.canSelectBodyParts = false;
                    //UpdatePosition();
                    UIManager.Instance.getObject = hit.transform.gameObject;

                    foreach (GameObject g in UIManager.Instance.bodyComponents)
                    {
                        g.SetActive(true);
                    }
                    //UIManager.Instance.getObject.gameObject.SetActive(true);
                }
            }
        }

    }

    public void UpdatePosition()
    {
        Vector3 newPosition = Vector3.Lerp(CameraController.Instance.transform.position, new Vector3(0, transform.GetChild(0).transform.position.y, -4f), 1f);
        CameraController.Instance.transform.position = newPosition;
    }
}
