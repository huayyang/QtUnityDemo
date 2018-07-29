using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class MetadataLoader : Singleton<MetadataLoader> {
    private SqliteHelper sqlHelper;

    private Dictionary<int, UnitBaseDBObject> unitMetadataMap;
    private Dictionary<int, AbilityDBObject> abilityMetadataMap;

    public void Initialize() {
        sqlHelper = new SqliteHelper();
        sqlHelper.InitializeDBConnection();

        LoadUnitMetadata();
        LoadAbilityMetadata();
    }

    public UnitBaseDBObject GetUnitMetadataWithId(int unitId) {
        if (!unitMetadataMap.ContainsKey(unitId)) {
            return null;
        }

        return unitMetadataMap[unitId];
    }

    public AbilityDBObject GetAbilityMetadataWithId(int abilityId) {
        if (!abilityMetadataMap.ContainsKey(abilityId)) {
            return null;
        }

        return abilityMetadataMap[abilityId];
    }

    private void LoadUnitMetadata() {
        unitMetadataMap = new Dictionary<int, UnitBaseDBObject>();
        SqliteCommand cmd = sqlHelper.CreateSqlCommand("SELECT * FROM unit_metadata um INNER JOIN unit_editable ue ON (um.id = ue.id)");
        SqliteDataReader reader = sqlHelper.ExecuteSqlCommand(cmd);
        while (reader.Read()) {
            UnitBaseDBObject row = new UnitBaseDBObject(reader);
            unitMetadataMap[row.unitId] = row;
        }

        sqlHelper.CloseResultReader(reader);
    }

    private void LoadAbilityMetadata() {
        abilityMetadataMap = new Dictionary<int, AbilityDBObject>();
        SqliteCommand cmd = sqlHelper.CreateSqlCommand("SELECT * FROM ability_metadata");
        SqliteDataReader reader = sqlHelper.ExecuteSqlCommand(cmd);
        while (reader.Read()) {
            AbilityDBObject row = new AbilityDBObject(reader);
            abilityMetadataMap[row.abilityId] = row;
        }

        sqlHelper.CloseResultReader(reader);
    }
}
