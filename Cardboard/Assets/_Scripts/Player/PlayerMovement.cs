using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float size; // 5

    private Vector3 offset;

    private Camera m_camera;

    void Start()
    {
        m_camera = Camera.main;

        size = m_camera.fieldOfView / 12.0f;
    }

    void Update()
    {
        // mouse
        Vector3 clickPosition = -Vector3.one;
        clickPosition = m_camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));

        // movemente
        if (Input.GetMouseButtonDown(0))
        {
            offset = transform.position - clickPosition;
        }
        else if (Input.GetMouseButton(0))
        {
            transform.position = (Vector2)clickPosition + (Vector2)offset;
        }

        // limit camera
        float w = size * (16f / 9f);

        float min = -w + m_camera.transform.position.x;
        float max = w + m_camera.transform.position.x;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min, max), Mathf.Clamp(transform.position.y, -size, size), transform.position.z);
    }

    enum PLAYER_STATE { PUSH, NO_PUSH, DEAD }
}
