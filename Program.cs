using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chucks_Game_Namespace;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //create game states
            CGameState currentState = new CGameState();
            CGameState lastState = new CGameState();
            CGameState nextState = new CGameState();
            CGameState introState = new CGameStateIntro();
            CGameState playState = new CGameStatePlay();
            CGameState exitState = new CGameStateExitProgram();
            CGameState helpState = new CGameStateHelp();
            CGameState historyState = new CGameStateHistory();
            CGameState mainState = new CGameStateMain();
            CGameState quitState = new CGameStateQuit();
            CGameState setupState = new CGameStateSetup();

            //initialize game states
            introState.InitializeState();
            playState.InitializeState();
            exitState.InitializeState();
            quitState.InitializeState();
            helpState.InitializeState();
            historyState.InitializeState();
            mainState.InitializeState();
            setupState.InitializeState();

            //map transition events to game states
            introState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_INTRO_TO_MAIN, mainState);
            mainState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_MAIN_TO_QUIT, quitState);
            mainState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_HELP, helpState);
            mainState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_HISTORY, historyState);
            mainState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_PLAY, playState);
            mainState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_SETUP, setupState);
            helpState.AddTransitionEvent((int)CGameState.STATE_EVENTS.RETURN_TO_MAIN, mainState);
            historyState.AddTransitionEvent((int)CGameState.STATE_EVENTS.RETURN_TO_MAIN, mainState);
            playState.AddTransitionEvent((int)CGameState.STATE_EVENTS.RETURN_TO_MAIN, mainState);
            setupState.AddTransitionEvent((int)CGameState.STATE_EVENTS.RETURN_TO_MAIN, mainState);
            quitState.AddTransitionEvent((int)CGameState.STATE_EVENTS.GO_QUIT_TO_EXIT, exitState);

            //game begins with intro
            currentState = introState;
            currentState.Draw();
            bool bRunning = true;
            while (bRunning)
            {                
                lastState = currentState;
                
                //update game data
                nextState = currentState.Update();

                //a game state change has occurred, do housekeeping
                if (nextState != lastState)
                {
                    lastState.ExitState();
                    currentState = nextState;
                    currentState.EnterState();
                }
                //no state change..do nothing
                else
                {
                }

                currentState.Draw();

                if (currentState == exitState)
                {
                    bRunning = false;
                    break;

                }
            }
            
            //terminate states
            introState.TerminateState();
            playState.TerminateState();
            exitState.TerminateState();
            quitState.TerminateState();
            helpState.TerminateState();
            historyState.TerminateState();
            mainState.TerminateState();
            setupState.TerminateState();
        }
    }
}
