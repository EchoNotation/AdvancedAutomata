using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public enum Triggers
{
    LISTEN,
    MATERIAL_NEARBY,
    ALWAYS,
    NEVER,
}

public enum Actions
{
    NONE,
    COLLECT_RESOURCE,
    DELIVER_RESOURCE,
    MOVE,
    BROADCAST,
}

public enum Values
{
    ZERO,
    HQLOC,
    HOME,
    HERE
}

public class UnitLogic : MonoBehaviour
{
    public class LogicCard
    {
        //The condition which needs to be met for this logic card to run.
        Triggers trigger;
        //What actions will be taken if that condition is met.
        List<Actions> actions;
        //Determines whether this card can be run in addition to other cards.
        bool instant;

        public LogicCard()
        {
            trigger = Triggers.NEVER;
            actions = new List<Actions>();
            actions.Add(Actions.NONE);
            instant = false;
        }

        public void setTrigger(Triggers newTrigger)
        {
            trigger = newTrigger;
        }

        public Triggers getTrigger()
        {
            return trigger;
        }

        public void insertAction(int index, Actions action)
        {
            actions.Insert(index, action);
        }

        public void removeAction(int index)
        {
            actions.RemoveAt(index);
        }

        public List<Actions> getActions()
        {
            return actions;
        }

        public int getNumberOfActions()
        {
            return actions.Count;
        }

        public void setInstant(bool newInst)
        {
            instant = newInst;
        }

        public bool isInstant()
        {
            return instant;
        }
    }

    //This list contains all of the logic for this particular unit.
    private List<LogicCard> cards;
    //How long between logic state refreshes.
    private int refreshRate = 5000;
    private System.Diagnostics.Stopwatch timer;
    private long initialTime;

    private int coalDepositsNearby, ironDepositsNearby, electrumDepositsNearby;

    // Start is called before the first frame update
    void Start()
    {
        coalDepositsNearby = 0;
        ironDepositsNearby = 0;
        electrumDepositsNearby = 0;

        cards = new List<LogicCard>();
        timer = new System.Diagnostics.Stopwatch();

        timer.Start();
        initialTime = timer.ElapsedMilliseconds;

        LogicCard lc1 = new LogicCard();
        lc1.setTrigger(Triggers.MATERIAL_NEARBY);
        lc1.insertAction(0, Actions.BROADCAST);
        lc1.setInstant(true);
        LogicCard lc2 = new LogicCard();
        lc2.setTrigger(Triggers.NEVER);
        lc2.insertAction(0, Actions.MOVE);
        lc2.setInstant(false);
        cards.Add(lc1);
        cards.Add(lc2);
    }

    // Update is called once per frame
    void Update()
    {
        //Waits until the correct time has passed before updating the logic states.
        if(timer.ElapsedMilliseconds - initialTime >= refreshRate)
        {
            //Make sure the list is sorted according to increasing priority before running this...
            refreshLogic();
            initialTime = timer.ElapsedMilliseconds;
        }
    }

    private void refreshLogic()
    {
        foreach(LogicCard lc in cards)
        {
            bool conditionMet = false;

            switch(lc.getTrigger())
            {
                case Triggers.ALWAYS:
                    conditionMet = true;
                    break;
                case Triggers.NEVER:
                    conditionMet = false;
                    break;
                case Triggers.MATERIAL_NEARBY:
                    //Logic not final, this particular trigger should specify which material to detect? Maybe?
                    conditionMet = coalNearby() | ironNearby() | electrumNearby();
                    break;
                case Triggers.LISTEN:
                    //This case has more sophisticated logic than described here.
                    conditionMet = false;
                    break;
                default:
                    Debug.Log("Invalid trigger found in refreshLogic! Did you forget to add an entry in the Triggers enum? Trigger: " + lc.getTrigger().ToString());
                    break;
            }

            //Try the next logic card if this condition was not met.
            if(!conditionMet) continue;

            //Otherwise run the appropriate actions...
            List<Actions> actList = lc.getActions();

            foreach(Actions act in actList)
            {
                switch(act)
                {
                    case Actions.NONE:
                        break;
                    case Actions.BROADCAST:
                        Debug.Log("Broadcasting!");
                        break;
                    case Actions.COLLECT_RESOURCE:
                        break;
                    case Actions.DELIVER_RESOURCE:
                        break;
                    case Actions.MOVE:
                        Debug.Log("Moving!");
                        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 1, this.gameObject.transform.position.y, 0);
                        break;
                    default:
                        Debug.Log("Invalid action encountered in refreshLogic! Did you forget to add an entry in the Actions enum? Action: " + act.ToString());
                        break;
                }
            }

            //Check if any more logic needs to be checked.
            if (lc.isInstant()) continue;
            //Actions have been executed, and the executed card was not instant, so no further logic needs to be refreshed.
            return;
        }
    }

    public void newMineralInRange(MineralDeposit.Minerals type)
    {
        switch(type)
        {
            case MineralDeposit.Minerals.COAL:
                coalDepositsNearby++;
                break;
            case MineralDeposit.Minerals.IRON:
                ironDepositsNearby++;
                break;
            case MineralDeposit.Minerals.ELECTRUM:
                electrumDepositsNearby++;
                break;
            default:
                Debug.Log("Invalid mineral type in UnitLogic! Did you forget to add a case for a new mineral? Mineral: " + type.ToString());
                break;
        }
    }

    public void mineralLeftRange(MineralDeposit.Minerals type)
    {
        switch (type)
        {
            case MineralDeposit.Minerals.COAL:
                coalDepositsNearby--;
                break;
            case MineralDeposit.Minerals.IRON:
                ironDepositsNearby--;
                break;
            case MineralDeposit.Minerals.ELECTRUM:
                electrumDepositsNearby--;
                break;
            default:
                Debug.Log("Invalid mineral type in UnitLogic! Did you forget to add a case for a new mineral? Mineral: " + type.ToString());
                break;
        }
    }

    private bool coalNearby()
    {
        return coalDepositsNearby > 0;
    }

    private bool ironNearby()
    {
        return ironDepositsNearby > 0;
    }

    private bool electrumNearby()
    {
        return electrumDepositsNearby > 0;
    }
}


