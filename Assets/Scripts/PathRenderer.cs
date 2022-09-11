using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TofArSlamViewr
{
    public class PathRenderer : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        private Transform targetTransform;
        private List<Vector3> points;

        void Start()
        {
            this.targetTransform = this.lineRenderer.transform;
            this.points = new List<Vector3>();
            this.StartCoroutine(this.Process());
        }

        private IEnumerator Process()
        {
            var lastPosition = this.targetTransform.transform.position;
            while (true)
            {
                if (lastPosition != this.targetTransform.position)
                {
                    this.points.Add(this.targetTransform.position);
                    this.lineRenderer.positionCount = this.points.Count;
                    this.lineRenderer.SetPositions(this.points.ToArray());
                }
                lastPosition = this.targetTransform.position;
                yield return null;
            }
        }
    }
}