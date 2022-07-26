
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ObjectReset_inator : UdonSharpBehaviour
{

    [SerializeField] GameObject[] toBeReset;
    Rigidbody[] rbs;
    Vector3[] OGpos;

    void Start()
    {
        OGpos = new Vector3[toBeReset.Length];
        rbs = new Rigidbody[toBeReset.Length];
        for ( int i = 0 ; i < toBeReset.Length; i++)
        {
            OGpos[i] = toBeReset[i].transform.position;
            rbs[i] = toBeReset[i].GetComponent<Rigidbody>();
        }
    }

    public void Interact(VRCPlayerApi player)
    {
        for (int i = 0 ; i < toBeReset.Length; i++)
        {
            Networking.SetOwner(player, toBeReset[i]);

            toBeReset[i].transform.position = OGpos[i];
            rbs[i].velocity = Vector3.zero;
        }
    }


}
