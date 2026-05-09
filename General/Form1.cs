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
    public class Save
    {
        public int timer = 0;
        int max = 1000;
        
        public void save(Hero hero , List<Enemy> Enemies)
        {
            saveHero(hero);
            saveEnemies( Enemies);

        }
        public void autoSave(Hero hero, List<Enemy> Enemies)
        {
            if(timer < max)
            {
                timer++;
            }
            else
            {
                timer = 0;
                save(hero , Enemies);
            }
        }

        void saveHero( Hero hero)
        {

            StreamWriter sw = new StreamWriter("Saves/hero.txt");

            sw.WriteLine("X,Y:" + hero.R.X.ToString() + "," + hero.R.Y.ToString());
            sw.WriteLine("Moving:" + hero.moving);
            sw.WriteLine("ySpeed:" + hero.ySpeed.ToString());

            sw.WriteLine("jumpsUsed:" + hero.jumpsUsed.ToString());
            sw.WriteLine("isGrounded:" + hero.isGrounded.ToString());
            sw.WriteLine("wasGrounded:" + hero.wasGrounded.ToString());
            sw.WriteLine("isLanding:" + hero.isLanding.ToString());
            sw.WriteLine("landingTimer:" + hero.landingTimer.ToString());
            sw.WriteLine("prevBottom:" + hero.prevBottom.ToString());

            sw.WriteLine("isTakingDamage:" + hero.isTakingDamage.ToString());
            sw.WriteLine("takingDamageTimer:" + hero.takingDamageTimer.ToString());

            sw.WriteLine("coins:" + hero.coins.ToString());

            sw.WriteLine("isAttacking:" + hero.isAttacking.ToString());
            sw.WriteLine("attackHasHit:" + hero.attackHasHit.ToString());

            sw.WriteLine("maxHP:" + hero.HP.maxHP.ToString());
            sw.WriteLine("HP:" + hero.HP.HP.ToString());

            sw.WriteLine("maxMana:" + hero.mana.maxMana.ToString());
            sw.WriteLine("mana:" + hero.mana.mana.ToString());
            sw.WriteLine("regenRate:" + hero.mana.regenRate.ToString());

            sw.WriteLine("facing:" + hero.facing.ToString());

            for (int i = 0; i < hero.Weapons.Count; i++)
            {
                sw.WriteLine("Weapon" + i + "_Damage:" + hero.Weapons[i].damage.ToString());
            }

            sw.WriteLine("currentWeapon:" + hero.currentWeapon.ToString());

            sw.WriteLine("isSpellCasting:" + hero.isSpellCasting.ToString());
            sw.WriteLine("isShooting:" + hero.isShooting.ToString());
            sw.WriteLine("spellCastPaused:" + hero.spellCastPaused.ToString());

            sw.WriteLine("manaRegenRate:" + hero.manaRegenRate.ToString());

            sw.WriteLine("isCastingAbility:" + hero.isCastingAbility.ToString());
            sw.WriteLine("abilityFireballSpawned:" + hero.abilityFireballSpawned.ToString());
            sw.WriteLine("abilityManaCost:" + hero.abilityManaCost.ToString());
            sw.WriteLine("abilityKeyDown:" + hero.abilityKeyDown.ToString());

            sw.WriteLine("isDead:" + hero.isDead.ToString());

            sw.Close();
        }

        void saveEnemies(List<Enemy> enemies)
        {
            StreamWriter sw = new StreamWriter("Saves/Enemies.txt");

            sw.WriteLine("EnemiesCount:" + enemies.Count.ToString());

            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy enemy = enemies[i];

                sw.WriteLine("Enemy" + i + "_X:" + enemy.R.X.ToString());
                sw.WriteLine("Enemy" + i + "_Y:" + enemy.R.Y.ToString());

                sw.WriteLine("Enemy" + i + "_speed:" + enemy.speed.ToString());

                sw.WriteLine("Enemy" + i + "_moving:" + enemy.moving.ToString());
                sw.WriteLine("Enemy" + i + "_facing:" + enemy.facing.ToString());
                sw.WriteLine("Enemy" + i + "_isRunning:" + enemy.isRunning.ToString());

                sw.WriteLine("Enemy" + i + "_velocityY:" + enemy.velocityY.ToString());
                sw.WriteLine("Enemy" + i + "_gravity:" + enemy.gravity.ToString());
                sw.WriteLine("Enemy" + i + "_max_speed:" + enemy.max_speed.ToString());

                sw.WriteLine("Enemy" + i + "_isGrounded:" + enemy.isGrounded.ToString());
                sw.WriteLine("Enemy" + i + "_wasGrounded:" + enemy.wasGrounded.ToString());
                sw.WriteLine("Enemy" + i + "_prevBottom:" + enemy.prevBottom.ToString());

                sw.WriteLine("Enemy" + i + "_isDead:" + enemy.isDead.ToString());
                sw.WriteLine("Enemy" + i + "_isTakingDamage:" + enemy.isTakingDamage.ToString());
                sw.WriteLine("Enemy" + i + "_isAttacking:" + enemy.isAttacking.ToString());

                sw.WriteLine("Enemy" + i + "_damageTimer:" + enemy.damageTimer.ToString());
                sw.WriteLine("Enemy" + i + "_attackTimer:" + enemy.attackTimer.ToString());
                sw.WriteLine("Enemy" + i + "_deathTimer:" + enemy.deathTimer.ToString());

                sw.WriteLine("Enemy" + i + "_attackFrameTimer:" + enemy.attackFrameTimer.ToString());
                sw.WriteLine("Enemy" + i + "_attackCooldown:" + enemy.attackCooldown.ToString());
                sw.WriteLine("Enemy" + i + "_attackDamageDone:" + enemy.attackDamageDone.ToString());

                sw.WriteLine("Enemy" + i + "_startX:" + enemy.startX.ToString());
                sw.WriteLine("Enemy" + i + "_patrolDistance:" + enemy.patrolDistance.ToString());
                sw.WriteLine("Enemy" + i + "_leftLimit:" + enemy.leftLimit.ToString());
                sw.WriteLine("Enemy" + i + "_rightLimit:" + enemy.rightLimit.ToString());

                sw.WriteLine("Enemy" + i + "_spawnX:" + enemy.spawnX.ToString());
                sw.WriteLine("Enemy" + i + "_spawnY:" + enemy.spawnY.ToString());
                sw.WriteLine("Enemy" + i + "_CanSpawn:" + enemy.CanSpawn.ToString());
                sw.WriteLine("Enemy" + i + "_spawnTime:" + enemy.spawnTime.ToString());

                sw.WriteLine("Enemy" + i + "_isWaiting:" + enemy.isWaiting.ToString());
                sw.WriteLine("Enemy" + i + "_waitTime:" + enemy.waitTime.ToString());
                sw.WriteLine("Enemy" + i + "_waitingTimer:" + enemy.waitingTimer.ToString());

                sw.WriteLine("Enemy" + i + "_spawnrange:" + enemy.spawnrange.ToString());
                sw.WriteLine("Enemy" + i + "_spawn:" + enemy.spawn.ToString());

                sw.WriteLine("Enemy" + i + "_attackrange:" + enemy.attackrange.ToString());
                sw.WriteLine("Enemy" + i + "_attackdis:" + enemy.attackdis.ToString());
                sw.WriteLine("Enemy" + i + "_attackmode:" + enemy.attackmode.ToString());

                sw.WriteLine("Enemy" + i + "_idle:" + enemy.idle.ToString());

                sw.WriteLine("Enemy" + i + "_enemyName:" + enemy.enemyName);

                sw.WriteLine("Enemy" + i + "_maxHP:" + enemy.HP.maxHP.ToString());
                sw.WriteLine("Enemy" + i + "_HP:" + enemy.HP.HP.ToString());
            }
            sw.Close();
        }
    }

    public class Load
    {
        public void load(Hero hero, List<Enemy> enemies)
        {
            loadHero(hero);
            loadEnemies(enemies);
        }
        int changeToInt(string val)
        {
            string num = "";
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == '.') break;
                num += val[i];
            }
            return Convert.ToInt32(num);
        }

        void loadHero(Hero hero)
        {
            StreamReader sr = new StreamReader("Saves/hero.txt");

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();

                string[] data = splitLine(line);

                string variable = data[0];
                string val = data[1];

                if (variable == "X,Y")
                {
                    string sx = "";
                    string sy = "";

                    bool foundComma = false;

                    for (int i = 0; i < val.Length; i++)
                    {
                        if (val[i] == ',')
                        {
                            foundComma = true;
                        }
                        else
                        {
                            if (foundComma == false)
                            {
                                sx += val[i];
                            }
                            else
                            {
                                sy += val[i];
                            }
                        }
                    }

                    hero.R.X = changeToInt(sx);
                    hero.R.Y = changeToInt(sy);
                }

                else if (variable == "Moving")
                {
                    hero.moving = val[0];
                }

                else if (variable == "ySpeed")
                {
                    hero.ySpeed = changeToInt(val);
                }

                else if (variable == "jumpsUsed")
                {
                    hero.jumpsUsed = changeToInt(val);
                }

                else if (variable == "isGrounded")
                {
                    if (val == "true")
                    {
                        hero.isGrounded = true;
                    }
                    else hero.isGrounded = false;
                }

                else if (variable == "wasGrounded")
                {
                    if (val == "true")
                    {
                        hero.wasGrounded = true;
                    }
                    else hero.wasGrounded = false;
                }

                else if (variable == "isLanding")
                {
                    if (val == "true")
                    {
                        hero.isLanding = true;
                    }
                    else hero.isLanding = false;
                }

                else if (variable == "landingTimer")
                {
                    hero.landingTimer = changeToInt(val);
                }

                else if (variable == "prevBottom")
                {
                    hero.prevBottom = changeToInt(val);
                }

                else if (variable == "isTakingDamage")
                {
                    if (val == "true")
                    {
                        hero.isTakingDamage= true;
                    }
                    else hero.isTakingDamage = false;
                }

                else if (variable == "takingDamageTimer")
                {
                    hero.takingDamageTimer = changeToInt(val);
                }

                else if (variable == "coins")
                {
                    hero.coins = changeToInt(val);
                }

                else if (variable == "isAttacking")
                {
                    if (val == "true")
                    {
                        hero.isAttacking = true;
                    }
                    else hero.isAttacking= false;
                }

                else if (variable == "attackHasHit")
                {
                    if (val == "true")
                    {
                        hero.attackHasHit= true;
                    }
                    else hero.attackHasHit = false;
                }

                else if (variable == "maxHP")
                {
                    hero.HP.maxHP = changeToInt(val);
                }

                else if (variable == "HP")
                {
                    hero.HP.HP = changeToInt(val);
                }

                else if (variable == "maxMana")
                {
                    hero.mana.maxMana = changeToInt(val);
                }

                else if (variable == "mana")
                {
                    hero.mana.mana = changeToInt(val);
                }

                else if (variable == "regenRate")
                {
                    hero.mana.regenRate = changeToInt(val);
                }

                else if (variable == "facing")
                {
                    hero.facing = val[0];
                }

                else if (variable == "Weapon0_Damage")
                {
                    hero.Weapons[0].damage = changeToInt(val);
                }

                else if (variable == "Weapon1_Damage")
                {
                    hero.Weapons[1].damage = changeToInt(val);
                }

                else if (variable == "Weapon2_Damage")
                {
                    hero.Weapons[2].damage = changeToInt(val);
                }

                else if (variable == "currentWeapon")
                {
                    hero.currentWeapon = changeToInt(val);
                }

                else if (variable == "isSpellCasting")
                {
                    if (val == "true")
                    {
                        hero.isSpellCasting = true;
                    }
                    else hero.isSpellCasting = false;
                }

                else if (variable == "isShooting")
                {
                    if (val == "true")
                    {
                        hero.isShooting = true;
                    }
                    else hero.isShooting = false;
                }

                else if (variable == "spellCastPaused")
                {
                    if (val == "true")
                    {
                        hero.spellCastPaused = true;
                    }
                    else hero.spellCastPaused = false;
                }

                else if (variable == "manaRegenRate")
                {
                    hero.manaRegenRate = changeToInt(val);
                }

                else if (variable == "isCastingAbility")
                {
                    if (val == "true")
                    {
                        hero.isCastingAbility = true;
                    }
                    else hero.isCastingAbility = false;
                }

                else if (variable == "abilityFireballSpawned")
                {
                    if (val == "true")
                    {
                        hero.abilityFireballSpawned = true;
                    }
                    else hero.abilityFireballSpawned= false;
                }

                else if (variable == "abilityManaCost")
                {
                    hero.abilityManaCost = changeToInt(val);
                }

                else if (variable == "abilityKeyDown")
                {
                    if (val == "true")
                    {
                        hero.abilityKeyDown = true;
                    }
                    else hero.abilityKeyDown = false;
                }

                else if (variable == "isDead")
                {
                    if (val == "true")
                    {
                        hero.isDead = true;
                    }
                    else hero.isDead = false;
                }
            }

            sr.Close();
        }

        void loadEnemies(List<Enemy> enemies)
        {
            StreamReader sr = new StreamReader("Saves/Enemies.txt");

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();

                string[] data = splitLine(line);

                string variable = data[0];
                string val = data[1];

                if (variable != "EnemiesCount")
                {
                    string num = "";
                    bool foundUnderscore = false;

                    for (int i = 5; i < variable.Length; i++)
                    {
                        if (variable[i] == '_')
                        {
                            foundUnderscore = true;
                            break;
                        }

                        num += variable[i];
                    }

                    int enemyIndex = changeToInt(num);

                    string property = "";
                    bool startWriting = false;

                    for (int i = 0; i < variable.Length; i++)
                    {
                        if (startWriting == true)
                        {
                            property += variable[i];
                        }

                        if (variable[i] == '_')
                        {
                            startWriting = true;
                        }
                    }

                    Enemy enemy = enemies[enemyIndex];

                    if (property == "X")
                    {
                        enemy.R.X = changeToInt(val);
                    }

                    else if (property == "Y")
                    {
                        enemy.R.Y = changeToInt(val);
                    }

                    else if (property == "speed")
                    {
                        enemy.speed = changeToInt(val);
                    }

                    else if (property == "moving")
                    {
                        enemy.moving = val[0];
                    }

                    else if (property == "facing")
                    {
                        enemy.facing = val[0];
                    }

                    else if (property == "isRunning")
                    {
                        if (val == "true")
                        {
                            enemy.isRunning = true;
                        }
                        else enemy.isRunning = false;
                    }

                    else if (property == "velocityY")
                    {
                        enemy.velocityY = changeToInt(val);
                    }

                    else if (property == "gravity")
                    {
                        enemy.gravity = changeToInt(val);
                    }

                    else if (property == "max_speed")
                    {
                        enemy.max_speed = changeToInt(val);
                    }

                    else if (property == "isGrounded")
                    {
                        if (val == "true")
                        {
                            enemy.isGrounded = true;
                        }
                        else enemy.isGrounded = false;
                    }

                    else if (property == "wasGrounded")
                    {
                        if (val == "true")
                        {
                            enemy.wasGrounded = true;
                        }
                        else enemy.wasGrounded = false;
                    }

                    else if (property == "prevBottom")
                    {
                        enemy.prevBottom = changeToInt(val);
                    }

                    else if (property == "isDead")
                    {
                        if (val == "true")
                        {
                            enemy.isDead = true;
                        }
                        else enemy.isDead = false;
                    }

                    else if (property == "isTakingDamage")
                    {
                        if (val == "true")
                        {
                            enemy.isTakingDamage = true;
                        }
                        else enemy.isTakingDamage = false;
                    }

                    else if (property == "isAttacking")
                    {
                        if (val == "true")
                        {
                            enemy.isAttacking = true;
                        }
                        else enemy.isAttacking = false;
                    }

                    else if (property == "damageTimer")
                    {
                        enemy.damageTimer = changeToInt(val);
                    }

                    else if (property == "attackTimer")
                    {
                        enemy.attackTimer = changeToInt(val);
                    }

                    else if (property == "deathTimer")
                    {
                        enemy.deathTimer = changeToInt(val);
                    }

                    else if (property == "attackFrameTimer")
                    {
                        enemy.attackFrameTimer = changeToInt(val);
                    }

                    else if (property == "attackCooldown")
                    {
                        enemy.attackCooldown = changeToInt(val);
                    }

                    else if (property == "attackDamageDone")
                    {
                        if (val == "true")
                        {
                            enemy.attackDamageDone = true;
                        }
                        else enemy.attackDamageDone = false; 
                    }

                    else if (property == "startX")
                    {
                        enemy.startX = changeToInt(val);
                    }

                    else if (property == "patrolDistance")
                    {
                        enemy.patrolDistance = changeToInt(val);
                    }

                    else if (property == "leftLimit")
                    {
                        enemy.leftLimit = changeToInt(val);
                    }

                    else if (property == "rightLimit")
                    {
                        enemy.rightLimit = changeToInt(val);
                    }

                    else if (property == "spawnX")
                    {
                        enemy.spawnX = changeToInt(val);
                    }

                    else if (property == "spawnY")
                    {
                        enemy.spawnY = changeToInt(val);
                    }

                    else if (property == "CanSpawn")
                    {
                        if (val == "true")
                        {
                            enemy.CanSpawn = true;
                        }
                        else enemy.CanSpawn = false;
                    }

                    else if (property == "spawnTime")
                    {
                        enemy.spawnTime = changeToInt(val);
                    }

                    else if (property == "isWaiting")
                    {
                        if (val == "true")
                        {
                            enemy.isWaiting = true;
                        }
                        else enemy.isWaiting = false;
                    }

                    else if (property == "waitTime")
                    {
                        enemy.waitTime = changeToInt(val);
                    }

                    else if (property == "waitingTimer")
                    {
                        enemy.waitingTimer = changeToInt(val);
                    }

                    else if (property == "spawnrange")
                    {
                        enemy.spawnrange = changeToInt(val);
                    }

                    else if (property == "spawn")
                    {
                        if (val == "true")
                        {
                            enemy.spawn = true;
                        }
                        else enemy.spawn = false;
                    }

                    else if (property == "attackrange")
                    {
                        enemy.attackrange = changeToInt(val);
                    }

                    else if (property == "attackdis")
                    {
                        enemy.attackdis = changeToInt(val);
                    }

                    else if (property == "attackmode")
                    {
                        if (val == "true")
                        {
                            enemy.attackmode = true;
                        }
                        else enemy.attackmode = false;
                    }

                    else if (property == "idle")
                    {
                        if (val == "true")
                        {
                            enemy.idle = true;
                        }
                        else enemy.idle = false;
                    }

                    else if (property == "enemyName")
                    {
                        enemy.enemyName = val;
                    }

                    else if (property == "maxHP")
                    {
                        enemy.HP.maxHP = changeToInt(val);
                    }

                    else if (property == "HP")
                    {
                        enemy.HP.HP = changeToInt(val);
                    }
                }
            }

            sr.Close();
        }

        string[] splitLine(string line)
        {
            string variable = "";
            string val = "";

            bool foundColon = false;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ':')
                {
                    foundColon = true;
                }
                else
                {
                    if (foundColon == false)
                    {
                        variable += line[i];
                    }
                    else
                    {
                        val += line[i];
                    }
                }
            }

            string[] lineVal = new string[2];

            lineVal[0] = variable;
            lineVal[1] = val;

            return lineVal;
        }

    }
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
        public float maxMana = 100;
        public float mana = 100;
        public float regenRate = 0.5f;

        public Mana(float mana, float maxMana)
        {
            this.mana = mana;
            this.maxMana = maxMana;
        }
        public void tick()
        {
            mana += regenRate;
            if (mana > maxMana) mana = maxMana;
        }

        public float getMana()
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

    public class Weapon
    {
        public Bitmap UIImage;
        public int damage;
        public int rangeW;
        public int rangeH;

        public int order; //key number

    }
    public class UIEntity
    {
        public bool isHero = false;

        public bool displayHPBar = true;
        public bool displayHPText = true;

        public bool displayManaBar = true;
        public bool displayManaText = true;

        public bool displayName = false;

        public RectangleF rect = new RectangleF();

        Bitmap hpBorder = new Bitmap("ui/Health/bar.png");
        Bitmap hpBackground = new Bitmap("ui/Health/bar_background.png");
        Bitmap hpInner = new Bitmap("ui/Health/health_bar.png");

        Bitmap manaBackground = new Bitmap("ui/Mana/mana_bg.png");
        Bitmap manaInner = new Bitmap("ui/Mana/manaInner.png");

        Bitmap heroIcon = new Bitmap("ui/hero_icon.png");
        Bitmap heroBorder = new Bitmap("ui/border.png");

        Bitmap heroWeaponSlot = new Bitmap("ui/menu/slotSelected.png");
        Bitmap heroSelectedSlot = new Bitmap("ui/menu/slot.png");


        Font heroFont = new Font("Palatino Linotype", 9f, FontStyle.Bold);
        Font manaFont = new Font("Palatino Linotype", 8f, FontStyle.Bold);
        Font normalFont = new Font("Palatino Linotype", 8f, FontStyle.Bold);

        SolidBrush textBrush = new SolidBrush(Color.White);
        SolidBrush bigoutline = new SolidBrush(Color.Black);

        Bitmap goldCoinIcon;
        Bitmap silverCoinIcon;
        Bitmap bronzeCoinIcon;


        public UIEntity(float x, float y, float w, float h, bool isHero, bool showHPText)
        {
            this.isHero = isHero;
            this.displayHPText = showHPText;

            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;

            if (isHero == true)
            {
                goldCoinIcon = new Bitmap("ui/Coins/Gold/1.png");
                silverCoinIcon = new Bitmap("ui/Coins/Silver/1.png");
                bronzeCoinIcon = new Bitmap("ui/Coins/Bronze/1.png");

            }
        }

        public void positionAbove(RectangleF ownerR, float gap)
        {
            rect.X = ownerR.X + (ownerR.Width - rect.Width) / 2f;
            rect.Y = ownerR.Y - rect.Height - gap;
        }

        public void draw(Graphics g, Health hp, Mana mana, int coins)
        {
            if (isHero)
            {
                drawHeroUI(g, hp, mana, coins);
            }
            else
            {
                drawEntityUI(g, hp);
            }
        }

        void drawHeroUI(Graphics g, Health hp, Mana mana, int coins)
        {
            float iconBorderX = rect.X;
            float iconBorderY = rect.Y + 15f;

            float iconBorderW = 78f;
            float iconBorderH = 120f - 40f;

            float iconPad = 10f;
            float iconX = iconBorderX + iconPad;
            float iconY = iconBorderY + iconPad;
            float iconW = iconBorderW - iconPad * 2f;
            float iconH = iconBorderW - iconPad * 2f;



            g.DrawImage(heroBorder, iconBorderX, iconBorderY, iconBorderW, iconBorderH);
            g.DrawImage(heroIcon, iconX, iconY, iconW, iconH);



            float barX = iconBorderX + iconBorderW + 18f;

            float hpBarY = rect.Y + 25f;
            float manaBarY = hpBarY + rect.Height + 18f;

            float barW = rect.Width;
            float barH = rect.Height;

            float manaBarW = barW;
            float manaBarH = rect.Height / 2;

            float coinX = barX + 4;
            float coinY = manaBarY + manaBarH + 10;
            drawCoins(g, coins, coinX, coinY);

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

        public void drawCoins(Graphics g, int coins, float x, float y)
        {
            int remaining = coins;

            int NGold = remaining / 1000;
            remaining = remaining - NGold * 1000;

            int NSilver = remaining / 100;
            remaining = remaining - NSilver * 100;

            int NBronze = remaining;


            int wh = 15;
            int spacing = 25;

            g.DrawImage(goldCoinIcon, x, y, wh, wh);
            x += wh + 5;
            drawTextWithShadow(g, NGold.ToString(), normalFont, x, y);


            x += spacing;
            g.DrawImage(silverCoinIcon, x, y, wh, wh);
            x += wh + 5;
            drawTextWithShadow(g, NSilver.ToString(), normalFont, x, y);

            x += spacing;
            g.DrawImage(bronzeCoinIcon, x, y, wh, wh);
            x += wh + 5;
            drawTextWithShadow(g, NBronze.ToString(), normalFont, x, y);




        }
        public void drawWeaponsUI(Graphics g, List<Weapon> weapons, int currentWeapon)
        {
            float spacing = 20f;
            float x = rect.X + rect.Width + 120;
            float y = rect.Y + 10;

            float wh = 70f;


            for (int i = 0; i < weapons.Count; i++)
            {
                Weapon wpn = weapons[i];
                int number = i + 1;
                if (currentWeapon != i)
                {
                    g.DrawImage(heroSelectedSlot, x, y, wh, wh);
                }
                else
                {
                    g.DrawImage(heroWeaponSlot, x, y, wh, wh);

                }

                float weaponImgWh = wh - 10;
                float wX = x + wh / 2 - weaponImgWh / 2;
                float wY = y + wh / 2 - weaponImgWh / 2;
                g.DrawImage(wpn.UIImage, wX, wY, weaponImgWh, weaponImgWh);

                drawTextWithShadow(g, number.ToString(), normalFont, x + 5, y + 5);

                x += (wh + spacing);
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

        public bool repeat = false;
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
            if (repeat == false)
            {
                timer++;

                if (timer >= maxTimer)
                {
                    finished = true;
                }
            }
        }
    }

    public class Fireball
    {
        public bool isItSingle = false;
        public RectangleF rect;
        public RectangleF SingleDrawRect;
        public float traveledDist = 0f;
        public float maxDist = 1000;
        public Animation animation = new Animation();
        public AnimationController anim = new AnimationController();
        public bool strong = false;

        public float speed = 52f;
        public float strongSpeed = 64f;
        public float currentSpeed;

        public float dirX = 1f;
        public float dirY = 0f;

        public float stepSize = 8f;

        public int damage = 15;
        public int strongDamage = 30;
        public bool finished = false;

        public Fireball(Random rr, float startX, float startY, float targetX, float targetY, bool isItSingle)
        {


            if (isItSingle == false)
            {
                float dx = targetX - startX;
                float dy = targetY - startY;

                float biggest = dx;
                if (biggest < 0) biggest = -biggest;
                if (dy < 0 && -dy > biggest) biggest = -dy;
                else if (dy > biggest) biggest = dy;

                if (biggest == 0) biggest = 1;

                dirX = dx / biggest;
                dirY = dy / biggest;

                int normOrStrong = rr.Next(0, 15);
                Bitmap img;
                for (int i = 1; i <= 5; i++)
                {
                    img = new Bitmap("Abilities/fireball/normal/FB500-" + i.ToString() + ".png");
                    animation.addFrame(img);
                }
                if (normOrStrong != 0)
                {
                    rect = new RectangleF(startX, startY, 30, 30);
                    currentSpeed = speed;
                }
                else
                {
                    strong = true;
                    maxDist = maxDist * 1.5f;

                    rect = new RectangleF(startX, startY, 40, 40);
                    currentSpeed = strongSpeed;
                    damage = 50;
                }

                anim.addAnim(animation);
                anim.currAnim = 0;
            }
            else
            {
                dirX = 1f;
                if (targetX < startX) dirX = -1f;

                dirY = 0f;

                this.isItSingle = true;
                Bitmap img;
                for (int i = 1; i <= 6; i++)
                {
                    img = new Bitmap("Abilities/fireball/strong/" + i.ToString() + ".png");
                    animation.addFrame(img);
                }

                strong = true;
                maxDist = 5000f;
                rect = new RectangleF(startX, startY, 74, 52);
                SingleDrawRect = new RectangleF(startX, startY, 74, 52);
                currentSpeed = strongSpeed;
                damage = strongDamage;

                anim.addAnim(animation);
                anim.currAnim = 0;
            }
        }


        public void moveFireball(List<tile> tiles, List<Enemy> enemies)
        {

            float speed = currentSpeed;
            float remainingDist = speed;

            while (remainingDist > 0f)
            {
                float step = remainingDist;
                if (step > stepSize) step = stepSize;

                rect.X += dirX * step;
                rect.Y += dirY * step;
                traveledDist += step;
                remainingDist -= step;



                if (traveledDist >= maxDist)
                {
                    finished = true;
                    return;
                }

                for (int t = 0; t < tiles.Count; t++)
                {
                    tile tl = tiles[t];
                    if (tl.interact == true && tl.jumpThrough == false)
                    {

                        if (rect.X < tl.R.X + tl.R.Width &&
                            rect.X + rect.Width > tl.R.X &&
                            rect.Y < tl.R.Y + tl.R.Height &&
                            rect.Y + rect.Height > tl.R.Y)
                        {
                            finished = true;
                            return;
                        }
                    }
                }

                for (int j = 0; j < enemies.Count; j++)
                {
                    Enemy en = enemies[j];
                    if (!en.isDead)
                    {
                        if (rect.X < en.R.X + en.R.Width &&
                            rect.X + rect.Width > en.R.X &&
                            rect.Y < en.R.Y + en.R.Height &&
                            rect.Y + rect.Height > en.R.Y)
                        {
                            en.takeHit(damage);
                            if (isItSingle == false)
                            {
                                finished = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void moveSingleFireball(List<tile> tiles, List<Enemy> enemies)
        {
            float remainingDist = currentSpeed;

            while (remainingDist > 0f)
            {
                float step = remainingDist;
                if (step > stepSize) step = stepSize;

                rect.X += dirX * step;
                traveledDist += step;
                remainingDist -= step;

                if (isItSingle == true)
                {
                    SingleDrawRect.X = rect.X;
                    SingleDrawRect.Y = rect.Y;

                    SingleDrawRect.Width += 0.2f;
                    SingleDrawRect.Height += (0.2f * (52f / 74f));
                    SingleDrawRect.Y -= 0.1f;
                }

                if (traveledDist >= maxDist)
                {
                    finished = true;
                    return;
                }

                for (int t = 0; t < tiles.Count; t++)
                {
                    tile tl = tiles[t];
                    if (tl.interact == true && tl.jumpThrough == false)
                    {
                        if (rect.X < tl.R.X + tl.R.Width &&
                            rect.X + rect.Width > tl.R.X &&
                            rect.Y < tl.R.Y + tl.R.Height &&
                            rect.Y + rect.Height > tl.R.Y)
                        {
                            finished = true;
                            return;
                        }
                    }
                }

                for (int j = 0; j < enemies.Count; j++)
                {
                    Enemy en = enemies[j];
                    if (!en.isDead)
                    {
                        if (rect.X < en.R.X + en.R.Width &&
                            rect.X + rect.Width > en.R.X &&
                            rect.Y < en.R.Y + en.R.Height &&
                            rect.Y + rect.Height > en.R.Y)
                        {
                            en.takeHit(damage);
                        }
                    }
                }
            }
        }

        public void draw(Graphics g)
        {
            Bitmap frame = anim.playFrame();
            Bitmap imgToDraw = frame;
            if (dirX == -1f)
            {
                imgToDraw = new Bitmap(frame);
                imgToDraw.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }


            if (isItSingle == false)
            {
                g.DrawImage(imgToDraw, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                
                g.DrawImage(imgToDraw, SingleDrawRect.X, SingleDrawRect.Y, SingleDrawRect.Width, SingleDrawRect.Height);

            }
        }
    }

    public class Ladder
    {
        public RectangleF rect = new RectangleF();

        public bool isMossy = false;

        public Bitmap ladderImg;

        int tileHeight;

        public Ladder(float x, float y, float height, bool isMossy)
        {
            this.isMossy = isMossy;

            if (isMossy == true)
            {
                ladderImg = new Bitmap("Tiles/Ladder/28x128/2.png");
            }
            else
            {
                ladderImg = new Bitmap("Tiles/Ladder/28x128/1.png");
            }

            tileHeight = ladderImg.Height;

            rect.X = x;
            rect.Y = y;

            rect.Width = 75;

            rect.Height = height;
        }

        public void draw(Graphics g, bool showRange)
        {
            int countLadders = 0;

            while ((countLadders + 1) * tileHeight <= rect.Height)
            {
                countLadders++;
            }

            float remainingHeight = rect.Height - countLadders * tileHeight + (countLadders - 1);

            float y = rect.Y;

            for (int i = 0; i < countLadders; i++)
            {
                g.DrawImage(ladderImg, rect.X, y, rect.Width, tileHeight);

                y += tileHeight - 1;
            }

            if (remainingHeight > 0)
            {
                RectangleF rcDst = new RectangleF(rect.X, y, rect.Width, remainingHeight);

                RectangleF rcSource = new RectangleF(0, 0, ladderImg.Width, remainingHeight);

                g.DrawImage(ladderImg, rcDst, rcSource, GraphicsUnit.Pixel);
            }

            if (showRange == true)
            {
                g.DrawRectangle(Pens.Orange, rect.X, rect.Y, rect.Width, rect.Height);
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
        public bool wasGrounded = false;

        public bool isLanding = false;
        public int landingTimer = 0;

        public float prevBottom = 0f;

        public bool isTakingDamage = false;
        public int takingDamageTimer = 0;

        Animation doubleJumpAnimation;
        Animation fireballAnimation;
        public int coins = 0;

        public AnimationController anim = new AnimationController();

        public Health HP = new Health(100, 100);
        public Mana mana = new Mana(100, 100);
        public UIEntity UI = new UIEntity(20f, 20f, 236f, 26f, true, true);


        public List<vfx> vfxes = new List<vfx>();


        public bool isAttacking = false;
        public bool attackHasHit = false;

        public int attackHitFrame = 4; //first 4 frames in teh attack animation are normal
        public int attackComboExtraFrames = 2; // last 2 frames are extra whgen there is a combo
        public float attackMoveMultiplier = 0.55f;

        public char facing = 'r';

        public float attackRange = 80f;
        public float attackHeightScale = 1.2f;

        public List<Weapon> Weapons = new List<Weapon>();

        public int currentWeapon = 0;


        public List<Fireball> fireballs = new List<Fireball>();
        public Random rnd = new Random();

        public bool isSpellCasting = false;
        public bool isShooting = false;
        public bool spellCastPaused = false;

        public float fireballManaCost = 10f;
        public float manaRegenRate = 0.5f;

        public int fireballSpawnDelay = 5;
        public int fireballSpawnTimer = 5;

        public float mouseX = 0f;
        public float mouseY = 0f;

        public bool isCastingAbility = false;
        public bool abilityFireballSpawned = false;
        public float abilityManaCost = 50f;
        public bool abilityKeyDown = false;
        public bool isDead = false;

        public void startAbilityCast()
        {
            if (isTakingDamage == true)
            {
                return;
            }
            if (isCastingAbility) return;
            if (mana.mana < abilityManaCost) return;

            isCastingAbility = true;
            abilityFireballSpawned = false;
            isAttacking = false;
            isShooting = false;

            anim.changeAnimation("spell_cast", -1);
            anim.restart();
        }
        public void updateSingleFireballAbility(List<Enemy> enemies, List<tile> tiles)
        {
            if (!isCastingAbility) return;

            anim.changeAnimation("spell_cast", -1);

            if (!abilityFireballSpawned && anim.currIdx >= 3)
            {
                abilityFireballSpawned = true;

                float spawnX = R.X + R.Width / 2f;
                if (facing == 'l') spawnX = R.X - 74;

                float spawnY = R.Y + R.Height * 0.3f;

                float targetX;
                if (facing == 'r') targetX = spawnX + 2000f;
                else targetX = spawnX - 2000f;
                float targetY = spawnY;

                Fireball fb = new Fireball(rnd, spawnX, spawnY, targetX, targetY, true);
                fireballs.Add(fb);

                mana.mana -= abilityManaCost;
                if (mana.mana < 0) mana.mana = 0;
            }

            Animation spellAnim = anim.getCurrentAnimation();
            if (anim.currIdx >= spellAnim.frames.Count - 1)
            {
                isCastingAbility = false;
                abilityFireballSpawned = false;
                isLanding = false;
                wasGrounded = isGrounded;
                ySpeed = 0;
                isGrounded = true;
                updateAnimation();
            }
        }
        public void initVFX()
        {
            doubleJumpAnimation = new Animation();
            doubleJumpAnimation.name = "doubleJump";
            doubleJumpAnimation.frameDelay = 1;

            for (int i = 1; i <= 5; i++)
            {
                Bitmap frame = new Bitmap("vfx/doubleJump/" + i + ".png");
                doubleJumpAnimation.addFrame(frame);
            }


            fireballAnimation = new Animation();
            fireballAnimation.name = "fireball";
            fireballAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {

                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/BurnEffect/Frames/BurnEffect_0" + i + ".png");
                else frame = new Bitmap("vfx/BurnEffect/Frames/BurnEffect_" + i + ".png");

                fireballAnimation.addFrame(frame);
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


        void createFireballVFX()
        {
            vfx fx = new vfx();

            fx.repeat = true;
            fx.name = "fireball";
            fx.anim.addAnim(fireballAnimation);
            fx.anim.changeAnimation("fireball", -1);


            fx.rect.Width = R.Width * 2;
            fx.rect.Height = 90;

            fx.rect.X = R.X + R.Width / 2 - fx.rect.Width / 2;

            fx.offsetY = -45;

            fx.followPlayer = true;


            vfxes.Add(fx);
        }
        public void Draw(Graphics g, bool showRanges)
        {
            drawR.X = R.X + (R.Width - drawR.Width) / 2f;
            drawR.Y = R.Y + (R.Height - drawR.Height);


            for (int i = 0; i < fireballs.Count; i++)
            {
                fireballs[i].draw(g);

                if (showRanges)
                {
                    Pen fbPen = new Pen(Color.Red, 1);
                    g.DrawRectangle(fbPen, fireballs[i].rect.X, fireballs[i].rect.Y, fireballs[i].rect.Width, fireballs[i].rect.Height);
                }
            }

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
                Bitmap imgToDraw = frame;

                if (facing == 'l')
                {
                    imgToDraw = new Bitmap(frame);
                    imgToDraw.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                g.DrawImage(imgToDraw, drawR.X, drawR.Y, drawR.Width, drawR.Height);
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

            for (int i = vfxes.Count - 1; i >= 0; i--)
            {
                vfxes[i].draw(g, R);

                if (vfxes[i].finished)
                {
                    vfxes.RemoveAt(i);
                }
            }


            UI.draw(g, HP, mana, coins);
            UI.drawWeaponsUI(g, Weapons, currentWeapon);
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


            Weapon sword = new Weapon();
            sword.damage = 25;
            sword.order = 1;
            sword.rangeH = 0;
            sword.rangeW = 0;
            sword.UIImage = new Bitmap("ui/Weapons/sword.png");
            Weapons.Add(sword);

            addFireballWeapon();
        }

        void addFireballWeapon()
        {

            Weapon fireball = new Weapon();
            fireball.damage = 15;
            fireball.order = 2;
            fireball.rangeH = 20;
            fireball.rangeW = 20;
            fireball.UIImage = new Bitmap("ui/Weapons/fireball.png");
            Weapons.Add(fireball);
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
                if (folders[i] == "walking") a.frameDelay = 1;
                else if (folders[i] == "idle") a.frameDelay = 1;
                else if (folders[i] == "landing") a.frameDelay = 1;
                else if (folders[i] == "taking_damage") a.frameDelay = 1;
                else if (folders[i] == "death") a.frameDelay = 1;
                string path = "Characters/Hero/Blue/" + folders[i] + "/";
                for (int j = 1; j <= numFrames[i]; j++)
                {
                    Bitmap img = new Bitmap(path + j.ToString() + ".png");
                    a.frames.Add(img);
                }
                this.anim.addAnim(a);
            }
        }

        public void ManageWeapon()
        {
            if (currentWeapon == 0)
            {
                isShooting = false;
                fireballSpawnTimer = fireballSpawnDelay;
                removeOtherWeaponVFX();
            }
            else if (currentWeapon == 1)
            {
                isAttacking = false;
                removeOtherWeaponVFX();
                createFireballVFX();

            }
        }
        void removeOtherWeaponVFX()
        {
            for (int i = 0; i < vfxes.Count; i++)
            {
                if (vfxes[i].name == "fireball")
                {
                    vfxes.RemoveAt(i);
                    i--;
                }
            }
        }
        public bool isDoingCombo = false;
        public void startAttack()
        {
            if (isAttacking || isDead)
            {
                return;
            }
            if (currentWeapon == 0)
            {
                swordLogic();
            }
            else if (currentWeapon == 1)
            {
                fireballLogic();
            }

        }

        void fireballLogic()
        {
            isShooting = true;
        }

        public void stopFireball()
        {
            isShooting = false;
            fireballSpawnTimer = fireballSpawnDelay;
        }


        public void updateFireballCast(List<Enemy> enemies, List<tile> tiles)
        {

            if (isShooting && mana.mana >= fireballManaCost)
            {
                fireballSpawnTimer++;
                if (fireballSpawnTimer >= fireballSpawnDelay)
                {
                    fireballSpawnTimer = 0;
                    throwFireball();
                }
            }
            else if (mana.mana < fireballManaCost)
            {
                isShooting = false;
            }

            for (int i = fireballs.Count - 1; i >= 0; i--)
            {
                if (fireballs[i].isItSingle)
                    fireballs[i].moveSingleFireball(tiles, enemies);
                else
                    fireballs[i].moveFireball(tiles, enemies);

                if (fireballs[i].finished)
                    fireballs.RemoveAt(i);
            }
        }

        void throwFireball()
        {
            if (mana.mana < fireballManaCost) return;

            float spawnX = R.X + R.Width / 2f;
            float spawnY = R.Y;

            Fireball fb = new Fireball(rnd, spawnX, spawnY, mouseX, mouseY, false);
            fireballs.Add(fb);

            mana.mana -= fireballManaCost;
            if (mana.mana < 0) mana.mana = 0;
        }
        void swordLogic()
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
                return new RectangleF(R.X, y, R.Width + attackRange, h);
            }
            else
            {
                return new RectangleF(R.X - attackRange + 5, y, R.Width + attackRange, h);
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
                            en.takeHit(Weapons[currentWeapon].damage);
                            // break;
                        }

                    }
                }

                attackHasHit = true;
            }
        }

        public void move(List<tile> tiles)
        {
            if (isDead == true)
            {
                moving = ' ';
                isAttacking = false;
                isShooting = false;
                isCastingAbility = false;

                Movement(tiles);
                updateAnimation();
                return;
            }
            if (isTakingDamage == true)
            {
                isAttacking = false;
                isShooting = false;
                isCastingAbility = false;
                moving = ' ';
                isGrounded = false;

                Movement(tiles);
                updateAnimation();
                return;
            }

            float moveSpeed = speed;

            if (isRunning == true)
            {
                moveSpeed = speed * 2f;
            }


            if (isAttacking == true && isGrounded == true) moveSpeed *= attackMoveMultiplier;

            if (isShooting && currentWeapon == 1) moveSpeed *= 0.75f;
            if (isCastingAbility) moveSpeed = 0f;

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

            if (!isAttacking && !isAttacking)
                updateAnimation();
        }
        public void Movement(List<tile> tiles)
        {
            wasGrounded = isGrounded;
            prevBottom = R.Y + R.Height;

            if (isCastingAbility == false)
            {

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
            }

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
                                if (ySpeed >= 0)
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
            if (isAttacking || isDead)
            {
                return;
            }
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
            if (isDead == true)
            {
                anim.changeAnimation("death", -1);
                return;
            }
            if (isTakingDamage)
            {
                anim.changeAnimation("taking_damage", -1);
                takingDamageTimer--;

                if (takingDamageTimer <= 0)
                {
                    isTakingDamage = false;
                }

                return;
            }
            if (isCastingAbility)
            {
                anim.changeAnimation("spell_cast", -1);
                return;
            }

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

        public void takeDamage(int amount)
        {
            if (isDead == true)
            {
                return;
            }
            if (isTakingDamage == true)
            {
                return;
            }

            HP.damage(amount);
            isAttacking = false;
            isShooting = false;
            isCastingAbility = false;
            moving = ' ';
            jumpHeld = true;
            if (HP.getHP() <= 0)
            {
                isDead = true;
                isTakingDamage = false;

                anim.changeAnimation("death", -1);
                anim.restart();

                return;
            }

            isTakingDamage = true;

            anim.changeAnimation("taking_damage", -1);
            anim.restart();

            Animation dmgAnim = anim.getCurrentAnimation();
            takingDamageTimer = dmgAnim.frames.Count * dmgAnim.frameDelay;
        }
    }
    public class Enemy
    {
        public RectangleF R = new RectangleF();
        public RectangleF drawR = new Rectangle();

        public float speed = 4f;

        public char moving = 'l';
        public char facing = ' ';
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

        public int attackFrameTimer = 0;
        public int attackCooldown = 0;
        public bool attackDamageDone = false;

        public float startX = 0f;
        public float patrolDistance = 200f;
        public float leftLimit = 0f;
        public float rightLimit = 0f;

        public int spawnX = 0;
        public int spawnY = 0;
        public bool CanSpawn = false;
        public int spawnTime = 600;

        public bool isWaiting = true;
        public int waitTime = 0;
        public int waitingTimer = 60;

        public int spawnrange = 600;
        public bool spawn = false;
        public float attackrange = 65;
        public float attackdis = 200;
        public bool attackmode = false;
        public bool idle = false;

        public string enemyName;
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
            facing = 'r';

            HP = new Health(50, 50);
            UI = new UIEntity(0, 0, 70, 15, false, true);

            createAnim();
            anim.changeAnimation("idle", -1);

            isGrounded = true;
            wasGrounded = true;
        }
        public void draw(Graphics g, bool showRanges)
        {
            if (spawn)
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
                    Bitmap imgToDraw = frame;

                    if (facing == 'r')
                    {
                        imgToDraw = new Bitmap(frame);
                        imgToDraw.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }

                    g.DrawImage(imgToDraw, drawR.X, drawR.Y, drawR.Width, drawR.Height);
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
                    a.frameDelay = 1;
                }
                else if (folders[i] == "attack")
                {
                    a.frameDelay = 1;
                }
                else if (folders[i] == "hit")
                {
                    a.frameDelay = 1;
                }
                else if (folders[i] == "die")
                {
                    a.frameDelay = 1;
                }
                else if (folders[i] == "stun-attack")
                {
                    a.frameDelay = 1;
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

            isAttacking = false;
            attackmode = false;
            attackFrameTimer = 0;
            attackDamageDone = false;

            if (HP.getHP() <= 0)
            {
                isDead = true;
                isTakingDamage = false;

                deathTimer = 0;

                anim.changeAnimation("die", -1);
                anim.restart();
            }
            else
            {
                isTakingDamage = true;

                damageTimer = 15;

                anim.changeAnimation("hit", -1);
                anim.restart();
            }
        }

        public void move(List<tile> tiles, Hero hero)
        {

            if (!spawn)
            {
                return;
            }

            if (hero.isDead)
            {
                attackmode = false;
                isAttacking = false;
                attackFrameTimer = 0;
                attackDamageDone = false;
            }

            if (attackCooldown > 0)
            {
                attackCooldown--;
            }

            if (isDead || isTakingDamage)
            {
                applyPhysics(tiles);
                updateAnimation();
                return;
            }

            if (isAttacking)
            {
                if (hero.isDead == true)
                {
                    attackmode = false;
                    isAttacking = false;
                    attackFrameTimer = 0;
                    attackDamageDone = false;
                }
                if (attackFrameTimer <= 10 && attackDamageDone == false)
                {
                    hero.takeDamage(10);
                    attackDamageDone = true;
                }

                applyPhysics(tiles);
                updateAnimation();
                return;
            }

            if (attackCooldown > 0)
            {
                anim.changeAnimation("idle", -1);
                applyPhysics(tiles);
                return;
            }

            if (isWaiting)
            {
                updateAnimation();
                return;
            }

            float dx = 0f;

            if (isRunning && !attackmode)
            {
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
                    moving = 'l';
                    isRunning = false;
                    isWaiting = true;
                }
                else if (R.X >= rightLimit)
                {
                    R.X = rightLimit;
                    moving = 'r';
                    isRunning = false;
                    isWaiting = true;
                }
            }

            float distanceX = 0;
            float distanceY = 0;
            char dir = moving;

            if (R.X > hero.R.X)
            {
                distanceX = R.X - hero.R.X;
                dir = 'l';
                facing = 'l';
            }
            else if (R.X < hero.R.X)
            {
                distanceX = hero.R.X - R.X;
                dir = 'r';
                facing = 'r';
            }

            if (R.Y > hero.R.Y)
            {
                distanceY = R.Y - hero.R.Y;
            }
            else if (hero.R.Y > R.Y)
            {
                distanceY = hero.R.Y - R.Y;
            }

            bool sameY = false;

            if (distanceY < 50)
            {
                sameY = true;
            }

            if (distanceX <= attackdis && sameY == true && !hero.isDead)
            {
                attackmode = true;
            }
            else
            {
                attackmode = false;
            }

            if (attackmode)
            {
                moving = dir;

                if (R.X > hero.R.X)
                {
                    distanceX = R.X - hero.R.X;
                    R.X -= 5;
                    dx = -5;
                }
                else if (R.X < hero.R.X)
                {
                    distanceX = hero.R.X - R.X;
                    R.X += 5;
                    dx = 5;
                }

                if (distanceX <= attackrange && attackCooldown <= 0 && !hero.isDead)
                {
                    isAttacking = true;
                    attackFrameTimer = 20;
                    attackDamageDone = false;

                    anim.changeAnimation("attack", -1);
                    anim.restart();

                    applyPhysics(tiles);
                    return;
                }
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];

                if (t.interact == true && t.jumpThrough == false)
                {
                    bool overlappingX = false;

                    if (R.X + R.Width > t.R.X &&
                        R.X < t.R.X + t.R.Width)
                    {
                        overlappingX = true;
                    }

                    bool overlappingY = false;

                    if (R.Y + R.Height > t.R.Y &&
                        R.Y < t.R.Y + t.R.Height)
                    {
                        overlappingY = true;
                    }

                    if (overlappingX && overlappingY)
                    {
                        float overlapTop = R.Y;

                        if (t.R.Y > overlapTop)
                        {
                            overlapTop = t.R.Y;
                        }

                        float overlapBottom = R.Y + R.Height;

                        if (t.R.Y + t.R.Height < R.Y + R.Height)
                        {
                            overlapBottom = t.R.Y + t.R.Height;
                        }

                        float overlapY = overlapBottom - overlapTop;

                        if (overlapY > 3f)
                        {
                            if (dx > 0)
                            {
                                R.X = t.R.X - R.Width;
                                moving = 'l';
                                facing = 'l';
                            }
                            else if (dx < 0)
                            {
                                R.X = t.R.X + t.R.Width;
                                moving = 'r';
                                facing = 'r';
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
            if (isDead == true)
            {
                anim.changeAnimation("die", -1);
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

                attackFrameTimer--;

                if (attackFrameTimer <= 0)
                {
                    isAttacking = false;
                    attackCooldown = 100;
                    anim.changeAnimation("idle", -1);
                    anim.restart();
                }

                return;
            }

            if (isWaiting)
            {
                if (waitTime >= waitingTimer)
                {
                    waitTime = 0;
                    anim.changeAnimation("run", -1);
                    isWaiting = false;
                    isRunning = true;
                    if (moving == 'r')
                    {
                        moving = 'l';
                        facing = 'l';
                    }
                    else if (moving == 'l')
                    {
                        moving = 'r';
                        facing = 'r';
                    }
                }
                else
                {
                    waitTime++;
                    anim.changeAnimation("idle", -1);
                    return;
                }

            }

            if (isRunning)
            {
                anim.changeAnimation("run", -1);
                return;

            }

            if (isAttacking)
            {
                anim.changeAnimation("attack", -1);
                return;
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
                facing = 'l';

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
        Save save = new Save();
        Load load = new Load();


        Random Random = new Random();
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
        List<Ladder> ladders = new List<Ladder>();
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
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!hasStarted) return;

            if (e.Button == MouseButtons.Left)
            {
                if (hero.currentWeapon == 1)
                    hero.stopFireball();
            }
        }

        bool CheckIfWeaponUIClicked(int eX, int eY)
        {
            float spacing = 20f;
            float x = hero.UI.rect.X + hero.UI.rect.Width + 120;
            float y = hero.UI.rect.Y + 10;

            float wh = 70f;


            for (int i = 0; i < hero.Weapons.Count; i++)
            {

                if (eX > x && eX < x + wh &&
                    eY > y && eY < y + wh)
                {
                    hero.currentWeapon = i;
                    hero.ManageWeapon();
                    return true;

                }
                x += wh + spacing;
            }
            return false;
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
                    bool isClicked = CheckIfWeaponUIClicked(e.X, e.Y);

                    if (isClicked == false)
                    {
                        hero.mouseX = e.X;
                        hero.mouseY = e.Y;
                        hero.startAttack();
                    }
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
            else
            {
                hero.mouseX = e.X;
                hero.mouseY = e.Y;
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

            if (e.KeyCode == Keys.E)
            {
                hero.abilityKeyDown = false;
            }



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.O)
            {
                load.load(hero, enemies);
            }

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

                if (e.KeyCode == Keys.E && hero.abilityKeyDown == false)
                {
                    hero.abilityKeyDown = true;
                    hero.startAbilityCast();
                }
                if(e.KeyCode == Keys.R)
                {
                    if(hero.isDead == true)
                    {
                        hero.isDead = false;
                    }
                }

                if (hero.Weapons.Count > 1)
                {
                    if (e.KeyCode == Keys.D1)
                    {
                        hero.currentWeapon = 0;
                        hero.ManageWeapon();
                    }
                    else if (e.KeyCode == Keys.D2)
                    {
                        hero.currentWeapon = 1;
                        hero.ManageWeapon();

                    }
                    else if (hero.Weapons.Count > 2 && e.KeyCode == Keys.D3)
                    {
                        hero.currentWeapon = 2;
                        hero.ManageWeapon();


                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Text = save.timer.ToString();
            save.autoSave(hero, enemies);
            hero.move(tiles);
            if (hero.currentWeapon == 0)
            {
                hero.updateAttack(enemies);
            }
            hero.updateFireballCast(enemies, tiles);
            hero.updateSingleFireballAbility(enemies, tiles);

            hero.mana.tick();
            handleEnemyMovement();

            
            drawDubb(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);


            hero = new Hero(30, this.ClientSize.Height - 150 - 30, 150, 150);
            initTiles();
            initLadders();

            initEnemies();
            initButtons();
            initMenu();
            drawDubb(this.CreateGraphics());

        }

        void initLadders()
        {
            Ladder ladder;

            ladder = new Ladder(800 - 75, this.ClientSize.Height - 250 - 400, 400, false);
            ladders.Add(ladder);

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
                for (int i = 0; i < ladders.Count; i++)
                {
                    ladders[i].draw(g, showRanges);
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
                float distance;
                if (hero.R.X > enemies[i].R.X)
                {
                    distance = hero.R.X - enemies[i].R.X;
                }
                else
                {
                    distance = enemies[i].R.X - hero.R.X;
                }
                if (enemies[i].spawnrange >= distance)
                {
                    enemies[i].spawn = true;
                }
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

                enemies[i].move(tiles, hero);
            }
        }

    }
}
