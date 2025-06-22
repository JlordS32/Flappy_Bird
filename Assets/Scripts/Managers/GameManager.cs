using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputAction _pauseButton;
    [SerializeField] GameObject _pausePanel;
    [SerializeField] GameObject _deathPanel;

    PlayerMovement _player;

    void Awake()
    {
        _player = FindFirstObjectByType<PlayerMovement>();
    }

    void OnEnable()
    {
        _pauseButton.Enable();
    }

    void OnDisable()
    {
        _pauseButton.Disable();
    }

    void Update()
    {
        if (_pauseButton.WasPressedThisFrame())
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        AudioManager.Instance.PauseMusicBG();
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        _pausePanel.SetActive(!_pausePanel.activeSelf);
    }

    public void ToggleDeath()
    {
        AudioManager.Instance.PauseMusicBG();
        _deathPanel.SetActive(!_pausePanel.activeSelf);
    }
}
