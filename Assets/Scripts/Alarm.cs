using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
	private bool _isAlarmOn;
	private AudioSource _audio;
	private float _volumeDecreases = 0.8f;
	private float _volumeIncreases = 0.8f;
	private float _startVolume = 0.002f;
	private float _delay = 0.001f;

	public void Start()
	{
		_audio = GetComponent<AudioSource>();
		_audio.enabled = false;
		_isAlarmOn = false;
	}

	public void ThiefLose()
	{
		_isAlarmOn = false;
	}

	public void ThiefFound()
	{
		_audio.enabled = true;
		_audio.volume = _startVolume;
		_isAlarmOn = true;
		StartCoroutine(SoundChange(_delay));
	}

	private IEnumerator SoundChange(float delay)
	{
		var wait = new WaitForSeconds(delay);
		bool isContinue = true;

		while (isContinue)
		{
			if(_audio.volume == 0)
			{
				isContinue = false;
				_audio.enabled = false;
				continue;
			}

			if (_isAlarmOn)
				_audio.volume += _volumeIncreases * Time.deltaTime;
			else
				_audio.volume -= _volumeDecreases * Time.deltaTime;

			yield return wait;
		}
	}
}