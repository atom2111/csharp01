using System;
using System.Collections.Generic;

namespace oop_lessons
{
    public enum Gender
    {
        Male,
        Female
    }

    public class FamilyMember
    {
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public List<FamilyMember> Siblings { get; } = new List<FamilyMember>();
        public FamilyMember Spouse { get; set; } // Ссылка на супруга/супругу

        public void ShowParents()
        {
            if (Mother != null)
                Console.WriteLine($"Mother: {Mother.Name}");
            if (Father != null)
                Console.WriteLine($"Father: {Father.Name}");
        }

        public void ShowChildren()
        {
            Console.WriteLine($"Children of {Name}:");
            if (this is AdultFamilyMember adult)
            {
                if (adult.Children != null)
                {
                    foreach (var child in adult.Children)
                    {
                        Console.WriteLine(child.Name);
                    }
                }
            }
        }

        public void ShowSiblings()
        {
            Console.WriteLine($"Siblings of {Name}:");
            foreach (var sibling in Siblings)
            {
                Console.WriteLine(sibling.Name);
            }
        }

        public void ShowSpouse()
        {
            if (Spouse != null)
            {
                string relationship = Sex == Gender.Male ? "Wife" : "Husband";
                Console.WriteLine($"{relationship}: {Spouse.Name}");
            }
        }

        public void ShowGrandparents()
        {
            Console.WriteLine($"Grandparents of {Name}:");
            if (Mother != null && Mother.Mother != null)
                Console.WriteLine($"Maternal Grandmother: {Mother.Mother.Name}");
            if (Mother != null && Mother.Father != null)
                Console.WriteLine($"Maternal Grandfather: {Mother.Father.Name}");
            if (Father != null && Father.Mother != null)
                Console.WriteLine($"Paternal Grandmother: {Father.Mother.Name}");
            if (Father != null && Father.Father != null)
                Console.WriteLine($"Paternal Grandfather: {Father.Father.Name}");
        }

        // Метод для поиска самого старшего члена семьи
        public FamilyMember FindOldestFamilyMember()
        {
            FamilyMember oldest = this;

            if (Mother != null)
            {
                var motherOldest = Mother.FindOldestFamilyMember();
                if (motherOldest != null && motherOldest.Name != oldest.Name)
                {
                    if (motherOldest.Name.CompareTo(oldest.Name) < 0)
                    {
                        oldest = motherOldest;
                    }
                }
            }

            if (Father != null)
            {
                var fatherOldest = Father.FindOldestFamilyMember();
                if (fatherOldest != null && fatherOldest.Name != oldest.Name)
                {
                    if (fatherOldest.Name.CompareTo(oldest.Name) < 0)
                    {
                        oldest = fatherOldest;
                    }
                }
            }

            return oldest;
        }

        // Метод для вывода генеалогического дерева
        public void ShowGenealogicalTree()
        {
            var oldest = FindOldestFamilyMember();
            Console.WriteLine($"Genealogical Tree of {oldest.Name}:");
            Console.WriteLine("-------------------------------------");
            ShowGenealogicalTreeRecursive(oldest, 0);
        }

        // Рекурсивный метод для вывода генеалогического дерева
        private void ShowGenealogicalTreeRecursive(FamilyMember member, int depth)
        {
            Console.Write(new string(' ', depth * 4));
            if (depth > 0)
            {
                Console.Write(member.Mother != null ? "├──" : "└──");
            }
            Console.WriteLine(member.Name);

            if (member.Mother != null)
                ShowGenealogicalTreeRecursive(member.Mother, depth + 1);
            if (member.Father != null)
                ShowGenealogicalTreeRecursive(member.Father, depth + 1);
        }
    }

    public class AdultFamilyMember : FamilyMember
    {
        public FamilyMember[] Children { get; set; }
    }
}
