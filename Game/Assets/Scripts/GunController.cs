using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public GameObject bullet;
	public GameObject bulletImpact;

    Vector3 gunLocation;

	// Use this for initialization
	void Start () {
        gunLocation = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        gunLocation = gameObject.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(bullet, gunLocation, Quaternion.identity) as GameObject;
        }
		else if (Input.GetMouseButtonDown(1))
		{
			RaycastHit bulletHit;
			if (Physics.Raycast(gunLocation, -transform.forward, out bulletHit)) {
				Debug.Log(bulletHit.distance);
				Quaternion hitRotation = Quaternion.FromToRotation(Vector3.up, bulletHit.normal);
				Object bulletDecal = Instantiate(bulletImpact, bulletHit.point, hitRotation);
				Destroy(bulletDecal, 10f);
				if (Physics.Raycast(bulletHit.point, Vector3.Reflect(-transform.forward,bulletHit.normal), out bulletHit)) {
					Debug.Log(bulletHit.distance);
					hitRotation = Quaternion.FromToRotation(Vector3.up, bulletHit.normal);
					bulletDecal = Instantiate(bulletImpact, bulletHit.point, hitRotation);
					Destroy(bulletDecal, 10f);
				}
			}
		}
	}
}
