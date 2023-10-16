using UnityEngine;

public class PlayerInput : PlayerAbstract
{
    bool isActive = true;
    public bool IsActive { get => isActive; set => isActive = value; }

    // protected override void OnEnable()
    // {
    //     base.OnEnable();
    //     GameManager.Instance.OnWaveStart += OnGameStart;
    //     GameManager.Instance.OnWaveStop += OnGameStop;
    // }

    // protected virtual void OnDisable()
    // {
    //     GameManager.Instance.OnWaveStart -= OnGameStart;
    //     GameManager.Instance.OnWaveStop -= OnGameStop;
    // }

    private void Update()
    {
        if (!isActive) return;

        if (Input.GetMouseButton(0))
        {
            
        }

    }

    void OnGameStart()
    {
        isActive = true;
    }
    void OnGameStop()
    {
        isActive = false;
    }
}
