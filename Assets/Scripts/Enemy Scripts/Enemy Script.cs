using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody2D _rb;
    private Transform _target;
    private Vector2 _moveDirection;

    [SerializeField]
    private float _defense;
    private float _maxHealth = 100;
    private float _health;

    public Animator animator;
    private bool abovePlayer;

    private float eXp = 10;

    public GameObject healDrop;

    public ParticleSystem explosionParticle;

    public float defenseBuff = 0f;
    public float speedBuff = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        animator = GetComponent<Animator>();
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
        animator.SetBool("isPlayerAbove", abovePlayer); //Sets animation to front or back depending on player position relative to enemy
    }

    private void FixedUpdate()
    {
        if (_target)
        {
            _rb.linearVelocity = new Vector2(_moveDirection.x, _moveDirection.y) * _speed;
        }
    }

    private void OnDestroy()
    {
        if (explosionParticle != null)
        {
            explosionParticle.transform.parent = null;
            explosionParticle.Play();
            Destroy(explosionParticle.gameObject, explosionParticle.main.duration + 1);
        }
        DropSpawn(); 
        ScoreManager.Instance.scoreIncrease();
        if (_target)
        {
            PlayerExp exp = _target.GetComponent<PlayerExp>();
            exp.ExpUp(eXp);
        }
    }

    private void IsPlayerAbove() //determines if the cow is above or below the player (next to counts as above)
    {
        if (_target.transform.position.y >= transform.position.y)
        {
            abovePlayer = true;
        }
        else
        {
            abovePlayer = false;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= (damage-_defense);
        if (_health <= 0)
        {
            Destroy(gameObject);
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
}
