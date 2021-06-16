using System;
using System.ComponentModel;

namespace Shop.DAL
{
    internal class User
    {
        [DisplayName("ID пользователя")]
        public int Id { get; internal set; }
        [DisplayName("Логин")]
        public string Login { get; internal set; }
        [DisplayName("Пароль")]
        public string Passwrd { get; internal set; }
        [DisplayName("Сотрудник")]
        public string Name_sotr { get; internal set; }
        [DisplayName("Права")]
        public string Root { get; internal set; }
    }
}