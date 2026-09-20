using UnityEngine;

public class GlobalPreferences : MonoBehaviour
{
    // This value will be multiplied by 10 to get the time limit in seconds
    public static float timePreference = 11;
    public static int piecesPreference = 1;
    
    public static void SetTimePreference(float temp)
    {
        timePreference = temp;
    }

    public static void SetPiecesPreference(int temp)
    {
        piecesPreference = temp;
    }

    public static float GetTimePreference()
    {
        return timePreference;
    }

    public static int GetPiecesPreference()
    {
        return piecesPreference;
    }
}
