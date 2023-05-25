using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Playhub
{
    public class ProtocolModel
    {
        public class Base
        {
            public MessageType Type { get; set; }
            public DateTime DateTime { get; set; }
            public object Data { get; set; }

        }

        public class PlayerList
        {
            public ObservableCollection<Player> Players { get; set; }
        }
        
        public class Question
        {
            public int Index { get; set; }
            public string Text { get; set; }
            public int Type { get; set; }
            public  int Points { get; set; }
            public string Answer { get; set; }
            public string Subject { get; set; }
            
        }

        public class Answer
        {
            public string PlayerId { get; set; }
            public string answer { get; set; }
            public bool IsRight { get; set; }
        }
        
        public class LobbyMessage
        {
            public string Player { get; set; }
            public string Message { get; set; }
        }
        
        
        
        public class Player
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Point { get; set; }
        }
        public class ConnectionClient
        {
            public string Id { get; set; }
            public TcpClient Client { get; set; }
        }
        public class GameSetting
        {
            public string[] Subjects { get; set; }
            public int[] Points { get; set; }
            public  int[] Index { get; set; }
            public string GameName { get; set; }
            public bool IsRunning { get; set; }
        }
        public class Btn:Button
        {
            public int Index;
        }
        public enum MessageType
        {
            LobbyMessage,
            RequestKnowAnswer,
            ResponsePlayers,
            NewQuestion,
            ShowQuestion,
            RequestJoin,
            SendAnswer,
            RequestStart,
            ShowAnswer,
            RemoveButton,
            CanAnswer,
            CanChoose,
            SendTimerState,
            SendHostCheckAnswer,
            ResponseHostCheck,
            RequestGameSettings,
        }
    }
}
