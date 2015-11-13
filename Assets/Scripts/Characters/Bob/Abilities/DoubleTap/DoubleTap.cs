using UnityEngine;
using System.Collections;

public class DoubleTap : MonoBehaviour, Ability {

    public Rigidbody projectile;

    public float cooldown { get; set; }
    public float globalCooldown { get; set; }
    public string abilityName { get; set; }
    public string description { get; set; }


    float timer;
    float doubleTapInterval = 0.1f;
    float projectileSpeed = 100;

    // Use this for initialization
    void Start () {
        cooldown = 0.5f;
        globalCooldown = 1f;
        name = "Double Tap";
        description = "Shoots 2 bullets yo";
        projectile = (Resources.Load("Characters/Bob/Abilities/DoubleTap/DoubleTapProjectile") as GameObject).GetComponent<Rigidbody>();
	}

    void Update ()
    {
        timer += Time.deltaTime;
    }

    public void Cast()
    {
        if(timer >= cooldown)
        {
            //this is probably dumb
            timer = 0;
            StartCoroutine(shoot());
        }
        
    }

    private IEnumerator shoot()
    {
        
        spawnBullet();
        yield return new WaitForSeconds(doubleTapInterval);
        spawnBullet();
    }

    private void spawnBullet()
    {
        var bullet = (Rigidbody)Instantiate(this.projectile, transform.position, transform.rotation);
        bullet.velocity = transform.forward * projectileSpeed   ;
    }
}
