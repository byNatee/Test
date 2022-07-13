using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private void Update() =>
        transform.Translate(new Vector3(0, 0, _speed) * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }
}
