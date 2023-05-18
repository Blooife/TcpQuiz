using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Playhub
{
    public static class ProtocolProcess
    {
        //Datas
        public static ObservableCollection<ProtocolModel.Player> Players { get; set; }
        public static ObservableCollection<string> Messages { get; set; }
        public static ObservableCollection<ProtocolModel.Question> Questions { get; set; }
        public static ObservableCollection<ProtocolModel.Btn> Buttons { get; set; }
        public static bool CanAnswer { get; set; }
        public static event EventHandler OnShowAnswer;
        public static event EventHandler<AnswerReceivedEvent> OnHostCheckAnswer;
        public static event EventHandler<GameSettingsReceivedEvent> OnGameSettingsReceivedEvent;
        static ProtocolProcess()
        {
            Players = new ObservableCollection<ProtocolModel.Player>();
            Messages = new ObservableCollection<string>();
            Questions = new ObservableCollection<ProtocolModel.Question>();
            Buttons = new ObservableCollection<ProtocolModel.Btn>();
           // PanelShapes = new ObservableCollection<ProtocolModel.Shapes>();
            GameServer.OnDataReceived += GameServerOnDataReceived;
            CanAnswer = false;
        }

        private static void GameServerOnDataReceived(object sender, DataReceivedEvent e)
        {
            var token = e.Data.Split(new[] { "\\;end;\\" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var messageToken in token)
            {
                ProtocolModel.Base baseMessage = JsonConvert.DeserializeObject<ProtocolModel.Base>(messageToken);
                switch (baseMessage.Type)
                {
                    // Get PlayerList
                    case ProtocolModel.MessageType.ResponsePlayers:
                        {
                            Players.Clear();
                            foreach (var item in JsonConvert.DeserializeObject<ProtocolModel.PlayerList>(baseMessage.Data.ToString()).Players)
                            {
                                Players.Add(item);
                            }
                            break;
                        }
                    case ProtocolModel.MessageType.LobbyMessage:
                        {
                            ProtocolModel.LobbyMessage message = JsonConvert.DeserializeObject<ProtocolModel.LobbyMessage>(baseMessage.Data.ToString());
                            Messages.Add($"({baseMessage.DateTime}) {message.Player} : {message.Message}");
                            break;
                        }
                    case ProtocolModel.MessageType.NewQuestion:
                    {
                        ProtocolModel.Question question = JsonConvert.DeserializeObject<ProtocolModel.Question>(baseMessage.Data.ToString());
                        Questions.Add(question);
                        break;
                    }
                    case ProtocolModel.MessageType.ShowAnswer:
                    {
                        OnShowAnswer?.Invoke(null, EventArgs.Empty);
                        break;
                    }
                    case ProtocolModel.MessageType.CanAnswer:
                    { 
                        if (baseMessage.Data.ToString() == "True")
                        {
                             CanAnswer = true;
                        }
                        else
                        {
                             CanAnswer = false;
                        }
                        break;
                    }
                    case ProtocolModel.MessageType.RequestGameSettings:
                    {
                        OnGameSettingsReceivedEvent?.Invoke(null, new GameSettingsReceivedEvent(baseMessage.Data.ToString()));
                        break;
                    }
                    case ProtocolModel.MessageType.SendHostCheckAnswer:
                    {
                        ProtocolModel.Answer answer = JsonConvert.DeserializeObject<ProtocolModel.Answer>(baseMessage.Data.ToString());
                        OnHostCheckAnswer?.Invoke(null, new AnswerReceivedEvent(baseMessage.Data.ToString()));
                        break;
                    }
                    case ProtocolModel.MessageType.RemoveButton:
                    {
                        int n = Int16.Parse(JsonConvert.DeserializeObject<string>(baseMessage.Data.ToString()));
                        Buttons.Remove(Buttons.First(b => b.Index == n));
                        break;
                    }
                    
                }
            }

        }
        public static void CreateGame(string gameAdrress, int gamePort, string gameName)
        {
            GameServer.GameAdrress = gameAdrress;
            GameServer.GamePort = gamePort;
            GameServer.GameName = gameName;
            GameServer.CreateSocket();
            GameServer.LoadQuestions();
            GameServer.SetTimer();
        }
        public static void SetSettings( int winPoint, int numOfPl)
        {
            GameServer.GameWinPoint = winPoint;
            GameServer.NumOfPlayers = numOfPl;
        }
        public static void CreatePlayer(string gameAdrress, int gamePort)
        {
            GameServer.GameAdrress = gameAdrress;
            GameServer.GamePort = gamePort;
            GameServer.CreateClient();

        }
        public static async void StartServer()
        {
            await GameServer.StartServerSocketAsync();
        }
        public static async void StartClient()
        {
            await GameServer.StartClientSocketAsync();
        }
        public static void JoinGame(string playerName)
        {
            GameServer.RequestJoin(playerName);
        }
        public static void SendMessage(string message, string playerName)
        {
            GameServer.RequestSendMessage(message, playerName);
        }
        public static void RequestKnowAnswer()
        {
            GameServer.RequestKnowAnswer();
        }
        
        public static void SendAnswer(string data)
        {
            GameServer.SendAnswer(data);
        }

        public static void ShowQuestion(int nQ)
        {
            GameServer.RequestShowQuestion(nQ);
        }
        public static void RequestGameSettings()
        {
            GameServer.RequestGameSettings();
        }

        public static void ResponseHostCheck(ProtocolModel.Answer ans)
        {
            GameServer.ResponseHostCheck(ans);
        }
        public static void StartGame()
        {
            GameServer.RequestStartGame();
        }
    }
}
