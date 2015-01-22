using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksForDevelopers
{
	class Program
	{
		//================================================OOP StaticFieldOfGeneric ====================================================================

		//	static void Main()
		//	{
		//		Foo<int>.Bar++;
		//		Console.WriteLine(Foo<double>.Bar);
		//	}

		//class Foo<T>
		//{
		//	public static int Bar;
		//}

		//Объяснение

		//Классы Foo<int> и Foo<double> — это два разных класса, у каждого из них собственное статитческое поле Bar.

		//=======================================================LINK EnumerableToArray =============================================================

		//	public static string GetString(string s)
		//	{
		//		Console.WriteLine("GetString: " + s);
		//		return s;
		//	}
		//	public static IEnumerable<string> GetStringEnumerable()
		//	{
		//		yield return GetString("Foo");
		//		yield return GetString("Bar");
		//	}
		//	public static string[] EnumerableToArray()
		//	{
		//		var strings = GetStringEnumerable();
		//		foreach (var s in strings)
		//			Console.WriteLine("EnumerableToArray: " + s);
		//		return strings.ToArray();
		//	}
		//	static void Main()
		//	{
		//		EnumerableToArray();
		//	}
		//Ответ

		//GetString: Foo
		//EnumerableToArray: Foo
		//GetString: Bar
		//EnumerableToArray: Bar
		//GetString: Foo
		//GetString: Bar
		//Объяснение

		//LINQ-запросы являются ленивыми, т.е. реализуют отложенное исполнение. Это означает, что если сфомировать запрос и не вызвать для него явно метод вроде ToArray() или ToList(), то выполнение запроса будет отложено до того момента, пока мы явно не затребуем результатов. Таким образом, строка

		//var strings = GetStringEnumerable();
		//не выведет на консоль ничего. Далее, в цикле

		//foreach (var s in strings)
		//  Console.WriteLine("EnumerableToArray: " + s);
		//произойдёт выполнение запроса. Причём, сначала выполнится первый yield (вывод строки GetString: Foo), а после него выполнится тело цикла для первого значения перечисления (вывод строки EnumerableToArray: Foo). Далее, цикл foreach запросит второй элемент перечисления, будет выполнен второй yield (вывод строки GetString: Bar) и второй раз будет выполнено тело цикла для полученного элемента (вывод строки EnumerableToArray: Bar).

		//Далее следует строка

		//return strings.ToArray();
		//Тут можно наблюдать повторное исполнение LINQ-запроса, а значит мы вновь произойдёт вывод строк GetString: Foo и GetString: Bar.

		//=======================================================LINK ClosureAndForeach =============================================================

		//static void Main()
		//{
		//	var actions = new List<Action>();
		//	foreach (var i in Enumerable.Range(1, 3))
		//	  actions.Add(() => Console.WriteLine(i));
		//	foreach (var action in actions)
		//	  action();
		//}

		// В новых версиях компиляторов: 1 2 3.

		//		Объяснение

		//В старых версиях компиляторов приведённый код превращался в следующую конструкцию:

		//public void Run()
		//{
		//  var actions = new List<Action>();
		//  DisplayClass c1 = new DisplayClass();
		//  foreach (int i in Enumerable.Range(1, 3))
		//  {
		//	с1.i = i;
		//	list.Add(c1.Action);
		//  }
		//  foreach (Action action in list)
		//	action();
		//}

		//private sealed class DisplayClass
		//{
		//  public int i;

		//  public void Action()
		//  {
		//	Console.WriteLine(i);
		//  }
		//}
		//Таким образом, все три элемента списка на самом деле являются одним и тем же делегатом, поэтому в консоли мы увидим три одинаковых значения, равных последнему значению i.

		//В современных версиях компиляторов произошли изменения, новый вариант кода:

		//public void Run()
		//{
		//  var actions = new List<Action>();
		//  foreach (int i in Enumerable.Range(1, 3))
		//  {
		//	DisplayClass c1 = new DisplayClass();
		//	с1.i = i;
		//	list.Add(c1.Action);
		//  }
		//  foreach (Action action in list)
		//	action();
		//}

		//private sealed class DisplayClass
		//{
		//  public int i;

		//  public void Action()
		//  {
		//	Console.WriteLine(i);
		//  }
		//}
		//Теперь каждый элемент списка ссылается на собственный делегат, так что все полученные значения будут разными.

		//=======================================================LINK ClosureAndFor =============================================================

		//static void Main()
		//{
		//	var actions = new List<Action>();
		//	for (int i = 0; i < 3; i++)
		//		actions.Add(() => Console.WriteLine(i));
		//	foreach (var action in actions)
		//		action();
		//}

		//=======================================================LINK QueryAfterRemove =============================================================

		//static void Main()
		//{
		//	var list = new List<string> { "Foo", "Bar", "Baz" };
		//	var query = list.Where(c => c.StartsWith("B"));
		//	list.Remove("Bar");
		//	Console.WriteLine(query.Count());
		//}

		//При вызове list.Where(c => c.StartsWith("B")) запрос будет только построен, но не выполнен. Реальное выполнение начнётся в момент вызов query.Count(). К этому времени значение list будет { "Foo", "Baz" }, а значит, будет найден только один элемент, начинающийся с буквы 'B'.


	}
}
