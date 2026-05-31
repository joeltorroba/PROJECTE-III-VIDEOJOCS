using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetPropulse()  { anim.SetTrigger("Propulse"); }
    public void SetLand()      { anim.SetTrigger("Land"); }
    public void SetHit()       { anim.SetTrigger("Hit"); }
    public void SetDie()       { anim.SetTrigger("Die"); }
    public void SetEndEffect()  { anim.SetTrigger("EndEffect"); }
    // Llamado por Animation Event al final de FallFlatImpact
    public void OnDieAnimFinished()
    {
        GameManager.instance.GameOver();
    }
}