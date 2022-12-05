using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera zoomedCam;
    [SerializeField] GameObject magnifyPanel;

    Vector3 zoomTarget;
    Quaternion defaultCamRotation;

    float fullZoomedFOV = 20;
    float noZoomFOV = 60;

    bool zoomActive;

    bool zoomPanelLocked;

    // Start is called before the first frame update
    void Start()
    {
        defaultCamRotation = transform.rotation;

        magnifyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            zoomTarget = hit.point;

            //zoomedCam.transform.position = zoomTarget + new Vector3(0, 5, -5);

        }

        if (zoomActive)
        {
            if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(2))
            {
                zoomPanelLocked = !zoomPanelLocked;
            }

            if (!zoomPanelLocked)
            {
                zoomedCam.transform.LookAt(zoomTarget);

                magnifyPanel.transform.position = Input.mousePosition;
            }
        }

        //if (!ColourBlindManager.Instance.isMenuOpen)
        //{
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Camera.main.transform.LookAt(zoomTarget);

            //    DOTween.Kill(Camera.main);
            //    Camera.main.DOFieldOfView(fullZoomedFOV, 0.5f).SetEase(Ease.OutCirc);
            //}

            //if (Input.GetMouseButtonUp(0))
            //{
            //    Camera.main.transform.rotation = defaultCamRotation;

            //    DOTween.Kill(Camera.main);
            //    Camera.main.DOFieldOfView(noZoomFOV, 0.2f).SetEase(Ease.InCirc);
            //}
        //}

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ActivateZoom();
        }
    }

    public void ActivateZoom()
    {
        print("HI");

        zoomActive = !zoomActive;

        if (zoomActive)
        {
            magnifyPanel.SetActive(true);
        }
        else
        {
            magnifyPanel.SetActive(false);
        }
    }
}
