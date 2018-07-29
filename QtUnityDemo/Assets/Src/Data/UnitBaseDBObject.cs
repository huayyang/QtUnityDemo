using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class UnitBaseDBObject {
    public int unitId;
    public string unitName;
    public int abilityId;

    public UnitBaseDBObject(SqliteDataReader reader) {
        unitId = reader.GetInt32(0);
        unitName = reader.GetString(1);
        abilityId = reader.GetInt32(2);
    }
}
