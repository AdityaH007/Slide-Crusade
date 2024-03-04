using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SphereCollisionHandler : MonoBehaviour
{
    public GameObject sphere;        // Drag the sphere GameObject here in the Inspector
    public int count;
    public Text CountText;
    public GameObject wintext;
    public Text timetext;
    public Timer timer; // Reference to the Timer script

    private HashSet<GameObject> hitObjects = new HashSet<GameObject>();

    void Start()
    {
        count = 0;
        wintext.SetActive(false);
    }

    void Update()
    {
        CountText.text = count.ToString();

        if (count == 8)
        {
            // Stop the timer and store the elapsed time in a variable
            float elapsedTime = timer.GetElapsedTime();
            timer.StopTimer();

            // Display the elapsed time (you can do whatever you want with it)
            Debug.Log("Elapsed Time: " + elapsedTime);

            wintext.SetActive(true);
            timetext.text=elapsedTime.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorChanger colorChanger = other.GetComponent<ColorChanger>();
        if (colorChanger != null && !hitObjects.Contains(other.gameObject))
        {
            hitObjects.Add(other.gameObject);
            count++;
            colorChanger.ChangeColor();
        }
    }
}
