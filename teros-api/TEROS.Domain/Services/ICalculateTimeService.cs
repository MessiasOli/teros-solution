namespace TEROS.Domain.Services
{
    public interface ICalculateTimeService
    {
        /// <summary>
        /// Calcula a diferença entre duas datas no formato especificado (dd/MM/yyyy HH:mm:ss) e retorna uma mensagem de boas-vindas, indicando o tempo decorrido.
        /// </summary>
        /// <param name="lastTime">A data anterior no formato dd/MM/yyyy HH:mm:ss.</param>
        /// <param name="actualTime">A data atual no formato dd/MM/yyyy HH:mm:ss.</param>
        /// <returns>Uma mensagem de boas-vindas com a diferença de tempo entre as datas, ou mensagens de erro para casos inválidos.</returns>
        string GetLastTime(string lastTime, string actualTime);
    }
}
