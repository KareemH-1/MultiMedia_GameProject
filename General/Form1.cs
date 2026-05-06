using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace General
{
    public class Animation
    {
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
        public int maxHP = 100;
        public int HP = 100;

        public Health(int hp, int maxHp)
        {
            HP = hp;
            maxHP = maxHp;
        }

        public int getHP()
        {
            if (HP < 0) return 0;
            if (HP > maxHP) return maxHP;
            return HP;
        }

        public float getPercent()
        {
            if (maxHP <= 0) return 0f;

            return getHP() * 1f / maxHP;
        }

        public void damage(int amount)
        {
            HP -= amount;
            if (HP < 0) HP = 0;
        }

        public void heal(int amount)
        {
            HP += amount;
            if (HP > maxHP) HP = maxHP;
        }
    }

    public class Mana
    {
        public int maxMana = 100;
        public int mana = 100;

        public Mana(int mana, int maxMana)
        {
            this.mana = mana;
            this.maxMana = maxMana;
        }

        public int getMana()
        {
            if (mana < 0) return 0;
            if (mana > maxMana) return maxMana;
            return mana;
        }

        public float getPercent()
        {
            if (maxMana <= 0) return 0f;

            return getMana() * 1f / maxMana;
        }

        public void use(int amount)
        {
            mana -= amount;
            if (mana < 0) mana = 0;
        }

        public void restore(int amount)
        {
            mana += amount;
            if (mana > maxMana) mana = maxMana;
        }
    }

    public class UIEntity
    {
        public bool isHero = false;

        public bool displayHPBar = true;
        public bool displayHPText = true;

        public bool displayManaBar = true;
        public bool displayManaText = true;

        public bool displayName = false;
        public bool displayLevel = true;

        public RectangleF rect = new RectangleF();

        Bitmap hpBorder = new Bitmap("ui/Health/bar.png");
        Bitmap hpBackground = new Bitmap("ui/Health/bar_background.png");
        Bitmap hpInner = new Bitmap("ui/Health/health_bar.png");

        Bitmap manaBackground = new Bitmap("ui/Mana/mana_bg.png");
        Bitmap manaInner = new Bitmap("ui/Mana/manaInner.png");

        Bitmap heroIcon = new Bitmap("ui/hero_icon.png");
        Bitmap heroBorder = new Bitmap("ui/border.png");

        Font heroFont = new Font("Palatino Linotype", 9f, FontStyle.Bold);
        Font manaFont = new Font("Palatino Linotype", 8f, FontStyle.Bold);
        Font normalFont = new Font("Palatino Linotype", 8f, FontStyle.Bold);

        SolidBrush textBrush = new SolidBrush(Color.White);
        SolidBrush bigoutline = new SolidBrush(Color.Black);

        public UIEntity(float x, float y, float w, float h, bool isHero, bool showHPText)
        {
            this.isHero = isHero;
            this.displayHPText = showHPText;

            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;
        }

        public void positionAbove(RectangleF ownerR, float gap)
        {
            rect.X = ownerR.X + (ownerR.Width - rect.Width) / 2f;
            rect.Y = ownerR.Y - rect.Height - gap;
        }

        public void draw(Graphics g, Health hp, Mana mana, int level)
        {
            if (isHero)
            {
                drawHeroUI(g, hp, mana, level);
            }
            else
            {
                drawEntityUI(g, hp);
            }
        }

        void drawHeroUI(Graphics g, Health hp, Mana mana, int level)
        {
            float iconBorderX = rect.X;
            float iconBorderY = rect.Y;

            float iconBorderW = 78f;
            float iconBorderH = 120f;

            float iconPad = 10f;

            float iconX = iconBorderX + iconPad;
            float iconY = iconBorderY + iconPad;
            float iconW = iconBorderW - iconPad * 2f;
            float iconH = iconBorderW - iconPad * 2f;



            g.DrawImage(heroBorder, iconBorderX, iconBorderY, iconBorderW, iconBorderH);
            g.DrawImage(heroIcon, iconX, iconY, iconW, iconH);

            float levelY = iconBorderY + iconW + 15;
            string levelText = "Level: " + level;

            drawTextWithShadow(g, levelText, heroFont, iconX + 2, levelY);

            float barX = iconBorderX + iconBorderW + 18f;

            float hpBarY = rect.Y + 25f;
            float manaBarY = hpBarY + rect.Height + 18f;

            float barW = rect.Width;
            float barH = rect.Height;

            float manaBarW = barW;
            float manaBarH = rect.Height / 2;

            if (displayHPText)
            {
                string hpText = "HP: " + hp.getHP() + " / " + hp.maxHP;

                float tx = barX + 10;
                float ty = hpBarY - 20f;

                drawTextWithShadow(g, hpText, heroFont, tx, ty);
            }

            if (displayHPBar)
            {
                drawFramedHPBar(g, hp, barX, hpBarY, barW, barH);
            }

            if (displayManaBar)
            {
                drawManaBar(g, mana, barX + 2, manaBarY, manaBarW, manaBarH);
            }

            if (displayManaText)
            {
                string manaText = "Mana: " + mana.getMana() + " / " + mana.maxMana;

                float tx = barX + 10;
                float ty = manaBarY - 17;

                drawTextWithShadow(g, manaText, manaFont, tx, ty);
            }
        }

        void drawEntityUI(Graphics g, Health hp)
        {
            if (displayHPBar == false) return;

            drawSimpleHPBar(g, hp, rect.X, rect.Y, rect.Width, rect.Height);

            if (displayHPText)
            {
                string txt = hp.getHP() + " / " + hp.maxHP;

                float tx = rect.X + rect.Width / 2f - txt.Length * 3.3f;
                float ty = rect.Y + rect.Height / 2f - 6f;

                drawTextWithShadow(g, txt, normalFont, tx, ty);
            }
        }

        void drawFramedHPBar(Graphics g, Health hp, float x, float y, float w, float h)
        {
            float innerX = x + w * 8f / 118f;
            float innerY = y + h * 2f / 13f;
            float innerW = w * 102f / 118f;
            float innerH = h * 10f / 13f;

            g.DrawImage(hpBackground, innerX, innerY, innerW, innerH);

            float widthHP = hp.getPercent() * innerW;

            if (widthHP > 0f)
            {
                g.DrawImage(hpInner, innerX, innerY, widthHP, innerH);
            }

            g.DrawImage(hpBorder, x, y, w, h);
        }

        void drawSimpleHPBar(Graphics g, Health hp, float x, float y, float w, float h)
        {
            g.DrawImage(hpBackground, x, y, w, h);

            float widthHP = hp.getPercent() * w;

            if (widthHP > 0f)
            {
                g.DrawImage(hpInner, x, y, widthHP, h);
            }
        }

        void drawManaBar(Graphics g, Mana mana, float x, float y, float w, float h)
        {
            g.FillRectangle(Brushes.White, x, y, w, h);
            g.DrawImage(manaBackground, x, y, w, h);

            float innerX = x + w * 8f / 118f - 2f;
            float innerY = y + h * 2f / 13f;
            float innerW = w * 102f / 118f;
            float innerH = h * 10f / 13f;

            float widthMana = mana.getPercent() * innerW;

            if (widthMana > 0f)
            {
                g.DrawImage(manaInner, innerX, innerY, widthMana, innerH);
            }
        }

        void drawTextWithShadow(Graphics g, string txt, Font f, float x, float y)
        {
            g.DrawString(txt, f, bigoutline, x + 2f, y + 2f);
            g.DrawString(txt, f, textBrush, x, y);
        }
    }
    public class AnimationController
    {
        public int currIdx = 0;
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

        public Bitmap playFrameOnce()
        {
            Bitmap frame = null;

            if (currIdx >= animations[currAnim].frames.Count) currIdx = animations[currAnim].frames.Count - 1;

            if (animations[currAnim].frames.Count > 0)
            {
                frame = animations[currAnim].frames[currIdx];
            }

            frameDelayCount++;

            if (currIdx < animations[currAnim].frames.Count - 1)
            {
                if (frameDelayCount >= animations[currAnim].frameDelay)
                {
                    frameDelayCount = 0;

                    if (currIdx < animations[currAnim].frames.Count - 1)
                        currIdx++;
                    else
                        currIdx = 0;
                }
            }

            return frame;
        }

        public Animation getCurrentAnimation()
        {
            if (animations.Count == 0) return null;
            if (currAnim < 0 || currAnim >= animations.Count) return null;

            return animations[currAnim];
        }

        public bool isCurrentAnimation(string name)
        {
            Animation a = getCurrentAnimation();
            if (a == null) return false;

            return a.name == name;
        }

        public void restart()
        {
            currIdx = 0;
            frameDelayCount = 0;
        }

    }

    public class vfx
    {
        public AnimationController anim = new AnimationController();

        public string name;
        public RectangleF rect = new RectangleF();

        public bool finished = false;
        public bool followPlayer = false;

        public int offsetX;
        public int offsetY;

        public int timer = 0;
        public int maxTimer = 20;

        public void draw(Graphics g, RectangleF ownerR)
        {
            if (followPlayer)
            {
                rect.X = ownerR.X + ownerR.Width / 2f - rect.Width / 2f + offsetX;
                rect.Y = ownerR.Y + ownerR.Height - rect.Height + offsetY;
            }

            Bitmap frame = anim.playFrame();

            if (frame != null)
            {
                g.DrawImage(frame, rect.X, rect.Y, rect.Width, rect.Height);
            }

            timer++;

            if (timer >= maxTimer)
            {
                finished = true;
            }
        }
    }

    public class Hero
    {
        public RectangleF R = new Rectangle();
        public RectangleF drawR = new Rectangle();

        public float speed = 6f;

        public char moving = ' ';
        public bool isRunning = false;

        public float ySpeed = 0f;

        public float jumpPower = -22f;
        public float doubleJumpPower = -19f;

        public float gravity = 1.8f;
        public float fallGravity = 3.5f;

        public float maxFallSpeed = 28f;
        public float jumpCutSpeed = -4f;

        public bool jumpHeld = false;

        public int jumpsUsed = 0;
        public int maxJumps = 2;

        public bool isGrounded = false;
        bool wasGrounded = false;

        public bool isLanding = false;
        int landingTimer = 0;

        float prevBottom = 0f;

        Animation doubleJumpAnimation;
        public int level = 0;

        public AnimationController anim = new AnimationController();

        public Health HP = new Health(50, 100);
        public Mana mana = new Mana(75, 100);
        public UIEntity UI = new UIEntity(20f, 20f, 236f, 26f, true, true);


        public List<vfx> vfxes = new List<vfx>();

        public int damage = 10;

        public bool isAttacking = false;
        public bool attackHasHit = false;

        public int attackHitFrame = 4; //first 4 frames in teh attack animation are normal
        public int attackComboExtraFrames = 2; // last 2 frames are extra whgen there is a combo
        public float attackMoveMultiplier = 0.55f;

        public char facing = 'r';

        public float attackRange = 80f;
        public float attackHeightScale = 1.2f;
        public void initVFX()
        {
            doubleJumpAnimation = new Animation();
            doubleJumpAnimation.name = "doubleJump";
            doubleJumpAnimation.frameDelay = 2;

            for (int i = 1; i <= 5; i++)
            {
                Bitmap frame = new Bitmap("vfx/doubleJump/" + i + ".png");
                doubleJumpAnimation.addFrame(frame);
            }
        }
        void createDoubleJumpVFX()
        {
            vfx fx = new vfx();

            fx.name = "doubleJump";
            fx.maxTimer = 5;
            fx.anim.addAnim(doubleJumpAnimation);
            fx.anim.changeAnimation("doubleJump", -1);


            fx.rect.Width = 90;
            fx.rect.Height = 45;

            fx.rect.X = R.X + R.Width / 2f - fx.rect.Width / 2f;
            fx.rect.Y = R.Y + R.Height - fx.rect.Height / 2f - 20;

            fx.followPlayer = false;


            fx.maxTimer = doubleJumpAnimation.frames.Count * doubleJumpAnimation.frameDelay;

            vfxes.Add(fx);
        }

        public void Draw(Graphics g, bool showRanges)
        {
            drawR.X = R.X + (R.Width - drawR.Width) / 2f;
            drawR.Y = R.Y + (R.Height - drawR.Height);

            for (int i = vfxes.Count - 1; i >= 0; i--)
            {
                vfxes[i].draw(g, R);

                if (vfxes[i].finished)
                {
                    vfxes.RemoveAt(i);
                }
            }

            Bitmap frame = anim.playFrame();

            if (frame != null)
            {
                g.DrawImage(frame, drawR.X, drawR.Y, drawR.Width, drawR.Height);
            }

            if (showRanges)
            {
                Pen p = new Pen(Color.Lime, 2);
                g.DrawRectangle(p, R.X, R.Y, R.Width, R.Height);

                if (isAttacking == true)
                {
                    RectangleF atk = getAttackHitBox();
                    Pen atkPen = new Pen(Color.Orange, 2);
                    g.DrawRectangle(atkPen, atk.X, atk.Y, atk.Width, atk.Height);
                }
            }

            UI.draw(g, HP, mana, level);
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
            initVFX();

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

        public bool isDoingCombo = false;
        public void startAttack()
        {
            if (isAttacking == true)
            {
                Animation attackAnim = anim.getCurrentAnimation();
                if (attackAnim != null)
                {
                    int usableFrames = attackAnim.frames.Count - attackComboExtraFrames;
                    if (anim.currIdx >= usableFrames)
                        isDoingCombo = true;
                }
                return;
            }

            isAttacking = true;
            attackHasHit = false;
            isDoingCombo = false;
            isRunning = false;

            anim.changeAnimation("attack", -1);
            anim.restart();
        }

        public RectangleF getAttackHitBox()
        {
            float h = R.Height * attackHeightScale;
            float y = R.Y + (R.Height - h) / 2f;

            if (facing == 'r')
            {
                return new RectangleF(R.X, y, R.Width + attackRange, h );
            }
            else
            {
                return new RectangleF( R.X - attackRange + 5, y, R.Width + attackRange, h);
            }
        }

        public void updateAttack(List<Enemy> enemies)
        {
            if (isAttacking == false) return;

            anim.changeAnimation("attack", -1);

            Animation attackAnim = anim.getCurrentAnimation();
            if (attackAnim == null) return;

            int usableFrames = attackAnim.frames.Count - attackComboExtraFrames;

            if (usableFrames <= 0)
            {
                usableFrames = attackAnim.frames.Count;
            }

            if (anim.currIdx >= usableFrames)
            {
                isAttacking = false;
                attackHasHit = false;

                if (isDoingCombo)
                {
                    isDoingCombo = false;
                    isAttacking = true;
                    anim.changeAnimation("attack", -1);
                    anim.restart();
                    attackHasHit = false;
                    return;
                }

                updateAnimation();
                return;
            }

            if (attackHasHit == false && anim.currIdx >= attackHitFrame - 1)
            {
                RectangleF hitBox = getAttackHitBox();

                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy en = enemies[i];

                    if (en.isDead == false)
                    {
                        if (hitBox.X <= en.R.X + en.R.Width && hitBox.X + hitBox.Width >= en.R.X &&
                            hitBox.Y <= en.R.Y + en.R.Height && hitBox.Y + hitBox.Height >= en.R.Y)
                        {
                            en.takeHit(damage);
                            // break;
                        }

                    }
                }

                attackHasHit = true;
            }
        }

        public void move(List<tile> tiles)
        {
            float moveSpeed = speed;

            if (isRunning == true)
            {
                moveSpeed = speed * 2f;
            }
            if (isAttacking == true && isGrounded == true) moveSpeed *= attackMoveMultiplier;

            float xMove = 0f;

            if (moving == 'l')
            {
                xMove = -moveSpeed;
            }
            else if (moving == 'r')
            {
                xMove = moveSpeed;
            }

            R.X += xMove;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];

                if (t.interact == true)
                {
                    if (t.jumpThrough == false)
                    {
                        bool hitTile = false;

                        if (R.X + R.Width > t.R.X &&
                            R.X < t.R.X + t.R.Width &&
                            R.Y + R.Height > t.R.Y &&
                            R.Y < t.R.Y + t.R.Height)
                        {
                            hitTile = true;
                        }

                        if (hitTile == true)
                        {
                            if (xMove > 0)
                            {
                                R.X = t.R.X - R.Width;
                            }
                            else if (xMove < 0)
                            {
                                R.X = t.R.X + t.R.Width;
                            }
                        }
                    }
                }
            }

            Movement(tiles);

            if (!isAttacking)
                updateAnimation();
        }
        public void Movement(List<tile> tiles)
        {
            wasGrounded = isGrounded;
            prevBottom = R.Y + R.Height;

            if (ySpeed < 0)
            {
                ySpeed += gravity;
            }
            else
            {
                ySpeed += fallGravity;
            }

            if (ySpeed > maxFallSpeed)
            {
                ySpeed = maxFallSpeed;
            }

            R.Y += ySpeed;

            isGrounded = false;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];

                if (t.interact == true)
                {
                    bool touchingX = false;

                    if (R.X + R.Width > t.R.X &&
                        R.X < t.R.X + t.R.Width)
                    {
                        touchingX = true;
                    }

                    if (touchingX == true)
                    {
                        if (t.jumpThrough == true)
                        {
                            if (ySpeed >= 0)
                            {
                                if (prevBottom <= t.R.Y)
                                {
                                    if (R.Y + R.Height >= t.R.Y)
                                    {
                                        R.Y = t.R.Y - R.Height;
                                        ySpeed = 0;
                                        isGrounded = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            bool touchingY = false;

                            if (R.Y + R.Height > t.R.Y &&
                                R.Y < t.R.Y + t.R.Height)
                            {
                                touchingY = true;
                            }

                            if (touchingY == true)
                            {
                                if (ySpeed > 0)
                                {
                                    R.Y = t.R.Y - R.Height;
                                    ySpeed = 0;
                                    isGrounded = true;
                                }
                                else if (ySpeed < 0)
                                {
                                    R.Y = t.R.Y + t.R.Height;
                                    ySpeed = 0;
                                }
                            }
                        }
                    }
                }
            }

            if (isGrounded == true)
            {
                jumpsUsed = 0;
                jumpHeld = false;

                if (wasGrounded == false)
                {
                    isLanding = true;
                    landingTimer = 6;
                    anim.changeAnimation("landing", -1);
                }
            }

            if (wasGrounded == true)
            {
                if (isGrounded == false)
                {
                    if (jumpsUsed == 0)
                    {
                        jumpsUsed = 1;
                    }
                }
            }
        }

        public void checkUnder(List<tile> tiles)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                tile trav = tiles[i];
                if (trav.jumpThrough == true && trav.interact == true)
                {
                    if (R.X <= trav.R.X + trav.R.Width && R.X + R.Width >= trav.R.X &&
                        R.Y < trav.R.Y && R.Y + R.Height + 1 >= trav.R.Y)
                    {
                        R.Y += 2;
                    }
                }
            }
        }
        public void stopJump()
        {
            jumpHeld = false;

            if (isGrounded == false && ySpeed < 0)
            {
                if (ySpeed * 0.35 > jumpCutSpeed) ySpeed = ySpeed * 0.35f;
                else ySpeed = jumpCutSpeed;
            }
        }
        public void jump()
        {
            jumpHeld = true; 

            if (isGrounded == true)
            {
                ySpeed = jumpPower;
                jumpsUsed = 1;
                isGrounded = false;
                isLanding = false;

                anim.changeAnimation("jump_flying", -1);
            }
            else
            {
                if (jumpsUsed < maxJumps)
                {
                    ySpeed = doubleJumpPower;
                    jumpsUsed++;

                    isLanding = false;
                    createDoubleJumpVFX();

                    anim.changeAnimation("jump_flying", -1);
                }
            }
        }
        public void updateAnimation()
        {
            if (isAttacking == true)
            {
                anim.changeAnimation("attack", -1);
                return;
            }

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
                if (ySpeed < 0)
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

    public class Enemy
    {
        public RectangleF R = new RectangleF();
        public RectangleF drawR = new Rectangle();

        public float speed = 4f;

        public char moving = 'l';
        public bool isRunning = false;

        public float velocityY = 0f;
        public float gravity = 1.2f;
        public float max_speed = 25f;

        public bool isGrounded = false;
        public bool wasGrounded = false;
        public float prevBottom = 0f;

        public bool isDead = false;
        public bool isTakingDamage = false;
        public bool isAttacking = false;

        public int damageTimer = 0;
        public int attackTimer = 0;
        public int deathTimer = 0;

        public float startX = 0f;
        public float patrolDistance = 200f;
        public float leftLimit = 0f;
        public float rightLimit = 0f;

        public int spawnX = 0;
        public int spawnY = 0;
        public bool CanSpawn = false;
        public int spawnTime = 600;

        public Health HP;
        public UIEntity UI;

        public AnimationController anim = new AnimationController();
        public Enemy(int startX, int startY, int w, int h)
        {
            spawnX = startX;
            spawnY = startY;

            drawR.X = startX;
            drawR.Y = startY;
            drawR.Width = w;
            drawR.Height = h;

            R.Width = w * 0.45f;
            R.Height = h * 0.60f;
            R.X = startX + (w - R.Width) / 2f;
            R.Y = startY + (h - R.Height);

            this.startX = R.X;

            leftLimit = R.X - patrolDistance;
            rightLimit = R.X + patrolDistance;

            moving = 'l';

            HP = new Health(50, 50);
            UI = new UIEntity(0, 0, 70, 15, false, true);

            createAnim();
            anim.changeAnimation("idle", -1);

            isGrounded = true;
            wasGrounded = true;
        }
        public void draw(Graphics g, bool showRanges)
        {
            drawR.X = R.X + (R.Width - drawR.Width) / 2f;
            drawR.Y = R.Y + (R.Height - drawR.Height);

            Bitmap frame;

            if (isDead)
            {
                frame = anim.playFrameOnce();
            }
            else
            {
                frame = anim.playFrame();
            }

            if (frame != null)
            {
                g.DrawImage(frame, drawR.X, drawR.Y, drawR.Width, drawR.Height);
            }

            if (showRanges)
            {
                Pen p = new Pen(Color.Red, 2);
                g.DrawRectangle(p, R.X, R.Y, R.Width, R.Height);
            }

            if (isDead == false)
            {
                UI.positionAbove(R, 8);
                UI.draw(g, HP, null, 0);
            }
        }
        void createAnim()
        {
            string[] folders = { "attack", "die", "hit", "idle", "run", "stun-attack" };
            int[] numFrames = { 10, 15, 5, 7, 8, 24 };

            for (int i = 0; i < 6; i++)
            {
                Animation a = new Animation();

                a.name = folders[i];
                if (folders[i] == "idle")
                {
                    a.frameDelay = 2;
                }
                else if (folders[i] == "run")
                {
                    a.frameDelay = 2;
                }
                else if (folders[i] == "attack")
                {
                    a.frameDelay = 2;
                }
                else if (folders[i] == "hit")
                {
                    a.frameDelay = 3;
                }
                else if (folders[i] == "die")
                {
                    a.frameDelay = 3;
                }
                else if (folders[i] == "stun-attack")
                {
                    a.frameDelay = 3;
                }

                string path = "Characters/Enemies/Mushroom/" + folders[i] + "/";

                for (int j = 1; j <= numFrames[i]; j++)
                {
                    Bitmap img = new Bitmap(path + j.ToString() + ".png");
                    a.frames.Add(img);
                }

                this.anim.addAnim(a);
            }
        }

        public void takeHit(int amount)
        {
            if (isDead == true)
            {
                return;
            }
            HP.damage(amount);

            if (HP.getHP() <= 0)
            {
                isDead = true;
                isTakingDamage = false;
                isAttacking = false;

                deathTimer = 0;

                anim.changeAnimation("die", -1);
                anim.restart();
            }
            else
            {
                isTakingDamage = true;
                isAttacking = false;

                damageTimer = 15;

                anim.changeAnimation("hit", -1);
                anim.restart();
            }
        }
        
        public void move(List<tile> tiles)
        {
            if (isDead || isTakingDamage || isAttacking)
            {
                applyPhysics(tiles);
                updateAnimation();
                return;
            }

            float dx = 0f;

            if (moving == 'l')
            {
                dx = -speed;
            }
            else if (moving == 'r')
            {
                dx = speed;
            }

            R.X += dx;

            if (R.X <= leftLimit)
            {
                R.X = leftLimit;
                moving = 'r';
            }
            else if (R.X >= rightLimit)
            {
                R.X = rightLimit;
                moving = 'l';
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];

                if (t.interact == true && t.jumpThrough == false)
                {
                    bool overlappingX = false;
                    if (R.X + R.Width > t.R.X &&
                        R.X < t.R.X + t.R.Width) overlappingX = true;

                    bool overlappingY = false;
                    if (R.Y + R.Height > t.R.Y &&
                        R.Y < t.R.Y + t.R.Height) overlappingY = true;

                    if (overlappingX && overlappingY)
                    {
                        float overlapTop = R.Y;
                        if (t.R.Y > overlapTop) overlapTop = t.R.Y;

                        float overlapBottom =R.Y + R.Height;
                        if(t.R.Y + t.R.Height < R.Y + R.Height ) overlapBottom = t.R.Y + t.R.Height;

                        float overlapY = overlapBottom - overlapTop;


                        if (overlapY > 3f)
                        {
                            if (dx > 0)
                            {
                                R.X = t.R.X - R.Width;
                                moving = 'l';
                            }
                            else if (dx < 0)
                            {
                                R.X = t.R.X + t.R.Width;
                                moving = 'r';
                            }
                        }
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

            if (velocityY > max_speed)
                velocityY = max_speed;

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
        }
        public void updateAnimation()
        {
            if (isDead)
            {
                if (anim.isCurrentAnimation("die") == false)
                {
                    anim.changeAnimation("die", -1);
                    anim.restart();
                }

                return;
            }

            if (isTakingDamage)
            {
                anim.changeAnimation("hit", -1);
                damageTimer--;

                if (damageTimer <= 0)
                {
                    isTakingDamage = false;
                }
                return;
            }

            if (isAttacking)
            {
                anim.changeAnimation("attack", -1);
                attackTimer--;

                if (attackTimer <= 0)
                {
                    isAttacking = false;
                }
                return;
            }

            if (moving == ' ')
            {
                anim.changeAnimation("idle", -1);
            }
            else
            {
                anim.changeAnimation("run", -1);
            }
        }
        public void respawn()
        {
            if (CanSpawn)
            {
                R.X = spawnX + (drawR.Width - R.Width) / 2f;
                R.Y = spawnY;
                drawR.X = spawnX;
                drawR.Y = spawnY - (drawR.Height - R.Height);

                velocityY = 0f;

                moving = 'l';

                isDead = false;
                isTakingDamage = false;
                isAttacking = false;

                damageTimer = 0;
                attackTimer = 0;
                deathTimer = 0;

                isGrounded = true;
                wasGrounded = true;

                HP.maxHP = 50;
                HP.HP = HP.maxHP;

                anim.changeAnimation("idle", -1);
            }
        }
    }

    public class tile
    {
        public Rectangle R = new Rectangle();
        public Color clr = Color.Black;
        public bool interact = false;
        public bool jumpThrough = false;

        public void draw(Graphics g)
        {
            SolidBrush bsh = new SolidBrush(clr);
            g.FillRectangle(bsh, R.X, R.Y, R.Width, R.Height);
        }

        public void init(int x, int y, int width, int height)
        {
            R.X = x;
            R.Y = y;
            R.Height = height;
            R.Width = width;
        }
    }

    public class Button
    {
        public Rectangle rect = new Rectangle();
        string text;

        public Button(int x, int y, int w, int h, string text)
        {
            this.text = text;
            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;
        }

        public void draw(Bitmap button, Graphics g, Font f, SolidBrush bsh, bool isCurrent)
        {
            g.DrawImage(button, rect.X, rect.Y, rect.Width, rect.Height);

            if (isCurrent == true)
            {
                drawSelectionIcon(g);
            }

            int startX = rect.X + rect.Width / 2 - text.Length * 7;
            g.DrawString(text, f, bsh, startX, rect.Y + rect.Height / 2 - 22);
        }

        void drawSelectionIcon(Graphics g)
        {
            Pen p = new Pen(Color.FromArgb(90, 40, 35), 5);
            g.DrawRectangle(p, rect.X + 3, rect.Y + 3, rect.Width - 8, rect.Height - 8);

            p = new Pen(Color.FromArgb(230, 180, 90), 3);
            g.DrawRectangle(p, rect.X + 8, rect.Y + 8, rect.Width - 18, rect.Height - 18);

            p = new Pen(Color.FromArgb(255, 230, 150), 1);
            g.DrawRectangle(p, rect.X + 12, rect.Y + 12, rect.Width - 26, rect.Height - 26);


        }
    }
    public partial class Form1 : Form
    {
        bool hasStarted = false;

        Bitmap button = new Bitmap("ui/menu/UI_TravelBook_Frame01a.png");
        int currentButton = 0;

        List<Bitmap> menuImgs = new List<Bitmap>();
        List<Button> btns = new List<Button>();


        bool showRanges = false;
        Bitmap off;
        Random RR = new Random();

        Hero hero;
        List<Enemy> enemies = new List<Enemy>();
        List<tile> tiles = new List<tile>();
        Timer timer = new Timer();

        public Form1()
        {
            this.Paint += Form1_Paint;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            this.BackColor = Color.FromArgb(115, 85, 87);
            this.Text = "Arcane";
            timer.Interval = 1;
            timer.Stop();
            timer.Tick += Timer_Tick;

            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (hasStarted == false)
            {
                Button btn = btns[btns.Count - 1];
                if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                            && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                {
                    startGame();
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    hero.startAttack();
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (hasStarted == false)
            {
                for (int i = 0; i < btns.Count; i++)
                {
                    Button btn = btns[i];
                    if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                        && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                    {
                        currentButton = i;
                        drawDubb(this.CreateGraphics());
                        break;
                    }
                }
            }
        }

        void startGame()
        {
            hasStarted = true;

            while (btns.Count > 0)
            {
                btns.RemoveAt(0);
            }

            while (menuImgs.Count > 0)
            {
                menuImgs.RemoveAt(0);
            }
            timer.Start();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (hasStarted == false) return;


            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && hero.moving == 'r')
            {
                hero.moving = ' ';

            }
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && hero.moving == 'l')
            {
                hero.moving = ' ';

            }
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                hero.stopJump();
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                hero.isRunning = false;
            }



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (hasStarted == false)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (currentButton < btns.Count - 2) currentButton++;
                    else currentButton = 0;
                    drawDubb(this.CreateGraphics());

                }
                if (e.KeyCode == Keys.Up)
                {
                    if (currentButton > 0) currentButton--;
                    else currentButton = btns.Count - 2;
                    drawDubb(this.CreateGraphics());
                }

                if (currentButton == 0 || currentButton == 1)
                {
                    if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                    {
                        currentButton = btns.Count - 1;
                        drawDubb(this.CreateGraphics());

                    }
                }
                else if (currentButton == btns.Count - 1)
                {
                    if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                    {
                        currentButton = 0;
                        drawDubb(this.CreateGraphics());

                    }
                }

                if (currentButton == btns.Count - 1)
                {
                    if (e.KeyCode == Keys.Enter) startGame();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    hero.moving = 'r';
                    hero.facing = 'r';
                }
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    hero.moving = 'l';
                    hero.facing = 'l';
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    hero.checkUnder(tiles);
                }
                if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                {
                    if (hero.jumpHeld == false)
                    {
                        hero.jump();
                    }
                }

                if (e.KeyCode == Keys.ShiftKey && hero.isAttacking == false)
                {
                    hero.isRunning = true;
                }


                if (e.KeyCode == Keys.P)
                {
                    if (showRanges == true) showRanges = false;
                    else showRanges = true;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            hero.move(tiles);
            hero.updateAttack(enemies);
            handleEnemyMovement();
            drawDubb(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);


            hero = new Hero(30, this.ClientSize.Height - 150 - 30, 150, 150);
            initTiles();
            initEnemies();
            initButtons();
            initMenu();
            drawDubb(this.CreateGraphics());

        }

        int getAboveGroundLoc(int idx)
        {
            return this.ClientSize.Height - 30 - enemyH[idx];
        }

        int[] enemyW = { 120 };
        int[] enemyH = { 96 };
        string[] enemyType = { "Mushroom" };



        void initEnemies()
        {
            for (int i = 0; i < enemyType.Length; i++)
            {
                if (enemyType[i] == "Mushroom")
                {
                    //call initMushroomEnemy later if its alot or just put all mushrooms here

                    Enemy en = new Enemy(600, getAboveGroundLoc(0), enemyW[i], enemyH[0]);
                    en.CanSpawn = true;
                    enemies.Add(en);

                    en = new Enemy(600, getAboveGroundLoc(0), enemyW[i], enemyH[0]);
                    enemies.Add(en);

                     en = new Enemy(700, getAboveGroundLoc(0), enemyW[i], enemyH[0]);
                    enemies.Add(en);
                     en = new Enemy(800, getAboveGroundLoc(0), enemyW[i], enemyH[0]);
                    enemies.Add(en);
                     en = new Enemy(900, getAboveGroundLoc(0), enemyW[i], enemyH[0]);
                    enemies.Add(en);
                }

            }
        }

        void initTiles()
        {
            tile pnn = new tile();
            pnn.interact = true;
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

            if (hasStarted == true)
            {
                for (int i = 0; i < tiles.Count; i++)
                {
                    tiles[i].draw(g);
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].draw(g, showRanges);
                }

                hero.Draw(g, showRanges);
            }
            else
            {
                displayMenu(g);
            }
        }

        void initMenu()
        {
            Bitmap img = new Bitmap("ui/menu/UI_TravelBook_BookCover01a.png");
            menuImgs.Add(img);
            img = new Bitmap("ui/menu/UI_TravelBook_BookPageLeft01a.png");
            menuImgs.Add(img);

            img = new Bitmap("ui/menu/UI_TravelBook_BookPageRight01a.png");

            menuImgs.Add(img);

            img = new Bitmap("ui/menu/mainImage.png");

            menuImgs.Add(img);
            img = new Bitmap("ui/border.png");

            menuImgs.Add(img);
            img = new Bitmap("ui/hero_icon.png");
            menuImgs.Add(img);
        }
        void initButtons()
        {
            int w = 300, h = 60;

            int ButtonsY = 60 + 300;
            int ButtonsX = (this.ClientSize.Width / 2) / 2 - w / 2;

            Button btn = new Button(ButtonsX, ButtonsY, w, h, "New Game");
            btns.Add(btn);

            ButtonsY += (h + 20);
            btn = new Button(ButtonsX, ButtonsY, w, h, "Load Game");
            btns.Add(btn);

            ButtonsY += (h + 20);
            btn = new Button(ButtonsX, ButtonsY, w, h, "Options");
            btns.Add(btn);

            ButtonsY += (h + 20);
            btn = new Button(ButtonsX, ButtonsY, w, h, "Credits");
            btns.Add(btn);


            ButtonsX = (this.ClientSize.Width / 2) + (this.ClientSize.Width / 2) / 2 - w / 2;

            int newGameY = 30 + this.ClientSize.Height - 160 - h;
            btn = new Button(ButtonsX, newGameY, w, h, "Start");
            btns.Add(btn);

        }
        void displayMenu(Graphics G)
        {
            G.DrawImage(menuImgs[0], 0, 0, this.ClientSize.Width, this.ClientSize.Height);
            int spacing = 20;
            G.DrawImage(menuImgs[1], spacing, spacing, this.ClientSize.Width / 2 - spacing, this.ClientSize.Height - spacing * 2);
            G.DrawImage(menuImgs[2], this.ClientSize.Width / 2, spacing, this.ClientSize.Width / 2 - spacing, this.ClientSize.Height - spacing * 2);

            int pad = 20;
            int borderW = this.ClientSize.Width / 2 - pad * 2;
            int borderHeight = this.ClientSize.Height - spacing * 2 - pad * 2 - 5;
            G.DrawImage(menuImgs[4], pad + 5, spacing + pad / 2, borderW, borderHeight);


            G.DrawImage(menuImgs[3], spacing + 20, spacing + 20, this.ClientSize.Width / 2 - spacing - 50, 400);

            //1/2   1/2
            //|  |  |  |  |
            int borderX = this.ClientSize.Width / 2 + pad;
            int borderY = spacing + pad / 2;
            G.DrawImage(menuImgs[4], borderX, borderY, borderW, borderHeight);



            int iconW = 100;
            G.DrawImage(menuImgs[5], borderX + 60, borderY + 60, iconW, iconW);


            Font f = new Font("Comic Sans MS", 18, FontStyle.Bold);
            SolidBrush bsh = new SolidBrush(Color.White);
            for (int i = 0; i < btns.Count; i++)
            {
                bool isIt = false;
                if (i == currentButton) isIt = true;


                Button btn = btns[i];
                if (i < btns.Count - 1 || currentButton == 0 || currentButton == 1 || currentButton == btns.Count - 1)
                    btn.draw(button, G, f, bsh, isIt);
            }


            loadScreen(G, borderX + 60 + 100 + 20, borderY + 60, borderW - (60 + 100 + 20), borderHeight - 60);
        }

        void loadScreen(Graphics G, int x, int y, int width, int height)
        {
            if (currentButton == 0)
            {
                //show new game screen
            }
            if (currentButton == 1)
            {
                //show load
            }
            if (currentButton == 0)
            {
                //show options
            }
            if (currentButton == 0)
            {
                //show credits
            }
        }


        void handleEnemyMovement()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].isDead)
                {
                    if (enemies[i].anim.currIdx == enemies[i].anim.animations[enemies[i].anim.currAnim].frames.Count - 1)
                    {
                        if (enemies[i].CanSpawn == false)
                        {
                            enemies.RemoveAt(i);
                            i--;
                            break;
                        }
                    }

                    enemies[i].deathTimer++;

                    if (enemies[i].deathTimer >= enemies[i].spawnTime)
                    {
                        enemies[i].respawn();
                    }
                }

                enemies[i].move(tiles);
            }
        }

        
    }
}
