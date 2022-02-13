using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TManager : MonoBehaviour
{
    TState currentState;

    public StartTutorialState tutorialState = new StartTutorialState();
    public AbyssTutorialState abyssState = new AbyssTutorialState();
    public LeafTutorialState leafState = new LeafTutorialState();
    public MovementTutorial movementState = new MovementTutorial();
    public MarvinTutorial marvinONEState = new MarvinTutorial();
    public Marvin2Tutorial marvinTWOState = new Marvin2Tutorial();
    public StartGameState startGameState = new StartGameState();

    // _______________________UI_____________________________________________________________________

    public GameObject playerInfo;
    public GameObject marvinMenu;
    public GameObject stoneSystem;
    public GameObject[] marvinExpr;
    public Button continueBtn;
    public Button startTutorial;
    public Button startGame;

    // _______________________UI_____________________________________________________________________

    // Start is called before the first frame update
    void Start()
    {
        currentState = tutorialState;
        currentState.enter(this);

        //_________________referenzen_______________________________________

        Button btnContinue = continueBtn.GetComponent<Button>();
        btnContinue.onClick.AddListener(ContinueText);

        Button btnTutorial = startTutorial.GetComponent<Button>();
        btnTutorial.onClick.AddListener(startCoolTutorial);

        Button btnstartGame = startGame.GetComponent<Button>();
        btnstartGame.onClick.AddListener(startCoolGame);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.react(this);
    }

    public void SwitchState(TState nextState)
    {
        currentState.exit(this);
        currentState = nextState;
        nextState.enter(this);
    }

    //_________________gameLogic_______________________________________

    public void ContinueText()
    {

    }

    public void startCoolTutorial()
    {

    }

    public void startCoolGame()
    {

    }
}
