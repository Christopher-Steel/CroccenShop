using UnityEngine;

public class EquipTest : MonoBehaviour {
    public EquipmentOrganiser croccen;

    void Start () {
        var equipment = GetComponent<Equipment>();
        croccen.Equip(equipment);
    }
}
