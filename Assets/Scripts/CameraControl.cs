using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 500.0f;
    [SerializeField]
    private GameObject _target;
    private float _defaultFieldOfView = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            OrbitCamera();
        }

        FitToScreen();
    }

    //Positions the camera so that it can see all objects from _target
    private void FitToScreen()
    {
        Camera.main.fieldOfView = _defaultFieldOfView;
        Bounds bound = GetBounds(_target);
        Vector3 boundSize = bound.size;

        float boundDiagonal = Mathf.Sqrt(boundSize.x * boundSize.x + boundSize.y * boundSize.y + boundSize.z * boundSize.z);
        float camDistanceToBoundCenter = boundDiagonal / 2.0f / (Mathf.Tan(Camera.main.fieldOfView / 2.0f * Mathf.Deg2Rad));
        float camDistanceToBoundWithOffset = camDistanceToBoundCenter + boundDiagonal / 2.0f - (Camera.main.transform.position - transform.position).magnitude;
        transform.position = bound.center + (-transform.forward * camDistanceToBoundWithOffset);
    }

    //Rotates camera to orbit _target
    private void OrbitCamera()
    {
        if(Input.GetAxis("Mouse X") != 0)
        {
            float horizontalInput = Input.GetAxis("Mouse X") * _rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(Vector3.up, horizontalInput, Space.World);
        }
    }

    //Gets the 3d bounding space of _target
    private Bounds GetBounds(GameObject target)
    {
        Bounds bound = new Bounds(target.transform.position, Vector3.zero);
        Renderer[] renderers = target.GetComponentsInChildren<Renderer>();
        foreach(Renderer r in renderers)
        {
            bound.Encapsulate(r.bounds);
        }

        bound.size *= 0.75f;
        return bound;
    }
}
