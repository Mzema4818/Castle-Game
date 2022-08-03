using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{

	public float force = 10f;
	public float forceOffset = 0.1f;
	public GameObject deformObject;
	//public Vector3 pos;
	public bool canDeform;
	private bool canRayCast;
	private MeshDeformer deformation;

	private void Start()
	{
		//deformObject = GameObject.Find("Sphere");
		canDeform = true;
		canRayCast = true;
		deformation = transform.GetComponent<MeshDeformer>();
	}

	void Update()
	{
		if (canDeform)
		{
			deformation.springForce = 0;
			HandleInput();
			canDeform = false;
		}

		/*
		if (deformObject.activeSelf == false)
		{
			canRayCast = false;
		}

		if (deformObject.activeSelf == true && canRayCast == false)
		{
			canDeform = true;
			canRayCast = true;
		}


		if (!canRayCast)
		{
			deformation.springForce = 300;
		}
		*/
	}

	void HandleInput()
	{
		Vector3 downward = deformObject.transform.TransformDirection(Vector3.down) * 10;
		Vector3 pos = deformObject.transform.position + new Vector3(0f, -1f, 0f);
		Ray inputRay = new Ray(pos, downward);
		RaycastHit hit;

		if (Physics.Raycast(inputRay, out hit) && canRayCast)
		{
			MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();

			Debug.DrawRay(pos, downward, Color.green);

			if (deformer)
			{
				Vector3 point = hit.point;
				point += hit.normal * forceOffset;
				deformer.AddDeformingForce(point, force);
			}
		}
	}

	/*void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			pos = contact.point;
			print(pos);
		}
	}
	*/
}