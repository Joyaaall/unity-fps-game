using UnityEngine;

public class player_look : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Transform playerCamera;
	[SerializeField] private InputManager inputManager;

	[Header("Look")]
	[SerializeField] private float sensitivity = 0.1f;
	[SerializeField] private float minPitch = -90f;
	[SerializeField] private float maxPitch = 90f;

	private float pitch;

	private void Awake()
	{
		if (playerCamera == null)
		{
			Camera camera = GetComponentInChildren<Camera>();
			playerCamera = camera != null ? camera.transform : null;
		}

		if (inputManager == null)
		{
			inputManager = FindFirstObjectByType<InputManager>();
		}

		if (playerCamera == null)
		{
			Debug.LogError("player_look requires a child Camera or an assigned camera transform.");
			enabled = false;
			return;
		}

		pitch = NormalizeAngle(playerCamera.localEulerAngles.x);
	}

	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private void Update()
	{
		if (inputManager == null)
		{
			return;
		}

		Vector2 lookInput = inputManager.ConsumeLookInput() * sensitivity;
		pitch = Mathf.Clamp(pitch - lookInput.y, minPitch, maxPitch);

		transform.Rotate(Vector3.up * lookInput.x);
		playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);
	}

	private static float NormalizeAngle(float angle)
	{
		return angle > 180f ? angle - 360f : angle;
	}
}
