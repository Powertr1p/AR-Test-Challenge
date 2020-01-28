using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackState : MonoBehaviour
{
    public bool FirstObjectIsSpotted { get; private set; }
    public bool SecondObjectIsSpotted { get; private set; }
    public bool ThirdObjectIsSpotted { get; private set; }

    public void FirstSpotted()
    {
        FirstObjectIsSpotted = true;
    }

    public void SecondSpotted()
    {
        SecondObjectIsSpotted = true;
    }

    public void ThirdSpotted()
    {
        ThirdObjectIsSpotted = true;
    }

    public void FirstNotSpotted()
    {
        FirstObjectIsSpotted = false;
    }

    public void SecondNotSpotted()
    {
        SecondObjectIsSpotted = false;
    }

    public void ThirdNotSpotted()
    {
        ThirdObjectIsSpotted = false;
    }
}
