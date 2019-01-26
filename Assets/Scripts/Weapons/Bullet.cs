using UnityEngine;
// Please don't destroy this object.
// It is part of a pool patern which is in the BulletPool class.
// If you want that item to dissapear, plase use the "registerToBuletPool" method.
public class Bullet : MonoBehaviour {
    [HideInInspector]
    public Gun owner;
    private Vector3 velocity;
    private Rigidbody rigid;
    private Timer onScreenTime;
    private void Start() {
        rigid = this.GetComponent<Rigidbody>();
        onScreenTime = new Timer(5f);
        onScreenTime.OnTimerEnd += registerToBulletPool;
        registerToBulletPool();
    }

    private void Update() {
        rigid.velocity = this.velocity;
    }
    private void OnCollisionEnter2D(Collision2D other) {

        registerToBulletPool();
    }

    public void fire(Vector2 velocity, Gun owner){
        this.owner = owner;
        this.velocity = new Vector3(velocity.x, 0, velocity.y);
        rigid.velocity = velocity;
        this.onScreenTime.EndTime = owner.travelTime;
        this.onScreenTime.ResetPlay();
    }

    private void registerToBulletPool(){
        onScreenTime.Pause();
        this.gameObject.SetActive(false);
        BulletPool.registerBullet(this);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Mob"){
            other.gameObject.GetComponent<BaseEntity>().Hit(owner.damages);
            registerToBulletPool();
        }
    }
}