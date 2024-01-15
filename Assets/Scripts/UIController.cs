using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button spawnTargetButton;

    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    [SerializeField] private Target _target;

    private void Awake()
    {
        spawnTargetButton.onClick.AddListener(SpawnTarget);
    }

    void SpawnTarget()
    {
        int randomInt = Random.RandomRange(0, _spawnPoints.Count);
        _target.transform.position = _spawnPoints[randomInt].transform.position;
        _target.gameObject.SetActive(true);
    }
}
