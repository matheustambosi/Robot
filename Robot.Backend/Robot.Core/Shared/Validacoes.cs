namespace Robot.Core.Shared
{
    public static class Validacoes
    {
        public static bool ProximoEstadoValido(int estadoAtual, int proximoEstado) => (proximoEstado + 1 == estadoAtual || proximoEstado - 1 == estadoAtual);
    }
}
