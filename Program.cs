using System;

namespace SolutionEdit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var projType = ProjectType.Project;
            var typeGuid = projType.ToGuid();
            var andBack = typeGuid.ToProjectType();
            Console.WriteLine($"Hello {projType} is {typeGuid.ToProjectGuidString()} !");
            Console.WriteLine($"Hello {andBack} is {andBack.ToProjectGuidString()} !");
        }
    }
}
