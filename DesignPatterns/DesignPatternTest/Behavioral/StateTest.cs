using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State.NotPattern;
using State.State;

namespace State.Test
{
	[TestClass]
	public class StateTest
	{
		private const string CATEGORY = "StatePattern";
		private const string CATEGORY_NOT_PATTERN = "NotStatePattern";

		[TestMethod, TestCategory(CATEGORY)]
		public void StatePattern_NewStateTest()
		{
		   ExecuteStateTest(() => new ProcessState(),
		                    StateName.NEW,
                          StateName.EDITED,
		                    StateName.NEW,
		                    StateName.NEW);
		}

		[TestMethod, TestCategory(CATEGORY)]
		public void StatePattern_EditedStateTest()
		{
		   ExecuteStateTest((() => new ProcessState(new EditedState())),
		                    StateName.EDITED,
		                    StateName.EDITED,
		                    StateName.SAVED,
		                    StateName.NEW);
		}

	   [TestMethod, TestCategory(CATEGORY)]
	   public void StatePattern_SavedStateTest()
      {
         ExecuteStateTest((() => new ProcessState(new SavedState())),
                          StateName.SAVED,
                          StateName.EDITED,
                          StateName.ACCEPTED,
                          StateName.NEW);

	      ExecuteSingleSaveStateTest(() => new ProcessState(new SavedState(false)), 
                                    StateName.ERROR);
	   }

	   [TestMethod, TestCategory(CATEGORY)]
	   public void StatePattern_AcceptedStateTest()
      {
         ExecuteStateTest((() => new ProcessState(new AcceptedState())),
                          StateName.ACCEPTED,
                          StateName.EDITED,
                          StateName.ACCEPTED,
                          StateName.ACCEPTED);
	   }

	   [TestMethod, TestCategory(CATEGORY)]
	   public void StatePattern_WalidationErrorStateTest()
      {
         ExecuteStateTest((() => new ProcessState(new WalidationErrorState())),
                          StateName.ERROR,
                          StateName.ERROR,
                          StateName.SAVED,
                          StateName.NEW);
	   }


      [TestMethod, TestCategory(CATEGORY_NOT_PATTERN)]
      public void NotStatePattern_NewStateTest()
      {
         ExecuteStateTest(() => new SimpleProcessState(),
                          StateName.NEW,
                          StateName.EDITED,
                          StateName.NEW,
                          StateName.NEW);
      }

      [TestMethod, TestCategory(CATEGORY_NOT_PATTERN)]
      public void NotStatePattern_EditedStateTest()
      {
         ExecuteStateTest((() => new SimpleProcessState(SimpleProcessState.EDITED)),
                          StateName.EDITED,
                          StateName.EDITED,
                          StateName.SAVED,
                          StateName.NEW);
      }

      [TestMethod, TestCategory(CATEGORY_NOT_PATTERN)]
      public void NotStatePattern_SavedStateTest()
      {
         ExecuteStateTest((() => new SimpleProcessState(SimpleProcessState.SAVED)),
                          StateName.SAVED,
                          StateName.EDITED,
                          StateName.ACCEPTED,
                          StateName.NEW);

         ExecuteSingleSaveStateTest(() => new SimpleProcessState(SimpleProcessState.SAVED){ValidationResult = false},
                                    StateName.ERROR);
      }

      [TestMethod, TestCategory(CATEGORY_NOT_PATTERN)]
      public void NotStatePattern_AcceptedStateTest()
      {
         ExecuteStateTest(() => new SimpleProcessState(SimpleProcessState.ACCEPTED),
                          StateName.ACCEPTED,
                          StateName.EDITED,
                          StateName.ACCEPTED,
                          StateName.ACCEPTED);
      }

      [TestMethod, TestCategory(CATEGORY_NOT_PATTERN)]
      public void NotStatePattern_WalidationErrorStateTest()
      {
         ExecuteStateTest((() => new SimpleProcessState(SimpleProcessState.ERROR)),
                          StateName.ERROR,
                          StateName.ERROR,
                          StateName.SAVED,
                          StateName.NEW);
      }

      /// <summary>
      /// 1. Stan Startowy
      /// 2. Edit()
      /// 3. Save()
      /// 4. Clear()
      /// </summary>
      /// <param name="a_prepereProcessStateMethod"></param>
      /// <param name="a_arrExpectedState"></param>
	   public void ExecuteStateTest(Func<IProcessState> a_prepereProcessStateMethod, params string[] a_arrExpectedState)
		{
			IProcessState processState = a_prepereProcessStateMethod();
			Console.WriteLine(processState.CurrentState);
			Assert.AreEqual(processState.CurrentState, a_arrExpectedState[0]);

			processState.Edit();
			Console.WriteLine(processState.CurrentState);
			Assert.AreEqual(processState.CurrentState, a_arrExpectedState[1]);

			processState = a_prepereProcessStateMethod();

			processState.Save();
			Console.WriteLine(processState.CurrentState);
			Assert.AreEqual(processState.CurrentState, a_arrExpectedState[2]);

			processState = a_prepereProcessStateMethod();

			processState.Clear();
			Console.WriteLine(processState.CurrentState);
         Assert.AreEqual(processState.CurrentState, a_arrExpectedState[3]);
		}

	   public void ExecuteSingleSaveStateTest(Func<IProcessState> a_prepereProcessStateMethod, string a_expectedState)
      {
         IProcessState processState = a_prepereProcessStateMethod();

         processState.Save();
         Console.WriteLine(processState.CurrentState);
         Assert.AreEqual(processState.CurrentState, a_expectedState);
      }
	}
}
