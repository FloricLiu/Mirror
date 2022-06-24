using UnityEngine;
using UnityEngine.SceneManagement;

class GoalScript2 : MonoBehaviour
{
    private bool memberPlayer = false;
    private bool memberShadow = false;
    [SerializeField] public GameObject FinishScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (memberPlayer == true && memberShadow == true)
        {
            Time.timeScale = 0;
            FinishScreen.SetActive(true);
        }
    }
    protected void OnTriggerStay2D(Collider2D localCollider)
    {

        GameObject localOtherObject = localCollider.gameObject;
        if (localOtherObject.name=="Player")
        {
            memberPlayer = true;
        }
        if (localOtherObject.name == "Shadow")
        {
            memberShadow = true;
        }
    }
    protected void OnTriggerExit2D(Collider2D localCollider)
    {

        GameObject localOtherObject = localCollider.gameObject;
        if (localOtherObject.name == "Player")
        {
            memberPlayer = false;
            print(memberPlayer);
        }
        if (localOtherObject.name == "Shadow")
        {
            memberShadow = false;
            print(memberShadow);
        }
    }
}
