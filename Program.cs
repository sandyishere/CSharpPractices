using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPractices
{
    public enum Mood {
        sulky,
        moody,
        happy,
        sad,
        rageMode
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. Strings Manipulation
            String[] stringsList = new String[] {"alan","betty","copper","danny","ellen","alex"};

            int index = 0;
            foreach(String s in stringsList)
            {
                stringsList[index]=s.ToUpper();
                index++;
            }

            String[] stringsList2 = (String[]) stringsList.Clone();

            List<String> stringsList3 = stringsList2.ToList();

            Action<String> printElement = s => Console.Write(s+" ");

            Func<String, Boolean> checkFirstLetter = s => s.ToLower().StartsWith("d");
            //Note: Func bool (predicate)

            stringsList3.ForEach(s => printElement(checkFirstLetter(s).ToString()));
            Console.WriteLine();

            stringsList3.ForEach(s => printElement(String.Concat(s, "2")));
            Console.WriteLine();

            stringsList3.ForEach(s => printElement(s));   //Note: above lambda preserves stringsList3
            Console.WriteLine();

            stringsList3.ForEach(s => printElement(s.Equals("BETTY").ToString()));
            Console.WriteLine();

            stringsList3.ForEach(s => printElement(s.ToLower().Replace('o','a')));
            Console.WriteLine();

            stringsList3.ForEach(s => printElement(s.Remove(0,2)));
            Console.WriteLine();

            List<String> stringList4 = stringsList3.ElementAt(0).Split('A').ToList();
            stringList4.ForEach(s => printElement(s));

            Console.WriteLine("length of string at index 0 is: "+stringsList3.ElementAt(0).Length);

            /*result: 
            False False False True False False
            ALAN2 BETTY2 COPPER2 DANNY2 ELLEN2 ALEX2
            ALAN BETTY COPPER DANNY ELLEN ALEX
            False True False False False False
            alan betty capper danny ellen alex
            AN TTY PPER NNY LEN EX
             L N length of string at index 0 is: 4 */


            //2. Formatting and Math class

            //casting
            string x1 = "2";
            double z1 = double.Parse(x1);
            int y1 = Int32.Parse(x1);

            int y = 2;
            double z = Convert.ToDouble(y);
            string x = Convert.ToString(y);

            Console.WriteLine("converted values: {0},{1},{2},{3}",z1,y1,z,x);
            Console.WriteLine("formatted values: {0:0.0},{1:0.00},{2:0.#},{3}", z1, y1, z, x);
            //result: formatted values: 2.0,2.00,2,2
            Console.WriteLine("converted values: ${0:0.00}", 55.5); //result: $55.50

            //Math
            //max,min,pow,round,abs,floor,ceiling

            Console.WriteLine(Math.Round(1.77)); //result: 2
            Console.WriteLine(Math.Round(1.47)); //result: 1
            Console.WriteLine(Math.Floor(1.77)); //result: 1
            Console.WriteLine(Math.Ceiling(1.77)); //result: 2
            Console.WriteLine(Math.Min(1,7)); //result: 1
            Console.WriteLine(Math.Abs(-1.5)); //result: 1.5
            Console.WriteLine(Math.Pow(2,3)); //result: 8
            Console.WriteLine(9%2); //result: 1


            //3. Switch statements and Enums (to add enums associated ints)
            //note: enum variable can be used as a data type, 
            //enum has to be intialised,
            //enum has to be explicitly type casted 

            Mood mood = new Mood(); 

            switch (mood) {
                case Mood.happy:
                    break;
                case Mood.moody:
                    break;
                case Mood.rageMode:
                    break;
                case Mood.sad:
                    break;
                case Mood.sulky:
                    break;
                default:
                    break;
            }

            int moodIndex = (int)Mood.happy;
            Console.WriteLine("mood index is: " + moodIndex); //result: mood index is 2


            //4. Collections (Regular, Generic)
            //Regular - ArrayList, Hashtable (todo)
            List<String> newList = new List<String>() {
                "abc","abc2","abc3"
            };

            Console.WriteLine(newList.Count()); 
            printList(newList);

            Console.WriteLine(newList.Contains("abc4"));

            Console.WriteLine(newList.IndexOf("abc3"));

            newList.Insert(1,"abc1");
            printList(newList);

            newList.Remove("abc");
            printList(newList);

            newList.RemoveAt(1);
            printList(newList);

            newList.Reverse();
            printList(newList);

            newList.Sort();
            printList(newList);

            newList.ToArray();
            Console.WriteLine("array is: "+String.Join(",",newList));

            List<String> stringList = new List<string>() {"1","2","3"};
            List<int> intList = stringList.Select(int.Parse).ToList(); //convert type of list
            printList(intList);

            newList.Clear();

            //Generic - Dictionary, List, Queue, Stack, SortedList
            //(todo)


            //5. Functional Programming 
            List<Horse> horseList = new List<Horse>() {
                new Horse("Horse E","nayyy5",new Owner("Owner 1")),
                new Horse("Horse B","nayyy2",new Owner("Owner 1")),
                new Horse("Horse A","nayyy2",new Owner("Owner 3")),
                new Horse("Horse C","nayyy3",new Owner("Owner 2")),
                new Horse("Horse D","nayyy4",new Owner("Owner 1")),
                new Horse("Horse A2","nayyy1",new Owner("Owner 3"))
            };

            printList(horseList.GroupBy(h => h.owner.name, h => h.sound).Select(h => h.Key).ToList());
            //result: Owner 1,Owner 3,Owner 2
            printList(horseList.OrderBy(h => h.sound).Select(h => h.sound).ToList());
            //result: nayyy1,nayyy2,nayyy2,nayyy3,nayyy4,nayyy5
            printList(horseList.OrderBy(h => h.name).ThenByDescending(h => h.sound).Select(h => h.name + "" + h.sound).ToList());
            //result: Horse Anayyy2,Horse A2nayyy1, Horse Bnayyy2,Horse Cnayyy3, Horse Dnayyy4,Horse Enayyy5
            printList(horseList.Take(2).Select(h=>h.name).ToList());
            //result: Horse E,Horse B
            printList(horseList.TakeWhile(h=>!h.name.EndsWith("B")).Select(h => h.name).ToList());
            //result: Horse E
            printList(horseList.Skip(4).Select(h => h.sound).ToList());
            //result: nayyy4,nayyy1
            printList(horseList.SkipWhile(h=>h.name.EndsWith("E")).Select(h=>h.sound).ToList());
            //result: nayyy2,nayyy2,nayyy3,nayyy4,nayyy1
            printList(horseList.ToDictionary(h => h.name, h => h.sound).ToList());
            //result: [Horse E, nayyy5],[Horse B, nayyy2],[Horse A, nayyy2],[Horse C, nayyy3],[Horse D, nayyy4],[Horse A2, nayyy1]
            

            //6. Others (exploring)
            int? ans1 = 1;
            int? ans2 = null;

            int reply1 = ans1 ?? 0;
            int reply2 = ans2 ?? 0;

            Console.WriteLine("testing operator ??: reply 1 is... {0} reply 2 is... {1}",reply1,reply2);
            //result: ...1 ...0

        }

        static void printList<T> (List<T> list) {
            Console.WriteLine(String.Join(",",list));
        }
    }
}
