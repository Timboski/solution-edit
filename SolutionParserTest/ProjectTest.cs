using System;
using Xunit;
using SolutionEdit;

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
    }
}
