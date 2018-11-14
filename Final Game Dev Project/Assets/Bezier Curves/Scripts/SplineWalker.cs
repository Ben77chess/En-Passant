using UnityEngine;

public class SplineWalker : MonoBehaviour {

	public BezierCurves.BezierCurve3D spline; //modified

	public float duration;

	public bool lookForward;

	public SplineWalkerMode mode;

	private float progress;
	private bool goingForward = true;

	private void Update () {
		if (goingForward) {
			progress += Time.deltaTime / duration;
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
		else {
			progress -= Time.deltaTime / duration;
			if (progress < 0f) {
				progress = -progress;
				goingForward = true;
			}
		}

		Vector3 position = spline.GetPoint(progress);
		transform.localPosition = position;
		if (lookForward) {
            transform.LookAt(spline.GetPoint(progress + Time.deltaTime));//modified //(position + BezierCurves.BezierCurve3D.GetNormalOnCubicCurve(progress, this.transform.up, spline.KeyPoints[0], spline.KeyPoints[2]));
		}
	}
}