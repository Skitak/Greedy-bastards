﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon {
   
    public float speed = 10f;
    public float range = 10f;
    [Range(0,1)]
    public float accuracy = 1f;
    [HideInInspector]
    public float travelTime;
    // private Player player;

    //Visual Effects
    public GameObject OnShootParticlesGo;
    public ParticleSystem OnShootParticles;

    public AudioPicker audioPick;


    protected override void Start() {
        base.Start();
        travelTime = range / speed;
    }
    protected override void use(Vector2 direction) 
    {
        --Ammunitions;
        Vector2 velocity = direction.normalized * speed;
        Vector3 spawningOffset = new Vector3 (direction.normalized.x, 0, direction.normalized.y);
        BulletPool.instantiateBullet(this.transform.position + spawningOffset, velocity, this);

        audioPick.Picker();

        if (OnShootParticles != null && OnShootParticlesGo != null)
        {
            /*OnShootParticlesGo.SetActive (true);*/
            OnShootParticles.Emit(1);
            OnShootParticles.enableEmission = true;
            OnShootParticles.Play();
            print (OnShootParticles.particleCount);
        }

    
    }

}
