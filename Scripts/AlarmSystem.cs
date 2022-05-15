using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Door _door;

    private Coroutine _increaseSound;
    private Coroutine _reduceSound;
    private AudioSource _audioSource;
    private float _finalVolueMaximum = 1;
    private float _finalVolumeMinimum = 0;
    private float _duration = 0.1f;

    private void OnEnable()
    {
        _door.WalkedInTheDoor += OnWenhThroughDoor;
        _door.WalkedOutOfTheDoor += OnWalkedOutOfTheDoor;
    }

    private void OnDisable()
    {
        _door.WalkedInTheDoor -= OnWenhThroughDoor;
        _door.WalkedOutOfTheDoor -= OnWalkedOutOfTheDoor;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnWenhThroughDoor()
    {
        IncreaseVolume();
    }

    private void OnWalkedOutOfTheDoor()
    {
        DecreaseVolume();
    }

    public void IncreaseVolume()
    {
        if (_reduceSound != null)
        {
            StopCoroutine(_reduceSound);
            _audioSource.Stop();
        }

        _increaseSound = StartCoroutine(ChangeVolume(_finalVolueMaximum, _duration));
        _audioSource.Play();
    }
       
    public void DecreaseVolume()
    {
        if (_increaseSound != null)
        {
            StopCoroutine(_increaseSound);
            _audioSource.Stop();
        }

        _reduceSound = StartCoroutine(ChangeVolume(_finalVolumeMinimum, _duration));
        _audioSource.Play();
    }
           
    private IEnumerator ChangeVolume(float finalValue, float duration)
    {
        while (_audioSource.volume != finalValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, finalValue, duration * Time.deltaTime);

            yield return null;
        }
    }
}
