using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _target;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _hp = 2;

    private void Start()
    {
        _target = FindObjectOfType<Player>();
        _healthBar.SetMaxHp(_hp);
    }

    private void Update()
    {
        transform.LookAt(_target.transform.position, Vector3.up);
    }

    private void GetDamage()
    {
        _hp--;
        _healthBar.SetHp(_hp);

        if (_hp <= 0)
            Die();
    }

    private void Die()
    {
        _healthBar.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            GetDamage();
        }
    }
}
