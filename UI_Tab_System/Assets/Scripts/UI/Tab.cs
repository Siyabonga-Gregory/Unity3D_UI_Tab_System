using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Tab : MonoBehaviour
{
    public InputField[] m_InputFields;
    EventSystem system;

    protected void Start()
    {
        //gameObject.GetComponent<InputField>().onEndEdit.AddListener(displayText);
        system = EventSystem.current;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {
                InputField inputfield = next.GetComponent<InputField>();
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));
                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
        }
    }

    public void AddOnValueChangedListeners(UnityAction<string> action)
    {
        for (int i = 0; i < m_InputFields.Length; i++)
        {
            InputField item = m_InputFields[i];
            item.onValueChanged.AddListener(action);
        }
    }
}
