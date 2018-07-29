using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour {
    public int unitId;
    public string unitName;
    public int abilityId;

	// Use this for initialization
	void Start () {
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Initialize() {
        UnitBaseDBObject metadata = MetadataLoader.Instance.GetUnitMetadataWithId(unitId);
        unitName = metadata.unitName;
        abilityId = metadata.abilityId;
    }
}
