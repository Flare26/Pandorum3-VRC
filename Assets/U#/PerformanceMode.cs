
using UdonSharp;
using UnityEngine;
using TMPro;
using VRC.SDKBase;
using VRC.Udon;

public class PerformanceMode : UdonSharpBehaviour
{
    [SerializeField] TextMeshProUGUI indicator;
    [SerializeField] GameObject[] targets;
    GameObject[] otherPerformanceButtons;
    bool isEnabled;
    void Start()
    {
        isEnabled = false;
    }

    public void ChangeState(bool currentState)
    {
        isEnabled = !currentState;
        //SyncOtherButtons
        switch (isEnabled)
        {
            case true:
                indicator.text = "[ENABLED]";
                indicator.color = Color.green;
                break;
            case false:
                indicator.text = "[DISABLED]";
                indicator.color = Color.red;
                break;
        }

        foreach (GameObject o in targets)
        {
            o.SetActive(!isEnabled); // if mode is enabled, stuff will be disabled
        }
    }

    private void SyncOtherButtons()
    {

    }
    public override void Interact()
    {
        ChangeState(isEnabled);
    }
}
