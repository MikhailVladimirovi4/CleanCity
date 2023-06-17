using UnityEngine;

public class GaragePanel : MonoBehaviour
{
    [SerializeField] private Info _bayInfo;

    private void OnEnable()
    {
        _bayInfo.gameObject.SetActive(false);
    }
}

