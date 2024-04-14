using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
	[SerializeField] private Alarm _alarm;

	private void OnTriggerEnter(Collider other)
	{
		_alarm.ThiefFound();
	}

	private void OnTriggerExit(Collider other)
	{
		_alarm.ThiefLose();
	}
}