using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float curretntTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        curretntTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(curretntTime / 60);
        int seconds = Mathf.FloorToInt(curretntTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
