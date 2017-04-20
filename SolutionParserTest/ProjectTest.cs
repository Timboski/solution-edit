using SolutionEdit;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace SolutionParserTest
{
    public class ProjectTest
    {
        [Fact]
        public void CreateNewDirectoryProject()
        {
            // Arrange.
            var directoryName = "Test";

            // Act.
            var directoryProject = Project.NewDirectoryProject(directoryName);

            // Assert.
            Assert.Equal(directoryName, directoryProject.Name);
            Assert.Equal(directoryName, directoryProject.Location);
            Assert.Equal(ProjectType.Directory, directoryProject.Type);
        }

        [Fact]
        public void ReadProjectFromStream()
        {
            // Project is of the form:
            //Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "SolutionParser", "SolutionParser\SolutionParser.csproj", "{AE17D442-B29B-4F55-9801-7151BCD0D9CA}"
            //EndProject

            // Arrange.
            var guid = new Guid("1DC4FA2D-16D1-459D-9C35-D49208F753C5");
            var projectName = "TestProject";
            var projectLocation = @"This\is\a\test\TestProject.csproj";
            var projectDefinition = $"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}\", \"{projectLocation}\", \"{guid.ToString("B").ToUpper()}\"\r\nEndProject\r\n";

            using (TextReader inStream = new StringReader(projectDefinition))
            {
                // Act.
                var project = new Project(inStream);

                // Assert.
                Assert.Equal(projectName, project.Name);
                Assert.Equal(projectLocation, project.Location);
                Assert.Equal(ProjectType.NetCoreProject, project.Type);
                var end = inStream.ReadToEnd();
                Assert.Equal("", end);
            }
        }

        [Fact]
        public void WriteProjectToStream()
        {
            // Project is of the form:
            //Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "SolutionParser", "SolutionParser\SolutionParser.csproj", "{AE17D442-B29B-4F55-9801-7151BCD0D9CA}"
            //EndProject

            // Arrange.
            var guid = new Guid("1DC4FA2D-16D1-459D-9C35-D49208F753C5");
            var projectName = "TestProject";
            var projectLocation = @"This\is\a\test\TestProject.csproj";
            var project = new Project(ProjectType.NetCoreProject, projectName, projectLocation, guid);

            // Act.
            var projectDefinition = new StringBuilder();
            using (TextWriter outStream = new StringWriter(projectDefinition))
            {
                project.Write(outStream);
            }

            // Assert.
            var expected = $"Project(\"{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}\") = \"{projectName}\", \"{projectLocation}\", \"{guid.ToString("B").ToUpper()}\"\r\nEndProject\r\n";
            var actual = projectDefinition.ToString();
            Assert.Equal(expected, actual);
        }
    }
}