using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 20;                  // The damage inflicted by each bullet.
        public float timeBetweenBullets = 0.15f;        // The time between each shot.
        public float range = 10f;                      // The distance the gun can fire.
        public Rigidbody bullet;
        public Rigidbody opponent;
        public string fireButton;


        float timer;                                    // A timer to determine when to fire.
        List<Rigidbody> bullets;


        void Awake ()
        {

            bullets = new List<Rigidbody>();
        }


        void Update()
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;
            foreach (var bullet in bullets)
            {
                bullet.velocity = bullet.velocity.normalized * (opponent.GetComponent<PlayerMovement>().currentSpeed + 0.01f) * 30;
            }


            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton(fireButton) && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // ... shoot the gun.
                Shoot();
            }

        }


        void Shoot ()
        {
            // Reset the timer.
            timer = 0f;

            //Create bullet
            var bullet = (Rigidbody)Instantiate(this.bullet, transform.position, transform.rotation);
            bullet.velocity = transform.forward * (transform.parent.GetComponent<PlayerMovement>().currentSpeed +1);
            bullets.Add(bullet);
        }
    }
}