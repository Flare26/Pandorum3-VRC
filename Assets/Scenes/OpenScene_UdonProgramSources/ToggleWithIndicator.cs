
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleWithIndicator : UdonSharpBehaviour
{

    [SerializeField] GameObject indicator;
    [SerializeField] GameObject[] objstotoggle;
    public override void Interact()
    {
        foreach (GameObject o in objstotoggle)
        {
            o.SetActive(!o.activeSelf);
        }
        indicator.SetActive(!indicator.activeSelf);
    }
}
