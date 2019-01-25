using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {
   
    public float speed = 10f;
    public float range = 10f;
    [Range(0,1)]
    public float accuracy = 1f;
    protected float travelTime;
    // private Player player;

    //Visual Effects
    public GameObject OnShootParticlesGo;
    public ParticleSystem OnShootParticles;


    protected override void Start() {
        base.Start();
        travelTime = range / speed;
    }
    protected override void use(Vector2 direction) 
    {
        --Ammunitions;
        Vector2 velocity = direction.normalized * speed;
        Vector3 spawningOffset = (Vector3) (direction.normalized / 1);
        BulletPool.instantiateBullet(this.transform.position + spawningOffset, velocity, travelTime, this.gameObject);

        OnShootParticlesGo.transform.LookAt(this.transform.position + spawningOffset);
        OnShootParticles.enableEmission = true;
        OnShootParticles.Play();

        Timer timer = new Timer(5f, delegate(){
            print("hi");
        });
    }

}
