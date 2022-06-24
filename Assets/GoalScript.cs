using UnityEngine;
using UnityEngine.SceneManagement;

class GoalScript : MonoBehaviour
{
    private bool memberPlayer = false;
    private bool memberShadow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        if (memberPlayer == true && memberShadow == true)
        {
            SceneManager.LoadScene("Level2");
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
