using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject FrontRightDoorExample;
    public GameObject FrontLeftDoorExample;
    public GameObject BackRightDoorExample;
    public GameObject BackLeftDoorExample;

    MeshRenderer CarMaterial;
    MeshRenderer FrontRightDoor;
    MeshRenderer FrontLeftDoor;
    MeshRenderer BackRightDoor;
    MeshRenderer BackLeftDoor;

    public Material RedColor;
    public Material WhiteColor;
    public Material BlackColor;
    public Material BlueColor;
    public Material BrownColor;
    public Material IceBlueColor;
    public Material LimeGreenColor;
    public Material YellowColor;
    public Material GreyColor;
    public Material OrangeColor;
    public Material PinkColor;
    public Material PurpleColor;

    public Dictionary<string, Material> colors = new();

    void Start()
    {
        colors["red"] = RedColor;
        colors["black"] = BlackColor;
        colors["white"] = WhiteColor;
        colors["blue"] = BlueColor;
        colors["brown"] = BrownColor;
        colors["iceblue"] = IceBlueColor;
        colors["limegreen"] = LimeGreenColor;
        colors["yellow"] = YellowColor;
        colors["orange"] = OrangeColor;
        colors["pink"] = PinkColor;
        colors["purple"] = PurpleColor;
        colors["grey"] = GreyColor;

        SaveSystem.LoadProgress();
        if (SaveSystem.CarColor == null)
        {
            SaveSystem.CarColor = "white";
        }

        CarMaterial = GetComponent<MeshRenderer>();
        FrontRightDoor = FrontRightDoorExample.GetComponent<MeshRenderer>();
        FrontLeftDoor = FrontLeftDoorExample.GetComponent<MeshRenderer>();
        BackRightDoor = BackRightDoorExample.GetComponent<MeshRenderer>();
        BackLeftDoor = BackLeftDoorExample.GetComponent<MeshRenderer>();

        CarMaterial.material = colors[SaveSystem.CarColor];
        FrontRightDoor.material = colors[SaveSystem.CarColor];
        FrontLeftDoor.material = colors[SaveSystem.CarColor];
        BackRightDoor.material = colors[SaveSystem.CarColor];
        BackLeftDoor.material = colors[SaveSystem.CarColor];
    }

}
