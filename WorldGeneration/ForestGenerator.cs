using UnityEngine;
using System.Collections;

public class ForestGenerator : MonoBehaviour
{
	public Renderer textureRender;
	public int mapWidth;
	public int mapHeight;
	public float noiseScale;
	public bool autoUpdate;

	public GameObject[] tree = new GameObject[4];
	public GameObject[] rock = new GameObject[2];
	public GameObject meshObject;
	public GameObject rockTransform;
	public GameObject treeTransform;
	public float minTreeSize;
	public float maxTreeSize;
	public Texture2D noiseImage;
	public float forestSize;
	public float treeDensity;

	public int heightScale = 5;
	public float detailScale = 5.0f;

	private float baseDensity = 5.0f;

	public int randomNum;
	public Shader shader;

	RaycastHit hit;

	public int groundLayer;
	public bool canSpawnObjects;
	public GameObject navMesh;

    private void Awake()
    {
		canSpawnObjects = false;

		float[,] noiseMap = GenerateForestMap(mapWidth, mapHeight, noiseScale);
		noiseImage = getForestMap(noiseMap);
		groundLayer = LayerMask.NameToLayer("Ground");
	}

    private void Update()
    {
        if (canSpawnObjects)
        {
			StartCoroutine(Generate());
			canSpawnObjects = false;
        }
	}

	IEnumerator Generate()
	{
		yield return new WaitForSeconds(0);

		foreach (var point in meshObject.GetComponent<MeshFilter>().mesh.vertices)
		{
			//get plant prefab
			Vector3 rayStart = meshObject.transform.TransformPoint(point) + Vector3.up * 100;

			for (int i = 0; i < 10; i++)
			{
				Vector3 offset = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
				rayStart += offset;

				if (Physics.Raycast(rayStart, Vector3.down, out hit))
				{
					//hit.normal -> rot
					//hit.point -> pos
					//print(hit.point);
					//spawn code
					float chance = noiseImage.GetPixel((int)hit.point.x, (int)hit.point.z).r / (baseDensity / treeDensity);

					if (ShouldPlaceTree(chance))
					{
						if (hit.point.y >= 4 && hit.point.y <= 17)
						{
							randomNum = Random.Range(0, 4);
							GameObject newTree = Instantiate(tree[randomNum]);
							newTree.SetActive(true);

							for (int i2 = 0; i2 < newTree.transform.childCount; i2++)
                            {
                                if (newTree.transform.GetChild(i2).name != "Empty")
                                {
									Renderer rend = newTree.transform.GetChild(i2).GetComponent<Renderer>();
									Color color = newTree.transform.GetChild(i2).GetComponent<Renderer>().material.color;
									rend.material = new Material(shader);
									rend.material.SetColor("_Tint", color);

									if (newTree.transform.GetChild(i2).name.Contains("branches") || newTree.transform.GetChild(i2).name.Contains("branchs") || newTree.transform.GetChild(i2).name.Contains("branch"))
									{
										changeShaderToTrunk(rend);
									}

									if (newTree.transform.GetChild(i2).name.Contains("leaves"))
									{
										changeShaderToLeaves(rend);
									}
								}
							}

							newTree.transform.position = hit.point;
							newTree.name = tree[randomNum].name;
							if (randomNum == 0 || randomNum == 1)
							{
								newTree.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
							}
							if (randomNum == 2 || randomNum == 3)
							{
								newTree.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
							}
							float randomRotation = Random.Range(0, 360);
							newTree.transform.Translate(Vector3.down * 0.5f);
							newTree.layer = groundLayer;
							newTree.transform.eulerAngles = new Vector3(
								 newTree.transform.eulerAngles.x,
								 newTree.transform.eulerAngles.y + randomRotation,
								 newTree.transform.eulerAngles.z
								 );
							foreach(Transform child in newTree.transform)
                            {
								child.gameObject.AddComponent<TreeScript>();
								child.gameObject.layer = groundLayer;
							}
							//addLOD(newTree);
							newTree.transform.parent = treeTransform.transform;
						}
						if (hit.point.y >= 18)
						{
							randomNum = Random.Range(4, 6);
							GameObject newTree = Instantiate(tree[randomNum]);
							newTree.SetActive(true);

							for (int i2 = 0; i2 < newTree.transform.childCount; i2++)
							{
								if (newTree.transform.GetChild(i2).name != "Empty")
								{
									Renderer rend = newTree.transform.GetChild(i2).GetComponent<Renderer>();
									Color color = newTree.transform.GetChild(i2).GetComponent<Renderer>().material.color;
									rend.material = new Material(shader);
									rend.material.SetColor("_Tint", color);

									if (newTree.transform.GetChild(i2).name.Contains("branches") || newTree.transform.GetChild(i2).name.Contains("branchs") || newTree.transform.GetChild(i2).name.Contains("branch"))
									{
										changeShaderToTrunk(rend);
									}

									if (newTree.transform.GetChild(i2).name.Contains("leaves"))
									{
										changeShaderToLeaves(rend);
									}
								}
							}

							newTree.transform.position = hit.point;
							newTree.name = tree[randomNum].name;
							if (randomNum == 5)
							{
								newTree.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
							}
							if (randomNum == 6)
							{
								newTree.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
							}
							float randomRotation = Random.Range(0, 360);
							newTree.transform.Translate(Vector3.down * 0.5f);
							newTree.layer = groundLayer;
							newTree.transform.eulerAngles = new Vector3(
								 newTree.transform.eulerAngles.x,
								 newTree.transform.eulerAngles.y + randomRotation,
								 newTree.transform.eulerAngles.z
								 );
							foreach (Transform child in newTree.transform)
							{
								child.gameObject.AddComponent<TreeScript>();
								child.gameObject.layer = groundLayer;
							}
							newTree.transform.parent = treeTransform.transform;
						}
					}
				}
			}
		}

		foreach (var point in meshObject.GetComponent<MeshFilter>().mesh.vertices)
		{
			//get plant prefab
			Vector3 rayStart = meshObject.transform.TransformPoint(point) + Vector3.up * 100;

			for (int i = 0; i < 10; i++)
			{
				Vector3 offset = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
				rayStart += offset;

				if (Physics.Raycast(rayStart, Vector3.down, out hit))
				{
					//hit.normal -> rot
					//hit.point -> pos
					//print(hit.point);
					//spawn code
					float chance = noiseImage.GetPixel((int)hit.point.x, (int)hit.point.z).r / (baseDensity / treeDensity);

					if (ShouldPlaceTree(chance))
					{
						if (hit.point.y >= 18)
						{
							randomNum = Random.Range(0, 2);
							GameObject newRock = Instantiate(rock[randomNum]);
							newRock.SetActive(true);
							newRock.transform.position = hit.point;
							newRock.transform.localScale = new Vector3(2, 2, 2);
							newRock.transform.Translate(Vector3.down * 2f);
							newRock.layer = groundLayer;
							newRock.name = rock[randomNum].name;
							float randomRotation = Random.Range(0, 360);
							newRock.transform.eulerAngles = new Vector3(
								 newRock.transform.eulerAngles.x,
								 newRock.transform.eulerAngles.y + randomRotation,
								 newRock.transform.eulerAngles.z
								 );
							foreach (Transform child in newRock.transform)
							{
								child.gameObject.AddComponent<StoneScript>();
								child.gameObject.layer = groundLayer;
							}
							newRock.transform.parent = rockTransform.transform;
						}
					}
				}
			}
		}

		canSpawnObjects = false;

		yield return new WaitForSeconds(1);
		navMesh.GetComponent<NavigationBaker>().shouldUpdate = true;
	}

