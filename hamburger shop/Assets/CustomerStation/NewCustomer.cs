using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewCustomer : MonoBehaviour
{
    public List<Image> customerSlots = new List<Image>();
    public List<CustomerSlot> customerScript = new List<CustomerSlot>();
    public List<Sprite> customers = new List<Sprite>();
    public bool timerOn;
    public NewOrderManager orderManager;
    public GameObject custo;

    private void Start()
    {
        int i = Random.Range(2, 10);
        print(i);
        timerOn = false;
        bool noMore = false;
        int c = Random.Range(0, customers.Count);
        print(orderManager.Full());
        for (int s = 0; s < customerScript.Count; s++)
        {
            print(noMore);
            print(customerScript[s]);
            if (customerScript[s].customer == null && noMore == false && orderManager.Full())
            {
                print("iets");
                customerSlots[s].sprite = customers[c];
                GameObject temp = Instantiate(custo, new Vector3(0, 0, 0), Quaternion.identity);
                customerScript[s].customer = temp.GetComponent<Customer>();
                customerScript[s].index = s;
                noMore = true;
                customerSlots[s].enabled = true;
            }
        }
    }
    void Update()
    {
        if (timerOn == false)
        {
            StartCoroutine(Timer());
            timerOn = true;
        }
    }

    IEnumerator Timer()
    {
        int i = Random.Range(2, 10);
        print(i);
        yield return new WaitForSeconds(i);
        timerOn = false;
        bool noMore = false;
        int c = Random.Range(0, customers.Count);
        print(orderManager.Full());
        for (int s = 0; s < customerScript.Count; s++)
        {
            print(noMore);
            print(customerScript[s]);
            if (customerScript[s].customer == null && noMore == false && orderManager.Full())
            {
                print("iets");
                customerSlots[s].sprite = customers[c];
                GameObject temp = Instantiate(custo, new Vector3(0, 0, 0), Quaternion.identity);
                customerScript[s].customer = temp.GetComponent<Customer>();
                customerScript[s].index = s;
                noMore = true;
                customerSlots[s].enabled = true;
            }
        }
    }
}
