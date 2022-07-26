
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DoorTP : UdonSharpBehaviour
{
    [SerializeField] Transform warpTo;
    public void Interact(VRCPlayerApi api)
    {
       
        Networking.LocalPlayer.TeleportTo(warpTo.position, warpTo.rotation);
    }
}
