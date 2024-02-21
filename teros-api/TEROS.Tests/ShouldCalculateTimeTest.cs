using TEROS.Domain.Services;

namespace TEROS.Tests
{
    public class ShouldCalculateTimeTest
    {
        protected ICalculateTimeService _calculateTimeService = new CalculateTimeService();

        [Theory]
        [InlineData("15/02/2024 08:30:00", "19/02/2024 15:45:30", "Bem-vindo de volta! Você esteve fora por 103 horas e 15 minutos.")]
        [InlineData("01/01/2022 12:00:00", "02/01/2022 14:30:45", "Bem-vindo de volta! Você esteve fora por 26 horas e 30 minutos.")]
        [InlineData("10/03/2023 18:45:00", "15/03/2023 10:00:00", "Bem-vindo de volta! Você esteve fora por 111 horas e 15 minutos.")]
        [InlineData("05/06/2023 09:00:00", "06/06/2023 09:30:00", "Bem-vindo de volta! Você esteve fora por 24 horas e 30 minutos.")]
        [InlineData("20/08/2022 20:15:30", "22/08/2022 10:45:00", "Bem-vindo de volta! Você esteve fora por 38 horas e 29 minutos.")]
        [InlineData("22/08/2022 10:15:00", "22/08/2022 10:45:30", "Bem-vindo de volta! Você esteve fora por 30 minutos.")]
        [InlineData("20/08/2022 20:15:30", "20/08/2022 20:15:45", "")]
        [InlineData("20/08/2022 20:15:30", "20/08/2022 20:15:30", "")]
        [InlineData("19/02/2024 15:45:30", "22/08/2022 10:45:00", "")]
        [InlineData("", "22/08/2022 10:45:00", "")]
        [InlineData("20/08/2022 20:15:30", "", "")]
        [InlineData("", "", "")]
        [InlineData(null, "22/08/2022 10:45:00", "")]
        [InlineData("20/08/2022 20:15:30", null, "")]
        [InlineData(null, null, "")]
        public void GetLastTimeTest(string lastTime, string actualTime, string expected)
        {
            var result  = _calculateTimeService.GetLastTime(lastTime, actualTime);
            Assert.Equal(expected, result);
        }
    }
}