using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class ColorChanger : MonoBehaviour
{
    public Material greenMaterial;   // Assign the green material here in the Inspector
    public UnityEvent onColorChange; // Unity Event to handle additional actions when color changes
    public AudioSource audio;
    public GameObject boxobject;
    public bool isgreen;

    private Renderer objectRenderer;

    void Start()
    {
        isgreen = false;
        // Get the renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Check if a renderer is present on the object
        if (objectRenderer == null)
        {
            Debug.LogError("ColorChanger script requires a Renderer component on the GameObject.");
            enabled = false; // Disable the script if no renderer is found
        }
    }

    public void ChangeColor()
    {
        // Check if a green material is assigned
        if (greenMaterial != null || isgreen==false)
        {
            // Change the color of the object to green
            objectRenderer.material = greenMaterial;
            isgreen = true;
            audio.Play();

            // Invoke Unity Event for additional actions
            onColorChange.Invoke();

            StartCoroutine(delay());
           
            
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3.0f);
        //Destroy(boxobject);
    }

}