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
    public class HealthBar
    {
        Bitmap Per100 = new Bitmap("./ui/Health/Heart1.png"); // 20 HP full
        Bitmap Per75 = new Bitmap("./ui/Health/Heart2.png"); // 15 HP
        Bitmap Per50 = new Bitmap("./ui/Health/Heart3.png"); // 10 HP
        Bitmap Per25 = new Bitmap("./ui/Health/Heart4.png"); // 5 HP
        Bitmap Per0 = new Bitmap("./ui/Health/Heart5.png"); // 0 HP

        public int X = 20;
        public int Y = 20;

        private Bitmap GetHeart(float hpInHeart)
        {
            if (hpInHeart >= 20) return Per100;
            if (hpInHeart >= 15) return Per75;
            if (hpInHeart >= 10) return Per50;
            if (hpInHeart >= 5) return Per25;
            return Per0;
        }

        public void drawBar(float HP, float MaxHP, Graphics G)
        {
            int heartSize = 30;
            int drawX = X;

            float hpLeft = HP;

            int totalHearts = (int)(MaxHP / 20);

            for (int i = 0; i < totalHearts; i++)
            {
                float heartHP = Math.Min(20, hpLeft);

                Bitmap heart = GetHeart(heartHP);

                G.DrawImage(heart, drawX, Y, heartSize, heartSize);

                hpLeft -= 20;
                drawX += heartSize;
            }
        }
    }
    public class CActor
    {
        public string name;
        public int X, Y;
        public int Width, Height;
        public bool movingLeft = false, movingRight = false;
        public char dir = 'r';

        public bool isJumping = false;
        public bool doubleJumped = false;
        public bool isFalling = true;
        public float velocityY = 0;
        public float gravity = 0.6f;
        public float jumpForce = -12f;
        public int jumpHeight = 100;

        public int rangeX;
        public int rangeY;
        public int rangeW;
        public int rangeH;

        public bool isHurting = false;

        public bool isAttacking = false;
        public float HP = 100.0f;
        public float MaxHP = 100.0f;
        public int attackCooldownTimer = 0;
        public int attackCooldownMax= 10;


        public int YOld;

        public int state = 0;

        public List<int> frameDelay = new List<int>();
        private int frameCounter = 0;

        public int curFrame = 0;
        public List<List<Bitmap>> frames = new List<List<Bitmap>>();


        public bool canAttack()
        {
            if(!isAttacking && !isHurting && attackCooldownTimer <= 0)
            {
                return true;
            }
            return false;
        }

        public void changeDelay(int animationIdx, int newD)
        {
            frameDelay[animationIdx] = newD;
        }
        public void addFrame(Bitmap img, int animationIdx)
        {
            while (frames.Count <= animationIdx)
            {
                frames.Add(new List<Bitmap>());
                frameDelay.Add(5);
            }

            frames[animationIdx].Add(img);
        }
        public void changeState(int state)
        {
            this.state = state;
            curFrame = 0;
        }


        public Bitmap playFrame()
        {
            Bitmap frame = null;

            if (curFrame >= frames[state].Count) curFrame = 0;
            if (frames.Count > 0)
            {
                frame = frames[state][curFrame];
                if (isAttacking == true && curFrame >= frames[2].Count - 1)
                {
                    isAttacking = false;
                    state = 0;
                    attackCooldownTimer = attackCooldownMax;
                }
                if (isHurting && state == 3 && curFrame >= frames[3].Count - 1)
                {
                    isHurting = false;
                    changeState(0);
                }
            }

            frameCounter++;

            if (frameCounter >= frameDelay[state])
            {
                frameCounter = 0;

                if (curFrame < frames[state].Count - 1)
                    curFrame++;
                else
                    curFrame = 0;
            }

            return frame;
        }
    }
    public class VFX
    {
        public string name;

        public List<Bitmap> frames = new List<Bitmap>();

        public int x, y;
        public int width, height;

        public int curFrame = 0;
        public int frameDelay = 2;
        private int frameCounter = 0;

        public bool finished = false;

        public bool followPlayer = false;
        public int offsetX;
        public int offsetY;
        public void AddFrame(Bitmap img)
        {
            frames.Add(img);
        }

        public void SetDelay(int d)
        {
            frameDelay = d;
        }

        public Bitmap GetFrame()
        {
            if (frames.Count == 0) return null;

            if (curFrame >= frames.Count)
            {
                finished = true;
                return null;
            }

            Bitmap frame = frames[curFrame];

            frameCounter++;

            if (frameCounter >= frameDelay)
            {
                frameCounter = 0;
                curFrame++;

                if (curFrame >= frames.Count)
                {
                    finished = true;
                }
            }

            return frame;
        }
    }

    public class Tile
    {
        public int X, Y, W, H;
        public bool solid = true;
        public Bitmap img;
        public Color clr;

    }

    public partial class Form1 : Form
    {
        List<Tile> tiles = new List<Tile>();
        List<CActor> actrs = new List<CActor>();
        CActor player = new CActor();
        HealthBar HP = new HealthBar();
        List<VFX> vfxTemplates = new List<VFX>();
        List<VFX> activeVFX = new List<VFX>();

        int curHover = -1;

        Timer t = new Timer();

        public Form1()
        {
            InitializeComponent();

            actrs.Add(player);
            for (int i = 0; i < 10; i++)
            {
                string filename = "./Characters/Samurai/Idle/tile00" + i.ToString() + ".png";
                Bitmap img = new Bitmap(filename);
                player.addFrame(img, 0);
            }

            for (int i = 0; i < 16; i++)
            {
                string filename;
                if (i < 10)
                    filename = "./Characters/Samurai/Run/tile00" + i.ToString() + ".png";
                else filename = "./Characters/Samurai/Run/tile0" + i.ToString() + ".png";
                Bitmap img = new Bitmap(filename);
                player.addFrame(img, 1);
            }
            player.changeDelay(1, 3);

            for (int i = 0; i < 7; i++)
            {
                string filename = "./Characters/Samurai/Attack/tile00" + i.ToString() + ".png";
                Bitmap img = new Bitmap(filename);
                player.addFrame(img, 2);
            }
            player.changeDelay(2, 2);

            for (int i = 0; i < 4; i++)
            {
                string filename = "./Characters/Samurai/Hurt/tile00" + i.ToString() + ".png";
                Bitmap img = new Bitmap(filename);
                player.addFrame(img, 3);
            }
            initVFX();

            this.Load += Form1_Load;

            this.Paint += Form1_Paint;

            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.MouseClick += Form1_MouseClick;

            this.MouseMove += Form1_MouseMove;

            this.WindowState = FormWindowState.Maximized;


            t.Interval = 16;
            t.Tick += T_Tick;
            t.Start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int found = 0;
            for (int i = 0; i < actrs.Count; i++)
            {
                CActor ptrav = actrs[i];
                if(e.X >= ptrav.rangeX && e.X <= ptrav.rangeX+ ptrav.rangeW&&
                    e.Y >= ptrav.rangeY && e.Y <= ptrav.rangeY + ptrav.rangeH)
                {
                    found = 1;
                    curHover = i;
                    break;
                }
            }
            if (found == 0) curHover = -1;
        }

        public void initVFX()
        {
            VFX doubleJump = new VFX();
            doubleJump.name = "doubleJump";

            for (int i = 1; i <= 5; i++)
            {
                string filename = "./vfx/doubleJump/" + i + ".png";
                Bitmap img = new Bitmap(filename);
                doubleJump.frames.Add(img);
            }

            doubleJump.width = 50;
            doubleJump.height = 25;

            vfxTemplates.Add(doubleJump);

            VFX Heal = new VFX();
            Heal.name = "Heal";

            for (int i = 0; i <= 10; i++)
            {
                string filename;
                if (i < 10) filename = "./vfx/HealEffect/Frames/HealEffect_0" + i + ".png";
                else filename = "./vfx/HealEffect/Frames/HealEffect_" + i + ".png";
                Bitmap img = new Bitmap(filename);
                Heal.frames.Add(img);
            }

            Heal.width = 200;
            Heal.height = 200;

            vfxTemplates.Add(Heal);
        }

        void SpawnVFX(string name, int x, int y , bool FollowPlayer)
        {
            for (int i = 0; i < vfxTemplates.Count; i++)
            {
                if (vfxTemplates[i].name == name)
                {
                    VFX template = vfxTemplates[i];

                    VFX v = new VFX();

                    v.frames = template.frames;

                    v.width = template.width;
                    v.height = template.height;

                    v.x = x;
                    v.y = y;
                    v.followPlayer = FollowPlayer;
                    v.offsetX = x - player.X;
                    v.offsetY = y - player.Y;

                    activeVFX.Add(v);
                    return;
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X >= player.rangeX + (player.rangeW / 2)) player.dir = 'r';
            else player.dir = 'l';
            if (player.canAttack())
            {
                player.isAttacking = true;
                player.changeState(2);
                                       
                player.attackCooldownTimer = player.attackCooldownMax;
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                player.movingRight = false;
                player.dir = 'r';
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                player.dir = 'l';
                player.movingLeft = false;
            }

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Space) player.isJumping = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!player.isHurting)
            {


                if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                {
                    player.movingRight = true;
                    player.movingLeft = false;
                }
                if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
                {
                    player.movingLeft = true;
                    player.movingRight = false;
                }

                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W)
                {
                    if (!player.isFalling)
                    {
                        player.velocityY = player.jumpForce;
                        player.isFalling = true;
                        player.doubleJumped = false;
                    }
                    else if (!player.doubleJumped)
                    {
                        player.velocityY = player.jumpForce;
                        player.doubleJumped = true;

                        SpawnVFX( "doubleJump", player.X + 80 , player.Y + 130 , false);
                    }
                }
            }

            if (e.KeyCode == Keys.H)
            {
                player.HP -= 10;

                player.isHurting = true;
                player.changeState(3);
            }

            if (e.KeyCode == Keys.Y)
            {
                player.HP += 10;

                SpawnVFX("Heal", player.X, player.Y + 50 , true );

                player.isHurting = false;

            }

        }

        private void T_Tick(object sender, EventArgs e)
        {

            this.Invalidate();

            if (player.attackCooldownTimer > 0)
            {
                player.attackCooldownTimer--;
            }

            player.velocityY += player.gravity;
            player.Y += (int)player.velocityY;

            player.rangeX = player.X + (player.Width - player.rangeW) / 2;
            player.rangeY = player.Y + (player.Height - player.rangeH) - 30;

            Tile groundTile = GetTileUnderPlayer();
            if (groundTile != null && player.velocityY >= 0)
            {
                int feetPos = player.rangeY + player.rangeH;
                int overlap = feetPos - groundTile.Y;

                player.Y -= overlap;
                player.velocityY = 0;
                player.isFalling = false;

                player.rangeY = player.Y + (player.Height - player.rangeH) - 30;
            }
            else
            {
                player.isFalling = true;
            }


            if (player.isHurting)
            {
                player.state = 3;
                if (!player.isFalling)
                    return;
            }

            if (player.movingRight == true)
            {
                if (player.rangeX < this.Width - player.rangeW - 5) player.X += 5;
                player.state = 1;

                
            }

            if (player.movingLeft == true)
            {
                if (player.rangeX > 0) player.X -= 5;
                player.state = 1;
                
            }

            if (player.isAttacking == true && !player.isHurting)
            {
                player.state = 2;
            }

            if (!player.movingRight && !player.movingLeft && !player.isAttacking) player.state = 0;
            if (player.isHurting) player.state = 3;

            player.rangeX = player.X + (player.Width - player.rangeW) / 2;
            player.rangeY = player.Y + (player.Height - player.rangeH) - 30;

        }

        public void fall()
        {
            if (player.isJumping == false)
            {
                if (player.Y + player.Height <= this.Location.Y + this.Height - 25)
                {
                    player.Y += 5;
                    player.isFalling = true;
                }
                else player.isFalling = false;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawScene(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.X = this.Location.X + 30;
            player.Y = this.ClientSize.Height / 2;

            player.Width = 200;
            player.Height = 200;

            player.rangeW = 80;
            player.rangeH = 70;
            player.rangeX = player.X + (player.Width - player.rangeW) / 2;
            player.rangeY = player.Y + (player.Height - player.rangeH) - 30;
            player.name = "Player";
            for(int i = 0; i < this.ClientSize.Width; i += 64)
            {
                Tile pnn = new Tile();
                pnn.X = i;
                pnn.Y = this.ClientSize.Height - 40;
                pnn.W = 64;
                pnn.H = 40;
                pnn.clr = Color.Black;
                pnn.solid = true;
                tiles.Add(pnn);
            }
        }

        Tile GetTileUnderPlayer()
        {
            int playerFeet = player.rangeY + player.rangeH;
            int playerLeft = player.rangeX;
            int playerRight = player.rangeX + player.rangeW;

            for(int i =0; i< tiles.Count; i++) {
                Tile ptrav = tiles[i];

                if (playerFeet >= ptrav.Y && playerFeet <= ptrav.Y + ptrav.H &&
                    playerLeft < ptrav.X + ptrav.W && playerRight > ptrav.X)
                {
                    return ptrav;
                }
            }
            return null;
        }

        void drawScene(Graphics g)
        {
            g.Clear(this.BackColor);

            for(int i =0; i< tiles.Count; i++)
            {
                Tile ptrav = tiles[i];
                if(ptrav.img != null)
                {
                    g.DrawImage(ptrav.img , ptrav.X , ptrav.Y , ptrav.W , ptrav.H);

                }
                else if (ptrav.clr != null)
                {
                    SolidBrush bsh = new SolidBrush(ptrav.clr);
                    g.FillRectangle(bsh, ptrav.X, ptrav.Y, ptrav.W, ptrav.H);
                    
                }
            }


            if (player.movingRight == true)
                g.DrawImage(player.playFrame(), player.X, player.Y, player.Width, player.Height);
            else if (player.movingLeft == true)
            {
                g.DrawImage(player.playFrame(), new Rectangle(player.X + player.Width, player.Y, -player.Width, player.Height));
            }

            if (!player.movingRight && !player.movingLeft)
            {
                if (player.dir == 'l')
                    g.DrawImage(player.playFrame(), new Rectangle(player.X + player.Width, player.Y, -player.Width, player.Height));
                else
                    g.DrawImage(player.playFrame(), player.X, player.Y, player.Width, player.Height);
            }

            for (int i = activeVFX.Count - 1; i >= 0; i--)
            {
                VFX v = activeVFX[i];
                Bitmap frame = v.GetFrame();

                if (frame != null)
                {
                    if (v.followPlayer)
                    {
                        v.x = player.X + v.offsetX;
                        v.y = player.Y + v.offsetY;
                    }

                    g.DrawImage(frame, v.x, v.y, v.width, v.height);
                }

                if (v.finished)
                {
                    activeVFX.RemoveAt(i);
                }
            }

            if(curHover != -1)
            {
                CActor cur = actrs[curHover];
                int nameHeight = 20;
                int nameWidth = 50;

                SolidBrush bsh = new SolidBrush(Color.FromArgb(128, 0, 5, 0));
                SolidBrush textBsh = new SolidBrush(Color.FromArgb(200, 200, 200));
                Pen border = new Pen(Color.Black);

                int actorMidX = cur.rangeX + (cur.rangeW / 2);
                int nameX = actorMidX - (nameWidth / 2);
                int nameY = cur.rangeY - nameHeight - 15; 

                g.FillRectangle(bsh, nameX, nameY, nameWidth, nameHeight);
                g.DrawRectangle(border, nameX, nameY, nameWidth, nameHeight);


                Font myFont = new Font("Arial", 9, FontStyle.Bold);

                float charWidth = 9 * 0.7f;
                float estimatedTextWidth = cur.name.Length * charWidth;
                float estimatedTextHeight = myFont.Height;

                float textX = nameX + (nameWidth - estimatedTextWidth) / 2;
                float textY = nameY + (nameHeight - estimatedTextHeight) / 2;

                g.DrawString(cur.name, myFont, textBsh, textX, textY);

            }

            HP.drawBar(player.HP, player.MaxHP, g);
        }
    }
}
