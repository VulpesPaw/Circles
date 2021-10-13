using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Threading;


/* Real world application:
 * https://www.facebook.com/jorgen.palsson.58/videos/1482170481917293/ 
 * Real world application, the program that we're useing in that instance was a first time prototype and got some small fixes after that.
 * That program was a JS protype me and my father built in a futile atempt to teach the JavaScript
 */

/* Future plans:
 * Move cirlces side to side / up and down
 * Set color of cirlse
 * visaul user validation ie: value to large --> default value and textbox background turns red
 * Center setup-circles compared to right side of grpbxControls and the right side of window
 */

namespace CirclesCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int canvasTop; // Value of the canvas top of the draw-canvas (px)
        int canvasHeight; // Value of the height of the draw-canvas (px)               
        public bool drawStart = true; // Determines whether OnPaint should paint or not
        CancellationTokenSource circleLoopCancelToken = new CancellationTokenSource(); // Creates and refreshes canceltoken (needs to be refreshed to be able to cancel it)
        CancellationTokenSource timeCancelToken; // Creates an unfreshed canceltoken
        //Cancellation Tokens have more function than a bool if you want to use it to cancel stuff. It's also thread safe and better for asynchronous.
        Thread threadDraw;
        
        enum canvasTokenCollection // Used to determine whether doubleclicker should set top, height or nothing at all
        {
            none = 0,
            setTop = 1,
            setHeight = 2,
            noneTwo = 3,
        }       
        enum lastCanvasChangeCollection //Used to determine whether textbox or doubleclicker was last to change the canvas values
        {
            none = 0,
            textbox = 1,
            doubleclicker = 2,
            noneTwo = 3,
        }
        canvasTokenCollection canvasToken = canvasTokenCollection.none;
        lastCanvasChangeCollection lastCanvasChangeTop = lastCanvasChangeCollection.none;
        lastCanvasChangeCollection lastCanvasChangeHeight = lastCanvasChangeCollection.none;


        protected override void OnPaint(PaintEventArgs e) // Paints the circles at setupscreen
        {
            if (drawStart == true) // Gives the possibility to 'turn off' onPaint
            {
                int maxSize = getMaxSize();
                int minSize = getMinSize();
                Graphics g = e.Graphics;
                SolidBrush wipeB = new SolidBrush(Color.Black);
                SolidBrush brushR = new SolidBrush(Color.Red);
                SolidBrush brushB = new SolidBrush(Color.Blue);
                g.FillRectangle(wipeB, 0, getCanvasY(), ClientRectangle.Width, getCanvasHeight()); // Draws a blank page above previose work, this does not casue a major buildup in ram due to c#'s garbage collection
                g.FillEllipse(brushR, (ClientRectangle.Width / 5) * 2 - maxSize / 2, ClientRectangle.Height / 2 - maxSize / 2, maxSize, maxSize); /*Draws the maximun cirle*/
                g.FillEllipse(brushB, (ClientRectangle.Width / 5) * 3 - minSize / 2, ClientRectangle.Height / 2 - minSize / 2, minSize, minSize); /* Draws minimum circle*/
            }
        }

        private void btnStart_Click(object sender, EventArgs e) // Initiates the draw-sequence
        {
            circleLoopCancelToken = new CancellationTokenSource(); // Refreshes the cancelation token

            if (threadDraw == null || threadDraw.IsAlive != true) // Checks if thread is not running
            {
                threadDraw = new Thread(new ThreadStart(drawAllCircles)); // Setups the aproitate thread

                System.Diagnostics.Debug.WriteLine("--Thread Prept--");

            }

            if (threadDraw.IsAlive != true) //Checks if the thread is alive; avoids dupplicates
            {
                threadDraw.IsBackground = true; // Makes the thread running in the background which also makes running threads to trun of if application is exited
                threadDraw.Start(); // Starts thread

                System.Diagnostics.Debug.WriteLine("--Thread Started--");
            }
        }

        private void drawAllCircles()
        {
            this.Invoke((MethodInvoker)delegate {
                /* Only the UI-thread (aka mainthread) can change UI elements, thereby a seperate thread cannot change any UI-elements. 
                 A way to go around the problem is to use invoke (in my case methodInvoker). If you invoke, in this case a method,
                 you basicly askes the main thread to run the invoked code (or in my case a method) when it is free, you may use BeginInvoke if you doesn't want to wait on freetime in UI-thread.
                 You may read an amazing explenation on how it works here(see Threading Model UI, currently second heighes rated commet posted by Ryszard Dżegan):
                 https://stackoverflow.com/questions/142003/cross-thread-operation-not-valid-control-accessed-from-a-thread-other-than-the#142108*/
                guiVisibilty(0); // Makes my UI elements invisible
            });

            SolidBrush brush = new SolidBrush(Color.White);

            DrawCircles draw = new DrawCircles // Mass declaration for the draw-class
            {
                g = genGr(),
                brush = brush,
                cliH = ClientRectangle.Height,
                cliW = ClientRectangle.Width,
                maxSize = getMaxSize(),
                minSize = getMinSize(),
                showTime = getShowTime(),
                hideTime = getHideTime(),
                canY = getCanvasY(),
                canHi = getCanvasHeight(),
            };

            drawStart = false; // Stops OnPaint from painting
            int circleAmount = getCircleAmount();
            Graphics g = genGr();
            SolidBrush wipeB = new SolidBrush(Color.Black);
            g.FillRectangle(wipeB, 0, 0, ClientRectangle.Width, ClientRectangle.Height); // Cleans canvas 
            sleepCanclePos(getTimeBeforeStart());

            for (int i = 0; i < circleAmount && !circleLoopCancelToken.IsCancellationRequested; i++) // Draws circles untill either it has reached circleAmount or if canceld by canceltoken
            {
                draw.drawCircles();
            }

            draw.reDraw(); // Draws after-image

            this.Invoke((MethodInvoker)delegate { //Transparent background doesn't exist in .NET with exception if I'd use a picturebox, thereby the labebackground is not transparent
                lblContinue.Font = new Font("Baskerville Old Face", ClientRectangle.Height / 30); //Makes the label more dynamic
                lblContinue.Location = new Point(ClientRectangle.Width / 2 - lblContinue.Size.Width / 2, (int)(ClientRectangle.Height * 0.05)); //Places the label in the middle top of the screen                
                lblContinue.Visible = true;
            });

            sleepCanclePos(45000);

            this.Invoke((MethodInvoker)delegate {
                lblContinue.Visible = false;
            });

            this.Invoke((MethodInvoker)delegate {
                guiVisibilty(1);
            });

            drawStart = true;
            Invalidate();
        }

        private Graphics genGr() // Generates graphics
        {
            Graphics g = base.CreateGraphics();
            return g;
        }

        /* 
         * Puts the thread to sleep with the possibility to cancel the sleeping process
         * 
         * OBS! NEVER USE IN UI-THREAD
         */
        private void sleepCanclePos(int millisecondsDelay)
        {
            timeCancelToken = new CancellationTokenSource(); // This makes it possible to cancel the method only while sleepCanclePos is running
            for (int i = 0; i < millisecondsDelay / 500 && !timeCancelToken.IsCancellationRequested; i++) // Enables me to cancel the sleepcycle if wished
            {
                System.Threading.Thread.Sleep(500);
            }
            timeCancelToken.Cancel(); // If this method is runned muliple times this keeps the cancellationtoken from being used outside of the method 
        }

        private void btnFullscreen_Click(object sender, EventArgs e) // Toggles between fullscreen and normal screen
        {
            if (WindowState == FormWindowState.Normal || this.FormBorderStyle != FormBorderStyle.None)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                btnFullscreen.Text = "Fullscreen (Esc)";
            } else
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Sizable;
                btnFullscreen.Text = "Fullscreen (F11)";
            }
            Invalidate();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) // If you drag the program to the top of your window it's just kinda fullscreen, makes it into true fullscreen
        {
            if (WindowState == FormWindowState.Maximized && this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                btnFullscreen.Text = "Fullscreen (Esc)";
                Invalidate();
            }
        }
        
        /*
         * Changes the visibility of controls
         * 
         * If state = 0 --> contols.visible
         * If state = 1 --> controls.visible = true
         * If state = null --> default: state = 3 --> controls.visible inverts
         * state = 3 makes input optional
         */
        private void guiVisibilty(int state = 3)
        {
            tbxDecoy.Select();/*An always invisible readonly textbox meant to avoid you from writing in other textboxes if guiVisibility() is invisible */

            switch (state)
            {
                case 0:
                    grpBxControls.Visible = false;
                    btnFullscreen.Visible = false;
                    btnExit.Visible = false;
                    lblVers.Visible = false;
                    lblSpaceStop.Visible = false;
                    break;
                case 1:
                    grpBxControls.Visible = true;
                    btnFullscreen.Visible = true;
                    btnExit.Visible = true;
                    lblVers.Visible = true;
                    lblSpaceStop.Visible = true;
                    break;
                default: // case 3: Inverts visibility
                    grpBxControls.Visible = grpBxControls.Visible ? false : true;
                    btnFullscreen.Visible = grpBxControls.Visible ? true : false;
                    btnExit.Visible = grpBxControls.Visible ? true : false;
                    lblVers.Visible = grpBxControls.Visible ? true : false;
                    lblSpaceStop.Visible = grpBxControls.Visible ? true : false;
                    break;
            }

            /*
             * Keeps you from writing while executing draw-time
             * Loops through all textboxes of groupcontrol
             */
            foreach (TextBoxBase c in grpBxControls.Controls.OfType<TextBoxBase>())
            {
                if (grpBxControls.Visible == false)
                {
                    c.ReadOnly = true;
                } else
                {
                    c.ReadOnly = false;
                }
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (canvasToken > 0)
            {
                lastCanvasChangeTop = lastCanvasChangeCollection.doubleclicker; // Says that clicker was last to change canvas
                lastCanvasChangeHeight = lastCanvasChangeCollection.doubleclicker; // Says that clicker was last to change canvas

                switch (canvasToken)
                {
                    case canvasTokenCollection.setTop:
                        canvasTop = MousePosition.Y;
                        tbxCanvasTop.Text = canvasTop.ToString();
                        canvasToken++;
                        break;

                    case canvasTokenCollection.setHeight:
                        if ((MousePosition.Y - canvasTop) > 20 && (ClientRectangle.Height) > (MousePosition.Y + 20) && !(MousePosition.Y > ClientRectangle.Height))
                        {
                            canvasHeight = MousePosition.Y - canvasTop;
                        } else
                        {
                            canvasHeight = ClientRectangle.Height - canvasTop;
                        }

                        tbxCanvasHeight.Text = canvasHeight.ToString();
                        canvasToken++;
                        break;
                }
            }
            Invalidate();
        }

        private void btnCanvasSize_Click(object sender, EventArgs e)
        {
            // Basicly a false/true statement which allows the Form1_MouseDoubleClick to perform its if-statement
            canvasToken = (WindowState == FormWindowState.Normal || this.FormBorderStyle != FormBorderStyle.None) ? canvasTokenCollection.none : canvasTokenCollection.setTop;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //Keypressess / keyboard-shortcuts
        {
            if (e.KeyCode == Keys.Space)
            {
                circleLoopCancelToken.Cancel();

                if (timeCancelToken != null && !timeCancelToken.IsCancellationRequested) // Ensure that we doesn't cancel what is already canceled
                {
                    timeCancelToken.Cancel();
                }
            }
            if (e.KeyCode == Keys.V) // Creates the possibillity to enable gui on the fly, useful for debugs
            {
                guiVisibilty();
            }
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                btnExit.PerformClick(); // With .PerformClick() we use btnFullscreen as a mehtod
            }
            if (e.KeyCode == Keys.F11)
            {
                btnFullscreen.PerformClick(); // With .PerformClick() we use btnFullscreen as a mehtod
            }
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            if (e.KeyCode == Keys.F2) // Usefull debug-window
            {
                StringBuilder debugMessage = new StringBuilder(); // Makes it possible to build messages including with if-statements 

                debugMessage.Append(
                    "---Window Sate---" + "\n" +
                    "FormWindowState: " + this.WindowState + "\n" +
                    "FormBorderStyle: " + this.FormBorderStyle + "\n" + "\n" +

                    "---Window Resolution---" + "\n" +
                    "WindowHeight: " + ClientRectangle.Height + "\n" +
                    "WindowWidth: " + ClientRectangle.Width + "\n" + "\n" +

                    "---Cancellation Token---" + "\n" +
                    "circleLoopCancelToken: " + circleLoopCancelToken.IsCancellationRequested + "\n"
                    );

                if (timeCancelToken != null)
                {
                    debugMessage.Append("timeCancelToken: " + timeCancelToken.IsCancellationRequested + "\n" + "\n");
                } else
                {
                    debugMessage.Append("\n");
                }

                if (threadDraw != null) // If the thread is null it cannot check for other values because the 'instant was set to null' which leads to errors 
                {
                    debugMessage.Append("---ThreadState---" + "\n" +
                      "TheadIsAlive: " + threadDraw.IsAlive + "\n" +
                      "ThreadState: " + threadDraw.ThreadState + "\n" + "\n");
                };

                if (grpBxControls.Visible || lblVers.Visible || btnFullscreen.Visible)
                {
                    debugMessage.AppendLine("--Element Visiblilty--");
                }
                if (grpBxControls.Visible)
                {
                    debugMessage.AppendLine("grpBxControls: true");
                } else
                {
                    debugMessage.AppendLine("grpBxControls: false");
                }
                if (lblVers.Visible)
                {
                    debugMessage.AppendLine("lblVers: true");
                } else
                {
                    debugMessage.AppendLine("lblVers: false");
                }
                if (btnFullscreen.Visible)
                {
                    debugMessage.AppendLine("btnFullscreen: true");
                } else
                {
                    debugMessage.AppendLine("btnFullscreen: false");
                }
                if (grpBxControls.Visible || lblVers.Visible || btnFullscreen.Visible)
                {
                    debugMessage.Append("\n");
                }

                debugMessage.Append(
                  "--Common Cricle Values--" + "\n" +
                  "Time before start: " + getTimeBeforeStart() + "\n" +
                  "Time shown: " + getShowTime() + "\n" +
                  "Time hidden: " + getHideTime() + "\n" +
                  "Circle amount: " + getCircleAmount() + "\n" +
                  "Max circle size: " + getMaxSize() + "\n" +
                  "Min circle size: " + getMinSize() + "\n" +
                  "Canvas top (Y-position): " + getCanvasY() + "\n" +
                  "Canvas height (Y-position): " + getCanvasHeight() + "\n" + "\n"
                  );

                MessageBox.Show(debugMessage.ToString());

                debugMessage.Clear();
            }
        }


        /*Get and Validation Methods*/

        private int getTimeBeforeStart()
        {
            int parsedValue;
            int beforeStartTime = 9500;
            if (!int.TryParse(tbxMinSize.Text, out parsedValue) || (int.Parse(tbxMinSize.Text) == 0))
            {
                beforeStartTime = 9500;
            } else
            {
                beforeStartTime = int.Parse(tbxTimeBeforeStart.Text);
            }
            return beforeStartTime;
        }

        private int getShowTime()
        {
            int parsedValue;
            int showTime;
            if (!int.TryParse(tbxTimeShow.Text, out parsedValue) || (int.Parse(tbxTimeShow.Text) == 0))
            {
                showTime = 3000;
            } else
            {
                showTime = int.Parse(tbxTimeShow.Text);
            }
            return showTime;
        }

        private int getHideTime()
        {
            int parsedValue;
            int hideTime;
            if (!int.TryParse(tbxTimeHide.Text, out parsedValue) || (int.Parse(tbxTimeHide.Text) == 0))
            {
                hideTime = 4000;
            } else
            {
                hideTime = int.Parse(tbxTimeHide.Text);
            }
            return hideTime;
        }

        private int getCircleAmount()
        {
            int parsedValue;
            int circleAmount;
            if (!int.TryParse(tbxCircleAmount.Text, out parsedValue) || (int.Parse(tbxCircleAmount.Text) == 0) || tbxCircleAmount.Text == "Empty = Endless")
            {
                circleAmount = 999999999; // Equivalent to 222 years, so basiclly endless
            } else
            {
                circleAmount = int.Parse(tbxCircleAmount.Text);
            }
            return circleAmount;
        }
        private int getMaxSize()
        {
            int parsedValue;
            int maxSize;
            // Checks if max-size textbox are empty or null. If it's true, it's given a default value. tryPared checks if it contains anything other than numbers
            if (!int.TryParse(tbxMaxSize.Text, out parsedValue) || (int.Parse(tbxMaxSize.Text) == 0))
            {
                maxSize = 250;
            } else
            {
                maxSize = int.Parse(tbxMaxSize.Text);
            }

            if (maxSize >= getCanvasHeight())
            {
                maxSize = (int)(0.7 * getCanvasHeight()); // In order to avoid cirlce to be larger than canvas
            }
            return maxSize;
        }

        private int getMinSize()
        {
            int parsedValue;
            int minSize;
            // Checks if max-size textbox are empty or null. If it's true, it's given a default value. tryPared checks if it contains anything other than numbers
            if (!int.TryParse(tbxMinSize.Text, out parsedValue) || (int.Parse(tbxMinSize.Text) == 0))
            {
                minSize = 75;
            } else
            {
                minSize = int.Parse(tbxMinSize.Text);
            }

            if (minSize > getMaxSize()) // Makes sure that min-size isn't larger than maxsize
            {
                minSize = getMaxSize();
            }
            return minSize;
        }

        private int getCanvasY()
        {
            int y;
            if ((canvasTop < 10 || WindowState == FormWindowState.Normal || this.FormBorderStyle != FormBorderStyle.None) && tbxCanvasTop.Text != null &&
                lastCanvasChangeTop != lastCanvasChangeCollection.textbox && lastCanvasChangeTop != lastCanvasChangeCollection.doubleclicker)
            {
                y = 0;
            } else if (lastCanvasChangeTop == lastCanvasChangeCollection.textbox)
            {
                y = int.Parse(tbxCanvasTop.Text);
            } else
            {
                y = canvasTop;
            }

            return y;
        }

        private int getCanvasHeight()
        {
            int y;
            if ((canvasHeight < 10 || WindowState == FormWindowState.Normal || this.FormBorderStyle != FormBorderStyle.None) && tbxCanvasTop.Text != null &&
                lastCanvasChangeHeight != lastCanvasChangeCollection.textbox && lastCanvasChangeHeight != lastCanvasChangeCollection.textbox)
            {
                y = ClientRectangle.Height;
            } else if (lastCanvasChangeHeight == lastCanvasChangeCollection.textbox)
            {
                y = int.Parse(tbxCanvasHeight.Text);
            } else
            {
                y = canvasHeight;
            }

            return y;
        }


        /* Text changed methods
         *
         * If text is changed OnPaint will redraw and thus load new value of maxSize
         */

        private void tbxMaxSize_TextChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void tbxMinSize_TextChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void tbxCanvasHeight_TextChanged(object sender, EventArgs e)
        {
            lastCanvasChangeHeight = lastCanvasChangeCollection.textbox; // Tells that textbox was last to change canvas value
            Invalidate();
        }

        private void tbxCanvasTop_TextChanged(object sender, EventArgs e)
        {
            lastCanvasChangeTop = lastCanvasChangeCollection.textbox; // Tells that textbox was last to change canvas value
            Invalidate();
        }


        /* Placeholder / Watermark methods*/

        private void tbxCircleAmount_Enter(object sender, EventArgs e)
        {
            if (tbxCircleAmount.Text == "Empty = Endless")
            {
                tbxCircleAmount.Text = "";
                tbxCircleAmount.ForeColor = Color.Black;
            }
        }

        private void tbxCircleAmount_Leave(object sender, EventArgs e)
        {
            if (tbxCircleAmount.Text == "")
            {
                tbxCircleAmount.Text = "Empty = Endless";
                tbxCircleAmount.ForeColor = Color.Gray;
            }
        }

        /* Closing arguments */
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Closes the running application including running threads
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
