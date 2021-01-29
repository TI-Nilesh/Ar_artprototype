/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
	#region PRIVATE_MEMBER_VARIABLES

	protected TrackableBehaviour mTrackableBehaviour;

	#endregion // PRIVATE_MEMBER_VARIABLES

	#region UNTIY_MONOBEHAVIOUR_METHODS

	protected virtual void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
	}

	#endregion // UNTIY_MONOBEHAVIOUR_METHODS

	#region PUBLIC_METHODS

	/// <summary>
	///     Implementation of the ITrackableEventHandler function called when the
	///     tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
			newStatus == TrackableBehaviour.Status.NO_POSE)
		{
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			OnTrackingLost();
		}
		else
		{
			// For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
			// Vuforia is starting, but tracking has not been lost or found yet
			// Call OnTrackingLost() to hide the augmentations
			OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS

	public bool isHuggies, isApartment;

	public GameObject panel, worldCanvas;

	public GameObject grass, jersey1, jersey2, logo, ball, text;

	#region PRIVATE_METHODS

	protected virtual void OnTrackingFound()
	{
		if (isApartment)
		{
			var rendererComponents = GetComponentsInChildren<Renderer>(true);
			var colliderComponents = GetComponentsInChildren<Collider>(true);
			var canvasComponents = GetComponentsInChildren<Canvas>(true);

			// Enable rendering:
			foreach (var component in rendererComponents)
				component.enabled = true;

			// Enable colliders:
			foreach (var component in colliderComponents)
				component.enabled = true;

			// Enable canvas':
			foreach (var component in canvasComponents)
				component.enabled = true;
		}

		if(isHuggies)
		{
			worldCanvas.transform.parent = this.transform;

			var rendererComponents = GetComponentsInChildren<Renderer>(true);
			var colliderComponents = GetComponentsInChildren<Collider>(true);
			var canvasComponents = GetComponentsInChildren<Canvas>(true);

			// Enable rendering:
			foreach (var component in rendererComponents)
				component.enabled = true;

			// Enable colliders:
			foreach (var component in colliderComponents)
				component.enabled = true;

			// Enable canvas':
			foreach (var component in canvasComponents)
				component.enabled = true;
			//panel.SetActive (true);


			worldCanvas.transform.localPosition = Vector3.zero;
			worldCanvas.SetActive (true);
		}

		else
			grass.SetActive (true);
	}


	protected virtual void OnTrackingLost()
	{
		if (isApartment)
		{
			var rendererComponents = GetComponentsInChildren<Renderer>(true);
			var colliderComponents = GetComponentsInChildren<Collider>(true);
			var canvasComponents = GetComponentsInChildren<Canvas>(true);

			// Disable rendering:
			foreach (var component in rendererComponents)
				component.enabled = false;

			// Disable colliders:
			foreach (var component in colliderComponents)
				component.enabled = false;

			// Disable canvas':
			foreach (var component in canvasComponents)
				component.enabled = false;
		}

		if(isHuggies)
		{
			var rendererComponents = GetComponentsInChildren<Renderer>(true);
			var colliderComponents = GetComponentsInChildren<Collider>(true);
			var canvasComponents = GetComponentsInChildren<Canvas>(true);

			// Disable rendering:
			foreach (var component in rendererComponents)
				component.enabled = false;

			// Disable colliders:
			foreach (var component in colliderComponents)
				component.enabled = false;

			// Disable canvas':
			foreach (var component in canvasComponents)
				component.enabled = false;

			worldCanvas.transform.parent = null;
		}

		else
		{
			grass.SetActive (false);
			jersey1.SetActive (false);
			jersey2.SetActive (false);
			ball.SetActive (false);
			logo.SetActive (false);
			text.SetActive (false);

		}

		//panel.SetActive (false);

		///worldCanvas.SetActive (false);
	}

	#endregion // PRIVATE_METHODS
}
