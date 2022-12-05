using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoR.Models.ProjetoR
{
    public enum Status
    {
        Solicitado,
        Preparando,
        Pronto,
        Entregue,
        Finalizado
    }
    public static class StatusAjudante
    {
        public static List<Status> Todos() { return new List<Status>()
        { Status.Solicitado,Status.Preparando,Status.Pronto,Status.Entregue,Status.Finalizado}; }
    }
}