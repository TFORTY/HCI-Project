using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Vector3 zoomTarget;

    Quaternion defaultCamRotation;

    // Start is called before the first frame update
    void Start()
    {
        defaultCamRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            zoomTarget = hit.point;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Camera.main.fieldOfView = 20;
            Camera.main.transform.LookAt(zoomTarget);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Camera.main.fieldOfView = 60;
            Camera.main.transform.rotation = defaultCamRotation;
        }
    }
}
