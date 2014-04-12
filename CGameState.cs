using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chucks_Game_Namespace
{
    
    public struct TRANSITION_EVENT
    {
        public int eventNumber;
        public CGameState gameState;
    }

    public class CGameState
    {
        public enum STATE_EVENTS : int
        {
            NO_EVENT = 0,
            GO_INTRO_TO_MAIN,
            GO_MAIN_TO_QUIT,
            GO_QUIT_TO_EXIT,
            GO_HELP,
            GO_HISTORY,
            GO_PLAY,
            GO_SETUP,
            RETURN_TO_MAIN
        };

        public CGameState()
        {

        }

        virtual public void InitializeState() { return; }
        virtual public void TerminateState() { return; }
        virtual public void EnterState() { return; }
        virtual public void ExitState() { return; }
        virtual public CGameState Update() { return this; }
        virtual public void Draw() { return; }
        virtual public void AddTransitionEvent(int eventNumber, CGameState gameState) { return; }

   }

}
