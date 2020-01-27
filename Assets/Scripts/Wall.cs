using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private GameObject _firstObject;
    [SerializeField] private GameObject _secondObject;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _positionDifference;
    private Vector3 _sizeTemp;
    private Vector3 _posTemp;

    public void Init(GameObject firstCylinder, GameObject secondCyclinder)
    {
        _firstObject = firstCylinder;
        _secondObject = secondCyclinder;
    }
}
