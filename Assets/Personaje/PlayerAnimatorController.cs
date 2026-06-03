using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Limpia la cola de espera de Unity para evitar acumulación de inputs
    public void ResetAllTriggers()
    {
        if (anim != null)
        {
            anim.ResetTrigger("Propulse");
            anim.ResetTrigger("Land");
            anim.ResetTrigger("Hit");
            anim.ResetTrigger("EndEffect");
        }
    }

    
    public void SetPropulse()  
    { 
        if (anim != null)
        {
            ResetAllTriggers();
           
            anim.Play("Falling", 0, 0f); 
            anim.SetTrigger("Propulse");
        }
    }
    
    
    public void SetLand()      
    { 
        if (anim != null)
        {
            ResetAllTriggers();
            anim.Play("Falling", 0, 0f); 
            anim.SetTrigger("Land");
        }
    }
    

    public void SetHit()       
    { 
        ResetAllTriggers(); 
        if (anim != null) 
        {
            anim.Play("Fall Flat", 0, 0f); 
        }
    }
    
    public void SetDie()       { anim.SetTrigger("Die"); }
    
    public void SetEndEffect() 
    { 
        ResetAllTriggers(); 
        if (anim != null) anim.SetTrigger("EndEffect"); 
    }

    public void OnDieAnimFinished()
    {
        GameManager.instance.GameOver();
    }
}