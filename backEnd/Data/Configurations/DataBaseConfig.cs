namespace APITarefas.Data.Configurations
{
    public class DataBaseConfig : IDataBaseConfig
    {
        public string DataBaseName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
    }
}
