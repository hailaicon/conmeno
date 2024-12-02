using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections;

public class RandomFunctionCaller_X : MonoBehaviour
{
    public Animator cuopanim;
    public Animator canhanim;

    // mau
    public Slider cuop_mau_sl;
    public Slider canh_mau_sl;
    public int mau_cuop;
    public int mau_canh;

    public GameObject player1;
    public GameObject player2;
    public TMP_Text timerText;
    public TMP_Text currentTurnText;

    private float turnTime = 7f;
    private float timeLeft;
    private bool isPlayer1Turn = true;

    private bool hasActedThisTurn = false;

    public static bool hasTriggeredWinCondition = false;

    void Start()
    {
        timeLeft = turnTime;
        currentTurnText.text = "YOUR_TURN";
        hasActedThisTurn = false;
        mau_cuop = 2;
        mau_canh = 2;
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

    private void FixedUpdate()
    {
        if (mau_cuop == 0 && !hasTriggeredWinCondition)
        {
            cuopanim.SetTrigger("die");
            GameObject cuop = GameObject.FindWithTag("cuop");
            Destroy(cuop, 2f);
            TatTextGoiCutScene();
            StartCoroutine(Win());
            hasTriggeredWinCondition = true;
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(3f);
        canhanim.SetTrigger("win");
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
            Function4();
            Invoke("CuopMatMau", 2f);
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            canhanim.SetTrigger("punch");
            Function4();
            Invoke("CuopMatMau", 2f);
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            canhanim.SetTrigger("spin");
            Invoke("Function4", 2f);
            Invoke("CuopMatMau", 2f);
            hasActedThisTurn = true;
        }
        //hasActedThisTurn = true;
    }

    // goi cútcene
    public void TatTextGoiCutScene()
    {
        timerText.enabled = false;
        currentTurnText.enabled = false;
    }    
    public void CuopMatMau()
    {
        mau_cuop = mau_cuop - 1;
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
                canhanim.SetTrigger("hit");
                hasActedThisTurn = true;
                mau_canh = mau_canh - 1;
                break;
            case 1:
                Function2();
                canhanim.SetTrigger("hit");
                hasActedThisTurn = true;
                mau_canh = mau_canh - 1;
                break;
            case 2:
                Function3();
                canhanim.SetTrigger("hit");
                hasActedThisTurn = true;
                mau_canh = mau_canh - 1;
                break;
        }

    }    
}
