using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour {

	private TextMesh displayTextMesh;

	[HideInInspector]
	public float cachedValue;

	[HideInInspector]
	public string cachedOperation;

	[HideInInspector]
	public bool displayNeedsReset;

	[HideInInspector]
	public string displayValAsString;

	[HideInInspector]
	public int displayValAsInt;

	[HideInInspector]
	public float displayValAsFloat;

	// Use this for initialization
	void Start () {

		// Any placeholder text should be cleared
		displayNeedsReset = true;

		// Assign the component
		displayTextMesh = this.GetComponent<TextMesh>();

	}

	public void ClearDisplay () {

		displayTextMesh.text = null;

	}

	public void UpdatePublicValues () {

		displayValAsString = displayTextMesh.text;
		displayValAsInt = int.Parse(displayValAsString);
		displayValAsFloat = float.Parse (displayValAsString);

	}

	public void Error () {

		displayTextMesh.text = "ERROR";
		displayNeedsReset = true;

	}


}
