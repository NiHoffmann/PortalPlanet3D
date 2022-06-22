using UnityEngine;

public static class storySlideState
{
    public enum STATES { 
        TUTORIAL1,
        ERSTESLEVEL
    }

    [SerializeField] public static STATES state = STATES.ERSTESLEVEL;
}
