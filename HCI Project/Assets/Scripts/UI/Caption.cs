using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Caption : MonoBehaviour
{
    TextMeshProUGUI captionText;
    bool captionShown;


    // Start is called before the first frame update
    void Start()
    {
        captionText = GetComponentInChildren<TextMeshProUGUI>();

        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (captionShown && Input.GetMouseButtonDown(2))
        {
            transform.DOScale(0, 0.5f).SetEase(Ease.InCirc);

            captionShown = false;
        }
    }

    public void SetCaption(string objectTag)
    {
        switch(objectTag)
        {
            case "Car":

                captionText.text = "This is a car. It is used as a mode of transport for people and things.";

                break;

            case "Tree":

                captionText.text = "This is a tree. It is made up of wood and leaves and provides oxygen for us to breathe.";

                break;

            case "Ground":

                captionText.text = "This is the ground. The ground is what we stand on.";

                break;
        }

        ShowCaption();
    }

    void ShowCaption()
    {
        transform.localScale = new Vector3(0, 0, 0);

        transform.DOScale(1, 0.5f).SetEase(Ease.OutElastic);

        captionShown = true;

        //StartCoroutine(FadeOutCaption());
    }

    //IEnumerator FadeOutCaption()
    //{
    //    yield return new WaitForSeconds(5);

    //    transform.DOScale(0, 1).SetEase(Ease.InCirc);
    //}
}
