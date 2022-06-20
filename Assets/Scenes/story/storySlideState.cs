using UnityEngine;

public static class storySlideState
{
    public enum STATES { 
        TUTORIAL2,
        TUTORIAL3
    }

    [SerializeField] public static STATES state = STATES.TUTORIAL2;
}
