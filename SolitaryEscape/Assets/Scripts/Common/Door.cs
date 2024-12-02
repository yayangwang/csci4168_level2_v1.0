using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<BoxMove> boxList;
    public bool enemyDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //¿ªÃÅ
    public void OpenDoor()
    {
        foreach (BoxMove box in boxList)
        {
            if(box.check==false)
            return;
        }
        if(enemyDoor)
        {
            GameLevelMgr.Instance.EnemyAppear();
        }
        this.gameObject.SetActive(false);
    }

}
