using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackState : MonoBehaviour
{
    public bool FirstObjectIsSpotted { get; private set; }
    public bool SecondIsObjectIsSpotted { get; private set; }
    public bool ThirdIsObjectIsSpotted { get; private set; }

    public void FirstSpotted()
    {
        FirstObjectIsSpotted = true;
    }

    public void SecondSpotted()
    {
        SecondIsObjectIsSpotted = true;
    }

    public void ThirdSpotted()
    {
        ThirdIsObjectIsSpotted = true;
    }

    public void FirstNotSpotted()
    {
        FirstObjectIsSpotted = false;
    }

    public void SecondNotSpotted()
    {
        SecondIsObjectIsSpotted = false;
    }

    public void ThirdNotSpotted()
    {
        ThirdIsObjectIsSpotted = false;
    }
}
