using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _target;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _hp = 2;
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Collider[] _colliders;
    private Animator _animator;
    private int _defaultLayer = 1;
    private bool _isRagdoll;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _target = FindObjectOfType<Player>();
        _healthBar.SetMaxHp(_hp);
        DisableRagdoll();
    }

    private void Update()
    {
        if(!_isRagdoll)
            transform.LookAt(_target.transform.position, Vector3.up);
    }

    private void EnableRagdoll()
    {
        _isRagdoll = true;
        foreach (var rigidbody in _rigidbodies)
            rigidbody.isKinematic = false;

        foreach (var collider in _colliders)
            collider.enabled = true;
    }
    
    private void DisableRagdoll()
    {
        _isRagdoll = false;
        foreach (var rigidbody in _rigidbodies)
            rigidbody.isKinematic = true;

        foreach (var collider in _colliders)
            collider.enabled = false;
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
        _animator.avatar = null;
        EnableRagdoll();
        gameObject.layer = _defaultLayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            GetDamage();
        }
    }
}
