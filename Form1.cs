using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace platformer_final
{
    public partial class Form1 : Form
    {
        Class1 model = new Class1();

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                model.goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                model.goright = false;
            }
            if(model.jumping == true)
            {
                model.jumping = false;
            }
            if(e.KeyCode == Keys.Enter && model.GameOver == true)
            {
                RestartGame();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                model.goleft = true;
            }
            if (e.KeyCode==Keys.Right)
            {
                model.goright = true;
            }
            if(e.KeyCode == Keys.Space && model.jumping == false)
            {
                model.jumping = true;
            }
        }

        private void MainGameEvent(object sender, EventArgs e)
        {
            label1.Text = "Score: " + model.score;

            player.Top += model.jumpSpeed;

            if(model.goleft == true)
            {
                player.Left -= model.player_speed;

            }
            if(model.goright == true)
            {
                player.Left += model.player_speed;
            }

            if(model.jumping == true && model.force < 0)
            {
                model.jumping = false;

            }
            if(model.jumping == true)
            {
                model.jumpSpeed = -8;
                model.force -= 1;
            }
            else
            {
                model.jumpSpeed = 10;
            }
            foreach(Control x in Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag == "platform")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds))
                        {
                            model.force = 8;
                            player.Top = x.Top - player.Height;

                            if((string)x.Name == "horizontalPlatform" && model.goleft ==false || (string)x.Name == "horizontalPlatform" && model.goright == false)
                            {
                                player.Left -= model.horizontalSpeed;
                            }


                        }

                        x.BringToFront();
                    }
                    if ((string)x.Tag == "coin")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            model.score++;
                        }
                    }

                    if((string)x.Tag=="enemy")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            model.GameOver = true;
                            label1.Text = "Score: " + model.score + Environment.NewLine + "You were killed hehe";

                        }
                    }
                }

                
            }

            horizontalPlatform.Left -= model.horizontalSpeed;
            if(horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                model.horizontalSpeed = -model.horizontalSpeed;
            }
            verticalPlatform.Top += model.verticalSpeed;
            if(verticalPlatform.Top < 100 || verticalPlatform.Top > 633)
            {
                model.verticalSpeed = -model.verticalSpeed;
            }

            enemyOne.Left -= model.enemyOneSpeed;
            if(enemyOne.Left< pictureBox7.Left || enemyOne.Left + enemyOne.Width > pictureBox7.Left + pictureBox7.Width)
            {
                model.enemyOneSpeed = -model.enemyOneSpeed;
            }
            enemyTwo.Left -= model.enemyTwoSpeed;
            if(enemyTwo.Left < pictureBox6.Left || enemyTwo.Left + enemyTwo.Width > pictureBox6.Left + pictureBox6.Width)
            {
                model.enemyTwoSpeed = -model.enemyTwoSpeed;
            }

            if(player.Top + player.Height > this.ClientSize.Height +50)
            {
                gameTimer.Stop();
                model.GameOver = true;
                label1.Text = "Score: " + model.score + Environment.NewLine + "You fell to your death hehe";

            }
            if(player.Bounds.IntersectsWith(door.Bounds) && model.score ==18 )
            {
                gameTimer.Stop();
                model.GameOver = true;
                label1.Text = "Score: " + model.score + Environment.NewLine + "You have done your quest or idk";

            }
            else
            {
                label1.Text = "Score: " + model.score + Environment.NewLine + "Collect all the golds";
            }
        }

        private void RestartGame()
        {
            model.jumping = false;
            model.goleft = false;
            model.goright = false;
            model.score = 0;

            label1.Text = "Score: " + model.score;

            foreach(Control x in Controls)
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

           
            player.Left = 30;
            player.Top = 732;
            
            enemyOne.Left = 452;
            enemyTwo.Left = 203;

            horizontalPlatform.Left = 410;
            verticalPlatform.Top = 622;

            gameTimer.Start();
        }
    }
}
