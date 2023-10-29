using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float distance;

    [SerializeField]
    private float xAxisSpeed = 400.0f;
    [SerializeField]
    private float yAxisSpeed = 500.0f;
    private float xAxisLimitMin = 5.0f;
    private float xAxisLimitMax = 80.0f;
    private float x, y;

    private void Awake()
    {
        distance = Vector3.Distance(transform.position, target.position);

        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }

    private void LateUpdate()
    {
        if (!target) return;

        transform.position = target.position + transform.rotation * Vector3.back * distance;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateRotate();
    }

    private void UpdateRotate()
    {
        y += Input.GetAxisRaw("Mouse X") * yAxisSpeed * Time.deltaTime;
        x = ClampAngle(x, xAxisLimitMin, xAxisLimitMax);

        transform.rotation = Quaternion.Euler(x, y, 0);

        if (target)
        {
            target.rotation = Quaternion.Euler(0, y, 0);
        }
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
