using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private static readonly int Run = Animator.StringToHash("Run");
    private GameObject[] _points;
    private int _pointCount = 0;
    private Vector3 _nextPoint;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _points = GameObject.FindGameObjectsWithTag("Point");
        
        _nextPoint = _points[_pointCount].transform.position;
        Move(_nextPoint);
    }

    private void Update()
    {
        if (_agent.isStopped)
        {
            var enemies = Physics.OverlapSphere(_nextPoint, 5, LayerMask.GetMask("Enemy"));
            if (enemies.Length == 0)
            {
                _pointCount++;
                _nextPoint = _points[_pointCount].transform.position;
                Move(_nextPoint);
            }
        }
    }

    private void Move(Vector3 point)
    {
        _agent.destination = point;
        _agent.isStopped = false;
        _animator.SetBool(Run, true);
    }

    private void Stop()
    {
        _agent.isStopped = true;
        _animator.SetBool(Run, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (_pointCount == _points.Length - 1)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                Stop();
        }
    }
}
