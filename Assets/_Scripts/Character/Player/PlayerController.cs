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

    [SerializeField] protected CharacterAnimation characterAnimation;
    public CharacterAnimation CharacterAnimation { get => characterAnimation; }
    [SerializeField] protected PlayerStatus playerStatus;
    public PlayerStatus PlayerStatus { get => playerStatus; }
    [SerializeField] protected PlayerInput playerInput;
    public PlayerInput PlayerInput { get => playerInput; }
    [SerializeField] protected PlayerPerformAbility playerPerformAbility;
    public PlayerPerformAbility PlayerPerformAbility { get => playerPerformAbility; }

    [SerializeField] protected Fence fence;

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
        {
            _instance = this;
        }

        PlayerStatus.OnTakeDamage += OnTakeDamage;
    }

    protected virtual void OnTakeDamage(DamageBlock block)
    {
        Debug.Log("take damage");
        fence.PlayHurtAnimation();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.characterAnimation = transform.Find("Model").GetComponent<CharacterAnimation>();
        this.playerStatus = transform.Find("Status").GetComponent<PlayerStatus>();
        this.playerInput = transform.Find("Input").GetComponent<PlayerInput>();
        this.playerPerformAbility = transform.Find("Abilities").GetComponent<PlayerPerformAbility>();
    }
    
}
