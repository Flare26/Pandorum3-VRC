
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ClickToDelete : UdonSharpBehaviour
{

    [SerializeField] GameObject []toDel;
    public override void Interact()
    {
        foreach(GameObject o in toDel)
        {
            o.SetActive(false);
        }
    }
}
