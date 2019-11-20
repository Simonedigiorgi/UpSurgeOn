using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSlider : MonoBehaviour
{
    public Transform mainCamera;

    private Vector3 position1 = new Vector3(0f, 0f, -5);
    private Vector3 position2 = new Vector3(0f, -1.65f, -5);

    void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(UpdatePosition);
    }

    public void UpdatePosition(float value)
    {
        Vector3 newPosition = Vector3.Lerp(position1, position2, value);
        mainCamera.transform.position = newPosition;
    }
}
