using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Timers;

using LiveSplit.Model;
using LiveSplit.UI.Components;
using LiveSplit.UI;
using LiveSplit.Model.Input;


namespace LiveSplit.SerialSplitter
{
    class SerialComm : UI.Components.IComponent
    {
        SerialPort Port;
        LiveSplitState State;
        TimerModel Timer;

        System.Timers.Timer TimerMonitoring;


        public ComponentSettings Settings { get; set; }

        public string COMPort { get; set; }
        public string BaudRate { get; set; }

        protected Form form { get; set; }

        public IDictionary<string, Action> ContextMenuControls { get; protected set; }

        public string ComponentName => $"LiveSplit Serial splitter";

        public float HorizontalWidth => 0;
        public float MinimumHeight => 0;
        public float VerticalHeight => 0;
        public float MinimumWidth => 0;
        public float PaddingTop => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;

        public SerialComm(LiveSplitState state)
        {
            State = state;
            form = State.Form;

            Timer = new TimerModel();
            Timer.CurrentState = State;

            Settings = new ComponentSettings();

            SetUpLiveSplitHandlers();

            //TODO: Display the saved port and baudrate upon initially populating the context menu
            //(Settings.Port / BaudRate are null at this time)
            ContextMenuControls = new Dictionary<string, Action>();
            ContextMenuControls.Add("Start serial communication", Start);
        }


        #region EventHandlers
        private void SetUpLiveSplitHandlers()
        {
            State.OnStart += new EventHandler(StateChanged);
            State.OnResume += new EventHandler(StateChanged);
            State.OnPause += new EventHandler(StateChanged);
            State.OnSplit += new EventHandler(StateChanged);
            State.OnReset += new EventHandlerT<TimerPhase>(StateChangedT);
        }


        private void DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort Sp = (SerialPort)sender;

            string Command = Sp.ReadExisting();

            HandleInput(Command);
        }


        private void SerialError(object sender, SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Serial communication error! Closing port." + "\nMessage:\n"
            + sender.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CloseSerialPort();
        }



        private void StateChanged(object sender, EventArgs e)
        {
            UpdateButton();
        }


        private void StateChangedT(object sender, TimerPhase t)
        {
            UpdateButton();
        }
        #endregion


        #region Context menu
        private void Start()
        {
            OpenSerialPort();

            if (Port != null && Port.IsOpen && Settings.Monitoring == "1")
            {
                StartMonitoring();
            }

            UpdateButton();
        }

        
        private void Stop()
        {
            CloseSerialPort();

            if (Settings.Monitoring == "1")
            {
                StopMonitoring();
            }
        }
        #endregion


        #region Serial port
        private void OpenSerialPort()
        {
            Port = new SerialPort(Settings.Port, int.Parse(Settings.BaudRate));

            Port.Parity = Parity.None;
            Port.StopBits = StopBits.One;
            Port.DataBits = 8;
            Port.Handshake = Handshake.None;
            Port.RtsEnable = true;

            Port.DataReceived += new SerialDataReceivedEventHandler(DataRecieved);
            Port.ErrorReceived += new SerialErrorReceivedEventHandler(SerialError);
            
            try
            {
                Port.Open();

                ContextMenuControls.Clear();
                ContextMenuControls.Add("Stop serial communication (" + Settings.Port +
                    ", " + Settings.BaudRate + ")", Stop);
            }
            catch (Exception x)
            {
                MessageBox.Show("Serial port could not be opened!" + "\nMessage:\n"
                    + x.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Port = null;
            }
        }


        private void CloseSerialPort()
        {
            if (Port != null)
            {
                try
                {
                    Port.Close();
                    Port.Dispose();
                    Port = null;

                    ContextMenuControls.Clear();
                    ContextMenuControls.Add("Start serial communication (" + Settings.Port +
                        ", " + Settings.BaudRate + ")", Start);
                }
                catch (Exception x)
                {
                    MessageBox.Show("Serial port could not be closed!" + "\nMessage:\n"
                    + x.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion


        #region Connectivity monitoring
        private void StartMonitoring()
        {
            TimerMonitoring = new System.Timers.Timer();
            TimerMonitoring.Interval = 5000;
            TimerMonitoring.Elapsed += new ElapsedEventHandler(ConnectionLost);

            TimerMonitoring.Start();
        }


        private void StopMonitoring()
        {
            TimerMonitoring.Stop();
            TimerMonitoring.Dispose();
        }

        private void ConnectionOK()
        {
            TimerMonitoring.Stop();     //Stop-start cycle to reset the timer
            TimerMonitoring.Start();
        }


        private void ConnectionLost(object sender, EventArgs e)
        {
            TimerMonitoring.Stop();
            TimerMonitoring.Dispose();

            MessageBox.Show("Device was disconnected! Reconnect the device.\nEnding serial communication.",
             "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Stop();
        }



        #endregion


        #region LiveSplit control
        private void HandleInput(string command)
        {
            switch (command)
            {
                case ">":   //Arduino connectivity poll
                    if (Settings.Monitoring == "1")
                    {
                        ConnectionOK();
                    }

                break;

                case "1":   //Split button

                    switch (State.CurrentPhase)
                    {
                        case TimerPhase.NotRunning:
                            Timer.Start();
                            break;

                        case TimerPhase.Running:
                            Timer.Split();
                            break;

                        case TimerPhase.Ended:
                            Timer.Reset();
                            break;

                        case TimerPhase.Paused:
                            Timer.Pause();
                            break;

                        default:
                            //Do nothing
                            break;
                    }

                    break;

                case "2":   //Pause button
                    if (State.CurrentPhase == TimerPhase.NotRunning || State.CurrentPhase == TimerPhase.Paused
                        || State.CurrentPhase == TimerPhase.Running)
                    {
                        Timer.Pause();
                        break;
                    }

                    break;

                default:
                    //Do nothing
                    break;
            }
        }

        private void UpdateButton()
        {
            if (Port != null && Port.IsOpen)
            {
                switch (State.CurrentPhase)
                {
                    case TimerPhase.Running:
                        Port.Write("1");
                        break;

                    case TimerPhase.Paused:
                        Port.Write("2");
                        break;

                    case TimerPhase.Ended:
                        Port.Write("3");
                        break;

                    case TimerPhase.NotRunning:
                        Port.Write("4");
                        break;

                    default:
                        //Do nothing
                        break;
                }
            }
        }
        #endregion


        #region Settings
        public Control GetSettingsControl(LayoutMode mode)
        {
            return Settings;
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public void Dispose()
        {
            CloseSerialPort();
        }
        #endregion




        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
        }
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
        }
        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
        }
    }
}
