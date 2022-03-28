using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class infoscript : MonoBehaviour
{
    public GameObject Textbox;
    bool closecooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Textbox.active && Input.GetKeyDown(KeyCode.Mouse0)&&!closecooldown)
        {
            Textbox.active = false;
        }
    }
    public void Openinfo(int info)
    {
        
        if (info == 0)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Brenton Harrison Tarrant, a 28-year-old man from Grafton, New South Wales, Australia,He committed two mass shootings in two different mosques in a single day,getting 51 kills and 40 injuries which is considered very good KDI (kill/death/injuries) ";
        }
        else if (info == 1)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Derek Michael Chauvin born March 19, 1976 is an American former police officer who was convicted for the murder of George Floyd in Minneapolis, Minnesota. Sadly the killing was not on purpose which makes him a little bit less based but we still have to tank him for radicalising the new generation by showing the monkies off to the whole world, he also has terrible KDI (kill/death/injuries)";
        }
        else if (info == 2)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Jeffrey Edward Epstein January 20, 1953 – August 10, 2019 was an American financier and convicted sex offender. He ran one of the biggest child trafficking rings in the entire world and sadly got caught which led to his demise, i'd guess pretty good KDI count though we cannot know for sure";
        }
        else if (info == 3)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Jhonny Depp and Chris Brown both beat their wives and got away with it (and they probably keep doing it), very based";
        }
        else if (info == 4)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Marvin Heemeyer October 28, 1951 – June 4, 2004 was an automobile muffler repair shop owner who Over about eighteen months had secretly modified a Komatsu D355A bulldozer by adding layers of steel and concrete, intended to serve as armor. On June 4, 2004, Heemeyer went on a spree in which he used the armored bulldozer to demolish the town hall, the former mayor's house, and several other buildings. He's a great inspiration to us because he showed us that its really easy to destroy the government with just a little planning (hopefully this game will help you accomplish that)";
        }
        else if (info == 5)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Osama bin Mohammed bin Awad bin Laden March 10, 1957 – May 2, 2011, also transliterated as Usama bin Ladin, was a Saudi terrorist and founder of the Pan-Islamic militant organization al-Qaeda. The group is designated as a terrorist group by the United Nations Security Council, the North Atlantic Treaty Organization (NATO), the European Union, and various countries. Under bin Laden's leadership, al-Qaeda was responsible for the September 11 attacks in the United States, and many other mass-casualty attacks worldwide. Very Muslim";
        }
        else if (info == 6)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Peter Gerard Scully born 13 January 1963 is an Australian man imprisoned for life in the Philippines after being convicted of one count of human trafficking and five counts of rape by sexual assault of underage girls. He is pending trial for other crimes against children, including the production and dissemination of child pornography, torture, and the alleged murder of an 11-year-old girl in 2012. Very based, very high KDI, 75 victims known for now";
        }
        else if (info == 7)
        {
            Textbox.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Theodore John Kaczynski born May 22, 1942, also known as the Unabomber , is an American domestic terrorist and former mathematics professor.he killed three people and injured 23 others in a nationwide bombing campaign. Very high KDI and very sneaky, though he did have some mental problems which led to his demise, overall he was pretty good";
        }
        Textbox.active = true;
        closecooldown = true;
        Invoke("startcooldown",2f);

    }
    void startcooldown()
    {
        closecooldown = false;
    }
}
