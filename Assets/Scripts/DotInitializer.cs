using UnityEngine;

namespace TofArSlamViewr
{
    public class DotInitializer : MonoBehaviour
    {
        public GameObject oneMeterPrefab;
        public Vector3 spaceSizeInMeter = new Vector3(20f, 4f, 20f);
        public GameObject origin;
        public GameObject axisX;
        public GameObject axisY;
        public GameObject axisZ;

        void Start()
        {
            var maxX = Mathf.Floor(this.spaceSizeInMeter.x / 2);
            var maxY = Mathf.Floor(this.spaceSizeInMeter.y / 2);
            var maxZ = Mathf.Floor(this.spaceSizeInMeter.z / 2);

            for (var x = maxX; x > 0; x -= 1f)
            {
                for (var y = maxY; y > 0; y -= 1f)
                {
                    for (var z = maxZ; z > 0; z -= 1f)
                    {
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(x, y, z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(x, y, -z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(x, -y, z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(x, -y, -z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(-x, y, z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(-x, y, -z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(-x, -y, z), Quaternion.identity, this.origin.transform);
                        GameObject.Instantiate(this.oneMeterPrefab, new Vector3(-x, -y, -z), Quaternion.identity, this.origin.transform);
                    }
                }
            }

            this.axisX.transform.localScale = new Vector3(this.axisX.transform.localScale.x, maxX, this.axisX.transform.localScale.z);
            this.axisY.transform.localScale = new Vector3(this.axisX.transform.localScale.x, maxY, this.axisX.transform.localScale.z);
            this.axisZ.transform.localScale = new Vector3(this.axisX.transform.localScale.x, maxZ, this.axisX.transform.localScale.z);
        }
    }
}
