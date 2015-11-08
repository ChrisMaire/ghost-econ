using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float Speed;
    float startSpeed;
    public float SpeedIncrease;
    public float Gravity;
    public float Upward;

    Rigidbody2D body;
    Collider2D collider2d;

    Business business;
    MenuManager menus;
    GameManager gameManager;

    Vector3 startPos;

    bool gravOn = false;
    Animator anim;

	void Awake() {
        startSpeed = Speed;
        gameManager = FindObjectOfType<GameManager>();
        business = FindObjectOfType<Business>();
        menus = FindObjectOfType<MenuManager>();

        anim = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
        body = GetComponent<Rigidbody2D>();

        startPos = body.position;

        gameManager.RunStarted += () => StartRun();
        gameManager.RunEnded += () => EndRun();
    }

    void Update () {
	    if(!gameManager.Running && (Input.GetButtonDown("Fire1") && !menus.MenuOpen()))
        {
            Vector2 loc = new Vector2();

            if (Input.touchCount > 0)
            {
                loc = Input.GetTouch(0).position;
            } else
            {
                loc = Input.mousePosition;
            }

            loc.x += Random.Range(-10f, 10f);
            loc.y += Random.Range(-10f, 10f);

            business.EarnMoney(business.MoneyPerClick);

            FloatyTextManager.ShowFloatyMoney(business.MoneyPerClick, loc);
        }
	}

    void FixedUpdate()
    {
        if(gameManager.Running)
        {
            Speed += SpeedIncrease * Time.deltaTime;

            float y = body.velocity.y;
            if (Input.GetButton("Fire1"))
            {
                y += Upward * Time.deltaTime;
            }
            else
            {
                y -= Gravity * Time.deltaTime;
            }
            body.velocity = new Vector3(Speed, y);
        }
    }

    void StartRun()
    {
        anim.SetBool("floating", false);
        transform.Rotate(new Vector3(0,180,0));
        body.isKinematic = false;
        Speed = startSpeed;
    }

    void EndRun()
    {
        anim.SetBool("floating", true);
        transform.Rotate(new Vector3(0, 180, 0));
        gravOn = false;
        body.isKinematic = true;
        //body.MovePosition(startPos);
        body.transform.position = startPos;
    }
}
