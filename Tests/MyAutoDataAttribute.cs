using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit2;

namespace Tests
{
    public class MyAutoDataAttribute : AutoDataAttribute
    {
        public MyAutoDataAttribute() : base(new Fixture()
            .Customize(new AutoNSubstituteCustomization()))
        {
        }
    }
}