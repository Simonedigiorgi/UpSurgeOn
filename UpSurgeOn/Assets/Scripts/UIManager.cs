using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject skinsButton;
    public GameObject musclesButton;

    public GameObject[] skins;
    public GameObject muscles;

    public Color enableColor;
    public Color disableColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
