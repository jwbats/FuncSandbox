using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncSandbox
{
	class Program
	{

		delegate void TickHandler();
		static event TickHandler Tick;

		private static void EventOwner()
		{
			Console.WriteLine("EventOwner doing some stuff.");

			if (Tick != null)
			{
				Tick();
			}
		}


		private static void EventListener()
		{
			Console.WriteLine("EventListener doing some stuff.");
		}


		delegate void Printer(string str);

		delegate int DelegateSquared(int i);


		private static void ExecuteAction(Action action)
		{
			action();
		}


		private static bool ExecuteFunc(Func<int, int, bool> func)
		{
			return func(1, 2);
		}


		private static void NamedMethodPrinter2(string str)
		{
			Console.WriteLine(str);
		}


		private static void SomeFunction1()
		{
			Console.WriteLine(3);
		}


		private static void SomeFunction2(int i)
		{
			Console.WriteLine(i);
		}


		static void Main(string[] args)
		{
			Func<int> GiveInt1 = () => { return 1; };
			Console.WriteLine(GiveInt1());

			Action GiveInt2 = () => { Console.WriteLine(2); };
			GiveInt2();
			ExecuteAction(GiveInt2);

			Predicate<int> IsEven1 = x => (x % 2 == 0);
			Console.WriteLine(IsEven1(2));

			Func<int, bool> IsEven2 = x => (x % 2 == 0);
			Console.WriteLine(IsEven2(2));

			Func<int, int, bool> AreEqual = (x, y) => x == y;
			Console.WriteLine(AreEqual(1, 1));

			Console.WriteLine(ExecuteFunc(AreEqual));

			Printer printer1 = delegate(string str)	{ Console.WriteLine(str); };
			printer1("printer1");

			Printer printer2 = NamedMethodPrinter2;
			printer2("printer2");

			Printer printer3 = (s) => { Console.WriteLine(s); };
			printer3("printer3");

			DelegateSquared delegateSquared1 = delegate(int i) { return i * i; };
			DelegateSquared delegateSquared2 = x => (x * x);
			
			Action intAction1 = SomeFunction1;
			intAction1();
			
			Action<int> intAction2 = SomeFunction2;
			intAction2(3);
			
			Console.WriteLine(ExecuteFunc(
				(x, y) => x == y	
			));

			Console.WriteLine(ExecuteFunc(
				delegate(int i, int j) { return i == j; }
			));

			TickHandler myTickHandler = new TickHandler(EventListener);

			Tick += myTickHandler;

			EventOwner();

			Tick -= myTickHandler;

			EventOwner();

			Console.ReadKey();
		}
	}
}
