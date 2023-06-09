using UnityEngine;

public class Town : MonoBehaviour
{
    [SerializeField] private AreaState[] _areas;
    public AreaState GetArea(int index) => _areas[index];
}
