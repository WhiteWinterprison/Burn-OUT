using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JXR.Utils;

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
    public GameObject continueBtn;
    public GameObject startTutorial;
    public GameObject startGame;
    public Text DebugStatesExplained;
    public Text QueCounter;
    public MenuSlider slideMenu;


    public int wieIchBockHab = 29;


    // _______________________referenzen_____________________________________________________________________

 [HideInInspector] public LManager levelInfo;
 public GameObject cursorStart;
    public GameObject dialogueQueue;
    public DialogueManager queueInfo;
    public IntReference Score;
    public PCManager collisionManagereee;


    // _______________________GameLogik_____________________________________________________________________

    [HideInInspector] public bool tutorialStarted = false;

    [HideInInspector] public bool gameStarted = false;

    [HideInInspector] public bool continuePress = false;

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


        GameObject Level = GameObject.Find("SceneManager");
        levelInfo = Level.GetComponent<LManager>();

        GameObject Player = GameObject.Find("PlayerCollisionManager");
        collisionManagereee = Player.GetComponent<PCManager>();

        GameObject Slider = GameObject.Find("SlideMenue");
        slideMenu = Slider.GetComponent<MenuSlider>();

        //GameObject CursorRef = GameObject.Find("SpawnCursor");
        //cursorStart = CursorRef.GetComponent<GameObject>();


        queueInfo = dialogueQueue.GetComponent<DialogueManager>();

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
        continuePress = true;
    }

    public void startCoolTutorial()
    {
        tutorialStarted = true;
    }

    public void startCoolGame()
    {
        gameStarted = true;
    }

    public void DialogueCount()
    {
        wieIchBockHab -= 1;
        
    }
}
