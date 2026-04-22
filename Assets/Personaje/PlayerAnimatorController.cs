using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetFalling()   { anim.SetTrigger("Falling"); }
    public void SetPropulse()  { anim.SetTrigger("Propulse"); }
    public void SetLand()      { anim.SetTrigger("Land"); }
    public void SetHit()       { anim.SetTrigger("Hit"); }
    public void SetDie()       { anim.SetTrigger("Die"); }

    // Llamado por Animation Event al final de FallFlatImpact
    public void OnDieAnimFinished()
    {
        GameManager.instance.GameOver();
    }
}