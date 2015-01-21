using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksForDevelopers
{
	//class Program
	//{
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



	
}
