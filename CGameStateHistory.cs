using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chucks_Game_Namespace
{
    class CGameStateHistory : CGameState
    {

        private List<TRANSITION_EVENT> te;

        public CGameStateHistory()
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
            ConsoleKeyInfo cki;
            int myEvent = (int)CGameState.STATE_EVENTS.NO_EVENT;

            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.D2)
            {
                myEvent = (int)CGameState.STATE_EVENTS.RETURN_TO_MAIN;
            }
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
            Console.WriteLine("History State");
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
