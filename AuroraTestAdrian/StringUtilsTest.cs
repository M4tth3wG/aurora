using Aurora.Utils;
using System;
using Xunit;

namespace AuroraTestAdrian
{
    public class StringUtilsTest
    {
        [Theory]
        [InlineData("FORMASTUDIOW")]
        [InlineData("           FoRMasTuDiOw   ")]
        public void GetDowolnyTekst_CheckingValidCasesToCatch_ReturnsDowolna(string value)
        {
            var result = StringUtils.GetDowolnyTekst(value);

            Assert.Equal("Dowolna", result);
        } 
        
        [Theory]
        [InlineData("F0RMASTUDI0W")]
        [InlineData("          _FoRMasTuD1qw   ")]
        public void GetDowolnyTekst_CheckingInvalidCasesToCatch_NoReturnsDowolna(string value)
        {
            var result = StringUtils.GetDowolnyTekst(value);

            Assert.NotEqual("Dowolna", result);

        }



        [Theory]
        [InlineData("Jan", "Kowalski", "Kowal")]
        [InlineData("Jan", "Kowalski", "ja")]
        [InlineData("Jan", "Kowalski", "Kowalski j")]
        [InlineData("Jan", "Kowalski", "jan K")]
        [InlineData("Jan", "Kowalski", "")]
        public void CzyKandydatPasuje_Checking_ReturnsTrue(string imie, string nazwisko, string searchText)
        {
            var result = StringUtils.CzyKandydatPasuje(imie, nazwisko, searchText);

            Assert.True(result);
        }


        [Theory]
        [InlineData("Jan", "Kowalski", "Kowalski Janina")]
        [InlineData("Jan", "Kowalski", "ja kowalski")]
        [InlineData("Jan", "Kowalski", "Kowal ski j")]
        [InlineData("Jan", "Kowalski", "Kowal               Jan")]
        public void CzyKandydatPasuje_Checking_ReturnsFalse(string imie, string nazwisko, string searchText)
        {
            var result = StringUtils.CzyKandydatPasuje(imie, nazwisko, searchText);

            Assert.False(result);
        }
    }
}
