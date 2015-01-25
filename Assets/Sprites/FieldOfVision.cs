﻿using UnityEngine;
using System.Collections;

public class FieldOfVision: MonoBehaviour
{
	public string objectName;
	private GameObject player;
    private Color kColor;

	void Start ()
    {
        /* Make sure you register your event methods in the 'OnStart' or 'OnAwake' methods
         * The delegate which is used has the following structure
         * Light2DDelegate(Light2d _light, GameObject _gameObject); */
        Light2D.RegisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
        Light2D.RegisterEventListener(LightEventListenerType.OnStay, OnLightStay);
        Light2D.RegisterEventListener(LightEventListenerType.OnExit, OnLightExit);

		player = GameObject.Find (objectName);
		float distance = 100;
		
		if (player != null) {
			distance = Vector3.Distance (player.transform.position, this.gameObject.transform.position);
		}
		
		if (distance < 10f) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, ((10f - distance) / 10f));
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0f);
		}

        // Keep the initial object color [For Visualization]
//        kColor = gameObject.renderer.material.color;
    }
	void Update(){
		player = GameObject.Find (objectName);
		float distance = 100;
		
		if (player != null) {
			distance = Vector3.Distance (player.transform.position, this.gameObject.transform.position);
		}
		
		if (distance < 10f) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, ((10f - distance) / 10f));
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0f);
		}
	}

    void OnDisable()
    {
        /* Make sure you remove your event methods in the 'OnDisable' or 'OnDestroy' method
         * If you forget to do this you may get errors pertaining to objects that no longer exist */
        Light2D.UnregisterEventListener(LightEventListenerType.OnEnter, OnLightEnter);
        Light2D.UnregisterEventListener(LightEventListenerType.OnStay, OnLightStay);
        Light2D.UnregisterEventListener(LightEventListenerType.OnExit, OnLightExit);
    }

    void OnLightEnter(Light2D _light, GameObject _go)
    {
        /* Function called everytime a new object enters the light.
         * Use the _go object that is passed to determin if the current
         * gameObject is equal to the one this script is in (if needed) */
        if (_go.GetInstanceID() == gameObject.GetInstanceID())
        {
            // GameObject just became visible by light object
            Debug.Log("THIS SHOULD SAY SOMETHING ELSE");
            // Change color [For Visualization]
//            gameObject.renderer.material.color = Color.blue;
        }
    }

    void OnLightStay(Light2D _light, GameObject _go)
    {
        /* Function called every LateUpdate if an object is in the light.
         * Use the _go object that is passed to determin if the current
         * gameObject is equal to the one this script is in (if needed) */
        if (_go.GetInstanceID() == gameObject.GetInstanceID())
        {
            // GameObject is currently visible by light object
            Debug.Log("Object Inside Light");

            // Change color [For Visualization]
//            gameObject.renderer.material.color = Color.Lerp(gameObject.renderer.material.color, Color.red, Time.deltaTime * 0.5f);
        }
    }

    void OnLightExit(Light2D _light, GameObject _go)
    {
        /* Function called everytime an object exits the light.
         * Use the _go object that is passed to determin if the current
         * gameObject is equal to the one this script is in (if needed) */
        if (_go.GetInstanceID() == gameObject.GetInstanceID())
        {
            // GameObject just left the visibility of the light object
            Debug.Log("Object Exited Light");
            // Change color [For Visualization]
//            gameObject.renderer.material.color = kColor;
        }
    }
}
