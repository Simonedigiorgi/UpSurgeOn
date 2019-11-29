using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRubyShared;

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

    [HideInInspector] public GameObject singleBodyPart;
    [HideInInspector] public bool isView;

    private Vector3 bodypartPosition;
    public Transform bodypartPivot;

    public GameObject[] clones;

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
        Image s = skinsButton.GetComponent<Image>();
        foreach (GameObject skin in skins)
        {
            if (skin.activeSelf == false)
                s.color = ChangeColor(enableColor, skin, true);
            else
                s.color = ChangeColor(disableColor, skin, false);
        }
    }

    public void CharacterMuscle()
    {
        Image m = musclesButton.GetComponent<Image>();
        if (muscles.activeSelf == false)
            m.color = ChangeColor(enableColor, muscles, true);
        else
            m.color = ChangeColor(disableColor, muscles, false);
    }

    public void CloseDescription()
    {
        humanAnatomy.GetComponent<Animator>().Play("BodyMoveLeft");
        if (isView)
            informativePanel.Play("InformativeDetailsClose");
        else
            informativePanel.Play("InformativeLeft");

        // Disable component colors
        foreach (GameObject i in bodyComponents)
        {
            i.GetComponent<Renderer>().material.color = i.GetComponent<BodyController>().bodyPart.disableColor;
            i.SetActive(true);
        }

        foreach (MeshRenderer mesh in humanAnatomy.GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = true;
            isView = false;
        }

        foreach (MeshCollider collider in humanAnatomy.GetComponentsInChildren<MeshCollider>())
            collider.GetComponent<MeshCollider>().enabled = true;
    }

    public void ShowLabels()
    {
        // Shows label name on body part 
        foreach (Text text in labelText)
        {
            Image t = labelsButton.GetComponent<Image>();
            if (text.enabled)
            {
                text.enabled = false;
                labelsButton.GetComponent<Image>().color = disableColor;
            }
            else
            {
                text.enabled = true;
                labelsButton.GetComponent<Image>().color = enableColor;
            }
        }
    }

    public void HideObject()
    {
        if(isView == false)
        {
            if (singleBodyPart.activeSelf)
                singleBodyPart.gameObject.SetActive(false);
            else
                singleBodyPart.gameObject.SetActive(true);
        }
        else
            singleBodyPart.gameObject.SetActive(true);

        foreach (Text t in labelText)
        {
            if (t.enabled)
            {
                t.enabled = false;
                labelsButton.GetComponent<Image>().color = disableColor;
            }
        }
    }

    public void DetailedView()
    {
        singleBodyPart.gameObject.SetActive(true);
        foreach (MeshRenderer mesh in humanAnatomy.GetComponentsInChildren<MeshRenderer>())
        {
            singleBodyPart.GetComponent<Renderer>().material.color = disableColor;
            mesh.enabled = false;
            singleBodyPart.GetComponent<MeshRenderer>().enabled = true;
        }

        foreach (MeshCollider collider in humanAnatomy.GetComponentsInChildren<MeshCollider>())
            collider.GetComponent<MeshCollider>().enabled = false;

        foreach (Text t in labelText)
        {
            if (t.enabled)
            {
                t.enabled = false;
                labelsButton.GetComponent<Image>().color = disableColor;
            }
        }

        singleBodyPart.GetComponent<MeshCollider>().enabled = true;
        isView = true;

        humanAnatomy.GetComponent<Animator>().Play("BodyMoveLeft");
        informativePanel.Play("InformativeDetails");
    }

    Color ChangeColor(Color color, GameObject obj, bool equal)
    {
        obj.SetActive(equal);
        return color;
    }
}
