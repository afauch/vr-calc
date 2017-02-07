using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorButton : MonoBehaviour {

	private GameObject displayTextObject;
	private DisplayText displayTextClass;
	private TextMesh displayTextMesh;

	[HideInInspector]
	public string operation;

	private bool isColliding;

	// Use this for initialization
	void Start () {

		displayTextObject = GameObject.Find ("DisplayText");
		displayTextMesh = displayTextObject.GetComponent<TextMesh>();
		displayTextClass = displayTextObject.GetComponent<DisplayText> ();

	}

	void OnCollisionEnter(Collision collision) {

		// State management
		if (isColliding)
			return;
		isColliding = true;

		// Call the correct operation
		switch (operation) {
		case "Addition":
			print ("Selected addition");
			Add ();
			break;
		case "Subtraction":
			print ("Selected subtraction");
			Subtract ();
			break;
		case "Multiplication":
			print ("Selected multiply");
			Multiply ();
			break;
		case "Division":
			print ("Selected division");
			Divide ();
			break;
		case "Equals":
			print ("Selected equals");
			Equals ();
			break;
		case "Clear":
			Clear ();
			break;
		default:
			print ("NONE");
			break;

		}

		// Highlight this button to indicate that it's been selected
		// TODO: HighlightButton();

	}

	void Update () {

		// Reset Collision
		isColliding = false;

	}

	void Add () {

		// Save the value to the cache
		displayTextClass.cachedValue = displayTextClass.displayValAsFloat;

		// Save the operation to the cache?
		displayTextClass.cachedOperation = "addition";

		// Flip the switch
		displayTextClass.displayNeedsReset = true;


	}

	void Subtract () {

		// Save the value to the cache
		displayTextClass.cachedValue = displayTextClass.displayValAsFloat;

		// Save the operation to the cache?
		displayTextClass.cachedOperation = "subtraction";

		// Flip the switch
		displayTextClass.displayNeedsReset = true;


	}

	void Multiply () {

		// Save the value to the cache
		displayTextClass.cachedValue = displayTextClass.displayValAsFloat;

		// Save the operation to the cache?
		displayTextClass.cachedOperation = "multiplication";

		// Flip the switch
		displayTextClass.displayNeedsReset = true;

	}


	void Divide () {

		// Save the value to the cache
		displayTextClass.cachedValue = displayTextClass.displayValAsFloat;

		// Save the operation to the cache?
		displayTextClass.cachedOperation = "division";

		// Flip the switch
		displayTextClass.displayNeedsReset = true;

	}

	void Equals () {

		float result;

		// Execute the cached operation between the displayText and the cachedValue
		// Call the correct operation
		switch (displayTextClass.cachedOperation) {
		case "addition":
			// Execute the addition operation
			result = displayTextClass.cachedValue + displayTextClass.displayValAsFloat;
			break;
		case "subtraction":
			// Execute the subtraction operation
			result = displayTextClass.cachedValue - displayTextClass.displayValAsFloat;	
			break;
		case "multiplication":
			// Execute the multiplication operation
			result = displayTextClass.cachedValue * displayTextClass.displayValAsFloat;	
			break;
		case "division":
			// Execute the division operation
			if (displayTextClass.displayValAsFloat == 0f) {
				// Error - can't divide by zero
				result = 0f;
				displayTextClass.Error ();
			} else {
				result = displayTextClass.cachedValue / displayTextClass.displayValAsFloat;	
			}
			break;			
		default:
			result = displayTextClass.displayValAsFloat;
			break;
		}
		
		// Clear the display
		displayTextClass.ClearDisplay();

		// Reset the cached value
		displayTextClass.cachedValue = 0f;
		displayTextClass.cachedOperation = null;

		// Print to the display
		displayTextMesh.text = result.ToString();
		displayTextClass.UpdatePublicValues ();

		// Reset the trigger
		displayTextClass.displayNeedsReset = true;

	}

	void Clear() {

		displayTextClass.ClearDisplay ();

	}


}
