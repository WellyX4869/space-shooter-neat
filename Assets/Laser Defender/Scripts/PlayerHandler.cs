using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler instance;

    // config params
    [Header("Player Stats")]
    [SerializeField] int health = 200;
    [SerializeField] int maxHealth = 300;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] Transform projectileTransform;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    [Header("Audio")]
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound = null;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    Coroutine firingCoroutine;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); }
        else { instance = this; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer || damageDealer.tag == BulletTags.PlayerBullet.ToString()) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        //FindObjectOfType<Level>().LoadGameOver();
        //Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    public void EnableFire()
    {
        firingCoroutine = StartCoroutine(FireContinuously());
    }

    public void DisableFire()
    {
        if (firingCoroutine != null)
            StopCoroutine(firingCoroutine);
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, projectileTransform.position, Quaternion.identity) as GameObject;
            laser.tag = BulletTags.PlayerBullet.ToString();
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            //AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
