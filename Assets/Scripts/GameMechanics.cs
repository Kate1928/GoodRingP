using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameMechanics : MonoBehaviour
{
    private CubePos nowCube = new CubePos(0,0,2);
    public float cubeChangePlaseSpeed = 0.5f;
    public Transform cubeToPlase;
    public GameObject cubeToCreate, allCubes;

    //список занятых позиций
    private List<Vector3> allCubesPosition = new List<Vector3>{
        new Vector3(0,0,0),
        new Vector3(0,0,1),
        new Vector3(0,0,2)
    };
    
    //основная функция
    private void Start()
    {
        StartCoroutine(NewCubePlase());
    }
    private void Update()
    {
        GameObject newCube = Instantiate(
            cubeToCreate,
            cubeToPlase.position,
            Quaternion.identity) as GameObject;

            newCube.transform.SetParent(allCubes.transform);
            nowCube.setVector(cubeToPlase.position);
            allCubesPosition.Add(nowCube.getVector());

    }
    //
    IEnumerator NewCubePlase()
    {
        while(true)
        {
            SpawnPositions();

            yield return new WaitForSeconds(cubeChangePlaseSpeed);
        }
    }
    //добавляем не занятые позиции и выбираем одну из них на вывод
    private void SpawnPositions()
    {
        //список свободных позиций
        List<Vector3> allFreeCubesPosition = new List<Vector3>();
        //List<Vector3> positions = new List<Vector3>();
        if(IsEmptyPosition(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z)) && nowCube.x + 1 != cubeToPlase.position.x)
            allFreeCubesPosition.Add(new Vector3(nowCube.x + 1, nowCube.y, nowCube.z));
        if(IsEmptyPosition(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z)) && nowCube.x - 1 != cubeToPlase.position.x)
            allFreeCubesPosition.Add(new Vector3(nowCube.x - 1, nowCube.y, nowCube.z));
        if(IsEmptyPosition(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1)) && nowCube.z + 1 != cubeToPlase.position.z)
            allFreeCubesPosition.Add(new Vector3(nowCube.x, nowCube.y, nowCube.z + 1));
        //добавляем рандомный кубик из возможных
        int Len = allFreeCubesPosition.Count;
        Len = UnityEngine.Random.Range(0, Len);
        cubeToPlase.position = allFreeCubesPosition[Len];
        //positions.Add();
    }
    //проверяем возможные позиции
    private bool IsEmptyPosition(Vector3 targetPos)
    {
        if(targetPos.x == -3 || targetPos.x == 3)
            return false;
        foreach(Vector3 pos in allCubesPosition)
        {
            if(pos.x == targetPos.x & pos.y == targetPos.y & pos.z == targetPos.z)
            return false;
        }
        return true;
    }
    
}
struct CubePos{
    public int x, y, z;
    public CubePos(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Vector3 getVector()
    {
        return new Vector3(x, y, z);
    }
    public void setVector(Vector3 pos)
    {
        x = Convert.ToInt32(pos.x);
        y = Convert.ToInt32(pos.y);
        z = Convert.ToInt32(pos.z);
    }
}
