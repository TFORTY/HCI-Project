using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraZoom : MonoBehaviour
{
    Vector3 zoomTarget;
    Quaternion defaultCamRotation;

    float fullZoomedFOV = 20;
    float noZoomFOV = 60;

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
            Camera.main.transform.LookAt(zoomTarget);

            DOTween.Kill(Camera.main);
            Camera.main.DOFieldOfView(fullZoomedFOV, 0.5f).SetEase(Ease.OutCirc);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Camera.main.transform.rotation = defaultCamRotation;

            DOTween.Kill(Camera.main);
            Camera.main.DOFieldOfView(noZoomFOV, 0.2f).SetEase(Ease.InCirc);
        }
    }
}
