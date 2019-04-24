using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{

	public GameObject energyCellPrefab, energyContainer;

	void Start()
	{
		energyCellPrefab = Resources.Load<GameObject>("EnergyCell");
		energyContainer = transform.Find("EnergyContainer").gameObject;
		playerObject = GameObject.Find("Player(Clone)");
		player = playerObject.GetComponent<PlayerMovement>();
		UpdateEnergy();
	}

	// Update is called once per frame
	void Update()
	{

	}
	GameObject playerObject;
	PlayerMovement player;
	List<GameObject> energyCells;

	void UpdateEnergy()
	{
		if (player.energyPool > energyCells.Count)
		{
			energyCells.Add(Instantiate(energyCellPrefab, energyContainer.transform));
		}
	}
}
