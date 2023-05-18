using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Playhub
{
    public class DataReceivedEvent : EventArgs
    {
        public string Data { get; set; }
        public DataReceivedEvent(string data)
        {
            Data = data;
        }
    }
    
    public class AnswerReceivedEvent : EventArgs
    {
        public ProtocolModel.Answer ans { get; set; }
        public AnswerReceivedEvent(string data)
        {
            ans = JsonConvert.DeserializeObject<ProtocolModel.Answer>(data);
        }
    }
    
    /*public class AnswerReceivedEvent : EventArgs
    {
        public ProtocolModel.GameSetting GameSettings { get; set; }
        public AnswerReceivedEvent(string data)
        {
            GameSettings = JsonConvert.DeserializeObject<ProtocolModel.GameSetting>(data); ;
        }
    }*/
    public class GameSettingsReceivedEvent : EventArgs
    {
        public ProtocolModel.GameSetting GameSettings { get; set; }
        public GameSettingsReceivedEvent(string data)
        {
            GameSettings = JsonConvert.DeserializeObject<ProtocolModel.GameSetting>(data); ;
        }
    }
}