	public void canTurnOnObjectSpawning()
    {
		canSpawnObjects = true;
    }

	//Returns true or false given some chance from 0 to 1
	public bool ShouldPlaceTree(float chance)
	{
		if (Random.Range(0.0f, 1.0f) <= chance)
		{
			return true;
		}
		return false;
	}

	public void GenerateMap()
	{
		float[,] noiseMap = GenerateForestMap(mapWidth, mapHeight, noiseScale);

		DrawForestMap(noiseMap);
	}

	public void DrawForestMap(float[,] noiseMap)
	{
		int width = noiseMap.GetLength(0);
		int height = noiseMap.GetLength(1);

		Texture2D texture = new Texture2D(width, height);

		Color[] colourMap = new Color[width * height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
			}
		}
		texture.SetPixels(colourMap);
		texture.Apply();

		textureRender.sharedMaterial.mainTexture = texture;
		textureRender.transform.localScale = new Vector3(width, 1, height);
	}

	public Texture2D getForestMap(float[,] noiseMap)
    {
		int width = noiseMap.GetLength(0);
		int height = noiseMap.GetLength(1);

		Texture2D texture = new Texture2D(width, height);

		Color[] colourMap = new Color[width * height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[x, y]);
			}
		}
		texture.SetPixels(colourMap);
		texture.Apply();

		return texture;
	}

	public static float[,] GenerateForestMap(int mapWidth, int mapHeight, float scale)
	{
		float[,] noiseMap = new float[mapWidth, mapHeight];

		if (scale <= 0)
		{
			scale = 0.0001f;
		}

		for (int y = 0; y < mapHeight; y++)
		{
			for (int x = 0; x < mapWidth; x++)
			{
				float sampleX = x / scale;
				float sampleY = y / scale;

				float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
				noiseMap[x, y] = perlinValue;
			}
		}

		return noiseMap;
	}

	public void changeShaderToTrunk(Renderer rend)
    {
		rend.material.SetFloat("_wind_size", 15f);
		rend.material.SetFloat("_tree_sway_stutter_influence", 0.2f);
		rend.material.SetFloat("_tree_sway_stutter", 1.5f);
		rend.material.SetFloat("_tree_sway_speed", 1f);
		rend.material.SetFloat("_tree_sway_disp", 0.3f);
		rend.material.SetFloat("_branches_disp", 0.3f);
		rend.material.SetFloat("_leaves_wiggle_disp", 0.07f);
		rend.material.SetFloat("_leaves_wiggle_speed", 0.01f);
		rend.material.SetFloat("_r_influence", 0.006f);
		rend.material.SetFloat("_b_influence", 1);
	}

	public void changeShaderToLeaves(Renderer rend)
	{
		rend.material.SetFloat("_wind_size", 11.2f);
		rend.material.SetFloat("_tree_sway_stutter_influence", 0.717f);
		rend.material.SetFloat("_tree_sway_stutter", 0.49f);
		rend.material.SetFloat("_tree_sway_speed", 1f);
		rend.material.SetFloat("_tree_sway_disp", 1f);
		rend.material.SetFloat("_branches_disp", 0.118f);
		rend.material.SetFloat("_leaves_wiggle_disp", 0.07f);
		rend.material.SetFloat("_leaves_wiggle_speed", 0.01f);
		rend.material.SetFloat("_r_influence", 0.03f);
		rend.material.SetFloat("_b_influence", 0f);
	}

	public void addLOD(GameObject gameObject)
    {
		gameObject.AddComponent<LODGroup>();
		LODGroup group = gameObject.GetComponent<LODGroup>();
		LOD[] lods = new LOD[1];
		Renderer[] renderers = new Renderer[1];
		renderers[0] = gameObject.GetComponent<Renderer>();

		lods[0] = new LOD(1.0F / (0 + 1), renderers);

		group.SetLODs(lods);
		group.RecalculateBounds();
	}
}