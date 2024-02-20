namespace TEROS.Domain.Services
{
    public class CalculateTimeService : ICalculateTimeService
    {
        public string GetLastTime(string lastTime, string actualTime)
        {
            DateTime lastDate;
            DateTime actualDate;

            if (!DateTime.TryParseExact(lastTime, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out lastDate) ||
                !DateTime.TryParseExact(actualTime, "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out actualDate))
                return "";

            if (lastDate >= actualDate)
                return "";

            TimeSpan diferenca = actualDate - lastDate;

            double horas = Math.Truncate(diferenca.TotalHours)  ;
            int minutos = diferenca.Minutes;

            if (horas + minutos == 0)
                return "";

            return $"Bem-vindo de volta! Você esteve fora por {(horas > 0 ? horas + " horas e " : "")}{minutos} minutos.";
        }
    }
}
