using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI() {
		MapGenerator mapGen = (MapGenerator)target;

		if (DrawDefaultInspector ()) {
			if (mapGen.autoUpdate) {
				mapGen.generate_map();
			}
		}

		if (GUILayout.Button ("Generate")) {
			mapGen.generate_map();
		}
	}
}