using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TouchDetector : MonoBehaviour
{
    public event Action OnMaxTouches;

    [SerializeField] private int _maxTouches = 10;
    private bool _touchedLastFrame = false;
    private int _countedTouches = 0;

    private void Update()
    {
        if (_touchedLastFrame && Input.touchCount == 0)
        {
            _touchedLastFrame = false;
            _countedTouches = 0;
        }
        else if (!_touchedLastFrame && Input.touchCount > 0)
        {
            _countedTouches++;
            _touchedLastFrame = true;
        }

        if (_countedTouches >= _maxTouches)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            { 
                if (Hit.collider.GetComponent<Wall>() != null)
                {
                    OnMaxTouches?.Invoke();
                    _countedTouches = 0;
                }
            }
        }

    }
}
