using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
	private AudioSource _audio;
	private float _sirenStartVolume = 0.002f;
	private float _sirenOnVolume = 1;
	private float _sirenOffVolume = 0;
	private bool _isCorutineWorking = false;
	private Coroutine _coroutine;

	public void Start()
	{
		_audio = GetComponent<AudioSource>();
		_audio.Stop();
	}

	public void TurnOffSiren()
	{
		if (_isCorutineWorking)
			StopAllCoroutines();

		_coroutine = StartCoroutine(SoundChange(_sirenOffVolume));
		_isCorutineWorking = true;
	}

	public void TurnOnSiren()
	{
		if (_isCorutineWorking)
			StopAllCoroutines();

		_audio.Play();
		_audio.volume = _sirenStartVolume;
		_coroutine = StartCoroutine(SoundChange(_sirenOnVolume));
		_isCorutineWorking = true;
	}

	private IEnumerator SoundChange(float targetVolume)
	{
		while (_audio.volume != targetVolume)
		{
			_audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, Time.deltaTime);
			yield return null;
		}

		if (_audio.volume == _sirenOffVolume)
			_audio.Stop();

		_isCorutineWorking = false;
	}
}