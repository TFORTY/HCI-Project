using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionSelector : MonoBehaviour
{
    [SerializeField] Caption caption;

    public delegate void Action(Vector3 mousePos);
    public static event Action OnRightClick;

    // Start is called before the first frame update
    void Start()
    {
        OnRightClick += DetectObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnRightClick?.Invoke(Input.mousePosition);
        }
    }

    void DetectObject(Vector3 mousePos)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        //Sets mouse variables based on the mouse position in the world
        if (Physics.Raycast(ray, out hit, 100))
        {
            caption.SetCaption(hit.collider.tag);
        }
    }
}
