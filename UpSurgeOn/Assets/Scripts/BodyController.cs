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

                    foreach (GameObject g in UIManager.Instance.bodyComponents)
                        g.GetComponent<Renderer>().material.color = bodyPart.disableColor;

                    if(UIManager.Instance.isView == false)
                        GetComponent<Renderer>().material.color = bodyPart.enableColor;

                    UIManager.Instance.singleBodyPart = hit.transform.gameObject;

                    foreach (GameObject g in UIManager.Instance.bodyComponents)
                        g.SetActive(true);

                    Debug.Log("HIT");
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
