using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Patroul : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private Transform _allPointsStorage;
	[SerializeField] private int _maxHalfCircle;

	private Animator _animator;
	private List<Transform> _allPoints;
	private Transform _point;
	private int _index = 1;
	private bool _moveForward = true;
	private int _halfCircleCount;
	private int _speedHash;

	public void Start()
	{
		int skipPoints = 1;
		_maxHalfCircle--;
		_allPoints = _allPointsStorage.GetComponentsInChildren<Transform>().Skip(skipPoints).ToList();
		_point = _allPoints[_index];
		transform.LookAt(_point.position);

		string animationHashName = "Speed";
		int snimationSpeed = 2;
		_animator = GetComponent<Animator>();
		_speedHash = Animator.StringToHash(animationHashName);
		_animator.SetInteger(_speedHash, snimationSpeed);
	}

	public void Update()
	{
		if (_halfCircleCount > _maxHalfCircle)
		{
			_animator.SetInteger(_speedHash, 0);
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);

		if (transform.position == _point.position)
		{
			_point = TakeNextPlace();
			transform.LookAt(_point.position);
		}
	}

	private Transform TakeNextPlace()
	{
		int indexCount = _index + 1;

		if (indexCount == _allPoints.Count || _index <= 0)
		{
			_halfCircleCount++;
			_moveForward = _moveForward == false;
		}

		if (_moveForward)
			_index++;
		else
			_index--;

		return _allPoints[_index];
	}
}