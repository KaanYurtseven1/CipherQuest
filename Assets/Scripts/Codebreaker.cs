using TMPro;
using UnityEngine;

public class Codebreaker : MonoBehaviour
{
    //designer'in inspector'da gormesi ve degistirebilmesi icin SerializeField attribute'unu kullandik
    //SerializeField attribute'u sayesinde private field'lar inspector'da gorunur ve degistirilebilir. Fakat baska bir script'ten erisilemezler. Bu, encapsulation (kapsulleme) prensibini korumamiza yardimci olur.
    [Header("Code Range")]
    [SerializeField] int lowestCode = 1;
    [SerializeField] int highestCode = 1000;
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI guessText; //uzerinde TextMeshPro component'i olan UI Text objesini inspector'dan atayabilmek icin SerializeField kullandik
    [SerializeField] TextMeshProUGUI attemptText;
    [SerializeField] TextMeshProUGUI dialogueText;
    //bunlar oyun oynanirken degisecek, bu yuzden SerializeField kullanmadik --> runtime state
    int min;
    int max;
    int guess;
    int attempts;

    void Start()
    {
        StartNewRound();
    }

    void StartNewRound()
    {
        min = Mathf.Min(lowestCode, highestCode);
        max = Mathf.Max(lowestCode, highestCode);

        attempts = 0;

        NextGuess();
    }

    public void OnPressHigher()
    {
        min = guess + 1; //min degerini bir arttiriyoruz cunku tahmin edilen deger artik min degeri olamaz. Bu sayede bir sonraki tahmin daha yuksek olacak.
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess - 1;
        NextGuess();
    }

    void NextGuess()
    {
        if (min > max)
        {
            StartNewRound(); //eger min > max ise, kullanici yanlis degerlendirme yapti demektir. Bu durumda yeni bir round baslatabiliriz.

            dialogueText.text = "Your clues contradict each other!\n" + "Rebooting... Is your secret code...";

            return;
        }

        guess = Random.Range(min, max + 1); //min dahil, max dahil degil.

        attempts++;

        guessText.text = guess.ToString();
        attemptText.text = "Attempt: " + attempts;
        dialogueText.text = "Is your secret code...";
    }
}
