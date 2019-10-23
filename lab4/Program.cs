using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string Str = Path.GetFullPath(args[0]); //Преобразуем относительный путь в абсолютный
                Assembly myFile = Assembly.LoadFile(Str);//Загружаем файл
                GetTypeList(myFile);//Процедура получения и вывода типов, отсортированных по пространству имен и по имени
                Console.ReadKey();
            }
            else
                Console.WriteLine("Ops");
        }

        static void GetTypeList(Assembly myFile)
        {
            Type[] ArrayOfType = myFile.GetTypes();//Извлечение всех типов
            List<Type> TypeList = new List<Type>(ArrayOfType);
            TypeList.Sort(MySort);//Сортировка по пространству имен и по имени
            
            foreach (Type t in TypeList)//Вывод типов
                Console.WriteLine(t);
        }
        static int MySort(Type FirstType, Type SecondType)
        {
            if ((FirstType != null) && (SecondType != null))
            {
                int a = FirstType.Namespace.CompareTo(SecondType.Namespace);
                if (a == 0)//Если пространство имен одинаковое, то сортируем по имени
                {
                    return FirstType.Name.CompareTo(SecondType.Name);
                }
                else return a;
            }
            throw new Exception();               
        }
    }
    class MyClass1 { }//Классы для проверки
    class MyClass2 { }
}
namespace abc//Пространство имен и его классы для проверки
{
    class MyClass4 { }
    class MyClass5 { }
    class MyClass3 { }
}
