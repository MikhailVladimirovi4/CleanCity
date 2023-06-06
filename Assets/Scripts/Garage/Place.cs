using UnityEngine;

public class Place : MonoBehaviour
{
    public bool IsBusy { get; private set; }

    private void Start()
    {
        IsBusy = false;
        this.gameObject.SetActive(false);
    }

    public void Take() => IsBusy = true;
}
