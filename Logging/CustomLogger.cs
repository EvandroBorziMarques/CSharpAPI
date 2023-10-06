
namespace Cadastro.CustomLoggerProviderConfiguration
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _configuration;
        public CustomLogger(string nome, CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = nome;
            _configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var mensagem = string.Format($"{logLevel} : {eventId} - {formatter(state, exception)}");
            EsreverTextoArquivo(mensagem);
        }

        private void EsreverTextoArquivo(string mensagem){
            var caminhoArquivo = @$"/Users/evandroborzi/Projects/Cadastro/Cadastro/bin/LOG-{DateTime.Now:yyyy-MM-dd}.txt";
            if (!File.Exists(caminhoArquivo))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoArquivo));
                File.Create(caminhoArquivo).Dispose();
            }
            
            using StreamWriter streamWriter = new StreamWriter(caminhoArquivo, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}