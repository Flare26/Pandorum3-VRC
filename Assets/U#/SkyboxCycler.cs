
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SkyboxCycler : UdonSharpBehaviour
{
    [SerializeField] Material [] skyboxes;
    [SerializeField] MeshRenderer currentviewMesh;
    //[SerializeField] MeshRenderer previewMesh;
    int c = 0;
    [UdonSynced] int c_sync;
    int cmax;
    [SerializeField] bool synced;

    private void Start()
    {

        cmax = skyboxes.Length;
        currentviewMesh.material = skyboxes[c];
    }
    public void Interact(VRCPlayerApi api)
    {
        c++;
        Debug.Log("local c " + c);
        Debug.Log("synced c " + c_sync);
         if (synced)
        {
            if (!Networking.IsOwner(gameObject))
                Networking.SetOwner(Networking.LocalPlayer, gameObject);

            c_sync = c;
            RequestSerialization();
        }

        UpdateSkyAndPreview();
    }


    void UpdateSkyAndPreview()
    {
        if (c < skyboxes.Length)
        {
            //Debug.Log("incrementing");
            Material s = skyboxes[c];
            RenderSettings.skybox = s;
            currentviewMesh.material = s;
        }
        else
        {
            //Debug.Log("resetting");
            c = 0;
            Material s = skyboxes[c];
            RenderSettings.skybox = s;
            currentviewMesh.material = s;
        }
    }

    public override void OnDeserialization()
    {
        if(synced)
        {
            c = c_sync;
            UpdateSkyAndPreview();
        }
    }
}
