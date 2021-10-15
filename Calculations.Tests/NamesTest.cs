using System;
using Xunit;

namespace Calculations.Tests
{
    public class NamesTest
    {
        [Fact]
        [Trait("Category", "Names")]
        public void MakeFullNameTest()
        {
            var names = new Names();
            var result = names.MakeFullName("Aref", "Karimi");
            //Assert.Equal("Aref Karimi", result, ignoreCase:true);
            //Assert.Contains("aref", result, StringComparison.InvariantCultureIgnoreCase);
            //Assert.StartsWith("Aref", result);
            //Assert.EndsWith("Karimi", result, StringComparison.InvariantCultureIgnoreCase);
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", result);
        }

        [Fact]
        [Trait("Category", "Names")]
        public void NickName_MustBeNull()
        {
            var names = new Names();            
            Assert.Null(names.NickName);
        }

        [Fact]
        [Trait("Category", "Names")]
        public void NickName_MustBeNotNull()
        {
            var names = new Names();
            names.NickName = "Strong Man";
            Assert.NotNull(names.NickName);
        }

        [Fact]
        [Trait("Category", "Names")]
        public void MakeFullName_AlwaysReturnValue()
        {
            var names = new Names();
            var result = names.MakeFullName("Aref", "Karimi");
            Assert.NotNull(result);
            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
