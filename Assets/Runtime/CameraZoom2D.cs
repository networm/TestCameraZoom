using UnityEngine;

public class CameraZoom2D : MonoBehaviour
{
    public float TargetSize = 5f;

    public float ZoomSpeed = 100f;

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

        var oldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        TargetSize -= scrollWheel * Time.deltaTime * ZoomSpeed * TargetSize;
        _camera.orthographicSize = TargetSize;
        var newPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _camera.transform.position += oldPosition - newPosition;
    }
}
