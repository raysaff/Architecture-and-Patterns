using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterpretatorExample : MonoBehaviour
{ 
    [SerializeField] 
        private Text _resultText;
    [SerializeField] 
        private InputField _usersInput;
    [SerializeField]
        private Button _calcButton;

    private void Start()
    {
        _calcButton.onClick.AddListener(Interpretator);
    }

    public void Interpretator()
    {
        _resultText.text = Calculation(_usersInput.text);

    }

    public string Calculation(string equation)
    {
        string reminder = equation.Replace(" ", string.Empty);
        char[] actionSymbols = new[]
        { 
            '+','-','*','/'
        };

        char[] actions = new char[0];
        int j = 0;
        for (int i=0;i<reminder.Length;i++)
        {
            if (reminder[i]=='/' || reminder[i] == '*' || reminder[i] == '+' || reminder[i] == '-')
            {
                Array.Resize(ref actions, actions.Length + 1);
                actions[j] = reminder[i];
                j++;
            }
        }
        List<string> numbersList = new List<string>(reminder.Split(actionSymbols));
        List<char> actionsList = new List<char>(actions);

        for (int i=0; i<actionsList.Count; i++)
        {
            if (actionsList[i] == '*')
            {
                numbersList[i] = (Convert.ToInt32(numbersList[i]) * Convert.ToInt32(numbersList[i + 1])).ToString();
                actionsList.RemoveAt(i);
                numbersList.RemoveAt(i + 1);
                i--;
                continue;
            }
            if (actionsList[i] == '/')
            {
                numbersList[i] = (Convert.ToInt32(numbersList[i]) / Convert.ToInt32(numbersList[i + 1])).ToString();
                actionsList.RemoveAt(i);
                numbersList.RemoveAt(i + 1);
                i--;
                continue;
            }
        }

        for (int i = 0; i < actionsList.Count; i++)
        {
            if (actionsList[i] == '+')
            {
                numbersList[i] = (Convert.ToInt32(numbersList[i]) + Convert.ToInt32(numbersList[i + 1])).ToString();
                actionsList.RemoveAt(i);
                numbersList.RemoveAt(i + 1);
                i--;
                continue;
            }
            if (actionsList[i] == '-')
            {
                numbersList[i] = (Convert.ToInt32(numbersList[i]) - Convert.ToInt32(numbersList[i + 1])).ToString();
                actionsList.RemoveAt(i);
                numbersList.RemoveAt(i + 1);
                i--;
                continue;
            }
        }
        
        return numbersList[0];
    }
}
