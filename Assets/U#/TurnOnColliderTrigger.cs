
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TurnOnColliderTrigger : UdonSharpBehaviour
{
    [SerializeField] BoxCollider c;
    void OnPlayerTriggerEnter(VRCPlayerApi api)
    {
        if (api.Equals(Networking.LocalPlayer))
            c.enabled = true;
    }
}
