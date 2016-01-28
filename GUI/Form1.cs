using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
//using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Xna.Framework.Input;
//sing Microsoft.Xna.Framework.Design;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Media;
//using Microsoft.Xna.Framework.Net;
//using Microsoft.Xna.Framework;
//using Microsoft.DirectX.DirectInput;
using SlimDX.DirectInput;

namespace GUI
{
    public partial class Form1 : Form
    {
        int KeysNumber = 8;
        int[] KeysPressed = new int[8]; // Array with the marks of the Keys Pressed (1 = Key Pressed, 0 = Key Not Pressed)
        string[] KeysPressedName = new string[8] {"UP", "DOWN", "LEFT", "RIGHT", "SHIFT_UP", "SHIFT_DOWN", "EMGCY_STOP"," AHEAD "}; // Array with the Name of the Keys
        int gear, gearMAX = 5, gearMIN = 1;
        int hour, min, sec, ms = 0; //timer values 
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        Joystick[] sticks;
        int xValue = 0;
        int yValue = 0;
        int zValue = 0;

        //WebRequest myWebRequest;
        //WebResponse response;

        public Form1()
        {
            InitializeComponent();
            Initial_State();
        }

        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();

            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController,DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    foreach(DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                    }
                    sticks.Add(stick);
                }
                catch(DirectInputException)
                {

                }
            }

            return sticks.ToArray(); 
        }

        //joystick control mode
        private void stickHandle(Joystick stick, int id)
        {
            // get the state of the controller and sets button values into variables
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();

            yValue = state.Y;
            xValue = state.X;
            zValue = state.Z;

            ///handle with this value to get analog inputs

            if (xValue > 50 && xValue < 70 && yValue < -20)
            {
                //KeysPressed[3] = 1;
                label29.Visible = true;
                label16.Visible = false;
                label30.Visible = false;
                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_3; // Change the image of the Steering Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller

                //car steering angle
                label17.Visible = true;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = false;

                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;
                var a = new WebClient();
                var aa = a.DownloadString("http://192.168.0.149:1234/direction/6.8");
            }

            if (xValue < -50 && xValue > -70 && yValue < -20)
            {
                ///KeysPressed[3] = 1;
                label29.Visible = false;
                label30.Visible = true;
                label16.Visible = false;

                //car steering angle
                label17.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = true;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = false;

                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_2; // Change the image of the Steering Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;

                var b = new WebClient();
                var bb = b.DownloadString("http://192.168.0.149:1234/direction/8");
            }

            if (xValue > 70 && xValue < 100 && yValue < -20)
            {
                //KeysPressed[3] = 1;
                label29.Visible = true;
                label30.Visible = false;
                label16.Visible = false;

                //car steering angle
                label17.Visible = false;
                label31.Visible = true;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = false;

                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_3; // Change the image of the Steering Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;

                var c = new WebClient();
                var cc = c.DownloadString("http://192.168.0.149:1234/direction/5.5");
            }

            if (xValue < -70 && xValue > -100 && yValue < -20)
            {
                //KeysPressed[3] = 1;
                label29.Visible = false;
                label30.Visible = true;
                label16.Visible = false;

                //car steering angle
                label17.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = true;
                label35.Visible = false;
                label36.Visible = false;

                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_2; // Change the image of the Steering Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;

                var d = new WebClient();
                var dd = d.DownloadString("http://192.168.0.149:1234/direction/9.5");
            }
            
            if (yValue > 30 && yValue < 50 && xValue > 20)
            {
                //KeysPressed[3] = 1;
                label29.Visible = true;
                label30.Visible = false;
                label16.Visible = false;
                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_3; // Change the image of the Steering Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;

                //car steering angle
                label17.Visible = false;
                label31.Visible = false;
                label32.Visible = true;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = false;

                var e = new WebClient();
                var ee = e.DownloadString("http://192.168.0.149:1234/direction/4.5");
            }
            
            if (yValue > 30 && yValue < 50 && xValue < -20)
            {
                //KeysPressed[3] = 1;
                label30.Visible = true;
                label16.Visible = false;
                label29.Visible = false;

                //car steering angle
                label17.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = true;
                label36.Visible = false;

                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_2; // Change the image of the Steering Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;

                var f = new WebClient();
                var ff = f.DownloadString("http://192.168.0.149:1234/direction/10.5");
            }
            
            ///neutral possition
            if (xValue < 30 && xValue > -10 && yValue < -20)
            {
                label16.Visible = true;
                label29.Visible = false;
                label30.Visible = false;

                //car steering angle
                label17.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = true;

                picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel; //Change the image of the Sterring Wheel
                joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                keyboard_pic.Visible = false;
                joystick_pic.Visible = true;

                var g = new WebClient();
                var gg = g.DownloadString("http://192.168.0.149:1234/direction/7.3");
            }

            bool[] buttons = state.GetButtons();
            if (id == 0)
            {
                if (buttons[0])
                {
                    //KeysPressed[0] = 1;
                    label13.Visible = true; //enable label for running car
                    label28.Visible = false; //dissable label for stopped car
                    joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                    keyboard_pic.Visible = false;
                    joystick_pic.Visible = true;

                    if (gear == 1)
                    {
                        var h = new WebClient();
                        var hh = h.DownloadString("http://192.168.0.149:1234/speed/7.26");
                    }
                    if (gear == 2)
                    {
                        var i = new WebClient();
                        var ii = i.DownloadString("http://192.168.0.149:1234/speed/7.6");
                    }
                    if (gear == 3)
                    {
                        var j = new WebClient();
                        var jj = j.DownloadString("http://192.168.0.149:1234/speed/8");
                    }
                    if (gear == 4)
                    {
                        var k = new WebClient();
                        var kk = k.DownloadString("http://192.168.0.149:1234/speed/8.5");
                    }
                    if (gear == 5)
                    {
                        var l = new WebClient();
                        var ll = l.DownloadString("http://192.168.0.149:1234/speed/9.5");
                    }
                }


                if (!buttons[0])
                {
                    //KeysPressed[0] = 0;
                    label13.Visible = false; //dissable label for running car
                    label28.Visible = true; //enable label for stopped car
                    var m = new WebClient();
                    var mm = m.DownloadString("http://192.168.0.149:1234/speed/6.8");
                }

                if (buttons[1])
                {
                    //KeysPressed[1] = 1;
                    joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                    keyboard_pic.Visible = false;
                    joystick_pic.Visible = true;

                    var n = new WebClient();
                    var nn = n.DownloadString("http://192.168.0.149:1234/speed/3.5");
                }

                if (!buttons[1])
                {
                    //KeysPressed[1] = 0;
                    //var o = new WebClient();
                    //var oo = o.DownloadString("http://192.168.0.149:1234/speed/3.5");
                }
                if (buttons[5])
                {
                    if (gear < gearMAX) // Increase the gear if it is possible to be increased
                        gear++;
                    joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                    keyboard_pic.Visible = false;
                    joystick_pic.Visible = true;

                    lManualGearValueUpdate(); // Update the lManualGear label
                }
                if (!buttons[5])
                {
                    //KeysPressed[4] = 0;
                }
                if (buttons[4])
                {
                    //KeysPressed[5] = 1;
                    joystick_pic.Image = GUI.Properties.Resources.joystick; // Change the image of the joystick xbox controller
                    keyboard_pic.Visible = false;
                    joystick_pic.Visible = true;

                    if (gear > gearMIN) // Decrease the gear if it is possible to be decreased
                        gear--;
                    lManualGearValueUpdate(); // Update the lManualGear label
                }
                if (!buttons[4])
                {
                    //KeysPressed[5] = 0;
                }
            }
        }
        

        private void Initial_State()
        {
            // Describe the Initial State of all Items of the GUI

            // 'Setup & Test' Tab
            bConnectCar.Enabled = true;

            // 'Manual Driving' Tab
            bManualStart.Enabled = true; // Manual Start Button is Enabled
            bManualStop.Enabled = false; // Manual Stop Button is Disabled
            lManualControlsTitle.Enabled = true; // Manual Controls Label is Enabled
            lManualControlsEnum.Enabled = true; // Manual Controls Enumeration Label is Enabled
            lManualControlsEnum.Text = "-"; // Manual Controls Enumeration Label is initialized with "-" symbol
            tabControlMain.KeyDown -= new KeyEventHandler(tabControlMain_KeyDown); // Disable KeyDown event
            tabControlMain.KeyUp -= new KeyEventHandler(tabControlMain_KeyUp); // Disable KeyUp event
            gear = gearMIN; // Start with minimum gear
            lManualGearValue.Text = "-"; // Manual Gear Label is initialized with "-" symbol
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = GetSticks();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void bAutoStart_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bConnectCar_Click(object sender, EventArgs e)
        {
   
        }

        private void bManualStart_Click(object sender, EventArgs e)
        {
            // Manual Start Button Clicked

            label11.Visible = true; //connected and disconnected status with server
            label26.Visible = false; //connected and disconnected status with client
            label27.Visible = true;
            label12.Visible = false;
            label13.Visible = false;
            label28.Visible = true;

            ///start joystick timer_tick
            GetSticks();
            sticks = GetSticks();
            timer2.Enabled = true;

            //enable wheel pic
            picManualSteeringWheel.Visible = true;          

            //reset timer for a new start
            ms = 0;
            sec = 0;
            min = 0;
            hour = 0;
            label14.Text = 0 + ":" + 00 + ":" + 00 + ":" + 00.ToString();

            //start timer for stopwatch
            timer1.Start();

            bManualStart.Enabled = false; // Manual Start Button is Disabled
            bManualStop.Enabled = true; // Manual Stop Button is Enabled
            tabControlMain.KeyDown += new KeyEventHandler(tabControlMain_KeyDown); // Enable KeyDown event
            tabControlMain.KeyUp += new KeyEventHandler(tabControlMain_KeyUp); // Enable KeyUp event
            lManualGearValue.Text = gear.ToString(); // Write the initial gear value

            var client = new WebClient();
            var content = client.DownloadString("http://192.168.0.149:1234/speed/6.8");
            var a = new WebClient();          
            var aa = a.DownloadString("http://192.168.0.149:1234/direction/7.3");
        }

        private void bManualStop_Click(object sender, EventArgs e)
        {
            // Manual Stop Button Clicked

            label11.Visible = false;  //connected and disconnected status with server
            label26.Visible = true;  //connected and disconnected status with client
            label27.Visible = false;
            label12.Visible = true;
            label13.Visible = false;
            label28.Visible = true;

            //stop timer for stopwatch
            timer1.Stop();

            //stop timer for joystick
            timer2.Stop();
            timer2.Enabled = false;

            bManualStart.Enabled = true; // Manual Start Button is Enabled
            bManualStop.Enabled = false; // Manual Stop Button is Disabled
            tabControlMain.KeyDown -= new KeyEventHandler(tabControlMain_KeyDown);  // Disable KeyDown event
            tabControlMain.KeyUp -= new KeyEventHandler(tabControlMain_KeyUp); // Disable KeyUp event
            lManualGearValue.Text = "-"; // Write the "-" symbol in gear value label

            var client = new WebClient();
            var content = client.DownloadString("http://192.168.0.149:1234/speed/6.8");
            var p = new WebClient();
            var pp = p.DownloadString("http://192.168.0.149:1234/direction/7.3");
        }

        private void lManualControlsEnumUpdate()
        {
            lManualControlsEnum.Text = "";

            // Check which key is pressed and write its name
            for (int i = 0; i < KeysNumber; ++i)
                if (KeysPressed[i] == 1)
                    lManualControlsEnum.Text += KeysPressedName[i] + " ";

            if (lManualControlsEnum.Text == "")
            {
                lManualControlsEnum.Text = "-";
                var r = new WebClient();
                var rr = r.DownloadString("http://192.168.0.149:1234/speed/6.8"); // Send command - Decrease speed slowly
                var s = new WebClient();
                var ss = s.DownloadString("http://192.168.0.149:1234/direction/7.3");
            }
        }

        private void tabControlMain_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true; // Diable left and right Navigation in tabControlMain

            // Check which Key is pressed and Mark that key in KeysPressed array
            switch (e.KeyData)
            {
                case System.Windows.Forms.Keys.Up:
                    {
                        KeysPressed[0] = 1;
                        label13.Visible = true; //enable label for running car
                        label28.Visible = false; //dissable label for stopped car
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        switch (gear) // Send command - Increase speed - according to the gear
                        {
                            case 1: 
                                {
                                    var t = new WebClient();
                                    var tt = t.DownloadString("http://192.168.0.149:1234/speed/7.26");
                                    break; 
                                }
                            case 2: 
                                {
                                    var u = new WebClient();
                                    var uu = u.DownloadString("http://192.168.0.149:1234/speed/7.6");
                                    break; 
                                }
                            case 3: 
                                {
                                    var v = new WebClient();
                                    var vv = v.DownloadString("http://192.168.0.149:1234/speed/8");
                                    break; 
                                }
                            case 4: 
                                {
                                    var w = new WebClient();
                                    var ww = w.DownloadString("http://192.168.0.149:1234/speed/8.5");
                                    break; 
                                }
                            case 5: 
                                {
                                    var x = new WebClient();
                                    var xx = x.DownloadString("http://192.168.0.149:1234/speed/9.5");
                                    break; 
                                }
                        }
                        break;
                    }
                case System.Windows.Forms.Keys.Down:
                    {
                        KeysPressed[1] = 1;
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        var y= new WebClient();
                        var yy = y.DownloadString("http://192.168.0.149:1234/speed/3.5"); // Send command - Decrease speed rapidly

                        break;
                    }
                case System.Windows.Forms.Keys.Left:
                    {
                        KeysPressed[2] = 1;
                        label30.Visible = true;
                        picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_2; // Change the image of the Steering Wheel
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        var z = new WebClient();
                        var zz = z.DownloadString("http://192.168.0.149:1234/direction/9.5"); // Send command - Turn left
                      
                        break;
                    }
                case System.Windows.Forms.Keys.Right:
                    {
                        KeysPressed[3] = 1;
                        label29.Visible = true;
                        picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel_3; // Change the image of the Steering Wheel
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        var aa = new WebClient();
                        var aaa = aa.DownloadString("http://192.168.0.149:1234/direction/4"); // Send command - Turn right
                       
                        break;
                    }
                case System.Windows.Forms.Keys.S:
                    {
                        KeysPressed[8] = 1;
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        var bb = new WebClient();
                        var bbb = bb.DownloadString("http://192.168.0.149:1234/direction/7.3");

                        break;
                    }
                case System.Windows.Forms.Keys.A:
                    {
                        KeysPressed[4] = 1;
                        if (gear < gearMAX) // Increase the gear if it is possible to be increased
                            gear++;
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        lManualGearValueUpdate(); // Update the lManualGear label
                        break;
                    }
                case System.Windows.Forms.Keys.D:
                    {
                        KeysPressed[5] = 1;
                        if (gear > gearMIN) // Decrease the gear if it is possible to be decreased
                            gear--;
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        lManualGearValueUpdate(); // Update the lManualGear label
                        break;
                    }
                case System.Windows.Forms.Keys.W:
                    {
                        KeysPressed[6] = 1;
                        var cc = new WebClient();
                        var ccc = cc.DownloadString("http://192.168.0.149:1234/speed/6.5"); // Send command - Decrease speed rapidly
                        var dd = new WebClient();
                        var ddd = dd.DownloadString("http://192.168.0.149:1234/direction/7.3");
                        keyboard_pic.Image = GUI.Properties.Resources.keyboard; // Change the image with keyboard picture
                        keyboard_pic.Visible = true;
                        joystick_pic.Visible = false;
                        joystick_pic.Visible = true;
                        break;
                    }
            }

            lManualControlsEnumUpdate(); // Update the lManualControlsEnum label
        }

        private void lManualGearValueUpdate()
        {
            lManualGearValue.Text = gear.ToString();
        }

        private void tabControlMain_KeyUp(object sender, KeyEventArgs e)
        {
            // Check which Key is not pressed anymore and Unmark that key in KeysPressed array
            switch (e.KeyData)
            {
                case System.Windows.Forms.Keys.Up:
                    {
                        KeysPressed[0] = 0;
                        label13.Visible = false; //dissable label for running car
                        label28.Visible = true; //enable label for stopped car
                        //var n = new WebClient();
                        //var nn = n.DownloadString("http://192.168.0.149:1234/speed/6.8");
                        break;
                    }
                case System.Windows.Forms.Keys.Down:
                    {
                        KeysPressed[1] = 0;
                        //var n = new WebClient();
                        //var nn = n.DownloadString("http://192.168.0.149:1234/speed/6.8");

                        break;
                    }
                case System.Windows.Forms.Keys.RShiftKey:
                    {
                        KeysPressed[8] = 0;
                        var x = new WebClient();
                        var xx = x.DownloadString("http://192.168.0.149:1234/direction/7.3");
                        break;
                    }
                case System.Windows.Forms.Keys.Left:
                    {
                        KeysPressed[2] = 0;
                        label30.Visible = false; 
                        picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel; // change the image of the Steering Wheel
                        var q = new WebClient();
                        var qq = q.DownloadString("http://192.168.0.149:1234/direction/7.3");
                        break;
                    }
                case System.Windows.Forms.Keys.Right:
                    {
                        KeysPressed[3] = 0;
                        label29.Visible = false;
                        picManualSteeringWheel.Image = GUI.Properties.Resources.steering_wheel; // change the image of the Steering Wheel
                        var r = new WebClient();
                        var rr = r.DownloadString("http://192.168.0.149:1234/direction/7.3");
                        break;
                    }
                case System.Windows.Forms.Keys.A:
                    {
                        KeysPressed[4] = 0;
                        break;
                    }
                case System.Windows.Forms.Keys.D:
                    {
                        KeysPressed[5] = 0;
                        break;
                    }
                case System.Windows.Forms.Keys.W:
                    {
                        KeysPressed[6] = 0;
                        break;
                    }
            }

            lManualControlsEnumUpdate(); // Update the lManualControlsEnum label
        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = hour + ":" + min + ":" + sec + ":" + ms.ToString();
            ms++;
            if (ms > 10)
            {
                sec++;
                ms = 0;
            }
            else
            {
                ms++;
            } 
            if (sec > 60)
            {
                min++;
                sec = 0;
            }
            if (min > 60)
            {
                hour++;
                min = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i=0; i< sticks.Length; i++)
            {
                stickHandle(sticks[i], i);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }
}