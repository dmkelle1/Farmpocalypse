using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _target;
    private Vector2 _moveDirection;

    [Header("Stats")]
    [SerializeField]
    private float _defense;
    [SerializeField]
    private float _speed;
    private float _maxHealth = 3;
    private float _health;

    [Header("References")]
    public Animator animator;
    public GameObject healDrop;
    public ParticleSystem explosionParticle;

    private float eXp = 10;
    private bool abovePlayer;
    private bool dead = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        _health = _maxHealth;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_target)
        {
            Vector2 direction = (_target.position - transform.position).normalized;
            _moveDirection = direction;
        }
        IsPlayerAbove();
        if (animator) 
        {
            animator.SetBool("isPlayerAbove", abovePlayer);
        }
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            _rb.linearVelocity = (_target.position - transform.position).normalized;
        }
    }

    private void IsPlayerAbove() //determines if the cow is above or below the player (next to counts as above)
    {
        if (_target)
        {
            abovePlayer = _target.position.y >= transform.position.y;
        }
    }

    public void TakeDamage(float damage)
    {
        if (dead) return;
        _health -= Mathf.Max(damage-_defense, 0);
        if (_health <= 0)
        {
            dead = true;
            StartCoroutine(HandleDeath());
        }
    }

    public void DropSpawn()
    {
        int chance = Random.Range(1, 100);
        if (chance == 1)
        {
            Instantiate(healDrop, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator HandleDeath()
    {
        if (animator) animator.enabled = false;
        if (_rb) _rb.simulated = false;
        yield return null;
        yield return null;
        yield return null;

        if (explosionParticle != null)
        {
            var ps = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            ps.Play();
            Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax + 0.5f);
        }

        if (_target)
        {
            var pxp = _target.GetComponent<PlayerExp>();
            if (pxp)
            {
                pxp.ExpUp(eXp);
            }
        }

        int chance = Random.Range(1, 101);
        if(chance == 1 && healDrop != null)
        {
            Instantiate(healDrop, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
