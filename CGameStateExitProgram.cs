using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chucks_Game_Namespace
{
    class CGameStateExitProgram : CGameState
    {

        private List<TRANSITION_EVENT> te;

        public CGameStateExitProgram()
        {

        }

        override public void InitializeState()
        {
            te = new List<TRANSITION_EVENT>();
            return;
        }
        override public void TerminateState()
        {
            return;
        }
        override public void EnterState()
        {
            return;
        }
        override public void ExitState()
        {
            return;
        }
        override public CGameState Update()
        {
            //ConsoleKeyInfo cki;
            int myEvent = (int)CGameState.STATE_EVENTS.GO_QUIT_TO_EXIT;

            try
            {
                foreach (TRANSITION_EVENT t in te)
                {
                    if (t.eventNumber == myEvent)
                        return t.gameState;
                }
            }
            catch
            {

            }

            return this;
        }
        override public void Draw()
        {
            Console.WriteLine("Exit State");
            return;
        }
        override public void AddTransitionEvent(int eventNumber, CGameState gameState)
        {

            TRANSITION_EVENT tempTE = new TRANSITION_EVENT();
            tempTE.eventNumber = eventNumber;
            tempTE.gameState = gameState;

            try
            {
                te.Add(tempTE);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Null Reference Exception");
            }

            return;
        }
    }
}
