using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _firstObject;
    [SerializeField] private GameObject _secondObject;
    [SerializeField] private GameObject _wallPrefab;

    private bool _isSpawned;

    private void Update()
    {
        if (!_isSpawned)
        {
            var wall = Instantiate(_wallPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            wall.GetComponent<Wall>().Init(ref _firstObject, ref _secondObject);
            _isSpawned = true;
        }
    }
}
