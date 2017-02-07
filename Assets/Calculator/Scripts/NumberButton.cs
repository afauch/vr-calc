using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberButton : MonoBehaviour {

	// TODO: All buttons should be abstracted via interfaces
	// Since they all access the same instance of DisplayText

	private GameObject displayTextObject;
	private DisplayText displayTextClass;
	private TextMesh displayTextMesh;

	private TextMesh buttonTextMesh;

	private float buttonValAsFloat; 
	private int buttonValAsInt;
	private string buttonValAsString;

	private bool isColliding;

	// Use this for initialization
	void Start () {

		// Get the DisplayText GameObject
		displayTextObject = GameObject.Find ("DisplayText");
		displayTextMesh = displayTextObject.GetComponent<TextMesh>();
		displayTextClass = displayTextObject.GetComponent<DisplayText> ();
	
		// Determine the child text value
		buttonTextMesh = this.GetComponentInChildren<TextMesh>();

		// Assign its values
		buttonValAsString = buttonTextMesh.text;
		buttonValAsInt = int.Parse(buttonValAsString);
		buttonValAsFloat = float.Parse(buttonValAsString);

	}
	
	void Update() {

		// State management
		isColliding = false;

	}

	void OnCollisionEnter(Collision collision){

		// State management
		if (isColliding)
			return;
		isColliding = true;

		// Does the display need to be reset?
		if (displayTextClass.displayNeedsReset) {

			// If so, clear the display first
			displayTextClass.ClearDisplay ();
			displayTextClass.displayNeedsReset = false;

		}

		// Update the text
		displayTextMesh.text += buttonValAsString;

		// Call the trigger in the class
		displayTextClass.UpdatePublicValues ();

	}

}
