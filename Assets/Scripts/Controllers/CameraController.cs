using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoom_speed = 4f;
    public float min_zoom = 6f;
    public float max_zoom = 9f;
    
    private float current_zoom;

    private void Start()
    {
        current_zoom = max_zoom;
    }

    private void Update()
    {
        current_zoom -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed;
        current_zoom = Mathf.Clamp(current_zoom, min_zoom, max_zoom);
    }
    // Use this for initialization
    private void LateUpdate()
    {
        if (target == null)
            return;
        transform.position = target.position - offset * current_zoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
