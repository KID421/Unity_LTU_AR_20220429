using UnityEngine;

public class SystemSpawn : MonoBehaviour
{
    [Header("要生成的物件")]
    public GameObject goSpawn;
    [Header("生成位置")]
    public Transform traSpawn;

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(goSpawn, traSpawn.position, traSpawn.rotation);
        }
    }
}
