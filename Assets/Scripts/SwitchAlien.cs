using UnityEngine;

public class SwitchAlien : MonoBehaviour
{
    public GameObject[] alienPreFabs;

    public GameObject alien1;
    public GameObject alien2;
    public GameObject car1;
    public GameObject car2;

    public bool editorswitch = false;

    public GameObject activeAlien;
    public GameObject activeCar;

    public void Awake()
    {
        activeAlien = alien1;
        activeCar = car1;
    }

    public void SwitchtoAlien2()
    {
        activeAlien = alien2;
        activeCar = car2;
        alien1.SetActive(false);
        alien2.SetActive(true);
        car1.SetActive(false);
        car2.SetActive(true);

    }

    public void SwitchtoAlien1()
    {
        activeAlien = alien1;
        activeCar = car1;
        alien1.SetActive(true);
        alien2.SetActive(false);
        car1.SetActive(true);
        car2.SetActive(false);

    }

    public void OnValidate()
    {
        if (editorswitch)
        {
            SwitchtoAlien2 ();
        }
        else
        {
            SwitchtoAlien1 ();
        }
    }
}
