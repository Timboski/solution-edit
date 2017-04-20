using SolutionEdit;
using Xunit;

namespace SolutionEditTest
{
    public class ProjectTypeTest
    {
        [Fact]
        public void ConvertProjectToGuidAndBack()
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