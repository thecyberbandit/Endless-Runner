using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float speed;
    
    private Animator playerAnim;
    private AnimatorStateInfo animatorState;

    static int jumpState = Animator.StringToHash("Base Layer.Take 001");

    public float moveHorizontal;
    public float moveVertical;

    private CapsuleCollider myCollider;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        myCollider = GetComponentInChildren<CapsuleCollider>();
    }

    void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            animatorState = playerAnim.GetCurrentAnimatorStateInfo(0);

            moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

            moveVertical = Mathf.Clamp(moveVertical, 0.4f, 1f);

            Vector3 movePosition = new Vector3(moveHorizontal, 0f, moveVertical);
            transform.Translate(movePosition * speed * Time.deltaTime);

            if (this.transform.position.x < -2f)
            {
                Vector3 pos = this.transform.position;
                pos.x = -2f;
                this.transform.position = pos;
            }

            if (this.transform.position.x > 2f)
            {
                Vector3 pos = this.transform.position;
                pos.x = 2f;
                this.transform.position = pos;
            }

            if (moveVertical >= 0.1f)
            {
                playerAnim.SetTrigger("run");
            }

            if (moveVertical < 0f)
            {
                moveVertical = 0.1f;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                playerAnim.SetTrigger("jump");
                AudioManager.instance.PlaySound("jump");

                //Vector3 newPosition = this.transform.position;
                //newPosition.y = 3f;
                //this.transform.position = newPosition;
            }

            if (animatorState.IsName("Base Layer.Take 001"))
            {
                if (!playerAnim.IsInTransition(0))
                {
                    myCollider.height = playerAnim.GetFloat("ColliderHeight");
                }
            }
        }
    }
}
