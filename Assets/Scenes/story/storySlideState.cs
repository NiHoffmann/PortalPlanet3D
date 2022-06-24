using UnityEngine;

public static class storySlideState
{
    public enum STATES { 
        TUTORIAL1,
        ERSTESLEVEL,
        BOSSLEVEL,
        GAMEEND,
        CREDITS
    }

    [SerializeField] public static STATES state = STATES.TUTORIAL1;
}
