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
        public rect drawR = new rect();

        public float speed = 6f;

        public char moving = ' ';
        public bool isRunning = false;

        public float velocityY = 0f;
        public float gravity = 1.2f;
        public float jumpForce = -18f;

        public bool isGrounded = false;
        bool wasGrounded = false;

        public bool isLanding = false;
        int landingTimer = 0;

        public float max_speed = 25f; 
        float prevBottom = 0f;

        public AnimationController anim = new AnimationController();

        public void Draw(Graphics g, bool showRanges)
        {
            drawR.x = R.x + (R.width - drawR.width) / 2f;
            drawR.y = R.y + (R.height - drawR.height);

            g.DrawImage(anim.playFrame(), drawR.x, drawR.y, drawR.width, drawR.height);

            if (showRanges)
            {
                Pen p = new Pen(Color.Lime, 2);
                g.DrawRectangle(p, R.x, R.y, R.width, R.height);
            }
        }
        public Hero(int startX, int startY, int w, int h)
        {
            drawR.x = startX;
            drawR.y = startY;
            drawR.width = w;
            drawR.height = h;

            R.width = w * 0.4f;
            R.height = h * 0.65f;
            R.x = startX + (w - R.width) / 2f;
            R.y = startY + (h - R.height);

            createAnim();
            anim.changeAnimation("idle", -1);

            wasGrounded = true;
            isGrounded = true;
        }

        void createAnim()
        {
            string[] folders = {"attack", "critical_attack", "crouch", "death",
            "idle", "jump_reload", "ladder_climbing", "running", "shield_defence",
            "sliding", "spell_cast", "taking_damage", "walking", "wall_sliding",
            "falling", "landing", "jump_flying", "jump_preparation"};

            int[] numFrames = { 8, 8, 3, 12, 6, 3, 10, 8, 3, 8, 8, 4, 10, 4, 4, 3, 4, 2 };

            for (int i = 0; i < 18; i++)
            {
                Animation a = new Animation();
                a.name = folders[i];
                if (folders[i] == "walking") a.frameDelay = 0;
                else if (folders[i] == "idle") a.frameDelay = 2;
                else if (folders[i] == "landing") a.frameDelay = 2;
                string path = "Characters/Hero/Blue/" + folders[i] + "/";
                for (int j = 1; j <= numFrames[i]; j++)
                {
                    Bitmap img = new Bitmap(path + j.ToString() + ".png");
                    a.frames.Add(img);
                }
                this.anim.addAnim(a);
            }
        }

        public void move(List<tile> tiles)
        {
            float speedM = speed;
            if (isRunning) speedM = speed * 2f;

            float dx = 0f;
            if (moving == 'l') dx = -speedM;
            else if (moving == 'r') dx = speedM;

            R.x += dx;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.interact == true && t.jumpThrough == false)
                {
                    bool overlapping = false;
                    if (R.x + R.width > t.R.x &&
                        R.x < t.R.x + t.R.width &&
                        R.y + R.height > t.R.y &&
                        R.y < t.R.y + t.R.height)
                    {
                        overlapping = true;
                    }

                    if (overlapping)
                    {
                        if (dx > 0) R.x = t.R.x - R.width;
                        else if (dx < 0) R.x = t.R.x + t.R.width;
                    }
                }
            }

            applyPhysics(tiles);

            updateAnimation();
        }

        public void applyPhysics(List<tile> tiles)
        {
            wasGrounded = isGrounded;
            prevBottom = R.y + R.height;

            velocityY += gravity;
            if (velocityY > max_speed) velocityY = max_speed;

            R.y += velocityY;

            isGrounded = false;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.interact == true)
                {
                    bool overlappingX = false;
                    if (R.x + R.width > t.R.x &&
                        R.x < t.R.x + t.R.width)
                    {
                        overlappingX = true;
                    }

                    if (overlappingX)
                    {
                        if (t.jumpThrough == true)
                        {
                            if (velocityY >= 0 &&
                                prevBottom <= t.R.y &&
                                R.y + R.height >= t.R.y)
                            {
                                R.y = t.R.y - R.height;
                                velocityY = 0;
                                isGrounded = true;
                            }
                        }
                        else
                        {
                            bool overlappingY = false;
                            if (R.y + R.height > t.R.y &&
                                R.y < t.R.y + t.R.height)
                            {
                                overlappingY = true;
                            }

                            if (overlappingY)
                            {
                                if (velocityY > 0)
                                {
                                    R.y = t.R.y - R.height;
                                    velocityY = 0;
                                    isGrounded = true;
                                }
                                else if (velocityY < 0)
                                {
                                    R.y = t.R.y + t.R.height;
                                    velocityY = 0;
                                }
                            }
                        }
                    }
                }
            }

            if (wasGrounded == false && isGrounded == true)
            {
                isLanding = true;
                landingTimer = 6;
                anim.changeAnimation("landing", -1);
            }
        }


        public void jump()
        {
            if (isGrounded)
            {
                velocityY = jumpForce;
                isGrounded = false;
                isLanding = false;
                anim.changeAnimation("jump_flying", -1);
            }
        }

        public void updateAnimation()
        {
            if (isLanding)
            {
                landingTimer--;
                if (landingTimer <= 0 || moving != ' ' || !isGrounded)
                {
                    isLanding = false;
                }
                else
                {
                    return;
                }
            }

            if (!isGrounded)
            {
                if (velocityY < 0)
                    anim.changeAnimation("jump_flying", -1);
                else
                    anim.changeAnimation("falling", -1);
                return;
            }

            if (moving == ' ')
                anim.changeAnimation("idle", -1);
            else if (isRunning)
                anim.changeAnimation("running", -1);
            else
                anim.changeAnimation("walking", -1);
        }
    }
    public class tile
    {
        public rect R = new rect();
        public Color clr = Color.Black;
        public bool interact = false;
        public bool jumpThrough = true;

        public void draw(Graphics g)
        {
            SolidBrush bsh = new SolidBrush(clr);
            g.FillRectangle(bsh, R.x, R.y, R.width, R.height);
        }

        public void init(int x , int y , int width , int height)
        {
            R.x = x;
            R.y = y;
            R.height = height;
            R.width = width;
        }
    }
    public partial class Form1 : Form
    {
        bool showRanges = false;
        Bitmap off;
        Random RR = new Random();

        Hero hero;
        List<tile> tiles = new List<tile>();
        Timer timer = new Timer();

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            timer.Interval = 6;
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
            if (e.KeyCode == Keys.Space)
            {
                hero.jump();
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                hero.isRunning = true;
            }

            if (e.KeyCode == Keys.P)
            {
                if (showRanges == true) showRanges = false;
                else showRanges = true;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Text = hero.isRunning.ToString(); 
            hero.move(tiles);

            drawDubb(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);


            hero = new Hero(30, this.ClientSize.Height - 150 - 30, 150, 150);
            drawDubb(this.CreateGraphics());
            initTiles();

        }

        void initTiles()
        {
            tile pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = true;
            pnn.init(0, this.ClientSize.Height - 30, this.ClientSize.Width, 30);
            tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = true;
            pnn.init(300, this.ClientSize.Height - 150, 200, 20);
            tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = false;
            pnn.clr = Color.DarkRed;
            pnn.init(600, this.ClientSize.Height - 250, 200, 30);
            tiles.Add(pnn);
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

            hero.Draw(g , showRanges);
            for(int i =0; i< tiles.Count; i++)
            {
                tiles[i].draw(g);
            }
        }
    }
}
