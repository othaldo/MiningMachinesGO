using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowInfo : MonoBehaviour {

    public GameObject panel;
    private bool isActive = false;

    // Use this for initialization
    void Start ()
    {
	    panel.SetActive(isActive);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        if (isActive == false)
        {
            isActive = true;
            panel.SetActive(isActive);
        } else
        {
            isActive = false;
            panel.SetActive(isActive);
        }

    }
}
