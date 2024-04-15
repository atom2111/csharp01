using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создание членов семьи
            FamilyMember grandmother1 = new FamilyMember { Name = "Grandma1", Sex = Gender.Female };
            FamilyMember grandfather1 = new FamilyMember { Name = "Grandpa1", Sex = Gender.Male };
            FamilyMember grandmother2 = new FamilyMember { Name = "Grandma2", Sex = Gender.Female };
            FamilyMember grandfather2 = new FamilyMember { Name = "Grandpa2", Sex = Gender.Male };
            FamilyMember mother = new FamilyMember { Name = "Mother", Sex = Gender.Female, Mother = grandmother1, Father = grandfather1 };
            FamilyMember father = new FamilyMember { Name = "Father", Sex = Gender.Male, Mother = grandmother2, Father = grandfather2 };
            AdultFamilyMember child1 = new AdultFamilyMember { Name = "Child1", Sex = Gender.Male, Mother = mother, Father = father };
            AdultFamilyMember child2 = new AdultFamilyMember { Name = "Child2", Sex = Gender.Female, Mother = mother, Father = father };
            FamilyMember spouse = new FamilyMember { Name = "Spouse", Sex = Gender.Male }; // Пример супруга

            // Установка связей супругов
            mother.Spouse = father;
            father.Spouse = mother;

            // Установка детей для взрослых членов семьи
            mother.Siblings.Add(new FamilyMember { Name = "Aunt1", Sex = Gender.Female, Mother = grandmother1, Father = grandfather1 });
            mother.Siblings.Add(new FamilyMember { Name = "Aunt2", Sex = Gender.Female, Mother = grandmother1, Father = grandfather1 });
            father.Siblings.Add(new FamilyMember { Name = "Uncle1", Sex = Gender.Male, Mother = grandmother2, Father = grandfather2 });

            // Вывод информации о родственниках
            Console.WriteLine("Information about family members:");
            Console.WriteLine("---------------------------------");
            mother.ShowParents();
            father.ShowParents();
            child1.ShowChildren();
            child2.ShowChildren();
            child1.ShowSiblings();
            child2.ShowSiblings();
            mother.ShowSpouse(); // Вывод супруга/супруги
            child1.ShowGrandparents();
            child2.ShowGrandparents();

            // Получение ссылки на самого старшего члена семьи и вывод его генеалогического дерева
            FamilyMember oldest = mother.FindOldestFamilyMember();
            oldest.ShowGenealogicalTree();

            Console.ReadLine(); // Для предотвращения закрытия консоли сразу после вывода информации
        }

    }
}

