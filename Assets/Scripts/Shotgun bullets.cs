
using UnityEngine;

public class Shotgunbullets : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask WhatIsEnemies;

    //Stats
    [Range(0f,1f)]
    public float bounciness;
    public bool useGravity;

    //Damage
    public int explosionDamage;
    public float explosionRange;

    //lifetime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions; 
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //when to explode:
        if (collisions > maxCollisions) Explode();

        //count down lifetime
        maxLifetime -= Time.deltaTime;
        if(maxLifetime <= 0) Explode();
    }

    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, WhatIsEnemies); 
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call take damage

            enemies[i].GetComponent<EnemyAiTutorial>().TakeDamage(explosionDamage);
        }
        //add a little dealy to make sure it works
        //Invoke("Delay, 0.05f");
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        

        //count up collisions
        collisions++;

        //explode if bullet hits and enemy directly and explode on touch is activated
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }
    private void Setup()
    {
        //create a new physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set Gravity
        rb.useGravity = useGravity;
    }


}