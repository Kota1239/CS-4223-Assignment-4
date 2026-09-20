using UnityEngine;

public class UniqueIdentifier : MonoBehaviour
{
    [SerializeField] private int identifier;

    public void SetIdentifier(int input)
    {
        identifier = input;
    }

    public int GetIdentifier()
    {
        return identifier;
    }
}
