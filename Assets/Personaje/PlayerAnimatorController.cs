using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    public Rig footRig;

    void Start()
    {
        anim = GetComponent<Animator>();
        footRig.weight = 1f; // siempre activo
    }

    public void SetFalling()   { anim.SetTrigger("Falling"); }
    public void SetPropulse()  { anim.SetTrigger("Propulse"); }
    public void SetLand()      { anim.SetTrigger("Land"); }
    public void SetHit()       { anim.SetTrigger("Hit"); }
    public void SetDie()       { anim.SetTrigger("Die"); }

    public void OnDieAnimFinished()
    {
        GameManager.instance.GameOver();
    }
}