using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class storySlideState
{
    public enum STATES { 
        TUTORIAL 
    }

    [SerializeField] public static STATES state = STATES.TUTORIAL;
}
