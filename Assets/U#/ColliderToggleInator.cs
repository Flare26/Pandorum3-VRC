// Nathan Frazier
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ColliderToggleInator : UdonSharpBehaviour
{
    [SerializeField] Collider[] colliders;

    public override void Interact()
    {
        ToggleColliders();
    }
    public void ToggleColliders()
    {
        foreach (Collider c in colliders )
        {
            c.enabled = !c.enabled; // c is natcee
        }
    }
}
