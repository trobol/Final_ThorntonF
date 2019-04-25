using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{

	GameObject energyCellPrefab, energyContainer;

	void Start()
	{
		energyCellPrefab = Resources.Load<GameObject>("EnergyCell");
		energyContainer = transform.Find("EnergyContainer").gameObject;
		playerObject = GameObject.FindGameObjectWithTag("Player");
		player = playerObject.GetComponent<PlayerMovement>();
		UpdateEnergy();
	}

	// Update is called once per frame
	void Update()
	{

	}
	GameObject playerObject;
	PlayerMovement player;
	List<GameObject> energyCells = new List<GameObject>();

	public void UpdateEnergy()
	{
		if (player.energyPool > energyCells.Count)
		{
            for (int i = 0; player.energyPool > energyCells.Count; i++)
            {
               GameObject g = Instantiate(energyCellPrefab, energyContainer.transform);
                energyCells.Add(g);
                g.GetComponent<EnergyCell>().Anim(((float)i) / 5);
            }
		}
		
		for(int i =0; i < energyCells.Count; i++) {
			if(player.energy > i) {
				energyCells[i].GetComponent<EnergyCell>().Activate(((float)i)/5);
			} else {
				energyCells[i].GetComponent<EnergyCell>().Deactivate(0);
			}
			
		}
	}
}
