﻿using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public BezierCurves.BezierCurve3D spline; //modified

	public float duration;

	public bool lookForward;

	public SplineWalkerMode mode;

	public float progress;
	private bool goingForward = true;

	private void Update () {
		if (goingForward && !WalkerController.walkerController.paused) {
            progress = WalkerController.walkerController.progress;
			progress += Time.deltaTime / duration;
            WalkerController.walkerController.progress = progress;
			if (progress > 1f) {
				if (mode == SplineWalkerMode.Once) {
					progress = 1f;
				}
				else if (mode == SplineWalkerMode.Loop) {
					progress -= 1f;
				}
				else {
					progress = 2f - progress;
					goingForward = false;
				}
			}
		}
		else if(!goingForward && !WalkerController.walkerController.paused) {
			progress -= Time.deltaTime / duration;
			if (progress < 0f) {
				progress = -progress;
				goingForward = true;
			}
		} else { //paused
            progress = WalkerController.walkerController.progress;
        }

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
        if (lookForward && !WalkerController.walkerController.paused) {
            transform.LookAt(spline.GetPoint(progress + Time.deltaTime));//modified //(position + BezierCurves.BezierCurve3D.GetNormalOnCubicCurve(progress, this.transform.up, spline.KeyPoints[0], spline.KeyPoints[2]));
		}
	}
}