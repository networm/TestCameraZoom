using UnityEngine;

public class CameraZoom3D : MonoBehaviour
{
    public float TargetSize = 60f;

    public float ZoomSpeed = 100f;

    private const float Farclip = 10f;

    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel == 0f)
        {
            return;
        }

        var oldPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Farclip));
        TargetSize -= scrollWheel * Time.deltaTime * ZoomSpeed * TargetSize;
        _camera.fieldOfView = TargetSize;
        var newPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Farclip));
        _camera.transform.position += oldPosition - newPosition;
    }
}
