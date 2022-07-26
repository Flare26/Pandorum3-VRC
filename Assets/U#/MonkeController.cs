
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MonkeController : UdonSharpBehaviour
{
    [SerializeField] Animator anim;
    AnimatorStateInfo asi;
    float timer = 0f;
    bool playerIsNear = false;

    private void Start()
    {
        anim.Play("sitting");
    }

    public override void OnPlayerTriggerStay(VRCPlayerApi api)
    {
        playerIsNear = true;
        if (api.Equals(Networking.LocalPlayer))
        {
            if (!asi.IsName("jumpinplace"))
                anim.Play("jumpinplace");
        }
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi api)
    {
        if (api.Equals(Networking.LocalPlayer))
        {
            playerIsNear = false;
        }
    }

    void SetAnimToSit()
    {
        if (true)
        {
            anim.SetBool("idle", true);
            anim.Play("idletosit");
            anim.SetBool("idle", false);
        }
    }
    private void Update()
    {
        asi = anim.GetCurrentAnimatorStateInfo(0);
        // jumping root motion handling
        if (asi.IsName("jumpinplace") && asi.normalizedTime < 0.01f && !playerIsNear)
            SetAnimToSit(); // should set to sit after jumpinplace finishes its current loop

        // random smile stuff
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else if (!playerIsNear)
        {
            //timer has been met
            anim.Play("smile");
            timer = Random.Range(5f, 20f);
        }
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
