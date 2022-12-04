using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ColourBlindManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;

    [SerializeField] TextureParameter defaultLUT;
    [SerializeField] TextureParameter protaLUT;
    [SerializeField] TextureParameter deuterLUT;
    [SerializeField] TextureParameter tritaLUT;

    [SerializeField] GradingModeParameter ldrMode;

    [SerializeField] PostProcessVolume volume;

    public bool isMenuOpen;

    public static ColourBlindManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isMenuOpen)
            {
                menuPanel.SetActive(false);
            }
            else
            {
                menuPanel.SetActive(true);
            }

            isMenuOpen = !isMenuOpen;
        }
    }

    public void ChangeToDefault()
    {
        ColorGrading color = null;

        if (volume.profile.TryGetSettings(out color))
        {
            color.enabled.value = true;
            color.ldrLut.value = null;
        }
    }

    public void ChangeToProta()
    {
        ColorGrading color = null;

        if (volume.profile.TryGetSettings(out color))
        {
            color.enabled.value = true;
            color.ldrLut.value = protaLUT;
        }
        //else
        //{
        //    ColorGrading newColor = (ColorGrading)ScriptableObject.CreateInstance("ColorGrading");
        //    newColor.gradingMode = ldrMode;
        //    newColor.ldrLut = protaLUT;

        //    volume.profile.AddSettings(color);

        //    print("Created Color");
        //}
    }

    public void ChangeToDeuter()
    {
        ColorGrading color = null;

        if (volume.profile.TryGetSettings(out color))
        {
            color.enabled.value = true;
            color.ldrLut.value = deuterLUT;
        }
    }

    public void ChangeToTrita()
    {
        ColorGrading color = null;

        if (volume.profile.TryGetSettings(out color))
        {
            color.enabled.value = true;
            color.ldrLut.value = tritaLUT;
        }
    }
}
