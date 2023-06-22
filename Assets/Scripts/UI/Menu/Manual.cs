using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    [SerializeField] private Scrollbar _vertical;

    private void OnEnable()
    {
        _vertical.value = 1;
    }
}
