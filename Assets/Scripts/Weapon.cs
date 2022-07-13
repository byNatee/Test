using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _containerForBullets;
    [SerializeField] private Transform _firePoint;
    private ObjectsPool _bulletsPool;

    private void Start()
    {
        _bulletsPool = new ObjectsPool(_bulletPrefab, _containerForBullets, true, 5);
        InputController.ShootAction += Attack;
    }

    private void Attack()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, ~LayerMask.GetMask("Point")))
        {
            var bullet = _bulletsPool.GetFreeElement();
            bullet.transform.position = _firePoint.position;
            bullet.transform.LookAt(hit.point);
        }
    }
}
