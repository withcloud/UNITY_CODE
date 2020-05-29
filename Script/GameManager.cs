using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Fungus;

public class GameManager : MonoBehaviour
{

    private CanvasGroup morsePanel;
    private Text showText;//当输入正确时显示摩斯密码对应的答案
    private Text morseText;//显示当前需要输入的摩斯密码
    private InputField morseInputField;
    [SerializeField]
    private Flowchart flowchart;

    public char sceneCode;
    private string[][] answerStrArray;//所有的答案组
    private int currentIndex = 0;//当前题组进度
    private string[] currentAnswer;//当前进度对应的答案组   
    private int currentAnswerIndex = 0;//当前游戏答案对应在答案组的编号
    private bool startAnswer = false;
    private bool startNext = false;
    [SerializeField]
    private string[] blockNames;
    private int currentSayIndex = 0;//当前游戏对话进度

    private void Awake()
    {
        morsePanel = transform.Find("MorsePanel").GetComponent<CanvasGroup>();
        showText = transform.Find("MorsePanel/Text").GetComponent<Text>();
        morseText= transform.Find("MorsePanel/InputField/MorseText").GetComponent<Text>();
        morseInputField = transform.Find("MorsePanel/InputField").GetComponent<InputField>();
        EventCenter.AddListener(GameEventType.EnterMorse, InputMorse);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(GameEventType.EnterMorse, InputMorse);
    }

    // Start is called before the first frame update
    void Start()
    {
        morsePanel.alpha = 0;
        morsePanel.gameObject.SetActive(false);
        GameData.SetMorseArraies(ref answerStrArray, sceneCode);//获取字符答案组，和摩斯密码答案组
    }

    // Update is called once per frame
    void Update()
    {
        if (startAnswer)
        {
            if (CheckMorse(morseInputField.text))
            {
                SetMorseText();
            }
            //若输入错误
            else {
                if (currentAnswer[currentAnswerIndex].Substring(0, morseInputField.text.Length) != morseInputField.text)
                {
                    morseInputField.text = "";  
                }
            }
            if (startNext) {
                if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.Period)) {
                    AnswerSet();
                    startNext = false;
                }
            }
        }
    }

    public void InputMorse() {
        morsePanel.gameObject.SetActive(true);
        morsePanel.alpha = 0;
        morsePanel.DOFade(1, 0.5f).OnComplete(() =>
        {
            startAnswer = true;
            AnswerSet();
        });
    }

    //答题设置
    private void AnswerSet() {
        showText.text = "";
        morseInputField.text = "";  
        //设置有戏进度所对应的游戏摩斯密码答案
        currentAnswer = answerStrArray[currentIndex];//获取当前进度对应的答案组
        currentAnswerIndex = 0;//初始化当前答案组对应的答案编号
        morseText.text = currentAnswer[currentAnswerIndex];//设置需要输入的答案摩斯密码显示
        morseInputField.interactable = true;
        morseInputField.Select();
    }

    public void CloseMorse() {
        morsePanel.alpha = 1;
        morsePanel.DOFade(0, 0.5f).OnComplete(() =>
        {
            Say();
            morsePanel.gameObject.SetActive(false);
        });
    }

    //检查输入摩斯密码是否正确,并且检查摩斯密码是否输入完全
    private bool CheckMorse(string playerInputStr)
    {
        if (!string.IsNullOrEmpty(playerInputStr)) {
            if (playerInputStr == currentAnswer[currentAnswerIndex]&& !string.IsNullOrEmpty(playerInputStr))
            {
                if (currentAnswerIndex >= currentAnswer.Length-1)
                {
                    currentIndex++;
                    //判断是否还有题目:若当前游戏进度大于等于所有答案组的长度，则表示当前题组已经完成
                    if (currentIndex> answerStrArray.Length-1) {
                        currentIndex = answerStrArray.Length - 1;
                        startAnswer = false;
                        CloseMorse();
                    }
                    morseInputField.text = "";  
                    morseInputField.interactable = false;
                    startNext = true;
                }
                return true;
            }
            else if (playerInputStr.Length > currentAnswer[currentAnswerIndex].Length)
            {
                return false;
            }
            else {
                if (currentAnswer[currentAnswerIndex].Substring(0, playerInputStr.Length) != playerInputStr)
                {
                    return false;
                }
            }
        }
        return false;
    }

    //设置需要输入的答案摩斯密码显示
    private void SetMorseText() {
        if (currentAnswerIndex < currentAnswer.Length)
        {
            showText.text += GameData.morse2CharDic[currentAnswer[currentAnswerIndex]].ToString();
            morseInputField.text = "";  
            currentAnswerIndex++;
            if (currentAnswerIndex > currentAnswer.Length - 1)
            {
                currentAnswerIndex = currentAnswer.Length - 1;
                //showText.text = "";
                morseText.text = "";
            }
            else {
                morseText.text = currentAnswer[currentAnswerIndex];
            }
        }
    }

    private void Say() {
        if (blockNames.Length==0) {
            return;
        }
        if (flowchart.HasBlock(blockNames[currentSayIndex])) {
            Debug.Log(blockNames[currentSayIndex]);
            flowchart.ExecuteBlock(blockNames[currentSayIndex]);
        }
        currentSayIndex++;
    }

}
