using UnityEngine;

public class ColorMenu : MonoBehaviour
{
    public GameObject CarExample;
    public GameObject FrontRightDoorExample;
    public GameObject FrontLeftDoorExample;
    public GameObject BackRightDoorExample;
    public GameObject BackLeftDoorExample;

    MeshRenderer Car;
    MeshRenderer FrontRightDoor;
    MeshRenderer FrontLeftDoor;
    MeshRenderer BackRightDoor;
    MeshRenderer BackLeftDoor;

    public ChangeColor changeColor;

    public void ChangeCarColor(string color)
    {
        SaveSystem.CarColor = color;
        SaveSystem.SaveCarColor();
        Car = CarExample.GetComponent<MeshRenderer>();
        FrontRightDoor = FrontRightDoorExample.GetComponent<MeshRenderer>();
        FrontLeftDoor = FrontLeftDoorExample.GetComponent<MeshRenderer>();
        BackRightDoor = BackRightDoorExample.GetComponent<MeshRenderer>();
        BackLeftDoor = BackLeftDoorExample.GetComponent<MeshRenderer>();

        Car.material = changeColor.colors[color];
        FrontRightDoor.material = changeColor.colors[color];
        FrontLeftDoor.material = changeColor.colors[color];
        BackRightDoor.material = changeColor.colors[color];
        BackLeftDoor.material = changeColor.colors[color];
    }

}
