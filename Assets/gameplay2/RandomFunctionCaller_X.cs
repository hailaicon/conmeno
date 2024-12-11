using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomFunctionCaller_X : MonoBehaviour
{
    public Animator cuopanim;
    public Animator canhanim;

    // mau
    public Slider cuop_mau_sl;
    public Slider canh_mau_sl;
    public Slider cuopManaSlider; // Slider mana của cướp
    public Slider canhManaSlider; // Slider mana của cảnh sát
    public Slider turnTimeSlider; // Slider thời gian lượt đánh

    public int mau_cuop;
    public int mau_canh;
    public int mana_cuop;
    public int mana_canh;

    public GameObject player1;
    public GameObject player2;
    public Text timerText;
    public Text currentTurnText;

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

        // Khởi tạo giá trị max cho sliders
        cuop_mau_sl.maxValue = mau_cuop;
        canh_mau_sl.maxValue = mau_canh;
        cuopManaSlider.maxValue = mana_cuop;
        canhManaSlider.maxValue = mana_canh;
        turnTimeSlider.maxValue = 1; // Giá trị max của thanh thời gian là 1 (tỉ lệ)
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
            SceneManager.LoadScene("end");
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(3f);
        canhanim.SetTrigger("win");
    }

    void Update()
    {
        TurnBase();

        if (isPlayer1Turn)
        {
            if (!hasActedThisTurn && mana_canh > 0)
            {
                PlayerAction();
                Debug.Log("mana canh: " + mana_canh);

            }
        }
        else
        {
            if (!hasActedThisTurn && mana_cuop > 0)
            {
                RandomAttack();
                Debug.Log("mana cuop: " + mana_cuop);
            }
        }

        if (mana_canh == 0)
        {
            HoiMana(mana_canh);
        }
        if (mana_cuop == 0)
        {
            HoiMana(mana_cuop);
        }

        UpdateSliders(); // Cập nhật sliders mỗi frame
    }

    public IEnumerator HoiMana(int mana)
    {
        yield return new WaitForSeconds(21f);
        mana = mana + 1;
    }

    public void PlayerAction()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CallAudio();
            canhanim.SetTrigger("kick");
            Function4();
            Invoke("CuopMatMau", 2f);
            mana_canh = mana_canh - 1;
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            canhanim.SetTrigger("punch");
            CallAudio();
            Function4();
            Invoke("CuopMatMau", 2f);
            mana_canh = mana_canh - 1;
            hasActedThisTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            canhanim.SetTrigger("spin");
            Invoke("CallAudio()", 1.5f);
            Invoke("Function4", 2f);
            Invoke("CuopMatMau", 2f);
            mana_canh = mana_canh - 1;
            hasActedThisTurn = true;
        }
    }

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
            timerText.text = Mathf.RoundToInt(timeLeft).ToString();
        }
        else
        {
            isPlayer1Turn = !isPlayer1Turn;
            timeLeft = turnTime;
            ChangeTurnText();
            hasActedThisTurn = false;
        }
    }

    public void ChangeTurnText()
    {
        currentTurnText.text = isPlayer1Turn ? "Lượt Cảnh Sát" : "Lượt Cướp";
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
                mana_cuop = mana_cuop - 2;
                break;
            case 1:
                Function2();
                canhanim.SetTrigger("hit");
                mana_cuop = mana_cuop - 1;
                hasActedThisTurn = true;
                mau_canh = mau_canh - 1;
                break;
            case 2:
                Function3();
                canhanim.SetTrigger("hit");
                hasActedThisTurn = true;
                mau_canh = mau_canh - 1;
                mana_cuop = mana_cuop - 3;
                break;
        }
    }

    void UpdateSliders()
    {
        cuop_mau_sl.value = mau_cuop;
        canh_mau_sl.value = mau_canh;
        cuopManaSlider.value = mana_cuop;
        canhManaSlider.value = mana_canh;
        turnTimeSlider.value = timeLeft / turnTime;
    }
}