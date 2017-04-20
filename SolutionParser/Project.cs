using System;

namespace SolutionEdit
{
    public class Project
    {
        private const string Seperator = "\", \"";
        private const int NameSection = 0;
        private const int PathSection = 1;
        private const int GuidSection = 2;
        private string[] section;

        public ProjectType Type { get; }
        public string Name { get; }
        public string Location { get; }
        public Guid ProjectGuid { get; }

        public Project(System.IO.TextReader inStream)
        {
            var projectDefinition = inStream.ReadLine();
            section = System.Text.RegularExpressions.Regex.Split(projectDefinition, Seperator);

            var end = inStream.ReadLine();
            System.Diagnostics.Debug.Assert(end == "EndProject");

            // Load project from text
            Type = GetProjectType();
            Name = GetProjectName();
            Location = GetProjectLocation();
            ProjectGuid = GetProjectGuid();
        }

        public Project(ProjectType type, string name, string location, Guid projectGuid)
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

        private ProjectType GetProjectType()
        {
            int offset = "Project(\"".Length;
            int length = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}".Length;
            var guid = section[NameSection].Substring(offset, length);
            return new Guid(guid).ToProjectType();
        }

        private string GetProjectName()
        {
            int offset = "Project(\"{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\") = \"".Length;
            return section[NameSection].Substring(offset);
        }

        private string GetProjectLocation()
        {
            return section[PathSection];
        }

        private Guid GetProjectGuid()
        {
            var guidString = section[GuidSection].TrimEnd('"');
            return new Guid(guidString);
        }
    }
}