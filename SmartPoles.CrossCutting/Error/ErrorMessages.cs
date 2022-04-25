using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoles.CrossCutting.Error
{
    public static class ErrorMessages
    {
        public static string INVALID_USER = "Usuário ou senha inválidos.";
        public static string CONDOMINIUM_NOT_FOUND = "Condomínio informado não existe.";
        public static string USER_ALREADY_EXISTS = "Usuário já existe.";
        public static string USER_NOT_FOUND = "Usuário não encontrado.";
        public static string CONDOMINIUM_ALREADY_HAS_GATEWAY_POLE = "O condomínio selecionado já possui um poste gateway.";
    }
}
