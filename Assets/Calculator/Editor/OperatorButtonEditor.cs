using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OperatorButton))]
public class OperatorButtonEditor : Editor
{
	string[] _choices = new [] { "Addition", "Subtraction", "Multiplication", "Division", "Equals", "Clear" };
	int _choiceIndex;

	public override void OnInspectorGUI ()
	{
		// Draw the default inspector
		DrawDefaultInspector();
		// Draw a label
		EditorGUILayout.LabelField("Operation");

		// Assign target instance
		var operatorClass = target as OperatorButton;

		// Set the choice index to the previously selected index
		_choiceIndex = Array.IndexOf(_choices, operatorClass.operation);

		// If the choice is not in the array then the _choiceIndex will be -1 so set back to 0
		if (_choiceIndex < 0)
			_choiceIndex = 0;

		_choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices);

		// Update the selected choice in the underlying object
		operatorClass.operation = _choices[_choiceIndex];
		// Save the changes back to the object
		EditorUtility.SetDirty(target);
	}
}
