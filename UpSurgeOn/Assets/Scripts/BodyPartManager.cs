using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartManager : MonoBehaviour
{
    public Body body;
    public Text nameLabel;

    private void Start()
    {
        nameLabel.text = body.name;
    }

    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(transform.position);
        nameLabel.transform.position = namePos;
    }
}
