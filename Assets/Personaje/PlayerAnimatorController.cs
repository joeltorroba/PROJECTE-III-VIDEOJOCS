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

    // 🛋️ COLCHONETA: Usamos Trigger para que respete el caminito automático hacia Falling Idle
    public void SetPropulse()  
    { 
        if (anim != null)
        {
            ResetAllTriggers();
            // Forzamos un micro-reseteo al estado base por si venías de estar aplastado por la mancuerna
            anim.Play("Falling", 0, 0f); 
            anim.SetTrigger("Propulse");
        }
    }
    
    // 📦 FLOTADOR / CAJA: Usamos Trigger para que respete la transición automática hacia Idle
    public void SetLand()      
    { 
        if (anim != null)
        {
            ResetAllTriggers();
            // Si venías de estar aplastado en horizontal, te ponemos en vertical en un frame antes de lanzar el Land
            anim.Play("Falling", 0, 0f); 
            anim.SetTrigger("Land");
        }
    }
    
    // 🔨 MANCUERNA / YUNQUE: Este SÍ sigue usando Play directo porque el daño rompe todo de forma destructiva
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