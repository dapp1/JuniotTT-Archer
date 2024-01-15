using UnityEngine;

public class PigController : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private GameObject _arrowPrefab;

    private Animator _animator;

    private float _distance;
    private Vector2 _startPoint;
    private Vector2 _direction;
    private Quaternion _rotation;

    [SerializeField] private float _pushForce = 4f;
    [SerializeField] private GameObject _bone;
    [SerializeField] private GameObject _dot;

    [SerializeField] GameObject _endPoint;
    [SerializeField] private Traektory _traektory;

    public static Vector2 force;

    private void Start()
    {
        _rotation = _bone.transform.rotation;
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _startPoint = _dot.transform.position;
        _distance = Vector2.Distance(_startPoint, _endPoint.transform.position);

        if (_endPoint.activeSelf && _distance < 30)
        {
            StartShooting();
        }
        else
        {
            _bone.transform.rotation = _rotation;
            _traektory.Hide();
        }
    }

    void StartShooting()
    {
        _direction = (_endPoint.transform.position - (Vector3)_startPoint).normalized;
        force = _direction * _distance * _pushForce;

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle - 93, Vector3.forward);

        if (_endPoint.transform.position.x < transform.position.x)
            targetRotation *= Quaternion.Euler(0f, 180f, 0f);
        else if (_endPoint.transform.position.x >= transform.position.x)
            targetRotation *= Quaternion.Euler(0f, 0f, 0f);

        _bone.transform.rotation = Quaternion.Lerp(_bone.transform.rotation, targetRotation, 0.3f);

        _animator.SetBool("attack", true);
        _traektory.UpdateDots(_startPoint, force);
    }

    //Anim Event
    public void SpawnArrrow()
    {
        Instantiate(_arrowPrefab, _arrow.transform.position, _arrow.transform.rotation);
    }

    //Anim Event
    public void AnimBool()
    {
        _animator.SetBool("attack", false);
    }

}
