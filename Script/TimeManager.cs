using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    private Text timeText;
    private int second;
    //Coroutine currentCoroutine;
    private bool isPause = false;
    private int answerTime = 2 * 60;

    private void Awake()
    {
        timeText = GetComponent<Text>();
        EventCenter.AddListener<int>(GameEventType.StartTimer, StartTimer);
        EventCenter.AddListener(GameEventType.StopTimer, StopTimer);
        EventCenter.AddListener(GameEventType.PauseTimer, PauseTimer);
        EventCenter.AddListener(GameEventType.ContinueTimer, ContinueTimer);
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        StartTimer(answerTime);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener<int>(GameEventType.StartTimer, StartTimer);
        EventCenter.RemoveListener(GameEventType.StopTimer, StopTimer);
        EventCenter.RemoveListener(GameEventType.PauseTimer, PauseTimer);
        EventCenter.RemoveListener(GameEventType.ContinueTimer, ContinueTimer);
    }

    private void StartTimer(int second) {
        this.second = second;
        gameObject.SetActive(true);
        //currentCoroutine = null;
        StopAllCoroutines();
        //currentCoroutine = StartCoroutine(ShowTime(second));
        StartCoroutine(ShowTime(second));
    }

    private IEnumerator ShowTime(int s) {
        if (timeText == null) {
            yield return 0;
        }
        while (s > 0) {
            timeText.text = GetTime(s);
            if (!isPause) {
                s--;
                this.second = s;
                yield return new WaitForSeconds(1);
            }
        }
        timeText.text = "00:00";
        EventCenter.Boardcast(GameEventType.StopAllBlock);
        //EventCenter.Boardcast(GameEventType.HideSpeed);
        //EventCenter.Boardcast(GameEventType.ShowEndPanel);
    }

    private string GetTime(int currentS) {
        int min = currentS / 60;
        int s = currentS % 60;
        string minStr = (min >= 10 ? min.ToString() : ("0" + min));
        string sStr = (s >= 10 ? s.ToString() : ("0" + s));
        return minStr + ":" + sStr;
    }

    private void StopTimer() {
        StopAllCoroutines();
        //StopCoroutine(ShowTime());
        timeText.text = "00:00";
        timeText.gameObject.SetActive(false);
    }

    private void PauseTimer() {
        //if (currentCoroutine != null)
        //{
        //    isPause = true;
        //    //StopCoroutine(currentCoroutine);
        //    StopAllCoroutines();
        //}
        isPause = true;
        StopAllCoroutines();
    }

    private void ContinueTimer() {
        StopAllCoroutines();
        gameObject.SetActive(true);
        isPause = false;
        StartCoroutine(ShowTime(second));
        //currentCoroutine = null;
        //currentCoroutine = StartCoroutine(ShowTime(second));
    }

}
