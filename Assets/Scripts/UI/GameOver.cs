using UnityEngine;

public class GameOver : MonoBehaviour
{
    private AudioSource _sound;

    private void OnEnable()
    {
        _sound = GetComponent<AudioSource>();
        _sound.Play();
    }
}
