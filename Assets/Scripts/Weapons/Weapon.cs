using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    public int damages = 1;
    public int startingAmmunitions = 2;
    public int maxAmmunitions = 10;
    public float fireRate = 0.5f;
    public float ammunitionRegenerationRate = 0.5f;
    // protected BaseCharacter owner;
    
    private Timer ammunitionRegenerationTimer;
    private Timer fireRateTimer;
    private int ammunitions; 
    public int Ammunitions {
        get {
            return ammunitions;
        }
        set {
            if (value > maxAmmunitions)
                ammunitions = maxAmmunitions;
            else if (value < 0)
                ammunitions = 0;
            else
                ammunitions = value;
            ammunitionRegenerationTimer.ResetPlay();
        }
    }
    protected virtual void Start() {
        ammunitions = startingAmmunitions;
        // owner = this.gameObject.GetComponent<BaseCharacter>();
        ammunitionRegenerationTimer = new Timer(ammunitionRegenerationRate, delegate(){
            this.Ammunitions++;
        });
        ammunitionRegenerationTimer.Play();
        fireRateTimer = new Timer(fireRate, true);
    }

    // The player (or anything) asks the weapon to be used in a direction
    public void tryUse(Vector2 direction) {
        if (fireRateTimer.IsFinished()){
            if (Ammunitions > 0)
                use(direction);
            else
                fail(direction);
            fireRateTimer.ResetPlay();
        }
    }

    protected abstract void use(Vector2 direction);

    protected virtual void fail(Vector2 direction){
        // nothing happens here
    } 

    public float getReloadPercentage(){
        return ammunitionRegenerationTimer.GetPercentage();
    }

    public void reset(){
        ammunitions = startingAmmunitions;
        ammunitionRegenerationTimer.ResetPlay();
    }

}
