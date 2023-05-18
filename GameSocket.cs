using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;   
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Playhub
{
    public static class GameServer
    {
        //Game Settings
        public static string GameAdrress { get; set; }
        public static int GamePort { get; set; }
        public static string GameName { get; set; }
        public static int GameWinPoint { get; set; }

        public static int NumOfPlayers { get; set; }

        private static bool GameRunning = false;

        public static System.Timers.Timer GameTimer;
        public static Stopwatch watch;
        public static bool ReceiveAnswer = false;

        private static ProtocolModel.Question CurrentQuestion { get; set; }

        //Game List
        private static ObservableCollection<ProtocolModel.Player> Players { get; set; }
        private static List<ProtocolModel.ConnectionClient> Clients { get; set; }

        private static List<ProtocolModel.Question> Questions { get; set; }

        //Data Handler event
        public static event EventHandler<DataReceivedEvent> OnDataReceived;

        //Stop tokens (not using)
        private static CancellationTokenSource _cancellationServerToken;
        private static CancellationTokenSource _cancellationClientToken;

        //Socket
        private static TcpListener GameSocket { get; set; }

        private static TcpClient PlayerClient { get; set; }
        //Create
        

        public static void CreateSocket()
        {
            if (GameAdrress == null || GamePort == 0)
            {
                throw new ArgumentNullException("GameAdrress or GamePort");
            }

            GameSocket = new TcpListener(IPAddress.Parse(GameAdrress), GamePort);
            GameSocket.Start();

        }

        public static async void CreateClient()
        {
            if (GameAdrress == null || GamePort == 0)
            {
                throw new ArgumentNullException("GameAdrress or GamePort");
            }

            if (PlayerClient == null)
            {
                PlayerClient = new TcpClient
                {
                    NoDelay = true
                };
                await PlayerClient.ConnectAsync(IPAddress.Parse(GameAdrress), GamePort);
            }

        }

        //Listener
        public static async Task StartServerSocketAsync()
        {
            while (NumOfPlayers + 1 > Clients.Count)
            {
                await Task.Run(async () =>
                {
                    TcpClient client = await GameSocket.AcceptTcpClientAsync();
                    client.NoDelay = true;
                    ProtocolModel.ConnectionClient connectionClient = new ProtocolModel.ConnectionClient
                    {
                        Id = Guid.NewGuid().ToString(),
                        Client = client
                    };
                    Clients.Add(connectionClient);
                    ReadFromClient(connectionClient);
                });
            }

            GameSocket.Stop();
        }

        //Listener Process From Client Data
        private static async void ReadFromClient(ProtocolModel.ConnectionClient connectionClient)
        {
            try
            {
                await Task.Run(async () =>
                {
                    while (connectionClient.Client.Connected)
                    {
                        if (connectionClient.Client.GetStream().DataAvailable)
                        {
                            NetworkStream stream = connectionClient.Client.GetStream();
                            byte[] data = new byte[1024];
                            string json = string.Empty;
                            var bytes = stream.Read(data, 0, data.Length);
                            if (bytes > 0)
                            {
                                json = Encoding.UTF8.GetString(data, 0, bytes);
                            }

                            //Data Processing
                            var token = json.Split(new[] { "\\;end;\\" }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var msgToken in token)
                            {
                                ProtocolModel.Base baseMessage =
                                    JsonConvert.DeserializeObject<ProtocolModel.Base>(msgToken);
                                switch (baseMessage.Type)
                                {
                                    // Join new player and send current players
                                    case ProtocolModel.MessageType.RequestJoin:
                                    {
                                        ProtocolModel.Player player =
                                            JsonConvert.DeserializeObject<ProtocolModel.Player>(
                                                baseMessage.Data.ToString());
                                        player.Id = connectionClient.Id;
                                        Players.Add(player);
                                        BroadcastPlayers();
                                        RequestSendMessage(
                                            $"--> {Players.First(i => i.Id == connectionClient.Id).Name} is joined.");
                                        break;
                                    }
                                    // Lobby Messages
                                    case ProtocolModel.MessageType.LobbyMessage:
                                    {
                                        BroadcastFromServer(json);
                                        break;
                                    }
                                    case ProtocolModel.MessageType.NewQuestion:
                                    {
                                        SendCanAnswer(true);
                                        BroadcastFromServer(json);
                                        break;
                                    }
                                    // Start Game
                                    case ProtocolModel.MessageType.RequestStart:
                                    {
                                        GameRunning = true;
                                        RequestSendMessage($"--> Game started by host");
                                        break;
                                    }
                                    case ProtocolModel.MessageType.RequestKnowAnswer:
                                    {
                                        BroadcastFromServer(JsonConvert.SerializeObject(new ProtocolModel.Base
                                        {
                                            Type = ProtocolModel.MessageType.CanAnswer,
                                            Data = "False"
                                        }));
                                        if (ReceiveAnswer)
                                        {
                                            BroadcastFromServerToOne(JsonConvert.SerializeObject(new ProtocolModel.Base
                                            {
                                                Type = ProtocolModel.MessageType.CanAnswer,
                                                Data = "True"
                                            }), connectionClient);
                                        }
                                        ReceiveAnswer = false;
                                        GameTimer.Stop();
                                        watch.Stop();
                                        break;
                                    }
                                    case ProtocolModel.MessageType.SendAnswer:
                                    {
                                        var m = JsonConvert.DeserializeObject<ProtocolModel.Answer>(
                                            baseMessage.Data.ToString());
                                        m.PlayerId = connectionClient.Id;
                                        BroadcastFromServerToOne(JsonConvert.SerializeObject(new ProtocolModel.Base
                                        {
                                            Type = ProtocolModel.MessageType.SendHostCheckAnswer,
                                            Data = new ProtocolModel.Answer()
                                            {
                                               answer = m.answer,
                                               PlayerId = m.PlayerId
                                            }
                                        }), Clients[0]);
                                        break;
                                    }
                                    case ProtocolModel.MessageType.ResponseHostCheck:
                                    {
                                        var m = JsonConvert.DeserializeObject<ProtocolModel.Answer>(
                                            baseMessage.Data.ToString());
                                        if (HandleReceivedAnswer(m)) 
                                        {
                                            SendCanAnswer(false);
                                            ShowAnswer();
                                        }
                                        else
                                        {
                                            int remainingtime = 7000 - (int)watch.ElapsedMilliseconds;
                                            if (remainingtime > 0)
                                            {
                                                GameTimer.Interval = remainingtime;
                                                GameTimer.Start();
                                                watch.Start();
                                                SendCanAnswer(true);
                                            }
                                            else
                                            {
                                                GameTimer.Stop();
                                                GameTimer.Interval = 7000;
                                                watch.Stop();
                                                SendCanAnswer(false);
                                                ShowAnswer();
                                            } 
                                        }
                                        break;
                                    }
                                    case ProtocolModel.MessageType.ShowQuestion:
                                    {
                                        int m = Int16.Parse(JsonConvert.DeserializeObject<string>(
                                            baseMessage.Data.ToString()));
                                        RequestNewQuestion(m);
                                        GameTimer.Start();
                                        watch.Start();
                                        BroadcastFromServer(JsonConvert.SerializeObject(new ProtocolModel.Base
                                        {
                                            Type = ProtocolModel.MessageType.RemoveButton,
                                            Data = m.ToString()
                                                }));
                                        break;
                                    }
                                    // Game Settings
                                    case ProtocolModel.MessageType.RequestGameSettings:
                                    {
                                        BroadcastFromServerToOne(JsonConvert.SerializeObject(new ProtocolModel.Base
                                        {
                                            Type = ProtocolModel.MessageType.RequestGameSettings,
                                            Data = new ProtocolModel.GameSetting
                                            {
                                                GameName = GameName,
                                                Points = Questions.Select(q => q.Points).ToArray(),
                                                Subjects = Questions.Select(q => q.Subject).ToArray(),
                                                Index = Questions.Select(q=>q.Index).ToArray(),
                                            }
                                        }), connectionClient);
                                        break;
                                    }
                                }
                            }
                        }

                        Thread.Sleep(25);
                    }
                });
            }
            finally
            {
                Players.Remove(Players.First(i => i.Id == connectionClient.Id));
                connectionClient.Client.Close();
                BroadcastPlayers();
            }

        }

        public static void ResponseHostCheck(ProtocolModel.Answer ans)
        {
            string json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                Type = ProtocolModel.MessageType.ResponseHostCheck,
                DateTime = DateTime.Now,
                Data = new ProtocolModel.Answer
                {
                    PlayerId = ans.PlayerId,
                    IsRight = ans.IsRight,
                    answer = ans.answer
                }
            });
            SendFromClient(json);
        }
        
        public static bool HandleReceivedAnswer(ProtocolModel.Answer answer)
        {
            var pl = Players.First(i => i.Id == answer.PlayerId);
            if (answer.IsRight)
            {
                pl.Point += CurrentQuestion.Points;
                RequestSendMessage($"{pl.Name}'s gets {CurrentQuestion.Points} points for right answer");
                BroadcastPlayers();
                return true;
            }
            pl.Point -= CurrentQuestion.Points;
            RequestSendMessage($"{pl.Name}'s loses {CurrentQuestion.Points} points for wrong answer");
            BroadcastPlayers();
            return false;
        }
        public static async Task StartClientSocketAsync()
        {
            try
            {
                _cancellationClientToken = CancellationTokenSource.CreateLinkedTokenSource(new CancellationToken());
                while (!_cancellationClientToken.Token.IsCancellationRequested)
                {
                    await Task.Run(() =>
                    {
                        if (PlayerClient.Connected && PlayerClient.GetStream().DataAvailable &&
                            PlayerClient.GetStream().CanRead)
                        {
                            NetworkStream stream = PlayerClient.GetStream();
                            byte[] data = new byte[1024 * 1024];
                            string json = string.Empty;
                            var bytes = stream.Read(data, 0, data.Length);
                            if (bytes > 0)
                            {
                                json = Encoding.UTF8.GetString(data, 0, bytes);
                            }

                            OnDataReceived?.Invoke(null, new DataReceivedEvent(json));
                        }

                        Thread.Sleep(25);
                    }, _cancellationClientToken.Token);
                }
            }
            catch
            {
                MessageBox.Show("Client disconnected");
            }
            finally
            {
                PlayerClient.Client.Close();
            }

        }

        //Game
        static GameServer()
        {
            Players = new ObservableCollection<ProtocolModel.Player>();
            Clients = new List<ProtocolModel.ConnectionClient>();
            Questions = new List<ProtocolModel.Question>();
            watch = new Stopwatch();
        }

        //Broadcast
        public static void BroadcastFromServer(string data)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < Clients.Count; i++)
                {
                    var client = Clients[i];
                    if (client.Client.Connected && client.Client.GetStream().CanWrite)
                    {
                        try
                        {
                            NetworkStream stream = client.Client.GetStream();
                            byte[] buffer = Encoding.UTF8.GetBytes(data + "\\;end;\\");
                            if (client.Client.Connected)
                                stream.Write(buffer, 0, buffer.Length);
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        client.Client.Close();
                        Clients.Remove(client);
                    }

                }
            });
        }
        
        public static void BroadcastFromServerToOne(string data, ProtocolModel.ConnectionClient connectionClient)
        {
            Task.Run(() =>
            {
                var client = Clients.First(cl=>cl.Id==connectionClient.Id);
                    if (client.Client.Connected && client.Client.GetStream().CanWrite)
                    {
                        try
                        {
                            NetworkStream stream = client.Client.GetStream();
                            byte[] buffer = Encoding.UTF8.GetBytes(data + "\\;end;\\");
                            if (client.Client.Connected)
                                stream.Write(buffer, 0, buffer.Length);
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        client.Client.Close();
                        Clients.Remove(client);
                    }
            });
        }

        public static void BroadcastPlayers()
        {
            BroadcastFromServer(JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                Type = ProtocolModel.MessageType.ResponsePlayers,
                DateTime = DateTime.Now,
                Data = new ProtocolModel.PlayerList
                {
                    Players = new ObservableCollection<ProtocolModel.Player>(Players.OrderByDescending(i => i.Point))
                }
            }));
            if (Questions.Count == 0)
            {
                BroadcastWinner(); 
            }
            
        }

        public static void SendCanAnswer(bool ca)
        {
            ReceiveAnswer = ca;
            BroadcastFromServer(JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                Type = ProtocolModel.MessageType.CanAnswer,
                Data = ca.ToString()
            }));
            
        }
        public static void BroadcastWinner()
        {
            var players = Players.OrderBy(pl => pl.Point);
            Players = new ObservableCollection<ProtocolModel.Player>(Players.OrderByDescending(i => i.Point));
            RequestSendMessage($"{Players.First().Name} ({Players.First().Point}) is Won");
            RequestSendMessage($"Game Finished");
            GameRunning = false;
        }

        //Request
        public static void SendFromClient(string data)
        {
            if (PlayerClient.Connected)
            {
                NetworkStream stream = PlayerClient.GetStream();
                byte[] buffer = Encoding.UTF8.GetBytes(data + "\\;end;\\");
                stream.Write(buffer, 0, buffer.Length);
            }

        }

        public static void RequestJoin(string playerName)
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.RequestJoin,
                Data = new ProtocolModel.Player
                {
                    Name = playerName,
                    Point = 0
                }
            });
            SendFromClient(json);
        }

        public static void RequestNewQuestion(int n)
        {
            if (Questions.Count > 0)
            {
                CurrentQuestion = Questions.First(q=>q.Index==n);
                Questions.Remove(CurrentQuestion);
                var json = JsonConvert.SerializeObject(new ProtocolModel.Base
                {
                    DateTime = DateTime.Now,
                    Type = ProtocolModel.MessageType.NewQuestion,
                    Data = new ProtocolModel.Question()
                    {
                        Text = CurrentQuestion.Text,
                        Answer = CurrentQuestion.Answer,
                        Points = CurrentQuestion.Points,
                        Type = CurrentQuestion.Type
                    }
                });
                SendFromClient(json);
            }
        }

        public static void RequestSendMessage(string message, string userName = "")
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.LobbyMessage,
                Data = new ProtocolModel.LobbyMessage()
                {
                    Player = userName,
                    Message = message
                }
            });
            SendFromClient(json);
        }

        public static void RequestGameSettings()
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.RequestGameSettings,
                Data = ""
            });
            SendFromClient(json);
        }

        public static void LoadQuestions() ///будет передаваться файл
        {
            List<ProtocolModel.Question> list = new List<ProtocolModel.Question>();
            string filePath = "C:/Users/Asus/Desktop/playhub-master/Playhub/quizes/1.txt";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int num = int.Parse(reader.ReadLine());
                        for (int i = 0; i < num; i++)
                        {
                            ProtocolModel.Question qu = new ProtocolModel.Question();
                            qu.Subject = line;
                            qu.Text = reader.ReadLine();
                            qu.Answer = reader.ReadLine();
                            qu.Points = int.Parse(reader.ReadLine());
                            list.Add(qu);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ошибка чтения файла: " + ex.Message);
            }
            int ind = 0;
            var groupedItems = list.GroupBy(x => x.Subject);
            foreach (var gr in groupedItems)
            {
                var o = gr.OrderBy(x => x.Points);
                foreach (var el in o)
                {
                    el.Index = ind;
                    ind++;
                    Questions.Add(el);
                }
            }
        }

        public static void RequestStartGame()
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.RequestStart,
                Data = ""
            });
            SendFromClient(json);
        }

        public static void RequestKnowAnswer()
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.RequestKnowAnswer,
                Data = ""
            });
            SendFromClient(json);
        }

        public static void SendAnswer(string data)
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.SendAnswer,
                Data = new ProtocolModel.Answer()
                {
                    answer = data,
                }
            });
            SendFromClient(json);
        }

        public static void RequestShowQuestion(int nQ)
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                    DateTime = DateTime.Now,
                    Type = ProtocolModel.MessageType.ShowQuestion,
                    Data = nQ.ToString()
            });
            SendFromClient(json); 
            
        }

        public static void ShowAnswer()
        {
            var json = JsonConvert.SerializeObject(new ProtocolModel.Base
            {
                DateTime = DateTime.Now,
                Type = ProtocolModel.MessageType.ShowAnswer,
                Data = ""
            });
            BroadcastFromServer(json);
        }
        
        public static void SetTimer()
        {
            GameTimer = new System.Timers.Timer(7000);
            GameTimer.Elapsed += OnTimedEvent;
            GameTimer.AutoReset = false;
            GameTimer.Enabled = false; 
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GameTimer.Interval = 7000;
            SendCanAnswer(false);
            ShowAnswer();
        }
    }
}
