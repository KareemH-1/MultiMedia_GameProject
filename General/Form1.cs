using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace General
{
    public class Animation{
        public string name;
        public List<Bitmap> frames = new List<Bitmap>();
        public int frameDelay = 1;

        public void addFrame(Bitmap img)
        {
            frames.Add(img);
        }

    }
    public class AnimationController
    {
        public int currIdx =0;
        public int currAnim = 0;

        public int frameDelayCount = 0;
        public List<Animation> animations = new List<Animation>();

        public void addAnim(Animation anim)
        {
            animations.Add(anim);
        }

        public void changeAnimation(string name, int index)
        {
            int newAnim = -1;

            if (name == "")
            {
                if (index >= 0 && index < animations.Count)
                    newAnim = index;
            }
            else
            {
                for (int i = 0; i < animations.Count; i++)
                {
                    if (animations[i].name == name)
                    {
                        newAnim = i;
                        break;
                    }
                }
            }

            if (newAnim == -1)
            {
                MessageBox.Show("Animation not found");
                return;
            }

            if (currAnim != newAnim)
            {
                currAnim = newAnim;
                currIdx = 0;
                frameDelayCount = 0;
            }
        }
        public Bitmap playFrame()
        {
            Bitmap frame = null;

            if (currIdx >= animations[currAnim].frames.Count) currIdx = 0;
            if (animations[currAnim].frames.Count > 0)
            {
                frame = animations[currAnim].frames[currIdx];

                
            }

            frameDelayCount++;

            if (frameDelayCount >= animations[currAnim].frameDelay)
            {
                frameDelayCount = 0;

                if (currIdx < animations[currAnim].frames.Count - 1)
                    currIdx++;
                else
                    currIdx = 0;
            }

            return frame;
        }
    }

    public class rect
    {
        public float x , y;
        public float width, height;
      
    }

        

    public class Hero
    {
        public rect R = new rect();
        public float speed = 6f;

        public char moving = ' ';
        public bool isJumping = false;
        public bool isRunning = false;

        public int jumpHeight = 30;

        public AnimationController anim = new AnimationController();

        public void Draw(Graphics g)
        {
            g.DrawImage(anim.playFrame(), R.x, R.y, R.width, R.height);
        }
        public Hero(int startX , int startY , int w , int h)
        {
            R.x = startX;
            R.y = startY;
            R.width = w;
            R.height = h;

            createAnim();
            anim.changeAnimation("idle" , -1);
        }

        void createAnim()
        {
            string[] folders = {"attack", "critical_attack", "crouch", "death",
                "idle", "jump", "ladder_climbing", "running", "shield_defence",
                "sliding", "spell_cast", "taking_damage", "walking", "wall_sliding" };

            int[] numFrames = { 8, 8, 3, 12, 6, 16, 10, 8, 3, 8, 8, 4, 10, 4 };
            // C: \Users\User\source\repos\GameProject\General\bin\Debug\Characters\Hero\Blue\attack
            for (int i = 0; i < 14; i++)
            {
                Animation anim = new Animation();
                anim.name = folders[i];
                if (folders[i] == "walking") anim.frameDelay = 0;
                else if (folders[i] == "idle") anim.frameDelay = 2;
                string path = "Characters/Hero/Blue/" + folders[i] + "/";
                for(int j =1; j <= numFrames[i]; j++)
                {
                    Bitmap img = new Bitmap(path + j.ToString() + ".png");
                    anim.frames.Add(img);
                }
                this.anim.addAnim(anim);
            }

        }
        public void move()
        {
            float speedM = speed;
            if (isRunning == true) speedM = speed * 2f;
            if (moving == 'l') R.x -= speedM;
            else if(moving == 'r') R.x += speedM;

            if (moving == ' ')
            {
                anim.changeAnimation("idle", -1);
            }
            else
            {
                if (isRunning== true)
                    anim.changeAnimation("running", -1);
                else
                    anim.changeAnimation("walking", -1);
            }

        }
    }


    public partial class Form1 : Form
    {
        Bitmap off;
        Random RR = new Random();

        Hero hero;
        Timer timer = new Timer();

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && hero.moving == 'r')
            {
                hero.moving = ' ';

            }
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && hero.moving == 'l')
            {
                hero.moving = ' ';

            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                hero.isRunning = false;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                hero.moving = 'r';
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                hero.moving = 'l';

            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                hero.isRunning = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Text = hero.isRunning.ToString();
            hero.move();
            drawDubb(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);


            hero = new Hero(30, this.ClientSize.Height - 150, 150, 150);
            drawDubb(this.CreateGraphics());

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawDubb(this.CreateGraphics());
        }


        void drawDubb(Graphics G)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawScene(g2);
            G.DrawImage(off, 0, 0);
        }

        void drawScene(Graphics g)
        {
            g.Clear(this.BackColor);

            hero.Draw(g);
        }
    }
}
