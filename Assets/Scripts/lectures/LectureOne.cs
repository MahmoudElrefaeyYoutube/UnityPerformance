using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LectureOne : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject parent;

    private int testsCount = 1000000;
    private TestComponent test;

    private void Start()
    {
    }

    private void Strings()
    {
        //using (new CustomTimer(" string  Method", testsCount))
        //{
        //    string testString = "";
        //    for (int i = 0; i < testsCount; i++)
        //    {
        //        testString += i.ToString();
        //        testString += " - ";
        //    }
        //    Debug.Log(testString);
        //}
        //using (new CustomTimer(" string ", testsCount))
        //{
        //    string testString = "";
        //    for (int i = 0; i < testsCount; i++)
        //    {
        //        testString = string.Concat(testString, i.ToString());
        //        testString = string.Concat(testString, " - ");
        //    }
        //    Debug.Log(testString);
        //}
        using (new CustomTimer("string builder", testsCount))
        {
            StringBuilder testString = new StringBuilder();

            for (int i = 0; i < testsCount; i++)
            {
                testString.Append(i.ToString());
                testString.Append(" - ");
            }
            Debug.Log(testString);
        }
    }

    private void AccessingComponent()
    {
        TestComponent test;
        using (new CustomTimer("GetComponent(string)", testsCount))
        {
            for (var i = 0; i < testsCount; ++i)
            {
                test = (TestComponent)GetComponent("TestComponent");
            }
        }
        //using (new CustomTimer("GetComponent<ComponentName>", testsCount))
        //{
        //    for (var i = 0; i < testsCount; ++i)
        //    {
        //        test = GetComponent<TestComponent>();
        //    }
        //}
        ////using (new CustomTimer("GetComponent(typeof(ComponentName))", testsCount))
        //{
        //    for (var i = 0; i < testsCount; ++i)
        //    {
        //        test = (TestComponent)GetComponent(typeof(TestComponent));
        //    }
        //}
    }

    private void AccessingTag()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int r = 0; r < testsCount; r++)
            {
                if (parent.tag == "Player")
                {
                }
            }

            Debug.Break();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int r = 0; r < testsCount; r++)
            {
                if (parent.CompareTag("Player"))
                {
                }
            }

            Debug.Break();
        }
    }

    private void NullReferenceCheck()
    {
        using (new CustomTimer("Parent == null Test", testsCount))
        {
            for (var i = 0; i < testsCount; ++i)
            {
                if (parent == null) { }
            }
        }
        using (new CustomTimer("ReferenceEquals method", testsCount))
        {
            for (var i = 0; i < testsCount; ++i)
            {
                if (ReferenceEquals(parent, null)) { }
            }
        }
    }
}