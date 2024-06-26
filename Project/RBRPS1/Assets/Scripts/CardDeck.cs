using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardDeck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<Card> cards = new List<Card>();
    [Tooltip("False moves card to end, true removes card")]
    [SerializeField] private bool drawRemoves = false;

    [Header("Deck UI")][SerializeField] private TMPro.TextMeshProUGUI buttonText;
    [Header("Card UI")][SerializeField] private GameObject cardContainer;
    [SerializeField] private TMPro.TextMeshProUGUI title, cardType, body;
    private void Awake()
    {
        Debug.Log($"Shuffling {name}");
        for (int i = 0; i < cards.Count; i++)
        {
            var c = cards[i];
            int index = Random.Range(0, cards.Count);
            var other = cards[index];
            cards[index] = c;
            cards[i] = other;
        }

        buttonText.text = $"Deck Size {cards.Count}";
        if (cardContainer != null)
        {
            cardContainer.SetActive(false);
        }
    }

    public void Draw()
    {
        if (cards.Count > 0)
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            //shift card to end
            if (!drawRemoves)
            {
                cards.Add(card);
            }
            buttonText.text = $"Deck Size {cards.Count}";
            ShowCard(card);
        }
        else
        {
            Debug.LogError("Deck is empty");
        }

    }

    private void ShowCard(Card card)
    {
        title.text = $"{card.title}";
        cardType.text = $"{card.type}";
        body.text = $"{card.body}";
        cardContainer.SetActive(true);
    }

    public void Dismiss()
    {
        cardContainer.SetActive(false);
    }
}
[Serializable]
public class Card
{
    public string title;
    public string type;
    [TextArea]
    public string body;
}