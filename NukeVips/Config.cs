using Exiled.API.Interfaces;
using System.ComponentModel;

namespace NukeVips
{
    public class Config : IConfig
    {
        [Description("Indica si el plugin esta activado o no.")]
        public bool IsEnabled { get; set; } = true;
    }
}