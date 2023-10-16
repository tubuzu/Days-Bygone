using UnityEngine;

public class PlayerController : MyMonoBehaviour
{
    private static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<PlayerController>();
            }
            return _instance;
        }
    }

    [SerializeField] protected PlayerModel playerModel;
    public PlayerModel PlayerModel { get => playerModel; }
    [SerializeField] protected PlayerStatus playerStatus;
    public PlayerStatus PlayerStatus { get => playerStatus; }
    [SerializeField] protected PlayerInput playerInput;
    public PlayerInput PlayerInput { get => playerInput; }

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
        {
            _instance = this;
        }
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.playerModel = transform.Find("Model").GetComponent<PlayerModel>();
        this.playerStatus = transform.Find("Status").GetComponent<PlayerStatus>();
        this.playerInput = transform.Find("Input").GetComponent<PlayerInput>();
    }
    
}
