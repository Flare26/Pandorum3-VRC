
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class BouncerBlocker : UdonSharpBehaviour
{
    [SerializeField] Animator gateAnim;
    [SerializeField] BoxCollider invisibleWall;
    [SerializeField] GameObject indicator;

    [UdonSynced] bool sync_isOpen;
    bool isOpen;

    private void Start()
    {
        // on start, disable barrier
        invisibleWall.enabled = false;
        isOpen = true;
        indicator.SetActive(isOpen);
        gateAnim.SetBool("isOpen", isOpen);

        sync_isOpen = isOpen;
        RequestSerialization(); // send the updated isOpen value to the server.
    }
    public void Interact(VRCPlayerApi api)
    {
        Networking.SetOwner(api, gameObject); // make whoever pressed the button the new network owner so clients sync to them
        isOpen = !isOpen; // toggle state
        indicator.SetActive(isOpen);
        gateAnim.SetBool("isOpen", isOpen);
        invisibleWall.enabled = !isOpen; // if isOpen true, invisible wall is false

        sync_isOpen = isOpen;
        RequestSerialization(); // send the updated isOpen value to the server.
    }

     public override void OnDeserialization()
    {
        if (isOpen != sync_isOpen)
        {
            isOpen = sync_isOpen;
            // on udon synced variable change :
            gateAnim.SetBool("isOpen", isOpen);
            indicator.SetActive(isOpen);
            invisibleWall.enabled = !isOpen; // if isOpen true, invisible wall is false
        }
    }
}
