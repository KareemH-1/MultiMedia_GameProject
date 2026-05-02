using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public class Animation{
        public string name;
        public List<Bitmap> frames = new List<Bitmap>();
        public int frameDelay = 5;

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

        public void changeAnimation(string name , int index)
        {
            int idx = -1;
            // changeAnimation("" , idx); use either
            //or 
            // changeAnimation("walk" , -1);
            if(name == "")
            {
                if (index != -1)
                {
                    if (idx < animations.Count)
                    {
                        currAnim = idx;
                        currIdx = 0;
                        return;
                    }
                }
                MessageBox.Show("IDX  " + idx.ToString() + " doesnt exist");

            }
            else
            {
                for(int i =0; i< animations.Count; i++)
                {
                    Animation ptrav = animations[i];
                    if(ptrav.name == name)
                    {
                        currAnim = i;
                        currIdx = 0;
                        return;
                    }
                }
                MessageBox.Show("Couldnt Find animation with name " + name);
            }

            MessageBox.Show("no name or idx parameters");

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
        public int x , y;
        public int width, height;
        public rect(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

        

    public class Hero
    {
        public rect R;
        public float speed = 0f;
        public bool isJumping = false;
        public int jumpHeight = 30;

        public AnimationController anim = new AnimationController();

        public Bitmap img;
        public Hero createHero(int startX , int startY , int w , int h)
        {
            Hero hero = new Hero();
            hero.R.x = startX;
            hero.R.y = startY;
            hero.R.width = w;
            hero.R.height = h;
            hero.img = new bitmap("")
            

            return hero;
        }
    }


    public partial class Form1 : Form
    {
        Bitmap off;
        Random RR = new Random();


        public Form1()
        {
            this.Paint += Form1_Paint;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;

        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

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

        }
    }
}
