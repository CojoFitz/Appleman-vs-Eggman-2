using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D body;
    public Sprite appleSprite;
    public Sprite eggSprite;
    public string playerUsed;
    private SpriteRenderer spriteRenderer;
    public GameObject curSprite;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 20.0f;
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();

    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        playerUsed = tran.getLoser();
        if(playerUsed == "apple")
        {
            spriteRenderer.sprite = appleSprite;
        }else if(playerUsed == "egg")
        {
            spriteRenderer.sprite = eggSprite;

        }
    }

    void Update()
    {
        
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
