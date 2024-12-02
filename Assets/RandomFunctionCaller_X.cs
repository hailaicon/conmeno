using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RandomFunctionCaller_X : MonoBehaviour
{
    public Animator cuopanim;
    public Animator canhanim;

    public GameObject player1;
    public GameObject player2;
    public TMP_Text timerText;
    public TMP_Text currentTurnText;

    private float turnTime = 7f;
    private float timeLeft;
    private bool isPlayer1Turn = true;

    private bool hasActedThisTurn = false;

    void Start()
    {
        timeLeft = turnTime;
        currentTurnText.text = "YOUR_TURN";
        hasActedThisTurn = false;
    }


    public void Function1()
    {
        // Hàm 1: Thực hiện tác vụ gì đó
        cuopanim.SetTrigger("da");
    }

    public void Function2()
    {
        // Hàm 2: Thực hiện tác vụ gì đó
        cuopanim.SetTrigger("dam");
    }

    public void Function3()
    {
        // Hàm 3: Thực hiện tác vụ gì đó
        cuopanim.SetTrigger("spin");
    }

    public void Function4()
    {
        // Hàm 4: Thực hiện tác vụ gì đó
        cuopanim.SetTrigger("hit");
    }

    public void Function5()
    {
        // Hàm 4: Thực hiện tác vụ gì đó
        cuopanim.SetTrigger("die");
    }
    public void Function6()
    {
        // Hàm 4: Thực hiện tác vụ gì đó
        cuopanim.SetTrigger("win");
    }

    void Update()
    {
        Debug.Log(hasActedThisTurn);
        TurnBase();

        if (isPlayer1Turn)
        {
            if (!hasActedThisTurn)
            {
                PlayerAction();
            }
        }
        else
        {
            if (!hasActedThisTurn)
            {
                RandomAttack();
            }
        }
    }

    public void PlayerAction()
    {
        Debug.Log("goi player action");
        if(Input.GetKeyDown(KeyCode.Q))
        {
            canhanim.SetTrigger("kick");
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            canhanim.SetTrigger("punch");
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            canhanim.SetTrigger("spin");
            hasActedThisTurn = true;
        }
        //hasActedThisTurn = true;
    }

    public void TurnBase()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "" + Mathf.RoundToInt(timeLeft);
        }
        else
        {
            // Hết thời gian, đổi lượt
            isPlayer1Turn = !isPlayer1Turn;
            timeLeft = turnTime;
            currentTurnText.text = isPlayer1Turn ? "YOUR_TURN" : "ENEMY_TURN";
            hasActedThisTurn = false;
        }

        //hasActedThisTurn = false;
    }    

    public void RandomAttack()
    {
        int randomIndex = Random.Range(0, 3);

        switch (randomIndex)
        {
            case 0:
                Function1();
                hasActedThisTurn = true;
                break;
            case 1:
                Function2();
                hasActedThisTurn = true;
                break;
            case 2:
                Function3();
                hasActedThisTurn = true;
                break;
        }

    }    
}
