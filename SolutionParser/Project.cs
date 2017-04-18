using System;

namespace SolutionEdit
{
    public class Project
    {
        public ProjectType Type { get; }
        public string Name { get; }
        public string Location { get; }
        public Guid ProjectGuid { get; }

        public Project(System.IO.TextReader inStream)
        {
            // Load project from text
            Type = ProjectType.Project;
            Name = "TestProject";
            Location = "C:\\Test\\Test.csproj";
            ProjectGuid = Guid.NewGuid();
        }

        private Project(ProjectType type, string name, string location, Guid projectGuid)
        {
            Type = type;
            Name = name;
            Location = location;
            ProjectGuid = projectGuid;
        }
            
        public static Project NewDirectoryProject(string directoryName) =>
            new Project(ProjectType.Directory, directoryName, directoryName, Guid.NewGuid());

        public void Write(System.IO.TextWriter outStream)
        {
            outStream.WriteLine($"Project(\"{Type.ToProjectGuidString()}\") = \"{Name}\", \"{Location}\", \"{ProjectGuid.ToProjectGuidString()}\"");
            outStream.WriteLine("EndProject");
        }
    }
}