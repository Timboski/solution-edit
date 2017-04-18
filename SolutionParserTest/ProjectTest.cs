using System;
using Xunit;
using SolutionEdit;

namespace SolutionParserTest
{
    public class ProjectTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange.
            var projType = ProjectType.Project;

            // Act.
            var typeGuid = projType.ToGuid();
            var andBack = typeGuid.ToProjectType();

            // Assert.
            Assert.Equal(projType, andBack);
            Assert.Equal(typeGuid.ToProjectGuidString(), andBack.ToProjectGuidString());
        }
    }
}
