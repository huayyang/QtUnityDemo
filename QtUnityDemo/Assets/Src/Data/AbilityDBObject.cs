using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class AbilityDBObject {
    public int abilityId;
    public string abilityName;
    public string type;

    public AbilityDBObject(SqliteDataReader reader) {
        abilityId = reader.GetInt32(0);
        abilityName = reader.GetString(1);
        type = reader.GetString(2);
    }
}
