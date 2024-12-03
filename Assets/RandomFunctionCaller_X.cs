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

    public AudioSource atkSound;

    private bool hasActedThisTurn = false;

    public static bool hasTriggeredWinCondition = false;

    void Start()
    {
        timeLeft = turnTime;
        currentTurnText.text = "YOUR_TURN";
        hasActedThisTurn = false;
        mau_cuop = 3;
        mau_canh = 3;
    }

    public void CallAudio()
    {
        atkSound.Play();
    }



    public void Function1()
    {
        CallAudio();
        cuopanim.SetTrigger("da");
        
    }

    public void Function2()
    {
        
        cuopanim.SetTrigger("dam");
        CallAudio();
    }

    public void Function3()
    {
        
        cuopanim.SetTrigger("spin");
        CallAudio();
    }

    public void Function4()
    {
        
        cuopanim.SetTrigger("hit");
    }

    public void Function5()
    {
        
        cuopanim.SetTrigger("die");
    }
    public void Function6()
    {
        
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
        //Debug.Log(hasActedThisTurn);
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
        //Debug.Log("goi player action");
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CallAudio();
            canhanim.SetTrigger("kick");
            Function4();
            Invoke("CuopMatMau", 2f);
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            canhanim.SetTrigger("punch");
            CallAudio();
            Function4();
            Invoke("CuopMatMau", 2f);
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            canhanim.SetTrigger("spin");
            Invoke("CallAudio()", 1.5f);
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
                canhanim.SetTrigger("hit");
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
