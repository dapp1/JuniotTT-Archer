using UnityEngine;

public class Traektory : MonoBehaviour
{
    [SerializeField] private int _dotsNumber;
    [SerializeField] private GameObject _dotsParent;
    [SerializeField] private GameObject _dotPrefab;
    [SerializeField] private float _dotSpacing;
    [SerializeField][Range(0.01f, 0.3f)] private float _dotMinScale;
    [SerializeField][Range(0.3f, 1f)] private float _dotMaxScale;

    Transform[] _dotsList;
    Vector2 _pos;
    float _timeStamp;

    void Start()
    {
        PrepareDots();
    }

    void PrepareDots()
    {
        _dotsList = new Transform[_dotsNumber];
        _dotPrefab.transform.localScale = Vector3.one * _dotMaxScale;

        float scale = _dotMaxScale;
        float scaleFactor = scale / _dotsNumber;

        for (int i = 0; i < _dotsNumber; i++)
        {
            _dotsList[i] = Instantiate(_dotPrefab, null).transform;
            _dotsList[i].parent = _dotsParent.transform;

            _dotsList[i].localScale = Vector3.one * scale;
            if (scale > _dotMinScale)
                scale -= scaleFactor;
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        _dotsParent.SetActive(true);
        _timeStamp = _dotSpacing;
        for (int i = 0; i < _dotsNumber; i++)
        {
            _pos.x = (ballPos.x + forceApplied.x * _timeStamp);
            _pos.y = (ballPos.y + forceApplied.y * _timeStamp) - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2f;

            _dotsList[i].position = _pos;
            _timeStamp += _dotSpacing;
        }
    }

    public void Show()
    {
        _dotsParent.SetActive(true);
    }

    public void Hide()
    {
        _dotsParent.SetActive(false);
    }

}
