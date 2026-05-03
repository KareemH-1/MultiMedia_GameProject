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

    public class Health
    {
        public bool isHero = false;
        public bool showHPText = false;
        public int maxHP = 100;
        public int HP = 100;
        public RectangleF rect = new RectangleF();

        private Bitmap sBorder = new Bitmap("ui/Health/bar.png");
        private Bitmap sBackground = new Bitmap("ui/Health/bar_background.png");
        private Bitmap sBar = new Bitmap("ui/Health/health_bar.png");
        private Bitmap sHero;
        private float padXRatio = 8f / 118f;
        private float padYRatio = 2f / 13f;
        private float innerWRatio = 102f / 13f * 13f / 118f;
        private float innerHRatio = 10f / 13f;

        public Health(float x, float y, float w, float h, int hp, int maxHp, bool isHero , bool showHPText)
        {
            if (isHero == true) sHero = new Bitmap("ui/hero_icon.png");
            this.isHero = isHero;
            this.HP = hp;
            this.maxHP = maxHp;
            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;
            this.showHPText = showHPText;
        }

        public void positionAbove(RectangleF ownerR, float gap)
        {
            rect.X = ownerR.X + (ownerR.Width - rect.Width) / 2f;
            rect.Y = ownerR.Y - rect.Height - gap;
        }

        public void draw(Graphics g)
        {
            float innerX = 0f;
            float innerY = 0f;
            float innerW = 0f;
            float innerH = 0f;

            if (isHero)
            {
                g.DrawImage(sHero, rect.X, rect.Y, rect.Height * 2, rect.Height * 2);

                float X = rect.X + rect.Height + 25;
                float Y = rect.Y + 15;

                g.DrawImage(sBorder, X, Y, rect.Width, rect.Height);

                innerX = X + rect.Width * padXRatio;
                innerY = Y + rect.Height * padYRatio;
                innerW = rect.Width * innerWRatio;
                innerH = rect.Height * innerHRatio;
            }
            else
            {
                innerX = rect.X;
                innerY = rect.Y;
                innerW = rect.Width;
                innerH = rect.Height;
            }

            g.DrawImage(sBackground, innerX, innerY, innerW, innerH);

            int curHp = HP;
            if (curHp < 0) curHp = 0;
            if (curHp > maxHP) curHp = maxHP;

            float ratio = 0f;
            if (maxHP > 0) ratio = curHp * 1f / maxHP;

            float widthHP = ratio * innerW;

            if (widthHP > 0f)
            {
                g.DrawImage(sBar, innerX, innerY, widthHP, innerH);
            }

            if (showHPText == true)
            {
                string txt = curHp + " / " + maxHP;
                float fontSize = innerH * 0.5f;
                if (fontSize < 4f) fontSize = 4f;

                Font f = new Font("Arial", fontSize, FontStyle.Bold);

                float tx = innerX + (innerW/3) + innerW/14;
                float ty = innerY + (innerH / 14);

                SolidBrush fill = new SolidBrush(Color.White);
                g.DrawString(txt, f, fill, tx, ty);
            }
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

 


    public class Hero
    {
        public RectangleF R = new Rectangle();
        public RectangleF drawR = new Rectangle();

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

        public Health HP = new Health(20, 20, 236, 26, 50, 100, true , false);
        public void Draw(Graphics g, bool showRanges)
        {
            drawR.X = R.X + (R.Width - drawR.Width) / 2f;
            drawR.Y = R.Y + (R.Height - drawR.Height);

            g.DrawImage(anim.playFrame(), drawR.X, drawR.Y, drawR.Width, drawR.Height);

            if (showRanges)
            {
                Pen p = new Pen(Color.Lime, 2);
                g.DrawRectangle(p, R.X, R.Y, R.Width, R.Height);
            }

            HP.draw(g);
        }
        public Hero(int startX, int startY, int w, int h)
        {
            drawR.X = startX;
            drawR.Y = startY;
            drawR.Width = w;
            drawR.Height = h;

            R.Width = w * 0.4f;
            R.Height = h * 0.65f;
            R.X = startX + (w - R.Width) / 2f;
            R.Y = startY + (h - R.Height);

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

            R.X += dx;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.interact == true && t.jumpThrough == false)
                {
                    bool overlapping = false;
                    if (R.X + R.Width > t.R.X &&
                        R.X < t.R.X + t.R.Width &&
                        R.Y + R.Height > t.R.Y &&
                        R.Y < t.R.Y + t.R.Height)
                    {
                        overlapping = true;
                    }

                    if (overlapping)
                    {
                        if (dx > 0) R.X = t.R.X - R.Width;
                        else if (dx < 0) R.X = t.R.X + t.R.Width;
                    }
                }
            }

            applyPhysics(tiles);

            updateAnimation();
        }

        public void applyPhysics(List<tile> tiles)
        {
            wasGrounded = isGrounded;
            prevBottom = R.Y + R.Height;

            velocityY += gravity;
            if (velocityY > max_speed) velocityY = max_speed;

            R.Y += velocityY;

            isGrounded = false;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.interact == true)
                {
                    bool overlappingX = false;
                    if (R.X + R.Width > t.R.X &&
                        R.X < t.R.X + t.R.Width)
                    {
                        overlappingX = true;
                    }

                    if (overlappingX)
                    {
                        if (t.jumpThrough == true)
                        {
                            if (velocityY >= 0 &&
                                prevBottom <= t.R.Y &&
                                R.Y + R.Height >= t.R.Y)
                            {
                                R.Y = t.R.Y - R.Height;
                                velocityY = 0;
                                isGrounded = true;
                            }
                        }
                        else
                        {
                            bool overlappingY = false;
                            if (R.Y + R.Height > t.R.Y &&
                                R.Y < t.R.Y + t.R.Height)
                            {
                                overlappingY = true;
                            }

                            if (overlappingY)
                            {
                                if (velocityY > 0)
                                {
                                    R.Y = t.R.Y - R.Height;
                                    velocityY = 0;
                                    isGrounded = true;
                                }
                                else if (velocityY < 0)
                                {
                                    R.Y = t.R.Y + t.R.Height;
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
        public Rectangle R = new Rectangle();
        public Color clr = Color.Black;
        public bool interact = false;
        public bool jumpThrough = true;

        public void draw(Graphics g)
        {
            SolidBrush bsh = new SolidBrush(clr);
            g.FillRectangle(bsh, R.X, R.Y, R.Width, R.Height);
        }

        public void init(int x , int y , int width , int height)
        {
            R.X = x;
            R.Y = y;
            R.Height = height;
            R.Width = width;
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
