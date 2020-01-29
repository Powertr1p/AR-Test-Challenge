using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetector : MonoBehaviour
{
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                if (Hit.transform.GetComponent<Wall>() != null)
                    Hit.transform.GetComponent<Wall>().DestroySelf();
            }
        }
    }
}
