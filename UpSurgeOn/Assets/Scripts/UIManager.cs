using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }

    public GameObject[] bodyComponents;

    public GameObject skinsButton;
    public GameObject musclesButton;

    public Animator informativePanel;
    public Animator cameraSlide;
    public Animator humanAnatomy;

    public GameObject[] skins;
    public GameObject muscles;

    public Color enableColor;
    public Color disableColor;

    public Text text;

    public bool canSelectBodyParts;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        canSelectBodyParts = true;
    }

    public void CharacterSkins()
    {
        foreach (GameObject skin in skins)
        {
            if (skin.activeSelf == false)
            {
                skin.SetActive(true);
                skinsButton.GetComponent<Image>().color = enableColor;
            }

            else
            {
                skin.SetActive(false);
                skinsButton.GetComponent<Image>().color = disableColor;
            }

        }
    }

    public void CharacterMuscle()
    {
        if (muscles.activeSelf == false)
        {
            muscles.SetActive(true);
            musclesButton.GetComponent<Image>().color = enableColor;
        }

        else
        {
            muscles.SetActive(false);
            musclesButton.GetComponent<Image>().color = disableColor;
        }

    }

    public void CloseDescription()
    {
        humanAnatomy.GetComponent<Animator>().Play("BodyMoveLeft");
        informativePanel.Play("InformativeLeft");
        //cameraSlide.Play("SlideLeft");
        text.text = "Empty";

        // Disable components color
        foreach (GameObject i in bodyComponents)
        {
            i.GetComponent<Renderer>().material.color = i.GetComponent<BodyController>().bodyPart.disableColor;
            canSelectBodyParts = true;
        }
    }
}
