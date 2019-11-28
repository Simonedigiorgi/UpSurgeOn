using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private static CameraController _instance;
    public static CameraController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CameraController>();
            }

            return _instance;
        }
    }

    // Camera Zoom
    public Camera selectedCamera;
    public float minPinchSpeed = 5.0F;
    public float varianceInDistances = 5.0F;
    private float touchDelta = 0.0F;
    private Vector2 prevDist = new Vector2(0, 0);
    private Vector2 curDist = new Vector2(0, 0);
    private float speedTouch0 = 0.0F;
    private float speedTouch1 = 0.0F;

    // Camera Slider
    public Slider slider;
    private Vector3 position1 = new Vector3(0f, 0.03f, -5);
    private Vector3 position2 = new Vector3(0f, -1.65f, -5);

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        slider.onValueChanged.AddListener(UpdatePosition);
    }

    void Update()
    {
        // Zoom
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            curDist = Input.GetTouch(0).position - Input.GetTouch(1).position; //current distance between finger touches
            prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)); //difference in previous locations using delta positions
            touchDelta = curDist.magnitude - prevDist.magnitude;
            speedTouch0 = Input.GetTouch(0).deltaPosition.magnitude / Input.GetTouch(0).deltaTime;
            speedTouch1 = Input.GetTouch(1).deltaPosition.magnitude / Input.GetTouch(1).deltaTime;

            if ((touchDelta + varianceInDistances <= 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
                selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView + 0.2f, 1, 7);

            if ((touchDelta + varianceInDistances > 1) && (speedTouch0 > minPinchSpeed) && (speedTouch1 > minPinchSpeed))
                selectedCamera.fieldOfView = Mathf.Clamp(selectedCamera.fieldOfView - 0.2f, 1, 7);
        }
    }

    // Slider
    public void UpdatePosition(float value)
    {
        Vector3 newPosition = Vector3.Lerp(position1, position2, value);
        selectedCamera.transform.position = newPosition;
    }
}
