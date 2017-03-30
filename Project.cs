using System;

namespace SolutionEdit
{
    public class Project
    {
        private ProjectType type;
        private string name;
        private string location;
        private Guid projectGuid;

        public Project(System.IO.TextReader inStream)
        {
            // Load project from text
            type = ProjectType.Project;
            name = "TestProject";
            location = "C:\\Test\\Test.csproj";
            projectGuid = Guid.NewGuid();
        }

        public void Write(System.IO.TextWriter outStream)
        {
            outStream.WriteLine($"Project(\"{type.ToProjectGuidString()}\") = \"{name}\", \"{location}\", \"{projectGuid.ToProjectGuidString()}\"");
            outStream.WriteLine("EndProject");
        }
    }
}