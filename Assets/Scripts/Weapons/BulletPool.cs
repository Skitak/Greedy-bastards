using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class BulletPool : MonoBehaviour {
    private static BulletPool instance = null;
    public int startingBulletPoolSize = 50;
    public GameObject bulletPrefab = null;
    private Stack<Bullet> pool;

    private void Start() {
        if (BulletPool.instance != null){
            Debug.Log("Two instances of bullet pool.");
            return;
        }
        BulletPool.instance = this;
        pool = new Stack<Bullet>();
        for (int i = 0; i < startingBulletPoolSize; ++i){
            BulletPool.makeBullet();
        }
    }

    private static void makeBullet(){
        Instantiate (instance.bulletPrefab, new Vector3(0, 1000, -10), Quaternion.identity);
    }

    public static void registerBullet(Bullet bullet){
        instance.pool.Push(bullet);
    }

    public static void instantiateBullet(Vector3 position, Vector2 velocity, Gun owner){
        Bullet bullet = instance.pool.Pop();
        bullet.transform.position = position;
        bullet.gameObject.SetActive(true);
        bullet.fire(velocity, owner);
    }
}