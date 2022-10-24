
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MaterialCycler : UdonSharpBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] MeshRenderer render;
    int idx = 0;
    [UdonSynced] int idx_sync;

    public override void OnDeserialization()
    {
        if (idx != idx_sync)
        {
            idx = idx_sync;
            UpdateMat(idx);
        }
    }    
    void UpdateMat(int c)
    {
        //Debug.Log("setting material to idx " + c);
        render.material = materials[c];
    }
    public void Interact(VRCPlayerApi api)
    {
        //Debug.Log("Before " + 0);
        Networking.SetOwner(api, gameObject);
        idx++;

        // check if the index is still wtihin bounds else reset to 0
        if (idx > materials.Length - 1)
        {
            // Send back to start and change to that material
            //Debug.Log("Resetting to 0");
            idx = 0;
            idx_sync = idx;
            RequestSerialization();
            UpdateMat(idx);
        } else
        {
            // keep the modified idx and change to new material
            //Debug.Log("Incrementing Mat");
            idx_sync = idx;
            RequestSerialization();
            UpdateMat(idx);
        }
        //Debug.Log("After " + idx);
    }
}
