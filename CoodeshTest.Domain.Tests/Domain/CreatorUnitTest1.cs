using CoodeshTest.Domain.Entities;
using FluentAssertions;

namespace CoodeshTest.Tests.Domain
{
    public class CreatorUnitTest1
    {
        [Fact(DisplayName = "Create Creator With Valid State")]
        public void CreateCreator_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Creator(1, "Lucas");
            action.Should()
                .NotThrow<CoodeshTest.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Creating Creator With Invalid Name")]
        public void CreateCreator_InvalidName_DomainExceptionInvalid()
        {
            Action action = () => new Creator(1, "Ab");
            action.Should()
                .Throw<CoodeshTest.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. minimium 3 charecters");
        }
    }
}