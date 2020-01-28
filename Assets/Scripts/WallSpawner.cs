using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _firstObject;
    [SerializeField] private GameObject _secondObject;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private TrackState _detector;

    private bool _isSpawned;

    private void Start()
    {
        _detector = GetComponent<TrackState>();
    }

    public void SpawnWall()
    {
        if (!_isSpawned && _detector.FirstObjectIsSpotted && _detector.SecondIsObjectIsSpotted)
        {
            var wall = Instantiate(_wallPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            wall.GetComponent<Wall>().Init(ref _firstObject, ref _secondObject);
            wall.transform.SetParent(transform);
            _isSpawned = true;
        }
    }

    public void DestroyWall()
    {
        if (_isSpawned)
        {
            var wall = GetComponentInChildren<Wall>();
            Destroy(wall.gameObject);
            _isSpawned = false;
        }
    }
}
