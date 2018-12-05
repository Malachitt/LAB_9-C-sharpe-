using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp9
{
	class Program
	{
		//Делегаты
		delegate void Ataka(string message);
		delegate void Lechenie(string message);
		public delegate void Action<T>(T obj);
		delegate string DobSim(string x);
		delegate string Lower(string x);
		delegate string DeleteZapatie(string x);
		delegate string DeleteProbel(string x);
		delegate string Upper(string x);
		class Play
		{
			public int hp1;
			public event Ataka up1;		//Событие атаки
			public event Lechenie up2;	//Событие  лечения
			public Play(int hp)			//Конструктор
			{
				hp1 = hp;
				Console.WriteLine($"Первоначальное хп = {hp1}, дальнейшие действия  + :");
			}
			public void At(int hp)
			{
				if (up1 != null) up1($"Атакуем врага на : {hp} хп");
				hp1 -= hp;
				Console.WriteLine($"Оставшееся хп : {hp1}");
				//if (up2 != null) up2($"Оставшееся хп : {hp1}");
			}

			public void Le(int hp)
			{
				if (up2 != null) up2($"Лечим врага на : {hp} хп");
				hp1 += hp;
				Console.WriteLine($"Оставшееся хп : {hp1}");
			}
		}
			static void Main(string[] args)
		{

			Play play = new Play(50);
			play.up1 += Display;
			play.up2 += Display1;
			play.At(10);
			play.At(10);
			play.Le(15);


			Upper upper = x => x.ToUpper();								 //превращение в большие буквы
			Console.WriteLine(upper("превращение в большие буквы"));
			Lower lower = x => x.ToLower();                             //ПРЕВРАЩЕНИЕ В МАЛЕНЬКИЕ БУКВЫ
			Console.WriteLine(lower("ПРЕВРАЩЕНИЕ В МАЛЕНЬКИЕ БУКВЫ"));
			DeleteProbel deleteProbel = delegate (string x)
			{
				return x.Replace(" ", "");
			};
			Console.WriteLine(deleteProbel("     Удаление    в  стр оке   пробелов"));	//Удаление в строке пробелов
			DeleteZapatie deleteZapatie = x =>
			{
				return Regex.Replace(x, "[-.?!)(,:]", "");
			};																							//......
			Console.WriteLine(deleteZapatie("Удаление,,!:? --знаков препинания!"));
			DobSim dobSim = x => x + " --- дополнительные символы --- !?-,,";
			Console.WriteLine(dobSim("Добавляем символы "));

			string s2 = "Привет,,,! меня     зовут и, вот! БОЛьшИе   бу   кВЫ!!!!";

			Action<string> action = x =>					//Action
			{
				x = upper(x);
				x = lower(x);
				x = deleteProbel(x);
				x = deleteZapatie(x);
				x = dobSim(x);
				Console.WriteLine(x);
			};
			action(s2);

			Console.ReadKey();
		}
		static void Display(string message)
		{
			Console.WriteLine(message);

		}
		static void Display1(string message)
		{
			Console.WriteLine(message + "; ");
		}
	}
}
