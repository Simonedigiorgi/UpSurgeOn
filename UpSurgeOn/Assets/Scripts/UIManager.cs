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
    public Text[] labelText;

    public GameObject skinsButton;
    public GameObject musclesButton;
    public GameObject labelsButton;

    public Animator informativePanel;
    public Animator cameraSlide;
    public Animator humanAnatomy;

    public GameObject[] skins;
    public GameObject muscles;

    public Color enableColor;
    public Color disableColor;

    public Text titleText;
    public Text descriptionText;

    [HideInInspector] public GameObject getObject;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
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

        // Disable component colors
        foreach (GameObject i in bodyComponents)
        {
            i.GetComponent<Renderer>().material.color = i.GetComponent<BodyController>().bodyPart.disableColor;
            i.SetActive(true);
        }

    }

    public void ShowLabels()
    {
        // Shows label name on body part 
        foreach (Text t in labelText)
        {
            if (t.enabled)
            {
                t.enabled = false;
                labelsButton.GetComponent<Image>().color = disableColor;
            }
            else
            {
                t.enabled = true;
                labelsButton.GetComponent<Image>().color = enableColor;
            }

        }
    }

    public void HideObject()
    {
        if (getObject.activeSelf)
            getObject.gameObject.SetActive(false);
        else
            getObject.gameObject.SetActive(true);
    }
}
