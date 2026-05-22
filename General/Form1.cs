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

        int idx = 0;

        Font f = new Font("Palatino Linotype", 8f, FontStyle.Bold);

        SolidBrush textBrush = new SolidBrush(Color.White);
        SolidBrush bigoutline = new SolidBrush(Color.Black);

        string boolToText(bool value)
        {
            if (value == true)
            {
                return "True";
            }

            return "False";
        }

        public void save(Hero hero, List<Enemy> Enemies , int level)
        {
            saveLvl(level);
            saveHero(hero);
            saveEnemies(Enemies);

        }
        public void autoSave(Hero hero, List<Enemy> Enemies, int level, Graphics g , int clientHeight)
        {
            if(timer < 20)
            {
                string txt = "Saving";
                if(idx % 4 == 1)
                {
                    txt += ".";
                }
                else if(idx %4 == 2)
                {
                    txt += "..";
                }
                else if(idx % 4 == 3)
                {
                    txt += "...";
                }
                g.DrawString(txt, f, bigoutline, 12, clientHeight- 50);
                g.DrawString(txt, f, textBrush, 10, clientHeight - 48);

                idx++;
            }
            else
            {
                idx = 0;
            }

            if (timer < max)
            {
                timer++;
            }
            else
            {
                timer = 0;
                idx = 0;
                save(hero, Enemies , level);
            }
        }

        void saveLvl(int level)
        {
           
            StreamWriter sw = new StreamWriter("Saves/level.txt");
            sw.WriteLine(level.ToString());
            sw.Close();
        }

        void saveHero(Hero hero)
        {

            StreamWriter sw = new StreamWriter("Saves/hero.txt");
            sw.WriteLine("hero_color:" + hero.ColorIdx.ToString());
            sw.WriteLine("X,Y:" + hero.R.X.ToString() + "," + hero.R.Y.ToString());
            sw.WriteLine("Moving:" + hero.moving);
            sw.WriteLine("ySpeed:" + hero.ySpeed.ToString());

            sw.WriteLine("jumpsUsed:" + hero.jumpsUsed.ToString());

            sw.WriteLine("isTakingDamage:" + boolToText(hero.isTakingDamage));
            sw.WriteLine("takingDamageTimer:" + hero.takingDamageTimer.ToString());

            sw.WriteLine("coins:" + hero.coins.ToString());

            sw.WriteLine("isAttacking:" + boolToText(hero.isAttacking));
            sw.WriteLine("attackHasHit:" + boolToText(hero.attackHasHit));

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

            sw.WriteLine("isSpellCasting:" + boolToText(hero.isSpellCasting));
            sw.WriteLine("isShooting:" + boolToText(hero.isShooting));
            sw.WriteLine("spellCastPaused:" + boolToText(hero.spellCastPaused));

            sw.WriteLine("manaRegenRate:" + hero.mana.regenRate.ToString());

            sw.WriteLine("isCastingAbility:" + boolToText(hero.isCastingAbility));
            sw.WriteLine("abilityFireballSpawned:" + boolToText(hero.abilityFireballSpawned));
            sw.WriteLine("abilityManaCost:" + hero.abilityManaCost.ToString());
            sw.WriteLine("abilityKeyDown:" + boolToText(hero.abilityKeyDown));
            sw.WriteLine("isAbilityUnlocked:" + boolToText(hero.isAbilityUnlocked));

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
                sw.WriteLine("Enemy" + i + "_isRunning:" + boolToText(enemy.isRunning));

                sw.WriteLine("Enemy" + i + "_velocityY:" + enemy.velocityY.ToString());
                sw.WriteLine("Enemy" + i + "_gravity:" + enemy.gravity.ToString());
                sw.WriteLine("Enemy" + i + "_max_speed:" + enemy.max_speed.ToString());

                sw.WriteLine("Enemy" + i + "_isGrounded:" + boolToText(enemy.isGrounded));
                sw.WriteLine("Enemy" + i + "_wasGrounded:" + boolToText(enemy.wasGrounded));
                sw.WriteLine("Enemy" + i + "_prevBottom:" + enemy.prevBottom.ToString());

                sw.WriteLine("Enemy" + i + "_isDead:" + boolToText(enemy.isDead));
                sw.WriteLine("Enemy" + i + "_isTakingDamage:" + boolToText(enemy.isTakingDamage));
                sw.WriteLine("Enemy" + i + "_isAttacking:" + boolToText(enemy.isAttacking));

                sw.WriteLine("Enemy" + i + "_damageTimer:" + enemy.damageTimer.ToString());
                sw.WriteLine("Enemy" + i + "_attackTimer:" + enemy.attackTimer.ToString());
                sw.WriteLine("Enemy" + i + "_deathTimer:" + enemy.deathTimer.ToString());

                sw.WriteLine("Enemy" + i + "_attackFrameTimer:" + enemy.attackFrameTimer.ToString());
                sw.WriteLine("Enemy" + i + "_attackCooldown:" + enemy.attackCooldown.ToString());
                sw.WriteLine("Enemy" + i + "_attackDamageDone:" + boolToText(enemy.attackDamageDone));

                sw.WriteLine("Enemy" + i + "_startX:" + enemy.startX.ToString());
                sw.WriteLine("Enemy" + i + "_patrolDistance:" + enemy.patrolDistance.ToString());
                sw.WriteLine("Enemy" + i + "_leftLimit:" + enemy.leftLimit.ToString());
                sw.WriteLine("Enemy" + i + "_rightLimit:" + enemy.rightLimit.ToString());

                sw.WriteLine("Enemy" + i + "_spawnX:" + enemy.spawnX.ToString());
                sw.WriteLine("Enemy" + i + "_spawnY:" + enemy.spawnY.ToString());
                sw.WriteLine("Enemy" + i + "_CanSpawn:" + boolToText(enemy.CanSpawn));
                sw.WriteLine("Enemy" + i + "_spawnTime:" + enemy.spawnTime.ToString());

                sw.WriteLine("Enemy" + i + "_isWaiting:" + boolToText(enemy.isWaiting));
                sw.WriteLine("Enemy" + i + "_waitTime:" + enemy.waitTime.ToString());
                sw.WriteLine("Enemy" + i + "_waitingTimer:" + enemy.waitingTimer.ToString());

                sw.WriteLine("Enemy" + i + "_spawnrange:" + enemy.spawnrange.ToString());
                sw.WriteLine("Enemy" + i + "_spawn:" + boolToText(enemy.spawn));

                sw.WriteLine("Enemy" + i + "_attackrange:" + enemy.attackrange.ToString());
                sw.WriteLine("Enemy" + i + "_attackdis:" + enemy.attackdis.ToString());
                sw.WriteLine("Enemy" + i + "_attackmode:" + boolToText(enemy.attackmode));

                sw.WriteLine("Enemy" + i + "_idle:" + boolToText(enemy.idle));

                sw.WriteLine("Enemy" + i + "_enemyName:" + enemy.enemyName);

                sw.WriteLine("Enemy" + i + "_maxHP:" + enemy.HP.maxHP.ToString());
                sw.WriteLine("Enemy" + i + "_HP:" + enemy.HP.HP.ToString());
            }
            sw.Close();
        }
    }

    public class Load
    {
        public int level;

        bool changeBool(string val)
        {
            if (val == "True")
            {
                return true;
            }

            if (val == "False")
            {
                return false;
            }

            return false;
        }

        public void loadLevel()
        {

            StreamReader sr = new StreamReader("Saves/level.txt");
            string lvl = sr.ReadLine();
            sr.Close();

            if (lvl != null)
            {
                level = changeToInt(lvl);
            }
            else
            {
                level = 0;
            }
        }

        public Hero load(Hero hero, List<Enemy> enemies, int clientHeight)
        {
         

            hero = loadHero(hero, clientHeight);

            loadEnemies(enemies);
            return hero;
        }

        int changeToInt(string val)
        {
            bool negative = false;
            if (val.Length > 0 && val[0] == '-')
            {
                negative = true;
            }

            string num = "";
            int start = 0;
            if (negative == true)
            {
                start = 1;
            }

            for (int i = start; i < val.Length; i++)
            {
                if (val[i] == '.') break;
                num += val[i];
            }

            if (num == "")
            {
                return 0;
            }

            int result = Convert.ToInt32(num);

            if (negative == false)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }

        Hero loadHero(Hero hero, int clientHeight)
        {
            StreamReader sr = new StreamReader("Saves/hero.txt");

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();

                if (line != null)
                {
                    string[] data = splitLine(line);
                    string variable = data[0];
                    string val = data[1];

                    if (variable == "hero_color")
                    {
                        if (hero == null)
                        {
                            hero = new Hero(30, clientHeight - 150 - 30, 150, 150, changeToInt(val));
                        }
                    }

                    if (hero != null)
                    {
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
                                else if (foundComma == false)
                                {
                                    sx += val[i];
                                }
                                else
                                {
                                    sy += val[i];
                                }
                            }

                            hero.R.X = changeToInt(sx);
                            hero.R.Y = changeToInt(sy);
                        }
                        else if (variable == "isAbilityUnlocked")
                        {
                            hero.isAbilityUnlocked = changeBool(val);
                        }
                        else if (variable == "Moving")
                        {
                            if (val.Length > 0)
                            {
                                hero.moving = val[0];
                            }
                        }
                        else if (variable == "ySpeed")
                        {
                            hero.ySpeed = changeToInt(val);
                        }
                        else if (variable == "jumpsUsed")
                        {
                            hero.jumpsUsed = changeToInt(val);
                        }
                        else if (variable == "isTakingDamage")
                        {
                            hero.isTakingDamage = changeBool(val);
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
                            hero.isAttacking = changeBool(val);
                        }
                        else if (variable == "attackHasHit")
                        {
                            hero.attackHasHit = changeBool(val);
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
                            if (val.Length > 0)
                            {
                                hero.facing = val[0];
                            }
                        }
                        else if (variable == "Weapon0_Damage")
                        {
                            if (hero.Weapons.Count > 0)
                            {
                                hero.Weapons[0].damage = changeToInt(val);
                            }
                        }
                        else if (variable == "Weapon1_Damage")
                        {
                            if (hero.Weapons.Count > 1)
                            {
                                hero.Weapons[1].damage = changeToInt(val);
                            }
                        }
                        else if (variable == "Weapon2_Damage")
                        {
                            if (hero.Weapons.Count > 2)
                            {
                                hero.Weapons[2].damage = changeToInt(val);
                            }
                        }
                        else if (variable == "currentWeapon")
                        {
                            hero.currentWeapon = changeToInt(val);
                        }
                        else if (variable == "isSpellCasting")
                        {
                            hero.isSpellCasting = changeBool(val);
                        }
                        else if (variable == "isShooting")
                        {
                            hero.isShooting = changeBool(val);
                        }
                        else if (variable == "spellCastPaused")
                        {
                            hero.spellCastPaused = changeBool(val);
                        }
                        else if (variable == "manaRegenRate")
                        {
                            hero.mana.regenRate = changeToInt(val);
                        }
                        else if (variable == "isCastingAbility")
                        {
                            hero.isCastingAbility = changeBool(val);
                        }
                        else if (variable == "abilityFireballSpawned")
                        {
                            hero.abilityFireballSpawned = changeBool(val);
                        }
                        else if (variable == "abilityManaCost")
                        {
                            hero.abilityManaCost = changeToInt(val);
                        }
                        else if (variable == "abilityKeyDown")
                        {
                            hero.abilityKeyDown = changeBool(val);
                        }
                    }
                }
            }

            if (hero != null && hero.mana.regenRate == 0f)
            {
                hero.mana.regenRate = 0.5f;
            }

            sr.Close();
            return hero;
        }

        void loadEnemies(List<Enemy> enemies)
        {
            StreamReader sr = new StreamReader("Saves/Enemies.txt");

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();

                if(line != null)
                {
                    string[] data = splitLine(line);
                    string variable = data[0];
                    string val = data[1];

                    if (variable != "EnemiesCount")
                    {
                        int underscorePos = -1;
                        for (int i = 5; i < variable.Length; i++)
                        {
                            if (variable[i] == '_')
                            {
                                underscorePos = i;
                                break;
                            }
                        }

                        if(underscorePos != -1)
                        {
                            string numStr = "";
                            for (int i = 5; i < underscorePos; i++)
                            {
                                numStr += variable[i];
                            }

                            string property = "";
                            for (int i = underscorePos + 1; i < variable.Length; i++)
                            {
                                property += variable[i];
                            }

                            int enemyIndex = changeToInt(numStr);

                            if (enemyIndex >= 0 && enemyIndex < enemies.Count)
                            {
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
                                    if (val.Length > 0)
                                    {
                                        enemy.moving = val[0];
                                    }
                                }
                                else if (property == "facing")
                                {
                                    if (val.Length > 0)
                                    {
                                        enemy.facing = val[0];
                                    }
                                }
                                else if (property == "isRunning")
                                {
                                    enemy.isRunning = changeBool(val);
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
                                    enemy.isGrounded = changeBool(val);
                                }
                                else if (property == "wasGrounded")
                                {
                                    enemy.wasGrounded = changeBool(val);
                                }
                                else if (property == "prevBottom")
                                {
                                    enemy.prevBottom = changeToInt(val);
                                }
                                else if (property == "isDead")
                                {
                                    enemy.isDead = changeBool(val);
                                }
                                else if (property == "isTakingDamage")
                                {
                                    enemy.isTakingDamage = changeBool(val);
                                }
                                else if (property == "isAttacking")
                                {
                                    enemy.isAttacking = changeBool(val);
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
                                    enemy.attackDamageDone = changeBool(val);
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
                                    enemy.CanSpawn = changeBool(val);
                                }
                                else if (property == "spawnTime")
                                {
                                    enemy.spawnTime = changeToInt(val);
                                }
                                else if (property == "isWaiting")
                                {
                                    enemy.isWaiting = changeBool(val);
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
                                    enemy.spawn = changeBool(val);
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
                                    enemy.attackmode = changeBool(val);
                                }
                                else if (property == "idle")
                                {
                                    enemy.idle = changeBool(val);
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
                    }
                }
            }

            checkEnemies(enemies);

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].isDead)
                {
                    enemies.RemoveAt(i);
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
                else if (foundColon == false)
                {
                    variable += line[i];
                }
                else
                {
                    val += line[i];
                }
            }

            string[] lineVal = { "", "" };
            lineVal[0] = variable;
            lineVal[1] = val;
            return lineVal;
        }

        void checkEnemies(List<Enemy> enemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy trav = enemies[i];
                trav.takeHit(0);
            }
        }
    }
    public class Animation
    {
        public string name;
        public List<Bitmap> frames = new List<Bitmap>();
        public List<Bitmap> leftFrames = new List<Bitmap>();
        public List<Bitmap> rightFrames = new List<Bitmap>();
        public int frameDelay = 1;

        public void addFrame(Bitmap img, bool doDirections, bool isLeft)
        {
            if (doDirections)
            {
                if (isLeft)
                {
                    leftFrames.Add(img);
                }
                else
                {
                    rightFrames.Add(img);
                }
            }
            else
            {
                frames.Add(img);
            }
        }

        public List<Bitmap> getFrames(bool facingLeft)
        {
            if (facingLeft)
            {
                if (leftFrames.Count > 0)
                {
                    return leftFrames;
                }
                if (rightFrames.Count > 0)
                {
                    return rightFrames;
                }
            }

            if (!facingLeft)
            {
                if (rightFrames.Count > 0)
                {
                    return rightFrames;
                }
                if (leftFrames.Count > 0)
                {
                    return leftFrames;
                }
            }

            return frames;
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

    public class rectF
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public rectF()
        {
            X = 0;
            Y = 0; 
            Width = 0;
            Height = 0;
        }

        public rectF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    public class rect
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public rect()
        {
            X = 0;
            Y = 0; 
            Width = 0;
            Height = 0;
        }

        public rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
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

        public rectF rect = new rectF();

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

        public void positionAbove(rectF ownerR, float gap)
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
                {
                    newAnim = index;
                }
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

        public Bitmap playFrame(bool facingLeft, bool useFacing)
        {
            Bitmap frame = null;

            if (animations.Count == 0)
            {
                return null;
            }

            List<Bitmap> frames;
            if (useFacing)
            {
                frames = animations[currAnim].getFrames(facingLeft);
            }
            else
            {
                frames = animations[currAnim].frames;
            }

            if (currIdx >= frames.Count)
            {
                currIdx = 0;
            }

            if (frames.Count > 0)
            {
                frame = frames[currIdx];
            }

            frameDelayCount++;

            if (frameDelayCount >= animations[currAnim].frameDelay)
            {
                frameDelayCount = 0;

                if (currIdx < frames.Count - 1)
                {
                    currIdx++;
                }
                else
                {
                    currIdx = 0;
                }
            }

            return frame;
        }
        

        public Bitmap playFrameOnce(bool facingLeft, bool useFacing)
        {
            Bitmap frame = null;

            if (animations.Count == 0)
            {
                return null;
            }

            List<Bitmap> frames;
            if (useFacing)
            {
                frames = animations[currAnim].getFrames(facingLeft);
            }
            else
            {
                frames = animations[currAnim].frames;
            }

            if (frames.Count == 0)
            {
                return null;
            }

            if (currIdx >= frames.Count)
            {
                currIdx = frames.Count - 1;
            }

            frame = frames[currIdx];

            frameDelayCount++;

            if (frameDelayCount >= animations[currAnim].frameDelay)
            {
                frameDelayCount = 0;

                if (currIdx < frames.Count - 1)
                {
                    currIdx++;
                }
            }

            return frame;
        }

        public Bitmap playCurrentFrame(bool facingLeft, bool useFacing)
        {
            if (animations.Count == 0)
            {
                return null;
            }

            List<Bitmap> frames;
            if (useFacing)
            {
                frames = animations[currAnim].getFrames(facingLeft);
            }
            else
            {
                frames = animations[currAnim].frames;
            }

            if (frames.Count == 0)
            {
                return null;
            }

            if (currIdx >= frames.Count)
            {
                currIdx = frames.Count - 1;
            }

            return frames[currIdx];
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

            if (a.name == name)
            {
                return true;
            }

            return false;
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
        public rectF rect = new rectF();

        public bool finished = false;
        public bool followPlayer = false;

        public int offsetX;
        public int offsetY;

        public int timer = 0;
        public int maxTimer = 20;

        public bool repeat = false;
        public void draw(Graphics g, rectF ownerR , float camX, float camY)
        {
            if (followPlayer)
            {
                rect.X = ownerR.X + ownerR.Width / 2f - rect.Width / 2f + offsetX;
                rect.Y = ownerR.Y + ownerR.Height - rect.Height + offsetY;
            }

            Bitmap frame = anim.playFrame(false, false);

            if (frame != null)
            {
                g.DrawImage(frame, rect.X - camX, rect.Y - camY, rect.Width, rect.Height);
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
        public rectF rect;
        public rectF SingleDrawRect;
        public float traveledDist = 0f;
        public float maxDist = 2000;
        public Animation animation = new Animation();
        public AnimationController anim = new AnimationController();
        public bool strong = false;

        public float speed = 30;
        public float dirX = 1f;
        public float dirY = 0f;

        public float stepSize = 8f;

        public int damage = 15;
        public int strongDamage = 30;
        public bool finished = false;

        public float targetX, targetY;

        public Fireball(Random rr, float startX, float startY, float targetX, float targetY, bool isItSingle)
        {
            this.isItSingle = isItSingle;

            if (isItSingle == false)
            {

                int normOrStrong = rr.Next(0, 15);
                Bitmap img;
                for (int i = 1; i <= 5; i++)
                {
                    img = new Bitmap("Abilities/fireball/normal/FB500-" + i.ToString() + ".png");
                    animation.addFrame(img, false, false);
                }

                if (normOrStrong != 0)
                {
                    rect = new rectF(startX, startY, 30, 30);
                   
                }
                else
                {
                    strong = true;
                    maxDist = maxDist * 1.5f;
                    rect = new rectF(startX, startY, 40, 40);
                    speed = 45;
                    damage = 50;
                }

                dirX = 1f;
                if (targetX < startX)
                {
                    dirX = -1f;
                }

                int dist = 100;
                if (targetY > startY + dist)
                {
                    dirY = 1;
                }
                else if (targetY < startY - dist)
                {
                    dirY = -1;
                }
                else dirY = 0;
            }
            else
            {
                dirX = 1f;
                if (targetX < startX)
                {
                    dirX = -1f;
                }

                if(dirX == 1f)
                {
                    Bitmap img;
                    for (int i = 1; i <= 6; i++)
                    {
                        img = new Bitmap("Abilities/fireball/strong/right/" + i.ToString() + ".png");
                        animation.addFrame(img, false, false);
                    }

                }
                else
                {
                    Bitmap img;
                    for (int i = 1; i <= 6; i++)
                    {
                        img = new Bitmap("Abilities/fireball/strong/left/" + i.ToString() + ".png");
                        animation.addFrame(img, false, false);
                    }

                }
                dirY = 0f;

              
                strong = true;
                maxDist = 5000f;
                rect = new rectF(startX, startY, 74, 52);
                SingleDrawRect = new rectF(startX, startY, 74, 52);
                
                damage = strongDamage;
            }

            anim.addAnim(animation);
            anim.currAnim = 0;
        }


        public void moveFireball(List<tile> tiles, List<Enemy> enemies)
        {

            if (dirX > 0)
            {
                this.rect.X += speed;
            }
            else this.rect.X -= speed;

            if (dirY > 0)
            {
                this.rect.Y += speed;
            }
            else if(dirY < 0) this.rect.Y -= speed;


            traveledDist += 45;

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

        public void moveSingleFireball(List<tile> tiles, List<Enemy> enemies)
        {
            float remainingDist = 45;

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

        public void draw(Graphics g , float camX, float camY)
        {
            Bitmap frame = anim.playFrame(false, false);
            


            if (isItSingle == false)
            {
                g.DrawImage(frame, rect.X - camX, rect.Y - camY, rect.Width, rect.Height);
            }
            else
            {

                g.DrawImage(frame, SingleDrawRect.X - camX, SingleDrawRect.Y - camY, SingleDrawRect.Width, SingleDrawRect.Height);

            }
        }
    }

    public class Ladder
    {
        public rect rect = new rect();

        public bool isMossy = false;

        public Bitmap ladderImg;

        int tileHeight;

        public Ladder(int x, int y, int height, bool isMossy)
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

        public void draw(Graphics g, bool showRange , float camX, float camY)
        {
            int countLadders = rect.Height / tileHeight;

            int remainingHeight = rect.Height - countLadders * tileHeight + (countLadders - 1);


            int y = rect.Y;

            for (int i = 0; i < countLadders; i++)
            {
                g.DrawImage(ladderImg, rect.X - camX, y - camY, rect.Width, tileHeight);

                y += tileHeight - 1;
            }

            if (remainingHeight > 0)
            {
                Rectangle rcDst = new Rectangle((int)(rect.X - camX), (int)(y - camY), rect.Width, remainingHeight);

                Rectangle rcSource = new Rectangle(0, 0, ladderImg.Width, remainingHeight);

                g.DrawImage(ladderImg, rcDst, rcSource, GraphicsUnit.Pixel);
            }

            if (showRange == true)
            {
                g.DrawRectangle(Pens.Orange, rect.X - camX, rect.Y - camY, rect.Width, rect.Height);
            }
        }
    }

    public class Hero
    {
        public int ColorIdx = 0;
        public rectF R = new rectF();
        public rectF drawR = new rectF();

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

        public float lastValidX = 0f;
        public float lastValidY = 0f;

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

        public int fireballSpawnDelay = 5;
        public int fireballSpawnTimer = 5;

        public float mouseX = 0f;
        public float mouseY = 0f;

        public bool isCastingAbility = false;
        public bool abilityFireballSpawned = false;
        public float abilityManaCost = 50f;
        public bool abilityKeyDown = false;
        public bool isDead = false;

        public bool isAbilityUnlocked = true;

        public bool isClimbing = false;
        public float climbSpeed = 8f;
        public char climbDir = ' ';
        public bool isClimbingMoving = false;
        public bool isDoingCombo = false;


        //General
        public Hero(int startX, int startY, int w, int h, int colorIdx)
        {
            this.ColorIdx = colorIdx;

            drawR.X = startX;
            drawR.Y = startY;
            drawR.Width = w;
            drawR.Height = h;

            R.Width = w * 0.4f;
            R.Height = h * 0.65f;
            R.X = startX + (w - R.Width) / 2f;
            R.Y = startY + (h - R.Height);

            lastValidX = R.X;
            lastValidY = R.Y;

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

        public void Draw(Graphics g, bool showRanges, float camX, float camY)
        {
            drawR.X = R.X + (R.Width - drawR.Width) / 2f;
            drawR.Y = R.Y + (R.Height - drawR.Height);


            for (int i = 0; i < fireballs.Count; i++)
            {
                fireballs[i].draw(g , camX, camY);

                if (showRanges)
                {
                    Pen fbPen = new Pen(Color.Red, 1);
                    g.DrawRectangle(fbPen, fireballs[i].rect.X - camX, fireballs[i].rect.Y - camY, fireballs[i].rect.Width, fireballs[i].rect.Height);
                }
            }

            Bitmap frame;

            if (isDead || isLanding || (isClimbing && !isClimbingMoving))
            {
                if (isClimbing && !isClimbingMoving)
                {
                    if (facing == 'l')
                        frame = anim.playCurrentFrame(true, true);
                    else
                        frame = anim.playCurrentFrame(false, true);
                }
                else if (facing == 'l')
                    frame = anim.playFrameOnce(true, true);
                else
                    frame = anim.playFrameOnce(false, true);
            }
            else
            {
                if (facing == 'l')
                    frame = anim.playFrame(true, true);
                else
                    frame = anim.playFrame(false, true);
            }

            if (frame != null)
            {
                g.DrawImage(frame, drawR.X - camX, drawR.Y - camY, drawR.Width, drawR.Height);
            }
            if (showRanges)
            {

                Pen p = new Pen(Color.Lime, 2);
                g.DrawRectangle(p, R.X - camX, R.Y - camY, R.Width, R.Height);

                if (isAttacking == true)
                {
                    rectF atk = getAttackHitBox();
                    Pen atkPen = new Pen(Color.Orange, 2);
                    g.DrawRectangle(atkPen, atk.X - camX, atk.Y - camY, atk.Width, atk.Height);
                }
            }

            for (int i = vfxes.Count - 1; i >= 0; i--)
            {
                vfxes[i].draw(g, R , camX, camY);

                if (vfxes[i].finished)
                {
                    vfxes.RemoveAt(i);
                }
            }


            UI.draw(g, HP, mana, coins);
            UI.drawWeaponsUI(g, Weapons, currentWeapon);
        }

        public void initVFX()
        {
            doubleJumpAnimation = new Animation();
            doubleJumpAnimation.name = "doubleJump";
            doubleJumpAnimation.frameDelay = 1;

            for (int i = 1; i <= 5; i++)
            {
                Bitmap frame = new Bitmap("vfx/doubleJump/" + i + ".png");
                doubleJumpAnimation.addFrame(frame, false, false);
            }


            fireballAnimation = new Animation();
            fireballAnimation.name = "fireball";
            fireballAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {

                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/BurnEffect/Frames/BurnEffect_0" + i + ".png");
                else frame = new Bitmap("vfx/BurnEffect/Frames/BurnEffect_" + i + ".png");

                fireballAnimation.addFrame(frame, false, false);
            }
        }
        
        public void collectDroppedCoins(List<DroppedCoin> droppedCoins)
        {
            for (int i = 0; i < droppedCoins.Count; i++)
            {
                DroppedCoin coin = droppedCoins[i];

                if (R.X < coin.R.X + coin.R.Width &&
                    R.X + R.Width > coin.R.X &&
                    R.Y < coin.R.Y + coin.R.Height &&
                    R.Y + R.Height > coin.R.Y)
                {
                    coins += coin.coinvalue;

                    droppedCoins.RemoveAt(i);
                    i--;
                }
            }
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

        void createAnim()
        {
            string[] folders = {"attack", "critical_attack", "crouch", "death",
        "idle", "jump_reload", "ladder_climbing", "running", "shield_defence",
        "sliding", "spell_cast", "taking_damage", "walking", "wall_sliding",
        "falling", "landing", "jump_flying", "jump_preparation"};

            int[] numFrames = { 8, 8, 3, 12, 6, 3, 10, 8, 3, 8, 8, 4, 10, 4, 4, 3, 4, 2 };

            string colorName;
            if (ColorIdx == 0)
            {
                colorName = "Blue";
            }
            else if (ColorIdx == 1) colorName = "green";
            else if (ColorIdx == 2) colorName = "purple";
            else colorName = "red";

            for (int i = 0; i < 18; i++)
            {
                Animation a = new Animation();
                a.name = folders[i];
                if (folders[i] == "walking") a.frameDelay = 1;
                else if (folders[i] == "idle") a.frameDelay = 1;
                else if (folders[i] == "landing") a.frameDelay = 1;
                else if (folders[i] == "taking_damage") a.frameDelay = 1;
                else if (folders[i] == "death") a.frameDelay = 1;

                string basePath = "Characters/Hero/" + colorName + "/" + folders[i] + "/";
                string[] directions = { "left", "right" };

                for (int d = 0; d < directions.Length; d++)
                {
                    bool isLeft = false;

                    if (directions[d] == "left")
                    {
                        isLeft = true;
                    }

                    for (int j = 1; j <= numFrames[i]; j++)
                    {
                        Bitmap img = new Bitmap(basePath + directions[d] + "/" + j.ToString() + ".png");
                        a.addFrame(img, true, isLeft);
                    }
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
            if (isClimbing)
            {
                anim.changeAnimation("ladder_climbing", -1);
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
            if ((isClimbing || isClimbingMoving)) return;

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
            if (dmgAnim != null)
            {
                bool dirFacingL = false;
                if (facing == 'l') dirFacingL = true;
                List<Bitmap> dmgFrames = dmgAnim.getFrames(dirFacingL);
                if (dmgFrames.Count > 0)
                {
                    takingDamageTimer = dmgFrames.Count * dmgAnim.frameDelay;
                }
                else
                {
                    takingDamageTimer = dmgAnim.frames.Count * dmgAnim.frameDelay;
                }
            }
        }

        public void updateLastValidPosition()
        {
            if (isGrounded && !isDead)
            {
                lastValidX = R.X;
                lastValidY = R.Y;
            }
        }

        public void handleFallDamage()
        {
            R.X = lastValidX;
            R.Y = lastValidY;
            
            takeDamage(25);
        }

        // Attack
        public void startAbilityCast()
        {
            if ((isClimbing || isClimbingMoving)) return;

            if (isAbilityUnlocked == false) return;

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
            if (isAbilityUnlocked == false) return;

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
            if (spellAnim != null)
            {
                bool dirFacingL = false;
                if(facing == 'l') dirFacingL = true;
                List<Bitmap> spellFrames = spellAnim.getFrames(dirFacingL);
                if (spellFrames.Count > 0 && anim.currIdx >= spellFrames.Count - 1)
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
        public void startAttack()
        {
            if ((isClimbing || isClimbingMoving)) return;

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
            float spawnY = R.Y + 30;

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
                    bool dirFacingL = false;
                    if(facing == 'l') dirFacingL = true;
                    List<Bitmap> atkFrames = attackAnim.getFrames(dirFacingL);
                    int usableFrames = atkFrames.Count - attackComboExtraFrames;
                    if (usableFrames <= 0)
                    {
                        usableFrames = atkFrames.Count;
                    }
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
        
        public rectF getAttackHitBox()
        {
            float h = R.Height * attackHeightScale;
            float y = R.Y + (R.Height - h) / 2f;

            if (facing == 'r')
            {
                return new rectF(R.X, y, R.Width + attackRange, h);
            }
            else
            {
                return new rectF(R.X - attackRange + 5, y, R.Width + attackRange, h);
            }
        }

        public void updateAttack(List<Enemy> enemies)
        {
            if (isAttacking == false) return;

            anim.changeAnimation("attack", -1);

            Animation attackAnim = anim.getCurrentAnimation();
            if (attackAnim == null) return;

            bool dirFacingL = false;
            if(facing == 'l') dirFacingL = true;
            List<Bitmap> attackFrames = attackAnim.getFrames(dirFacingL);

            int usableFrames = attackFrames.Count - attackComboExtraFrames;

            if (usableFrames <= 0)
            {
                usableFrames = attackFrames.Count;
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
                rectF hitBox = getAttackHitBox();

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
       
        //movement
        public void move(List<tile> tiles , List<Ladder> ladders, int width , List<MovingPlatform> movingPlatforms)
        {
            if (isDead == true)
            {
                moving = ' ';
                isAttacking = false;
                isShooting = false;
                isCastingAbility = false;

                Movement(tiles , ladders, movingPlatforms);
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

                Movement(tiles , ladders , movingPlatforms);
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

            
            if(R.X + xMove < 0)
            {
                R.X = 0;
            }
            if(R.X+ R.Width + xMove > width)
            {
                R.X = width - R.Width;
            }
            else
                R.X += xMove;

            if (isClimbing && xMove != 0f)
            {
                if (checkLadders(ladders) == -1)
                    isClimbing = false;
            }

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

            Movement(tiles , ladders , movingPlatforms);

            if (!isAttacking && !isAttacking)
                updateAnimation();
        }
        
        public void Movement(List<tile> tiles, List<Ladder> ladders , List<MovingPlatform> movingPlatforms)
        {
            wasGrounded = isGrounded;
            prevBottom = R.Y + R.Height;

            if (isCastingAbility == false && isClimbing == false)
            {
                if (ySpeed < 0)
                    ySpeed += gravity;
                else
                    ySpeed += fallGravity;

                if (ySpeed > maxFallSpeed)
                    ySpeed = maxFallSpeed;

                R.Y += ySpeed;
            }

            isGrounded = false;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];

                if (t.interact == true)
                {
                    if (R.X + R.Width > t.R.X && R.X < t.R.X + t.R.Width)
                    {
                        if (t.jumpThrough == true)
                        {
                            if (ySpeed >= 0 && prevBottom <= t.R.Y && R.Y + R.Height >= t.R.Y)
                            {
                                R.Y = t.R.Y - R.Height;
                                ySpeed = 0;
                                isGrounded = true;
                            }
                        }
                        else
                        {
                            if (R.Y + R.Height > t.R.Y && R.Y < t.R.Y + t.R.Height)
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

            for (int i = 0; i < ladders.Count; i++)
            {
                Ladder trav = ladders[i];

                if (R.X + R.Width > trav.rect.X + 20 &&
                    R.X < trav.rect.X + trav.rect.Width - 20 &&
                    R.Y + R.Height >= trav.rect.Y &&
                    R.Y < trav.rect.Y + trav.rect.Height)
                {
                    if (isClimbing)
                    {
                        isClimbingMoving = false;

                        if (climbDir == 'u')
                        {
                            ySpeed = -climbSpeed;
                            isClimbingMoving = true;
                        }
                        else if (climbDir == 'd')
                        {
                            ySpeed = climbSpeed;
                            isClimbingMoving = true;
                        }
                        else
                        {
                            ySpeed = 0;
                        }

                        climbDir = ' ';

                        float prevY = R.Y + ySpeed;

                        bool tileCollisionFound = false;

                        for (int tileIndex = 0; tileIndex < tiles.Count; tileIndex++)
                        {
                            tile tileToCheck = tiles[tileIndex];
                            if (tileToCheck.interact == true)
                            {
                                if (R.X + R.Width > tileToCheck.R.X && R.X < tileToCheck.R.X + tileToCheck.R.Width)
                                {
                                    float prevTop = prevY;
                                    float prevBottom = prevY + R.Height;

                                    if (prevBottom > tileToCheck.R.Y && prevTop < tileToCheck.R.Y + tileToCheck.R.Height)
                                    {
                                        if (ySpeed < 0)
                                        {
                                            R.Y = tileToCheck.R.Y + tileToCheck.R.Height;
                                            ySpeed = 0;
                                            isClimbingMoving = false;
                                            tileCollisionFound = true;
                                            break;
                                        }
                                        else if (ySpeed > 0)
                                        {
                                            R.Y = tileToCheck.R.Y - R.Height;
                                            ySpeed = 0;
                                            isGrounded = true;
                                            isClimbing = false;
                                            isClimbingMoving = false;
                                            jumpsUsed = 0;
                                            tileCollisionFound = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        if (tileCollisionFound == false)
                        {
                            R.Y = prevY;

                            if (R.Y + R.Height <= trav.rect.Y)
                            {
                                R.Y = trav.rect.Y - R.Height;
                                ySpeed = 0;
                                isGrounded = true;
                                isClimbing = false;
                                jumpsUsed = 0;
                            }
                            else if (R.Y + R.Height >= trav.rect.Y + trav.rect.Height)
                            {
                                isClimbing = false;
                                ySpeed = 0;
                            }
                        }
                    }
                    else
                    {
                        if (ySpeed >= 0 && prevBottom <= trav.rect.Y && R.Y + R.Height >= trav.rect.Y)
                        {
                            R.Y = trav.rect.Y - R.Height;
                            ySpeed = 0;
                            isGrounded = true;
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
                    anim.changeAnimation("landing", -1);
                    anim.restart();
                }
            }

            if (wasGrounded == true && isGrounded == false && jumpsUsed == 0)
                jumpsUsed = 1;

            if (!isClimbing)
            {
                isClimbingMoving = false;
                climbDir = ' ';
            }
            checkMovingPlatformsCollision(movingPlatforms);
        }

        public int checkLadders(List<Ladder> ladders)
        {
            for (int i = 0; i < ladders.Count; i++)
            {
                Ladder trav = ladders[i];
                if (R.X + R.Width > trav.rect.X + 20 &&
                    R.X < trav.rect.X + trav.rect.Width -20 &&
                    R.Y + R.Height > trav.rect.Y + 5 &&
                    R.Y < trav.rect.Y + trav.rect.Height)
                {
                    return i;
                }
            }
            return -1;
        }
       
        public void checkUnder(List<tile> tiles, List<Ladder> ladders)
        {
            if (isClimbing)
            {
                climbDir = 'd';
                return;
            }

            int ladderIdx = -1;

            for (int i = 0; i < ladders.Count; i++)
            {
                Ladder trav = ladders[i];
                if (R.X + R.Width > trav.rect.X + 20 &&
                    R.X < trav.rect.X + trav.rect.Width -20 &&
                    R.Y + R.Height >= trav.rect.Y - 2 &&
                    R.Y + R.Height <= trav.rect.Y + 5)
                {
                    if(R.Y + R.Height >= trav.rect.Y)
                    {
                        R.Y += 5;
                    }
                    ladderIdx = i;
                }
            }

            if (ladderIdx == -1)
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
            else
            {
                isClimbing = true;
                isGrounded = false;
                isLanding = false;
                climbDir = 'd';
                R.Y += climbSpeed;
            }
        }

        public void climb(List<tile> tiles, List<Ladder> ladders)
        {
            if (isClimbing)
            {
                climbDir = 'u';
                return;
            }

            int ladderIdx = checkLadders(ladders);
            if (ladderIdx != -1)
            {
                isClimbing = true;
                isGrounded = false;
                isLanding = false;
                jumpHeld = false;
                jumpsUsed = 0;
                climbDir = 'u';
            }
        }

        public void handleLadderMovement()
        {
            climbDir = 'u';
        }
        
        public void stopJump()
        {
            jumpHeld = false;

            if (isGrounded == false && ySpeed < 0)
            {
                float minimumJumpVelocity = jumpPower * 0.65f;
                float reducedVelocity = ySpeed * 0.35f;
                
                if (reducedVelocity < minimumJumpVelocity)
                {
                    ySpeed = minimumJumpVelocity;
                }
                else
                {
                    ySpeed = reducedVelocity;
                }
            }
        }
        
        public void jump()
        {
            isClimbing = false;
            isClimbingMoving = false;
            climbDir = ' ';
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

        void checkMovingPlatformsCollision(List<MovingPlatform> movingPlatforms)
        {
            for (int i = 0; i < movingPlatforms.Count; i++)
            {
                MovingPlatform p = movingPlatforms[i];

                bool overlappingX =
                    R.X + R.Width > p.R.X &&
                    R.X < p.R.X + p.R.Width;

                bool fallingOntoPlatform =
                    ySpeed >= 0 &&
                    prevBottom <= p.lastY &&
                    R.Y + R.Height >= p.R.Y;

                if (overlappingX && fallingOntoPlatform)
                {
                    R.Y = p.R.Y - R.Height;

                    ySpeed = 0;
                    isGrounded = true;
                    wasGrounded = true;
                    jumpsUsed = 0;
                    isLanding = false;
                }
            }
        }


    }

    public class DroppedCoin
    {
        public rectF R = new rectF();

        public float velocityY = 0f;
        public float gravity = 1.2f;
        public float maxFallSpeed = 20f;
        public float prevBottom = 0f;

        public List<Bitmap> frames = new List<Bitmap>();
        public int currFrame = 0;
        public int frameDelay = 3;
        public int frameDelayCount = 0;

        public int coinvalue = 20;
        public string cointype = "";

        public DroppedCoin(float x, float y, string type ,int val)
        {
            cointype = type;
            coinvalue = val;

            R.X = x;
            R.Y = y;
            R.Width = 25;
            R.Height = 25;

            if (type == "copper")
            {
                for (int i = 1; i <= 7; i++)
                {
                    Bitmap img = new Bitmap("Collectables/Coins/Bronze/" + i.ToString() + ".png");
                    frames.Add(img);
                }
            }
        }

        public void updateAnimation()
        {
            frameDelayCount++;

            if (frameDelayCount >= frameDelay)
            {
                frameDelayCount = 0;

                currFrame++;

                if (currFrame >= frames.Count)
                {
                    currFrame = 0;
                }
            }
        }

        public void applyGravity(List<tile> tiles)
        {
            prevBottom = R.Y + R.Height;

            velocityY += gravity;
            if (velocityY > maxFallSpeed)
            {
                velocityY = maxFallSpeed;
            }

            R.Y += velocityY;

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

                    if (overlappingX == true)
                    {
                        if (t.jumpThrough == true)
                        {
                            if (velocityY >= 0 &&
                                prevBottom <= t.R.Y &&
                                R.Y + R.Height >= t.R.Y)
                            {
                                R.Y = t.R.Y - R.Height;
                                velocityY = 0;
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

        public void draw(Graphics g , float camX, float camY)
        {
            if (frames.Count == 0)
            {
                return;
            }

            g.DrawImage(frames[currFrame], R.X - camX, R.Y - camY, R.Width, R.Height);

            updateAnimation();
        }
    }
    public class Enemy
    {
        public rectF R = new rectF();
        public rectF drawR = new rectF();
        public Random rr = new Random();

        public string enemyName;
        public string enemyType;
        public string[] animFolders;
        public int[] animFrames;
        public string enemyFolder;


        public float speed = 4f;

        public char moving = 'l';
        public char facing = 'l';

        public bool isRunning = false;
        public bool idle = false;

        public float velocityY = 0f;
        public float gravity = 1.2f;
        public float max_speed = 25f;

        public bool isGrounded = false;
        public bool wasGrounded = false;
        public float prevBottom = 0f;

        public Health HP;
        public UIEntity UI;

        public bool isDead = false;
        public bool isTakingDamage = false;
        public bool isAttacking = false;
        public bool isSleeping = false;
        public bool isWakingUp = false;
        public bool canMoveAfterWakeup = true;

        public float wakeupDistance = 400f;


        public int damageTimer = 0;
        public int deathTimer = 0;

        public int attackTimer = 0;
        public int attackFrameTimer = 0;
        public int attackCooldown = 0;
        public string attackanimname;

        public bool attackDamageDone = false;
        public bool attackmode = false;

        public float attackrange = 65;
        public float attackdis = 200;

        public float startX = 0f;
        public float patrolDistance = 200f;
        public float leftLimit = 0f;
        public float rightLimit = 0f;

        public bool isWaiting = true;
        public int waitTime = 0;
        public int waitingTimer = 60;

        public int spawnX = 0;
        public int spawnY = 0;

        public bool CanSpawn = false;
        public bool spawn = false;

        public int spawnTime = 600;
        public int spawnrange = 600;

        public bool coindropped = false;

        public AnimationController anim = new AnimationController();

        public Enemy(int startX, int startY, int w, int h, string type)
        {
            enemyType = type;
            enemyName = type;

            spawnX = startX;
            spawnY = startY;

            R.Width = w;
            R.Height = h;
            R.X = startX;
            R.Y = startY;


            setEnemyType(type);

            this.startX = R.X;
            leftLimit = R.X - patrolDistance;
            rightLimit = R.X + patrolDistance;

            moving = 'l';
            facing = 'l';

            UI = new UIEntity(0, 0, 70, 15, false, true);

            createAnim();

            if (isSleeping)
            {
                anim.changeAnimation("sleep", -1);
            }
            else
            {
                anim.changeAnimation("idle", -1);
            }
            anim.restart();

            isGrounded = true;
            wasGrounded = true;
        }

        void setEnemyType(string type)
        {
            if (type == "mushroom")
            {
                drawR.X = R.X;
                drawR.Y = R.Y;
                drawR.Width = R.Width * 1.5f;
                drawR.Height = R.Height * 1.5f;

                enemyName = "mushroom";
                enemyFolder = "Mushroom";
                attackanimname = "attack";

                speed = 4f;
                gravity = 1.2f;
                max_speed = 25f;

                patrolDistance = 200f;
                attackrange = 65f;
                attackdis = 200f;
                isSleeping = false;
                isWakingUp = false;
                canMoveAfterWakeup = true;

                spawnrange = 600;
                spawnTime = 600;

                HP = new Health(50, 50);

                string[] mushroomFolders = { "attack", "die", "hit", "idle", "run", "stun-attack" };
                int[] mushroomFrames = { 10, 15, 5, 7, 8, 24 };

                animFolders = mushroomFolders;
                animFrames = mushroomFrames;
            }
            else if (type == "bat")
            {


                drawR.X = R.X ;
                drawR.Y = R.Y + 20;
                drawR.Width = 100;
                drawR.Height = 100;

                enemyName = "bat";
                enemyFolder = "Bat";

                attackanimname = "attack1";
                speed = 6f;
                gravity = 0f;
                max_speed = 20f;

                patrolDistance = 300f;
                attackrange = 50f;
                attackdis = 250f;

                isSleeping = true;
                isWakingUp = false;
                canMoveAfterWakeup = false;

                wakeupDistance = 400f;

                spawnrange = 700;
                spawnTime = 500;

                HP = new Health(30, 30);
                string[] batFolders = { "attack1", "attack2", "die", "hit", "idle", "run", "sleep", "wakeup" };
                int[] batFrames = { 8, 11, 12, 5, 9, 8, 3, 16 };

                animFolders = batFolders;
                animFrames = batFrames;
            }
        }

        void createAnim()
        {
            for (int i = 0; i < animFolders.Length; i++)
            {
                Animation a = new Animation();

                a.name = animFolders[i];

                if (animFolders[i] == "idle")
                {
                    a.frameDelay = 2;
                }
                else if (animFolders[i] == "sleep")
                {
                    a.frameDelay = 4;
                }
                else if (animFolders[i] == "wakeup")
                {
                    a.frameDelay = 2;
                }
                else if (animFolders[i] == "attack1" || animFolders[i] == "attack2")
                {
                    a.frameDelay = 1;
                }
                else if (animFolders[i] == "die")
                {
                    a.frameDelay = 1;
                }
                else if (animFolders[i] == "hit")
                {
                    a.frameDelay = 1;
                }
                else if (animFolders[i] == "run")
                {
                    a.frameDelay = 1;
                }
                else
                {
                    a.frameDelay = 1;
                }

                string basePath = "Characters/Enemies/" + enemyFolder + "/" + animFolders[i] + "/";
                string[] directions = { "left", "right" };

                for (int d = 0; d < directions.Length; d++)
                {
                    bool isLeft = false;

                    if (directions[d] == "left")
                    {
                        isLeft = true;
                    }

                    for (int j = 1; j <= animFrames[i]; j++)
                    {
                        Bitmap img = new Bitmap(basePath + directions[d] + "/" + j.ToString() + ".png");
                        a.addFrame(img, true, isLeft);
                    }
                }

                anim.addAnim(a);
            }
        }

        public void applyPhysics(List<tile> tiles)
        {
            wasGrounded = isGrounded;
            prevBottom = R.Y + R.Height;

            velocityY += gravity;

            if (velocityY > max_speed)
            {
                velocityY = max_speed;
            }

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
                anim.changeAnimation(attackanimname, -1);

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
                anim.changeAnimation(attackanimname, -1);
                return;
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
                if (amount > 0)
                {
                    isTakingDamage = true;

                    damageTimer = 15;

                    anim.changeAnimation("hit", -1);
                    anim.restart();
                }
            }
        }

        float getDistanceFromHero(Hero hero)
        {
            float distanceX = 0;
            float distanceY = 0;

            if (R.X > hero.R.X)
            {
                distanceX = R.X - hero.R.X;
            }
            else
            {
                distanceX = hero.R.X - R.X;
            }

            if (R.Y > hero.R.Y)
            {
                distanceY = R.Y - hero.R.Y;
            }
            else
            {
                distanceY = hero.R.Y - R.Y;
            }

            return distanceX + distanceY;
        }

        public void draw(Graphics g, bool showRanges , float camX, float camY)
        {
            if (spawn)
            {
                drawR.X = R.X + (R.Width - drawR.Width) / 2f;
                drawR.Y = R.Y + (R.Height - drawR.Height);
                if(this.enemyType == "bat")
                {
                    drawR.Y = R.Y - 20;

                }

                Bitmap frame;

                if (isDead || isTakingDamage || isAttacking || isWakingUp)
                {
                    if (facing == 'l')
                    {
                        frame = anim.playFrameOnce(true, true);
                    }
                    else
                    {
                        frame = anim.playFrameOnce(false, true);
                    }
                }
                else
                {
                    if (facing == 'l')
                    {
                        frame = anim.playFrame(true, true);
                    }
                    else
                    {
                        frame = anim.playFrame(false, true);
                    }
                }

                if (frame != null)
                {
                    g.DrawImage(frame, drawR.X - camX, drawR.Y - camY, drawR.Width, drawR.Height);
                }

                if (showRanges)
                {
                    Pen p = new Pen(Color.Red, 2);
                    g.DrawRectangle(p, R.X - camX, R.Y - camY, R.Width, R.Height);
                }

                if (isDead == false)
                {
                    rectF screenR = new rectF();
                    screenR.X = R.X - camX;
                    screenR.Y = R.Y - camY;
                    screenR.Width = R.Width;
                    screenR.Height = R.Height;


                    UI.positionAbove(screenR, 8);
                    UI.draw(g, HP, null, 0);
                }
            }
        }

        int calculateHowValue()
        {
            int multiplier = rr.Next(1, 5);
            return (HP.maxHP / multiplier);
        }

        int[] calculateHowManyCoins()
        {
            int[] coins = { 0, 0, 0 }; //bronze , silver , gold
            int val = calculateHowValue();

            int remaining = val;

            int NGold = remaining / 1000;
            remaining = remaining - NGold * 1000;

            int NSilver = remaining / 100;
            remaining = remaining - NSilver * 100;

            int NBronze = remaining;

            coins[0] = NBronze;
            coins[1] = NSilver;
            coins[2] = NGold;

            return coins;
        }
        public void dropCoin(List<DroppedCoin> droppedCoins)
        {
            if (coindropped == true)
            {
                return;
            }

            if (enemyName == "mushroom")
            {
                float x = R.X + (R.Width / 2);
                float y = R.Y + (R.Height / 2);

                int[] howMany = calculateHowManyCoins();
                for (int i = 0; i < 3; i++)
                {
                    string type;
                    if (i == 0) type = "copper";
                    else if (i == 1) type = "silver";
                    else type = "gold";
                    DroppedCoin coin = new DroppedCoin(x, y, type , howMany[i]);
                    
                    droppedCoins.Add(coin);
                }
                coindropped = true;
            }
            else if (enemyName == "bat")
            {
                float x = R.X + (R.Width / 2);
                float y = R.Y + (R.Height / 2);

                int[] howMany = calculateHowManyCoins();
                for (int i = 0; i < 3; i++)
                {
                    string type;
                    if (i == 0) type = "copper";
                    else if (i == 1) type = "silver";
                    else type = "gold";
                    DroppedCoin coin = new DroppedCoin(x, y, type, howMany[i]);

                    droppedCoins.Add(coin);
                }
                coindropped = true;
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
                attackFrameTimer = 0;
                attackCooldown = 0;
                attackDamageDone = false;

                attackmode = false;

                isWaiting = true;
                isRunning = false;
                waitTime = 0;

                isGrounded = true;
                wasGrounded = true;

                coindropped = false;

                HP.maxHP = 50;
                HP.HP = HP.maxHP;

                anim.changeAnimation("idle", -1);
                anim.restart();
            }
        }

    }

    public class EnemyController
    {
        public List<Enemy> enemies = new List<Enemy>();

        public void Update(List<tile> tiles, Hero hero, List<DroppedCoin> droppedCoins)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies[i];

                float distance;
                if (hero.R.X > e.R.X)
                    distance = hero.R.X - e.R.X;
                else
                    distance = e.R.X - hero.R.X;

                if (e.spawnrange >= distance)
                    e.spawn = true;

                if (e.isDead)
                {
                    e.dropCoin(droppedCoins);

                    Animation currDead = e.anim.getCurrentAnimation();
                    if (currDead != null)
                    {
                        bool dirFacingL = e.facing == 'l';
                        List<Bitmap> deadFrames = currDead.getFrames(dirFacingL);
                        if (deadFrames.Count > 0 && e.anim.currIdx >= deadFrames.Count - 1)
                        {
                            if (e.CanSpawn == false)
                            {
                                enemies.RemoveAt(i);
                                i--;
                            }
                            else
                            {
                                e.deathTimer++;
                                if (e.deathTimer >= e.spawnTime)
                                    e.respawn();
                            }
                        }
                        else
                        {
                            e.deathTimer++;
                            if (e.deathTimer >= e.spawnTime)
                                e.respawn();
                        }
                    }
                }
                else
                {
                    if (e.spawn)
                        moveEnemy(e, tiles, hero);
                }
            }
        }

        void moveEnemy(Enemy e, List<tile> tiles, Hero hero)
        {
            if (e.enemyName == "bat")
                moveFly(e, tiles, hero);
            else
                moveGround(e, tiles, hero);
        }

        void moveFly(Enemy e, List<tile> tiles, Hero hero)
        {
            if (e.isSleeping)
            {
                e.anim.changeAnimation("sleep", -1);
                float d = getDist(e, hero);
                if (d <= e.wakeupDistance)
                {
                    e.isSleeping = false;
                    e.isWakingUp = true;
                    e.canMoveAfterWakeup = false;
                    e.anim.changeAnimation("wakeup", -1);
                    e.anim.restart();
                }
                return;
            }
            if (e.isWakingUp)
            {
                e.anim.changeAnimation("wakeup", -1);
                Animation currWake = e.anim.getCurrentAnimation();
                if (currWake != null)
                {
                    bool dirFacingL = e.facing == 'l';
                    List<Bitmap> wakeFrames = currWake.getFrames(dirFacingL);
                    if (wakeFrames.Count > 0 && e.anim.currIdx >= wakeFrames.Count - 1)
                    {
                        e.isWakingUp = false;
                        e.canMoveAfterWakeup = true;
                        e.anim.changeAnimation("idle", -1);
                        e.anim.restart();
                    }
                }
                return;
            }
            if (!e.canMoveAfterWakeup)
                return;

            if (hero.isDead)
            {
                e.attackmode = false;
                e.isAttacking = false;
                e.attackFrameTimer = 0;
                e.attackDamageDone = false;
            }

            if (e.attackCooldown > 0)
                e.attackCooldown--;

            if (e.isDead || e.isTakingDamage)
            {
                e.applyPhysics(tiles);
                e.updateAnimation();
                return;
            }

            if (e.isAttacking)
            {
                if (hero.isDead)
                {
                    e.attackmode = false;
                    e.isAttacking = false;
                    e.attackFrameTimer = 0;
                    e.attackDamageDone = false;
                }
                else
                {
                    if (e.anim.currIdx >= 4 && !e.attackDamageDone)
                    {
                        hero.takeDamage(10);
                        e.attackDamageDone = true;
                    }
                }
                e.applyPhysics(tiles);
                e.updateAnimation();
                return;
            }

            if (e.isWaiting)
            {
                e.updateAnimation();
                return;
            }

            float dx = 0f;
            float distanceX = 0;
            float distanceY = 0;
            char dir = e.moving;

            if (e.R.X > hero.R.X) { distanceX = e.R.X - hero.R.X; dir = 'l'; }
            else if (e.R.X < hero.R.X) { distanceX = hero.R.X - e.R.X; dir = 'r'; }

            if (e.R.Y > hero.R.Y) distanceY = e.R.Y - hero.R.Y;
            else if (hero.R.Y > e.R.Y) distanceY = hero.R.Y - e.R.Y;

            if (distanceX <= 500 && distanceY <= 300 && !hero.isDead)
                e.attackmode = true;
            else
                e.attackmode = false;

            if (e.attackmode)
            {
                e.moving = dir;
                if (dir == 'l')
                    e.facing = 'r';
                else
                    e.facing = 'l';

                float moveY = 0f;

                if (distanceX > e.attackrange)
                {
                    e.isWaiting = false;
                    e.isRunning = true;
                    if (e.R.X > hero.R.X) { e.R.X -= e.speed; dx = -e.speed; }
                    else if (e.R.X < hero.R.X) { e.R.X += e.speed; dx = e.speed; }
                    e.anim.changeAnimation("run", -1);
                }

                if (distanceY > e.attackrange)
                {
                    if (e.R.Y > hero.R.Y) moveY = -e.speed;
                    else if (e.R.Y < hero.R.Y) moveY = e.speed;
                }

                e.R.Y += moveY;

                distanceX = 0;
                distanceY = 0;
                if (e.R.X > hero.R.X) distanceX = e.R.X - hero.R.X;
                else distanceX = hero.R.X - e.R.X;
                if (e.R.Y > hero.R.Y) distanceY = e.R.Y - hero.R.Y;
                else distanceY = hero.R.Y - e.R.Y;

                if (distanceX <= e.attackrange && distanceY <= e.attackrange && e.attackCooldown > 0)
                {
                    e.moving = ' ';
                    e.isRunning = false;
                    e.anim.changeAnimation("idle", -1);
                    e.applyPhysics(tiles);
                    return;
                }

                if (distanceX <= e.attackrange && distanceY <= e.attackrange && e.attackCooldown <= 0 && !hero.isDead)
                {
                    e.isAttacking = true;
                    e.attackFrameTimer = 20;
                    e.attackDamageDone = false;
                    int r = e.rr.Next(0, 2);
                    if (r == 0)
                        e.attackanimname = "attack1";
                    else
                        e.attackanimname = "attack2";
                    e.anim.changeAnimation(e.attackanimname, -1);
                    e.anim.restart();
                    e.applyPhysics(tiles);
                    return;
                }
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.interact && !t.jumpThrough)
                {
                    bool overlappingX = e.R.X + e.R.Width > t.R.X && e.R.X < t.R.X + t.R.Width;
                    bool overlappingY = e.R.Y + e.R.Height > t.R.Y && e.R.Y < t.R.Y + t.R.Height;
                    if (overlappingX && overlappingY)
                    {
                        float overlapTop = e.R.Y;
                        if (t.R.Y > overlapTop) overlapTop = t.R.Y;
                        float overlapBottom = e.R.Y + e.R.Height;
                        if (t.R.Y + t.R.Height < e.R.Y + e.R.Height) overlapBottom = t.R.Y + t.R.Height;
                        float overlapY = overlapBottom - overlapTop;
                        if (overlapY > 3f)
                        {
                            if (dx > 0)
                            {
                                e.R.X = t.R.X - e.R.Width;
                                e.moving = 'l';
                                e.facing = 'l';
                            }
                            else if (dx < 0)
                            {
                                e.R.X = t.R.X + t.R.Width;
                                e.moving = 'r';
                                e.facing = 'r';
                            }
                        }
                    }
                }
            }

            e.applyPhysics(tiles);
            e.updateAnimation();
        }

        void moveGround(Enemy e, List<tile> tiles, Hero hero)
        {
            if (hero.isDead)
            {
                e.attackmode = false;
                e.isAttacking = false;
                e.attackFrameTimer = 0;
                e.attackDamageDone = false;
            }

            if (e.attackCooldown > 0)
                e.attackCooldown--;

            if (e.isDead || e.isTakingDamage)
            {
                e.applyPhysics(tiles);
                e.updateAnimation();
                return;
            }

            if (e.isAttacking)
            {
                if (hero.isDead)
                {
                    e.attackmode = false;
                    e.isAttacking = false;
                    e.attackFrameTimer = 0;
                    e.attackDamageDone = false;
                }
                else
                {
                    if (e.anim.currIdx >= 4 && !e.attackDamageDone)
                    {
                        hero.takeDamage(10);
                        e.attackDamageDone = true;
                    }
                }
                e.applyPhysics(tiles);
                e.updateAnimation();
                return;
            }

            if (e.isWaiting)
            {
                e.updateAnimation();
                return;
            }

            float dx = 0f;

            if (e.isRunning && !e.attackmode)
            {
                if (e.moving == 'l')
                    dx = -e.speed;
                else
                    dx = e.speed;
                e.R.X += dx;

                if (e.R.X <= e.leftLimit)
                {
                    e.R.X = e.leftLimit;
                    e.moving = 'l';
                    e.facing = 'l';
                    e.isRunning = false;
                    e.isWaiting = true;
                }
                else if (e.R.X >= e.rightLimit)
                {
                    e.R.X = e.rightLimit;
                    e.moving = 'r';
                    e.facing = 'r';
                    e.isRunning = false;
                    e.isWaiting = true;
                }
            }

            float distanceX = 0;
            float distanceY = 0;
            char dir = e.moving;

            if (e.R.X > hero.R.X) { distanceX = e.R.X - hero.R.X; dir = 'l'; }
            else if (e.R.X < hero.R.X) { distanceX = hero.R.X - e.R.X; dir = 'r'; }

            if (e.R.Y > hero.R.Y) distanceY = e.R.Y - hero.R.Y;
            else if (hero.R.Y > e.R.Y) distanceY = hero.R.Y - e.R.Y;

            bool sameY = distanceY < 50;
            bool wasInAttackMode = e.attackmode;

            if (distanceX <= e.attackdis && sameY && !hero.isDead)
            {
                e.attackmode = true;
            }
            else
            {
                e.attackmode = false;
                if (wasInAttackMode)
                {
                    e.isAttacking = false;
                    e.attackDamageDone = false;
                    e.isWaiting = false;
                    e.isRunning = true;

                    if (e.R.X <= e.leftLimit)
                    {
                        e.R.X = e.leftLimit;
                        e.moving = 'r';
                        e.facing = 'r';
                    }
                    else if (e.R.X >= e.rightLimit)
                    {
                        e.R.X = e.rightLimit;
                        e.moving = 'l';
                        e.facing = 'l';
                    }
                    else
                    {
                        float distToLeft = e.R.X - e.leftLimit;
                        float distToRight = e.rightLimit - e.R.X;
                        if (distToLeft < distToRight) { e.moving = 'r'; e.facing = 'r'; }
                        else { e.moving = 'l'; e.facing = 'l'; }
                    }

                    e.anim.changeAnimation("run", -1);
                    e.anim.restart();
                }
            }

            if (e.attackmode)
            {
                e.moving = dir;
                e.facing = dir;

                if (distanceX <= e.attackrange)
                {
                    if (e.attackCooldown > 0)
                    {
                        e.moving = ' ';
                        e.isRunning = false;
                        e.anim.changeAnimation("idle", -1);
                        e.applyPhysics(tiles);
                        return;
                    }

                    if (e.attackCooldown <= 0 && !hero.isDead)
                    {
                        e.isAttacking = true;
                        e.attackFrameTimer = 20;
                        e.attackDamageDone = false;
                        e.attackanimname = "attack";
                        e.anim.changeAnimation(e.attackanimname, -1);
                        e.anim.restart();
                        e.applyPhysics(tiles);
                        return;
                    }
                }

                if (distanceX > e.attackrange)
                {
                    if (e.R.X > hero.R.X) { e.R.X -= e.speed; dx = -e.speed; e.moving = 'l'; e.facing = 'l'; }
                    else if (e.R.X < hero.R.X) { e.R.X += e.speed; dx = e.speed; e.moving = 'r'; e.facing = 'r'; }
                    e.anim.changeAnimation("run", -1);
                }
            }

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.interact && !t.jumpThrough)
                {
                    bool overlappingX = e.R.X + e.R.Width > t.R.X && e.R.X < t.R.X + t.R.Width;
                    bool overlappingY = e.R.Y + e.R.Height > t.R.Y && e.R.Y < t.R.Y + t.R.Height;
                    if (overlappingX && overlappingY)
                    {
                        float overlapTop = e.R.Y;
                        if (t.R.Y > overlapTop) overlapTop = t.R.Y;
                        float overlapBottom = e.R.Y + e.R.Height;
                        if (t.R.Y + t.R.Height < e.R.Y + e.R.Height) overlapBottom = t.R.Y + t.R.Height;
                        float overlapY = overlapBottom - overlapTop;
                        if (overlapY > 3f)
                        {
                            if (dx > 0) { e.R.X = t.R.X - e.R.Width; e.moving = 'l'; e.facing = 'l'; }
                            else if (dx < 0) { e.R.X = t.R.X + t.R.Width; e.moving = 'r'; e.facing = 'r'; }
                        }
                    }
                }
            }

            e.applyPhysics(tiles);
            e.updateAnimation();
        }

        float getDist(Enemy e, Hero hero)
        {
            float dx = 0, dy = 0;
            if (e.R.X > hero.R.X) dx = e.R.X - hero.R.X;
            else dx = hero.R.X - e.R.X;
            if (e.R.Y > hero.R.Y) dy = e.R.Y - hero.R.Y;
            else dy = hero.R.Y - e.R.Y;
            return dx + dy;
        }

        public void Draw(Graphics g, bool showRanges, float camX, float camY)
        {
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].draw(g, showRanges, camX, camY);
        }
    }

    public class tile
    {
        public rectF R = new rectF();
        public Bitmap img = null;
        public bool showColor = true;
        public Color clr;
        public bool interact = false;
        public bool jumpThrough = false;

        public bool couldDamage = false;
        public int dmg = 10;
        public int cooldown = 21;
        public int cooldownTimer = 0;

        public void makeItDamage(int dmg , int cooldown)
        {
            couldDamage = true;
            this.dmg = dmg;
            this.cooldown = cooldown;
        }
        public void checkHero(Hero hero)
        {
            if (couldDamage == true)
            {
                if (cooldownTimer != 0)
                {
                    if (cooldownTimer < cooldown)
                    {
                        cooldownTimer++;
                    }
                    else cooldownTimer = 0;
                }
                else
                {

                    if (hero.R.X <= R.X + R.Width && hero.R.X + hero.R.Width >= R.X &&
                        hero.R.Y <= R.Y + R.Height && hero.R.Y + hero.R.Height >= R.Y)
                    {
                        hero.takeDamage(dmg);
                        cooldownTimer = 1;
                    }

                }
            }
        }
        public void draw(Graphics g , float camX, float camY , bool ShowRanges)
        {
            if (showColor == false && img != null)
            {
                int tileWidth = img.Width;
                int countTiles = (int)(R.Width / tileWidth);
                int remainingWidth = (int)(R.Width - countTiles * tileWidth + (countTiles - 1));

                int x = (int)R.X;
                for (int i = 0; i < countTiles; i++)
                {
                    g.DrawImage(img, x - camX, R.Y - camY, tileWidth, R.Height);
                    x += tileWidth - 1;
                }

                if (remainingWidth > 0)
                {
                    Rectangle rcDst = new Rectangle((int)(x - camX), (int)(R.Y - camY), remainingWidth, (int)R.Height);
                    Rectangle rcSource = new Rectangle(0, 0, remainingWidth, img.Height);
                    g.DrawImage(img, rcDst, rcSource, GraphicsUnit.Pixel);
                }
            }
            else if (showColor == true) {
                SolidBrush bsh = new SolidBrush(clr);
                g.FillRectangle(bsh, R.X - camX, R.Y - camY, R.Width, R.Height);
            }

            if(ShowRanges == true)
            {
                Pen green = new Pen(Color.Brown , 3);
                g.DrawRectangle(green, R.X - camX, R.Y - camY, R.Width, R.Height);
            }
        }
        public void AddImg(Bitmap img)
        {
            this.img = img;
        }
        public void changeColor(Color clr)
        {
            this.clr = clr;
        }

        public void init(int x, int y, int width, int height , bool showColor)
        {
            R.X = x;
            R.Y = y;
            R.Height = height;
            R.Width = width;
            this.showColor = showColor;
        }
    }

    public class MovingPlatform
    {
        public rectF R = new rectF();

        public float startY;
        public float minY;
        public float maxY;

        public float speed = 3f;
        public int dir = -1; 

        public float lastY;
        public float dy;

        public Brush platformBrush = Brushes.SaddleBrown;
        public Pen platformPen = Pens.Black;

        public MovingPlatform(float x, float y, float w, float h, float range, float speed)
        {
            R.X = x;
            R.Y = y;
            R.Width = w;
            R.Height = h;

            startY = y;

            minY = y - range; 
            maxY = y;         

            this.speed = speed;

            lastY = y;
            dy = 0;
        }

        public void move()
        {
            lastY = R.Y;

            R.Y += speed * dir;

            if (R.Y <= minY)
            {
                R.Y = minY;
                dir = 1; 
            }
            else if (R.Y >= maxY)
            {
                R.Y = maxY;
                dir = -1; 
            }

            dy = R.Y - lastY;
        }

        public void draw(Graphics g, float camX)
        {
            g.FillRectangle(platformBrush, R.X - camX, R.Y, R.Width, R.Height);
            g.DrawRectangle(platformPen, R.X - camX, R.Y, R.Width, R.Height);
        }
    }
    public class Button
    {
        public rectF rect = new rectF();
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

            int startX = (int)(rect.X + rect.Width / 2 - text.Length * 7);
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

    
    public class level
    {
        public List<Ladder> ladders = new List<Ladder>();
        public List<Enemy> enemies = new List<Enemy>();
        public List<tile> tiles = new List<tile>();
        public List<MovingPlatform> movingPlatforms = new List<MovingPlatform>();
        public Teleporter teleporter;
        public Bitmap background;
        public int worldWidth = 0;
        public int worldHeight = 0;
        public bool isVoidLevel = false;
        public string displayName = "";

        public float startHeroX;
        public float startHeroY;

        public level(Bitmap bk , int width , int height , float startHeroX , float startHeroY)
        {
            background = bk;
            worldWidth = width;
            worldHeight = height;
            this.startHeroX = startHeroX;
            this.startHeroY = startHeroY;
            isVoidLevel = false;
            displayName = "";
        }

        public level(Bitmap bk, int width, int height, float startHeroX, float startHeroY, bool isVoidLevel, string displayName)
        {
            background = bk;
            worldWidth = width;
            worldHeight = height;
            this.startHeroX = startHeroX;
            this.startHeroY = startHeroY;
            this.isVoidLevel = isVoidLevel;
            this.displayName = displayName;
        }

        public void addEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void addLadder(Ladder ladder)
        {
            ladders.Add(ladder);
        }
        public void addTiles(tile tile)
        {
            tiles.Add(tile);
        }

        public void addMovingPlatform(MovingPlatform movingPlatform)
        {
            movingPlatforms.Add(movingPlatform);
        }
    }

    public class levelController
    {
        public List<level> levels = new List<level>();
        public int currentLevel = -1;

        public levelController(int height , int width)
        {
            initLevelData(height, width);
            initAll(height);
        }

        public void initLevelData(int height, int width)
        {

            //level 1 (idx 0)
            Bitmap background = new Bitmap("Backgrounds/Forest.png");
            int worldWidth = background.Width;
            int worldHeight = height;

            float startHeroX = 30;
            float startHeroY = height - 150 - 30;

            level lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, false, "Forest");
            levels.Add(lvl);

            background = new Bitmap("Backgrounds/shop.png");
            worldWidth = width;
            worldHeight = height;

            startHeroX = 100;
            startHeroY = worldHeight- 120;

            lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, true, "The Void");
            levels.Add(lvl);

            background = new Bitmap("Backgrounds/Dungeon.png");
            worldWidth = background.Width * 2;
            worldHeight = background.Height * 2;


            startHeroX = 10;
            startHeroY = worldHeight - 115;

            lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, false, "Dungeon");
            levels.Add(lvl);

            background = new Bitmap("Backgrounds/shop.png");
            worldWidth = width;
            worldHeight = height;

            startHeroX = 100;
            startHeroY = worldHeight - 120;

            lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, true, "The Void");
            levels.Add(lvl);

            initTeleporters();
        }

        public void initTeleporters()
        {
            level lvl = levels[0];

            lvl.teleporter = new Teleporter(0, lvl.worldWidth - 300 , lvl.worldHeight - 180, 140 , 140 , 300, 100);

            lvl = levels[1];
            lvl.teleporter = new Teleporter(2, lvl.worldWidth- 250, lvl.worldHeight - 200, 175, 175, 0, 100);
            lvl.teleporter.isUnlocked = true;
            lvl.teleporter.requiredCoins = 0;

            lvl = levels[2];
            lvl.teleporter = new Teleporter(1, lvl.worldWidth - 300, lvl.worldHeight - 90 - 175, 175, 175, 300, 100);

            lvl = levels[3];
            lvl.teleporter = new Teleporter(2, lvl.worldWidth - 250, lvl.worldHeight - 200, 175, 175, 0, 100);
            lvl.teleporter.isUnlocked = true;
            lvl.teleporter.requiredCoins = 0;



        }
        public void initAll(int height)
        {
            removeAllFromLevels();
            initTiles(height);
            initLadders(height);
            initEnemies(height);
            initPlatforms();

        }

        void removeAllFromLevels()
        {
            for(int i =0 ; i< levels.Count ; i++){

                while(levels[i].enemies.Count > 0){
                    levels[i].enemies.RemoveAt(0);
                }
                while(levels[i].ladders.Count > 0){
                    levels[i].ladders.RemoveAt(0);
                }
                while(levels[i].tiles.Count > 0){
                    levels[i].tiles.RemoveAt(0);
                }
                while (levels[i].movingPlatforms.Count > 0)
                {
                    levels[i].movingPlatforms.RemoveAt(0);
                }

            }
        }

        void initLadders( int height)
        {
            initLadders0(height);
            initLadders2();


        }
        void initLadders2()
        {
            Ladder ladder;

            ladder = new Ladder(1916 ,645 , 330, true);

            levels[2].ladders.Add(ladder);

            ladder = new Ladder(1420, 320, 325, false);

            levels[2].ladders.Add(ladder);
        }
        void initLadders0(int height)
        {
            Ladder ladder;

            ladder = new Ladder(800 - 75, height - 250 - 400, 400, false);
            levels[0].ladders.Add(ladder);

        }

        int getAboveGroundLoc(int enemyH , int Height)
        {
            return Height - 30 - enemyH;
        }

        void initEnemies(int height)
        {
            Enemy en;

            // Mushroom size
            int mushroomW = 90;
            int mushroomH = 70;
            int mushroomY = getAboveGroundLoc(mushroomH , height);

            en = new Enemy(600, mushroomY, mushroomW, mushroomH, "mushroom");
            en.CanSpawn = true;
            en.spawn = true;
            levels[0].enemies.Add(en);


            int batW = 50;
            int batH = 34;
            int batY = getAboveGroundLoc(batH + 300, height);

            en = new Enemy(1000, batY, batW, batH, "bat");
            en.CanSpawn = true;
            en.spawn = true;
            levels[0].enemies.Add(en);



            
        }

        void initPlatforms()
        {
            levels[0].addMovingPlatform(new MovingPlatform(600, 500, 150, 30, 200, 3));
        }

        void initTiles(int height)
        {
            initTilesLevel0(height);
            initTilesLevel1(height);
            initTilesLevel2();
            initTilesLevel3(height);
        }

        void initTilesLevel1(int height)
        {
            tile pnn = new tile();
            pnn.interact = true;
            pnn.init(0, height - 30, levels[1].worldWidth, 30, true);
            pnn.changeColor(Color.Black);
            levels[1].tiles.Add(pnn);
        }

        void initTilesLevel2()
        {
            int height = levels[2].worldHeight;

            tile pnn = new tile();

            pnn = new tile();
            pnn.interact = true;
            pnn.init(0, height - 112, 2067, 30 , false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(1366, height - 112 - 37, 164, 36, false);
            pnn.AddImg(new Bitmap("Characters/Enemies/Spikes/spikes.png"));
            pnn.makeItDamage(10, 21);

            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(2216, height - 112, 1700, 30, false);
            levels[2].tiles.Add(pnn);


            pnn = new tile();
            pnn.interact = true;
            pnn.init(1235, 917, 127 , 54, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(1275, 860, 58, 60, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(2236, 917, 127, 54, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(2273, 855, 60, 54, false);
            levels[2].tiles.Add(pnn);

            //2nd floor

            pnn = new tile();
            pnn.interact = true;
            pnn.init(0, 720, 70, 105, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(135, 647, 1775, 83, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(1992, 647, 1775, 83, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(3765, 405, 133, 320, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(3825, 730, 70, 250, false);
            levels[2].tiles.Add(pnn);


            //3rd
            pnn = new tile();
            pnn.interact = true;
            pnn.init(0, 320, 1405, 80, false);
            levels[2].tiles.Add(pnn);

            //0 400 130 325
            pnn = new tile();
            pnn.interact = true;
            pnn.init(0, 400, 130, 325, false);
            levels[2].tiles.Add(pnn);


            pnn = new tile();
            pnn.interact = true;
            pnn.init(135, 0, 3700, 120, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(0, 0, 135, 150, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(2732, 320, 1171, 86, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(1499, 321, 903, 86, false);
            levels[2].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.init(3770, 120, 130, 35, false);
            levels[2].tiles.Add(pnn);
        }

        void initTilesLevel3(int height)
        {
            tile pnn = new tile();
            pnn.interact = true;
            pnn.init(0, height - 30, levels[3].worldWidth, 30, true);
            pnn.changeColor(Color.Black);
            levels[3].tiles.Add(pnn);
        }
        void initTilesLevel0(int height)
        {
            tile pnn = new tile();
            pnn.interact = true;
            pnn.init(0, height - 30, levels[0].worldWidth, 30 , true);
            pnn.changeColor(Color.Black);
            levels[0].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = true;
            pnn.init(300, height - 150, 200, 20 , true);
            pnn.changeColor(Color.Black);
            levels[0].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = false;
            pnn.clr = Color.DarkRed;
            pnn.init(600, height - 250, 200, 30 , true);
            pnn.changeColor(Color.Red);

            levels[0].tiles.Add(pnn);
        }

        public void loadLadders(List<Ladder>ladders)
        {
            while (ladders.Count > 0)
            {
                ladders.RemoveAt(0);
            }

            if (currentLevel < 0 || currentLevel >= levels.Count)
            {
                return;
            }

            level curLvl = levels[currentLevel];

            for (int i = 0; i < curLvl.ladders.Count; i++)
            {
                Ladder temp = curLvl.ladders[i];
                ladders.Add(temp);
            }

        }

        public void loadEnemies(List<Enemy>enemies)
        {
            while (enemies.Count > 0)
            {
                enemies.RemoveAt(0);
            }

            if (currentLevel < 0 || currentLevel >= levels.Count)
            {
                return;
            }

            level curLvl = levels[currentLevel];

            for (int i = 0; i < curLvl.enemies.Count; i++)
            {
                Enemy temp = curLvl.enemies[i];
                enemies.Add(temp);
            }
        
        }

        public void loadTiles(List<tile>tiles)
        {
            
            while (tiles.Count > 0)
            {
                tiles.RemoveAt(0);
            }

                if (currentLevel < 0 || currentLevel >= levels.Count)
                {
                    return;
                }

            level curLvl = levels[currentLevel];
            for (int i = 0; i < curLvl.tiles.Count; i++)
            {
                tile temp = curLvl.tiles[i];
                tiles.Add(temp);
            }

        }
        public void loadPlatforms(List<MovingPlatform> movingPlatforms)
        {
            while (movingPlatforms.Count > 0)
            {
                movingPlatforms.RemoveAt(0);
            }

            if (currentLevel < 0 || currentLevel >= levels.Count)
            {
                return;
            }

            level curLvl = levels[currentLevel];

            for (int i = 0; i < curLvl.movingPlatforms.Count; i++)
            {
                MovingPlatform temp = curLvl.movingPlatforms[i];
                movingPlatforms.Add(temp);
            }
        }
        public void removeAll(List<Enemy> enemies, List<Ladder> ladders, List<tile> tiles , List<DroppedCoin> coins)
        {
            while(coins.Count > 0)
            {
                coins.RemoveAt(0);
            }

            while(enemies.Count > 0)
            {
                enemies.RemoveAt(0);
            }

            while (ladders.Count > 0)
            {
                ladders.RemoveAt(0);
            }

            while (tiles.Count > 0)
            {
                tiles.RemoveAt(0);
            }
        }

        public void assignAll(List<Enemy> enemies, List<Ladder> ladders, List<tile> tiles)
        {
            level curLvl = levels[currentLevel];

            while (enemies.Count > 0)
            {
                enemies.RemoveAt(0);
            }
            while (ladders.Count > 0)
            {
                ladders.RemoveAt(0);
            }
            while (tiles.Count > 0)
            {
                tiles.RemoveAt(0);
            }

            for(int i =0; i < curLvl.enemies.Count; i++)
            {
                Enemy temp = curLvl.enemies[i];
                enemies.Add(temp);
            }

            for (int i = 0; i < curLvl.ladders.Count; i++)
            {
                Ladder temp = curLvl.ladders[i];
                ladders.Add(temp);
            }

            for (int i = 0; i < curLvl.tiles.Count; i++)
            {
                tile temp = curLvl.tiles[i];
                tiles.Add(temp);
            }
        }
        public void nextLevel(List<Enemy> enemies , List<Ladder> ladders , List<tile> tiles , List<DroppedCoin> coins, List<MovingPlatform> movingPlatforms)
        {
            if (currentLevel < levels.Count - 1)
            {
                currentLevel++;
                removeAll(enemies, ladders, tiles , coins);
                assignAll(enemies, ladders, tiles);
                loadPlatforms(movingPlatforms);
            }
        }
        public bool isVoidLevel()
        {
            if (currentLevel < 0 || currentLevel >= levels.Count)
            {
                return false;
            }

            return levels[currentLevel].isVoidLevel;
        }

        public string getCurrentLevelTitle()
        {
            if (currentLevel < 0 || currentLevel >= levels.Count)
            {
                return "";
            }

            if (levels[currentLevel].displayName != "")
            {
                return levels[currentLevel].displayName;
            }

            return "Level: " + (currentLevel + 1).ToString();
        }
        public float getNewHeroX()
        {
            return levels[currentLevel].startHeroX;
        }

        public float getNewHeroY()
        {
            return levels[currentLevel].startHeroY;
        }

        public Bitmap getBackground()
        {
            return levels[currentLevel].background;
        }
    }   

    public class Teleporter
    {
        public int level;
        public rect rect = new rect();
        public Animation Animation = new Animation();
        public int currF = 0;
        public int requiredCoins = 200;
        public bool isUnlocked = false;

        public bool loopIt = false;
        public int range = 100;
        public bool isHeroInRange = false;
        
        public Teleporter(int level , int x , int y , int w , int h , int coins , int range)
        {
            this.level = level;
            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;

            requiredCoins = coins;
            this.range = range;

            initAnim(level);
        }

        void initAnim(int level)
        {
            if (level == 0)
            {
                for (int i = 1; i <= 8; i++) {
                    Bitmap frame = new Bitmap("Teleporters/Green/" + i.ToString() + ".png");
                    Animation.addFrame(frame, false, false);
                }
                loopIt = true;
            }

            else if (level == 1)
            {
                for (int i = 0; i <= 40; i++)
                {
                    string numbers = "";
                    if(i < 10)
                    {
                        numbers += "0";
                    }
                    numbers += i.ToString();
                    Bitmap frame = new Bitmap("Teleporters/Key/sprite_" + numbers + ".png");
                    Animation.addFrame(frame, false, false);
                }
                loopIt = false;
            }
            else if(level == 2){

                for (int i = 0; i <= 21; i++)
                {
                    string numbers = "";
                    if (i < 10)
                    {
                        numbers += "0";
                    }
                    numbers += i.ToString();
                    Bitmap frame = new Bitmap("Teleporters/Purple/Sequence" + numbers + ".png");
                    Animation.addFrame(frame, false, false);
                }

                loopIt = false;
            }
        }

        public Bitmap getFrame()
        {
            if(this.loopIt == true)
            {
                Bitmap frame = Animation.frames[currF];
                if (currF < Animation.frames.Count - 1)
                {
                    currF++;
                }
                else currF = 0;
                return frame;
            }
            else
            {
                if(isUnlocked == false)
                {
                    return Animation.frames[0];
                }
                else
                {
                    if(currF < Animation.frames.Count - 1)
                    {
                        if(currF == Animation.frames.Count/4)
                        {

                            if (level == 1)
                            {
                                rect.Y -= 23;
                            }
                        }
                        currF++;
                        return Animation.frames[currF];
                    }
                    else
                    {
                        return Animation.frames[Animation.frames.Count - 1];
                    }
                }
            }
        }

        public void checkHero(Hero hero)
        {
            if(loopIt == false && isUnlocked == true && currF < Animation.frames.Count - 1)
            {
                isHeroInRange = false;
                return;
            }
            int startX = rect.X - range;
            int endX = rect.X + rect.Width + range;

            int startY = rect.Y - range;
            int endY = rect.Y + rect.Height + range;

            if (hero.R.X < startX + endX && hero.R.X + hero.R.Width >= startX &&
                hero.R.Y < startY + endY && hero.R.Y + hero.R.Height >= startY)
            {
                isHeroInRange = true;
            }
            else isHeroInRange = false;
            
        }
        public void draw(Graphics g, Hero hero, bool showRange , float camX, float camY)
        {
            checkHero(hero);
            g.DrawImage(getFrame(), rect.X - camX, rect.Y - camY, rect.Width, rect.Height);

            if (showRange == true)
            {
                Pen red = new Pen(Color.Red);
                g.DrawRectangle(red, rect.X - range - camX, rect.Y - range - camY, range*2 + rect.Width, range + rect.Height);
            }

            int h = 40;
            int w = 165;
            float positionButtonX = rect.X + rect.Width / 2 - w / 2 - camX;
            float positionButtonY = rect.Y - h - 20 - camY;

            if (isHeroInRange == true)
            {
                SolidBrush greyBrush = new SolidBrush(Color.Gray);
                g.FillRectangle(greyBrush, positionButtonX, positionButtonY, w, h);

                Pen blackPen = new Pen(Color.Black, 3);
                g.DrawRectangle(blackPen, positionButtonX, positionButtonY, w, h);

                Font font = new Font("Arial", 12, FontStyle.Bold);
                SolidBrush textBrush = new SolidBrush(Color.Black);

                string text = "Press Q to unlock!";
                if(hero.coins < this.requiredCoins)
                {
                    text = "You need " + (requiredCoins - hero.coins).ToString() + " Coins!";
                }
                if(isUnlocked == true)
                {
                    text = "Unlocked! Press Q";
                }
                g.DrawString(text, font, textBrush, positionButtonX, positionButtonY + 10);
            }

        }
    }
    public partial class Form1 : Form
    {
        Save save = new Save();
        Load load = new Load();

        Random Random = new Random();
        bool hasStarted = false;
        bool isGamePaused = false;

        Bitmap button = new Bitmap("ui/menu/UI_TravelBook_Frame01a.png");
        int currentButton = 0;
        int lastMenuScreen = 0;

        List<Bitmap> menuImgs = new List<Bitmap>();
        List<Button> btns = new List<Button>();

        List<Button> PauseBtns = new List<Button>();
        int currPauseBtn = 0;

        List<Button> GameOverBtns = new List<Button>();
        int currGameOverBtn = 0;
        bool isGameOverScreenShown = false;
        int gameOverScreenDelay = 0;
        int gameOverScreenDelayMax = 10;

        bool showRanges = false;
        Bitmap off; 
        Random RR = new Random();

        bool isLevelIntroVisible = false;
        int levelIntroTimer = 0;
        int levelIntroTimerMax = 10;
        int levelIntroNumber = 1;

        float camX = 0;
        float camY = 0;


        levelController levels;

        Hero hero;
        EnemyController enemyController = new EnemyController();
        List<tile> tiles = new List<tile>();
        List<Ladder> ladders = new List<Ladder>();
        List<DroppedCoin> droppedCoins = new List<DroppedCoin>();
        List<MovingPlatform> movingPlatforms = new List<MovingPlatform>();
        Timer timer = new Timer();


        List<Animation> heroColors = new List<Animation>();
        List<rectF> clrBtns = new List<rectF>();
        bool upHeld = false;

        int animIdx = 0;
        int ChoiceIdx = 0;


        float[] lastPos = { 0, 0 };
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
            timer.Tick += Timer_Tick;
            timer.Start();

            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
        }

        //Form Functions
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!hasStarted || isGamePaused == true || isLevelIntroVisible) return;
            if (levels != null && levels.isVoidLevel() == true) return;

            if (e.Button == MouseButtons.Left)
            {
                if (hero.currentWeapon == 1)
                    hero.stopFireball();
            }
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPos[0] = e.X + camX;
            lastPos[1] = e.Y + camY;

            if (hasStarted == false)
            {
                for (int i = 0; i < clrBtns.Count; i++)
                {
                    rectF btnC = clrBtns[i];
                    if (e.X > btnC.X && e.X < btnC.X + btnC.Width
                        && e.Y > btnC.Y && e.Y < btnC.Y + btnC.Height)
                    {
                        ChoiceIdx = i;
                    }
                }

                Button btn = btns[btns.Count - 1];
                if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                            && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                {
                    if (lastMenuScreen == 0)
                    {
                        startNewGame();
                        save.save(hero, enemyController.enemies , levels.currentLevel);
                    }

                    startGame();
                }
            }
            else if (isGameOverScreenShown == true)
            {
                for (int i = 0; i < GameOverBtns.Count; i++)
                {
                    Button btn = GameOverBtns[i];
                    if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                                && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                    {
                        currGameOverBtn = i;
                        manageGameOver();
                        break;
                    }
                }
            }
            else if (isGamePaused == false && hero.isDead == false && isLevelIntroVisible == false)
            {
                if (levels != null && levels.isVoidLevel() == true)
                {
                    return;
                }

                if (e.Button == MouseButtons.Left)
                {
                    bool isClicked = CheckIfWeaponUIClicked(e.X, e.Y);

                    if (isClicked == false)
                    {
                        hero.mouseX = e.X + camX;
                        hero.mouseY = e.Y + camY;
                        hero.startAttack();
                    }
                }
            }
            else
            {
                for (int i = 0; i < PauseBtns.Count; i++)
                {
                    Button btn = PauseBtns[i];
                    if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                                && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                    {
                        managePause();
                        break;
                    }
                }
            }
        }
        
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            this.Text = "X,Y: " + (e.X+camX).ToString() + " , "+ (e.Y+camY).ToString() + " | difference: "+ ((e.X + camX) - lastPos[0]).ToString() + " , " + ((e.Y + camY) - lastPos[1]).ToString();
            if (hasStarted == false)
            {
                for (int i = 0; i < btns.Count; i++)
                {
                    Button btn = btns[i];
                    if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                        && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                    {
                        if (i != btns.Count - 1)
                        {
                            if (IsLeftMenu(currentButton) == true)
                            {
                                lastMenuScreen = currentButton;
                            }

                            currentButton = i;

                            break;
                        }
                        else
                        {
                            if (currentButton == 0 || currentButton == 1)
                            {
                                if (IsLeftMenu(currentButton) == true)
                                {
                                    lastMenuScreen = currentButton;
                                }

                                currentButton = i;

                                break;
                            }
                        }
                    }
                }


            }
            else if (isGamePaused == false)
            {
                if (levels != null && levels.isVoidLevel() == true)
                {
                    return;
                }

                if (!isLevelIntroVisible)
                {
                    hero.mouseX = e.X + camX;
                    hero.mouseY = e.Y + camY;
                }
            }
            else if (isGamePaused == true)
            {
                for (int i = 0; i < PauseBtns.Count; i++)
                {
                    Button btn = PauseBtns[i];
                    if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                        && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                    {
                        currPauseBtn = i;
                        drawDubb(this.CreateGraphics());

                        break;
                    }
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawDubb(this.CreateGraphics());
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (hasStarted == false || isGamePaused == true || isLevelIntroVisible) return;


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
                if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                    upHeld = false;

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


            if (hasStarted == false)
            {
                if (e.KeyCode == Keys.D1)
                {
                    ChoiceIdx = 0;
                }
                else if (e.KeyCode == Keys.D2)
                {
                    ChoiceIdx = 1;
                }
                else if (e.KeyCode == Keys.D3)
                {
                    ChoiceIdx = 2;
                }
                else if (e.KeyCode == Keys.D4)
                {
                    ChoiceIdx = 3;
                }

                if (e.KeyCode == Keys.Down)
                {

                    if (currentButton < btns.Count - 2)
                    {
                        currentButton++;
                    }
                    else
                    {
                        currentButton = 0;
                    }

                }

                if (e.KeyCode == Keys.Up)
                {
                    if (currentButton > 0 && currentButton != btns.Count - 1)
                    {
                        currentButton--;
                    }
                    else
                    {
                        currentButton = btns.Count - 2;
                    }

                }

                if (currentButton == 0 || currentButton == 1)
                {
                    if (e.KeyCode == Keys.Right)
                    {
                        if (IsLeftMenu(currentButton) == true)
                        {
                            lastMenuScreen = currentButton;
                        }

                        if (currentButton == 1)
                        {
                            if (IsSaveAvailable() == true)
                            {
                                currentButton = btns.Count - 1;
                            }
                        }
                        else
                        {
                            currentButton = btns.Count - 1;
                        }

                    }
                }

                if (currentButton == btns.Count - 1)
                {
                    if (e.KeyCode == Keys.Left)
                    {
                        currentButton = 0;
                    }

                    if (e.KeyCode == Keys.Enter)
                    {
                        if (lastMenuScreen == 0)
                        {
                            startNewGame();
                            save.save(hero, enemyController.enemies , levels.currentLevel);

                        }

                        startGame();
                    }
                }
            }
            else
            {
                if (isLevelIntroVisible)
                {
                    return;
                }

                if (isGameOverScreenShown == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        manageGameOver();
                    }
                }
                else if (isGamePaused == true)
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        isGamePaused = false;
                        resumeGame();
                    }

                    if (e.KeyCode == Keys.Enter)
                    {
                        managePause();
                    }
                    if (e.KeyCode == Keys.Down)
                    {

                        if (currPauseBtn < PauseBtns.Count - 1)
                        {
                            currPauseBtn++;
                        }
                        else
                        {
                            currPauseBtn = 0;
                        }
                        drawDubb(this.CreateGraphics());


                    }

                    if (e.KeyCode == Keys.Up)
                    {
                        if (currPauseBtn > 0)
                        {
                            currPauseBtn--;
                        }
                        else
                        {
                            currPauseBtn = PauseBtns.Count - 2;
                        }
                        drawDubb(this.CreateGraphics());

                    }
                }
                else
                {
                    bool voidLevel = levels.isVoidLevel();

                    if (voidLevel == true)
                    {
                        if (e.KeyCode == Keys.Escape)
                        {
                            isGamePaused = true;
                            pauseGame();
                            return;
                        }

                        if (levels.levels[levels.currentLevel].teleporter.isHeroInRange == true)
                        {
                            if (e.KeyCode == Keys.Q)
                            {
                                int oldLevel = levels.currentLevel;
                                levels.nextLevel(enemyController.enemies, ladders, tiles, droppedCoins, movingPlatforms);

                                if (levels.currentLevel != oldLevel)
                                {
                                    hero.R.X = levels.getNewHeroX();
                                    hero.R.Y = levels.getNewHeroY();
                                    startLevelIntro();
                                }
                            }
                        }

                        if (camX < 0)
                        {
                            camX = 0;
                        }

                        float maxcamX = levels.getBackground().Width - this.ClientSize.Width;

                        if (maxcamX < 0)
                        {
                            maxcamX = 0;
                        }

                        if (camX > maxcamX)
                        {
                            camX = maxcamX;
                        }
                    }

                    if (e.KeyCode == Keys.Escape)
                    {
                        isGamePaused = true;
                        pauseGame();
                    }
                    if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && hero.isDead == false)
                    {
                        if (hero.R.X + hero.R.Width < levels.levels[levels.currentLevel].worldWidth)
                        {
                            hero.moving = 'r';
                            hero.facing = 'r';
                        }
                    }
                    if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && hero.isDead == false)
                    {
                        if (hero.R.X > 0)
                        {
                            hero.moving = 'l';
                            hero.facing = 'l';
                        }
                    }
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                    {
                        hero.checkUnder(tiles, ladders);
                    }
                    if (e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                    {
                        if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
                        {
                            upHeld = true;
                            hero.climb(tiles, ladders);

                            if (hero.isClimbing == false)
                            {
                                if (hero.jumpHeld == false)
                                {
                                    hero.jump();
                                }
                            }
                        }
                        else if (e.KeyCode == Keys.Space)
                        {
                            if (hero.jumpHeld == false)
                            {
                                hero.jump();
                            }
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
                    if (e.KeyCode == Keys.R)
                    {
                        if (hero.isDead == true)
                        {
                            hero.isDead = false;
                        }
                    }

                    if (hero.Weapons.Count > 1)
                    {
                        if (e.KeyCode == Keys.D1)
                        {
                            hero.coins += 20;
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
                    if(levels.levels[levels.currentLevel].teleporter.isHeroInRange == true)
                    {
                        if(e.KeyCode == Keys.Q)
                        {
                            if (levels.levels[levels.currentLevel].teleporter.isUnlocked == false)
                            {
                                if (hero.coins >= levels.levels[levels.currentLevel].teleporter.requiredCoins)
                                {
                                    levels.levels[levels.currentLevel].teleporter.isUnlocked = true;
                                    hero.coins -= levels.levels[levels.currentLevel].teleporter.requiredCoins;
                                }
                            }
                            else
                            {
                                int oldLevel = levels.currentLevel;
                                levels.nextLevel(enemyController.enemies, ladders, tiles, droppedCoins, movingPlatforms);

                                if (levels.currentLevel != oldLevel)
                                {
                                    hero.R.X = levels.getNewHeroX();
                                    hero.R.Y = levels.getNewHeroY();
                                    startLevelIntro();
                                }
                            }
                        }
                    }

                    if (camX < 0)
                    {
                        camX = 0;
                    }

                    float maxCamX = levels.getBackground().Width - this.ClientSize.Width;

                    if (maxCamX < 0)
                    {
                        maxCamX = 0;
                    }

                    if (camX > maxCamX)
                    {
                        camX = maxCamX;
                    }

                }
            }
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hasStarted == true)
            {
                updateLevelIntroState();

                if (isLevelIntroVisible)
                {
                    drawDubb(this.CreateGraphics());
                    return;
                }

                if (hero.isDead && !isGameOverScreenShown)
                {
                    if (gameOverScreenDelay == 0)
                    {
                        startGameOverScreen();
                    }

                    gameOverScreenDelay++;
                    if (gameOverScreenDelay >= gameOverScreenDelayMax)
                    {
                        isGameOverScreenShown = true;
                        currGameOverBtn = 0;
                        gameOverBtns();
                        timer.Stop();
                    }
                }
                else if (!hero.isDead)
                {
                    for (int i = 0; i < droppedCoins.Count; i++)
                    {
                        droppedCoins[i].applyGravity(tiles);
                    }

                    if (upHeld == true)
                    {
                        hero.climb(tiles, ladders);
                    }
                    hero.updateLastValidPosition();

                    if (hero.R.Y > levels.levels[levels.currentLevel].worldHeight)
                    {
                        hero.handleFallDamage();
                    }
                    for(int i =0; i< tiles.Count; i++)
                    {
                        tiles[i].checkHero(hero);
                    }

                    if (hero.currentWeapon == 0)
                    {
                        hero.updateAttack(enemyController.enemies);
                    }

                    for (int i = 0; i < movingPlatforms.Count; i++)
                    {
                        movingPlatforms[i].move();
                    }

                    hero.move(tiles, ladders, levels.levels[levels.currentLevel].worldWidth , movingPlatforms);
                    hero.collectDroppedCoins(droppedCoins);

                    hero.updateFireballCast(enemyController.enemies, tiles);
                    hero.updateSingleFireballAbility(enemyController.enemies, tiles);

                    hero.mana.tick();
                    enemyController.Update(tiles, hero, droppedCoins);
                    UpdateCamera();

                }
            }

            drawDubb(this.CreateGraphics());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            initButtons();
            initMenu();

            levels = new levelController(this.ClientSize.Height , this.ClientSize.Width);



            //hero = new Hero(30, this.ClientSize.Height - 150 - 30, 150, 150);


            loadData();

            drawDubb(this.CreateGraphics());

        }

        //draw
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

                if (isGameOverScreenShown == true)
                {
                    GameOverScreen(g);
                }
                else if (isGamePaused == true)
                {
                    SolidBrush background = new SolidBrush(Color.FromArgb(0, 0, 0));
                    g.FillRectangle(background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

                    PauseScreen(g);
                }
                else
                {

                    Bitmap bg = levels.getBackground();
                    float worldW = levels.levels[levels.currentLevel].worldWidth;
                    float worldH = levels.levels[levels.currentLevel].worldHeight;


                    // if teh bg width is lesser than the worldW we divide the camX by the ratio to move it correctly
                   
                    float divideX = bg.Width / worldW;
                    float divideY = bg.Height / worldH;

                    Rectangle rcSrc = new Rectangle((int)(camX * divideX), (int)(camY * divideY), (int)(this.ClientSize.Width * divideX), (int)(this.ClientSize.Height * divideY));
                    Rectangle rcDst = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);

                    g.DrawImage(bg, rcDst, rcSrc, GraphicsUnit.Pixel);



                    levels.levels[levels.currentLevel].teleporter.draw(g, hero, showRanges, camX, camY);

                    for (int i = 0; i < tiles.Count; i++)
                    {
                        tiles[i].draw(g,camX, camY , showRanges);
                    }
                    for (int i = 0; i < ladders.Count; i++)
                    {
                        ladders[i].draw(g, showRanges, camX, camY);
                    }
                    enemyController.Draw(g, showRanges, camX, camY);
                    for (int i = 0; i < droppedCoins.Count; i++)
                    {
                        droppedCoins[i].draw(g , camX, camY);
                    }
                    for (int i = 0; i < movingPlatforms.Count; i++)
                    {
                        movingPlatforms[i].draw(g, camX);
                    }

                    hero.Draw(g, showRanges, camX, camY);

                    
                    save.autoSave(hero, enemyController.enemies, levels.currentLevel, g, this.ClientSize.Height);
                    
                }

                if (isLevelIntroVisible == true)
                {
                    drawLevelIntro(g);
                }

            }
            else
            {
                displayMenu(g);
            }
        }

        void startLevelIntro()
        {
            isLevelIntroVisible = true;
            levelIntroTimer = 0;
            levelIntroNumber = levels.currentLevel + 1;
            camX = 0;
            camY = 0;

            upHeld = false;

            if (hero != null)
            {
                hero.moving = ' ';
                hero.isRunning = false;
                hero.stopFireball();
            }
        }

        void updateLevelIntroState()
        {
            if (isLevelIntroVisible == false)
            {
                return;
            }

            levelIntroTimer++;

            if (levelIntroTimer >= levelIntroTimerMax)
            {
                isLevelIntroVisible = false;
            }
        }

        void drawLevelIntro(Graphics g)
        {
            SolidBrush overlay = new SolidBrush(Color.FromArgb(220, 0, 0, 0));
            g.FillRectangle(overlay, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            string text = levels.getCurrentLevelTitle();

            Font levelFont = new Font("System", 48, FontStyle.Bold);
            SolidBrush outline = new SolidBrush(Color.FromArgb(0, 0, 0));
            SolidBrush textBrush = new SolidBrush(Color.White);

            int x = this.ClientSize.Width / 2 - 180;
            int y = this.ClientSize.Height / 2 - 40;

            g.DrawString(text, levelFont, outline, x + 3, y + 3);
            g.DrawString(text, levelFont, textBrush, x, y);
        }

        void drawNewGameScreen(Graphics G, int x, int y, int width, int height, Font titleFont, Font normalFont, Font smallFont, SolidBrush white, SolidBrush gold, Bitmap frame, Bitmap SelectedFrame)
        {
            G.DrawString("Begin Your Journey", titleFont, gold, x + 20, y + 10);

            x = x + 20;
            y = y + 60;
            G.DrawString("Choose a color for your hero", normalFont, white, x, y);

            y += 30;

            int widthF = 80; //56
            int heightF = 80;

            int currX = x;
            for (int i = 0; i < heroColors.Count; i++)
            {
                if (i == ChoiceIdx)
                {
                    G.DrawImage(SelectedFrame, currX, y, widthF, heightF);
                }
                else
                {
                    G.DrawImage(frame, currX, y, widthF, heightF);

                }

                Bitmap curr = heroColors[i].frames[animIdx];
                G.DrawImage(curr, currX, y - 20, 80, 80);

                clrBtns[i] = new rectF(currX, y - 20, 80, 80);

                currX += widthF + 10;
            }

            if (animIdx < heroColors[0].frames.Count - 1)
            {
                animIdx++;
            }
            else animIdx = 0;

            int statsX = x;
            int statsY = y + 120;

            G.DrawString("Base Stats", titleFont, gold, statsX, statsY);

            statsY += 40;

            G.DrawString("HP: 100", normalFont, white, statsX, statsY);

            statsY += 30;

            G.DrawString("Mana: 100", normalFont, white, statsX, statsY);

            statsY += 30;

            G.DrawString("Speed: 6", normalFont, white, statsX, statsY);
        }

        void drawLoadGameScreen(Graphics G, int x, int y, int width, int height, Font titleFont, Font normalFont, Font smallFont, SolidBrush white, SolidBrush gold, Bitmap frameSelectA, Bitmap slot)
        {
            if (IsSaveAvailable() == false)
            {
                G.DrawString("No Saves Available", titleFont, Brushes.Red, x + 40, y + 120);
                return;
            }

            drawBar(G, "Health", hero.HP.HP, hero.HP.maxHP, x + 170, y - 80, Brushes.DarkRed, Brushes.Red, smallFont);


            drawBar(G, "Mana", hero.mana.mana, hero.mana.maxMana, x + 170, y - 40, Brushes.DarkBlue, Brushes.DeepSkyBlue, smallFont);


            rectF saveRect = new rectF(x + 15, y + 10, width - 30, 420);

            int textX = (int)saveRect.X + 20;
            int currentY = (int)saveRect.Y;

            G.DrawString("Last Save", titleFont, gold, textX, currentY);

            G.DrawImage(slot, x + width - 120 - 20, currentY, 120, 120);
            G.DrawImage(heroColors[hero.ColorIdx].frames[0], x + width - 120 - 20, currentY - 20, 120, 120);
            G.DrawString(levels.getCurrentLevelTitle()+ " (lvl:" + (levels.currentLevel+1).ToString() + ")", normalFont, white, x + width - 120 - 20, currentY + 120);
            
            currentY += 40;

            
            G.DrawString("Coins : " + hero.coins, normalFont, white, textX, currentY);

            currentY += 35;

            string weapon = "Sword";

            if (hero.currentWeapon == 1) weapon = "Fireball";

            G.DrawString("Current Weapon : " + weapon, normalFont, white, textX, currentY);

            currentY += 35;


            G.DrawString("Sword Damage : " + hero.Weapons[0].damage, normalFont, white, textX, currentY);

            currentY += 35;

            if (hero.Weapons.Count > 1)
            {
                G.DrawString("Fireball Damage : " + hero.Weapons[1].damage, normalFont, white, textX, currentY);
                currentY += 35;
            }

            if (hero.isAbilityUnlocked == true)
                G.DrawString("Ability : Fire Blast", normalFont, white, textX, currentY);

            currentY += 35;

            G.DrawString("Ability Mana Cost : " + hero.abilityManaCost, normalFont, white, textX, currentY);

            currentY += 50;

            G.DrawString("Status : Alive", normalFont, Brushes.LightGreen, textX, currentY);

            int slotY = currentY + 50;
            int slotW = 70;
            int slotSpacing = 18;

            for (int i = 0; i < hero.Weapons.Count; i++)
            {
                int sx = x + 25 + (slotW + slotSpacing) * i;

                G.DrawImage(slot, sx, slotY, slotW, slotW);

                G.DrawImage(hero.Weapons[i].UIImage, sx + slotW / 2 - (slotW - 20) / 2, slotY + slotW / 2 - (slotW - 20) / 2, (slotW - 20), (slotW - 20));
            }

        }

        void drawControlsScreen(Graphics G, int x, int y, int width, int height, Font titleFont, Font normalFont, Font smallFont, SolidBrush white, SolidBrush gold)
        {
            G.DrawString("Controls", titleFont, gold, x + 20, y + 10);


            int textY = y + 100;
            G.DrawString("Display Enemy Ranges : P", smallFont, white, x + 70, textY);
            textY += 35;


            G.DrawString("AD / Arrows -> Move", smallFont, white, x + 70, textY);

            textY += 35;

            G.DrawString("LShift -> Run", smallFont, white, x + 70, textY);

            textY += 35;

            G.DrawString("Space/ W -> Jump", smallFont, white, x + 70, textY);

            textY += 35;

            G.DrawString("Left Click -> Attack", smallFont, white, x + 70, textY);

            textY += 35;

            G.DrawString("1 / 2  -> Weapons", smallFont, white, x + 70, textY);

            textY += 35;

            G.DrawString("E -> Ability", smallFont, white, x + 70, textY);
        }

        void drawCreditsScreen(Graphics G, int x, int y, int width, int height, Font titleFont, Font normalFont, SolidBrush white, SolidBrush gold)
        {
            G.DrawString("Credits", titleFont, gold, x + 20, y + 10);


            G.DrawString("Arcane", new Font("Comic Sans MS", 28, FontStyle.Bold), gold, x + 50, y + 110);

            G.DrawString("Developed By:", normalFont, white, x + 50, y + 190);

            G.DrawString("Kareem Ahmed Taha - 254914", normalFont, gold, x + 70, y + 250);

            G.DrawString("Mostafa Mohamed Saeed - 254595", normalFont, gold, x + 70, y + 300);

            Font smallFont = new Font("Comic Sans MS", 9, FontStyle.Italic);
            G.DrawString("Developed as part of the multimedia project at MSA University", smallFont, white, x + 70, y + 340);
        }

        void drawBar(Graphics G, string title, float value, float max, int x, int y, Brush backBrush, Brush fillBrush, Font smallFont)
        {
            G.DrawString(title, smallFont, Brushes.White, x, y);

            rectF back = new rectF(x + 80, y + 4, 220, 18);

            G.FillRectangle(backBrush, back.X, back.Y, back.Width, back.Height);

            float fillW = (220f * value / max);

            G.FillRectangle(fillBrush, back.X, back.Y, fillW, back.Height);

            G.DrawRectangle(Pens.Black, back.X, back.Y, back.Width, back.Height);

            G.DrawString(value.ToString() + " / " + max.ToString(), smallFont, Brushes.White, back.X + 70, back.Y - 2);
        }

        //Game setup
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

            while (heroColors.Count > 0)
            {
                heroColors.RemoveAt(0);
            }
        }

        void pauseGame()
        {
            timer.Stop();
            pauseBtns();
            drawDubb(this.CreateGraphics());
        }

        void resumeGame()
        {
            while (PauseBtns.Count > 0)
            {
                PauseBtns.RemoveAt(0);
            }

            timer.Start();
        }

        void startGameOverScreen()
        {
            gameOverScreenDelay = 0;
        }

        void manageGameOver()
        {
            hero.isDead = false;
            isGameOverScreenShown = false;
            hasStarted = false;
            while (GameOverBtns.Count > 0)
            {
                GameOverBtns.RemoveAt(0);
            }
            currGameOverBtn = 0;
            gameOverScreenDelay = 0;
            currentButton = 0;
            lastMenuScreen = 0;

            while (btns.Count > 0)
            {
                btns.RemoveAt(0);
            }
            while (menuImgs.Count > 0)
            {
                menuImgs.RemoveAt(0);
            }
            while (heroColors.Count > 0)
            {
                heroColors.RemoveAt(0);
            }
            while (clrBtns.Count > 0)
            {
                clrBtns.RemoveAt(0);
            }

            initMenu();
            initButtons();
            timer.Start();
            drawDubb(this.CreateGraphics());
        }

        void managePause()
        {
            if (currPauseBtn == 0)
            {
                isGamePaused = false;
                resumeGame();
            }
            else if (currPauseBtn == 1 && PauseBtns.Count == 3)
            {
                save.save(hero, enemyController.enemies , levels.currentLevel);
                PauseBtns.RemoveAt(1);
                drawDubb(this.CreateGraphics());

            }
            else if (currPauseBtn == 2 || (currPauseBtn == 1 && PauseBtns.Count == 2))
            {
                hasStarted = false;
                isGamePaused = false;


                initButtons();
                initMenu();
                timer.Start();
            }
        }

        void PauseScreen(Graphics g)
        {
            Font titleFont = new Font("Comic Sans MS", 22, FontStyle.Bold);
            Font normalFont = new Font("Comic Sans MS", 14, FontStyle.Bold);
            Font smallFont = new Font("Comic Sans MS", 11, FontStyle.Bold);

            SolidBrush white = new SolidBrush(Color.White);

            int X = this.ClientSize.Width / 2;
            int Y = 200;
            g.DrawString("Game is Paused", titleFont, white, X - 120, Y);

            for (int i = 0; i < PauseBtns.Count; i++)
            {
                bool isIt = false;

                if (i == currPauseBtn) isIt = true;

                Button btn = PauseBtns[i];

                btn.draw(button, g, normalFont, white, isIt);

            }
            if (PauseBtns.Count == 2)
            {
                int w = 300, h = 60;

                int ButtonsY = 70 + 200;
                int ButtonsX = (this.ClientSize.Width / 2) - w / 2;
                ButtonsY += (h + 20);

                g.DrawImage(button, ButtonsX, ButtonsY, w, h);

                string text = "Saved";
                int startX = ButtonsX + w / 2 - text.Length * 7;
                g.DrawString(text, normalFont, white, startX, ButtonsY + h / 2 - 22);
            }
        }

        void pauseBtns()
        {

            int w = 300, h = 60;

            int ButtonsY = 70 + 200;
            int ButtonsX = (this.ClientSize.Width / 2) - w / 2;

            Button btn = new Button(ButtonsX, ButtonsY, w, h, "Resume");
            PauseBtns.Add(btn);

            ButtonsY += (h + 20);
            btn = new Button(ButtonsX, ButtonsY, w, h, "Save Game");
            PauseBtns.Add(btn);

            ButtonsY += (h + 20);
            btn = new Button(ButtonsX, ButtonsY, w, h, "Main Menu");
            PauseBtns.Add(btn);

        }

        void gameOverBtns()
        {
            int w = 300, h = 60;

            int ButtonsY = 280;
            int ButtonsX = (this.ClientSize.Width / 2) - w / 2;

            Button btn = new Button(ButtonsX, ButtonsY, w, h, "Main Menu");
            GameOverBtns.Add(btn);
        }

        void GameOverScreen(Graphics g)
        {
            Font titleFont = new Font("Comic Sans MS", 28, FontStyle.Bold);
            Font normalFont = new Font("Comic Sans MS", 14, FontStyle.Bold);

            SolidBrush background = new SolidBrush(Color.FromArgb(0, 0, 0));
            g.FillRectangle(background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush red = new SolidBrush(Color.Red);

            int X = this.ClientSize.Width / 2;
            int Y = 100;
            string gameOverText = "GAME OVER";
            g.DrawString(gameOverText, titleFont, red, X - 120, Y);

            for (int i = 0; i < GameOverBtns.Count; i++)
            {
                bool isIt = false;

                if (i == currGameOverBtn) isIt = true;

                Button btn = GameOverBtns[i];

                btn.draw(button, g, normalFont, white, isIt);
            }
        }

        //Other functions 
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
        
        bool IsLeftMenu(int i)
        {
            if (i >= 0 && i <= 3) return true;

            return false;
        }


        void UpdateCamera()
        {
            camX = hero.R.X + hero.R.Width / 2 - this.ClientSize.Width / 2;
            float yOffset = this.ClientSize.Height * 0.20f;
            camY = hero.R.Y + hero.R.Height / 2f - this.ClientSize.Height / 2f + yOffset;

            if (camX < 0)
            {
                camX = 0;
            }

            if (camY < 0)
            {
                camY = 0;
            }

            float worldW = levels.levels[levels.currentLevel].worldWidth;
            float worldH = levels.levels[levels.currentLevel].worldHeight;

            float maxCamX = worldW - this.ClientSize.Width;
            float maxCamY = worldH - this.ClientSize.Height;

            if (maxCamX < 0)
            {
                maxCamX = 0;
            }

            if (maxCamY < 0)
            {
                maxCamY = 0;
            }

            if (camX > maxCamX)
            {
                camX = maxCamX;
            }

            if (camY > maxCamY)
            {
                camY = maxCamY;
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


            Animation heroBlue = new Animation();
            for(int i =1; i<= 6; i++)
            {
                string path = "characters/Hero/Blue/idle/left/" + i.ToString() + ".png";
                Bitmap frame = new Bitmap(path);
                heroBlue.frames.Add(frame);
            }
            heroColors.Add(heroBlue);

            rectF btn = new rectF(0, 0, 0, 0);
            clrBtns.Add(btn);
            btn = new rectF(0, 0, 0, 0);
            clrBtns.Add(btn);
            btn = new rectF(0, 0, 0, 0);
            clrBtns.Add(btn);
            btn = new rectF(0, 0, 0, 0);
            clrBtns.Add(btn);

            Animation heroGreen = new Animation();
            for (int i = 1; i <= 6; i++)
            {
                string path = "characters/Hero/green/idle/left/" + i.ToString() + ".png";
                Bitmap frame = new Bitmap(path);
                heroGreen.frames.Add(frame);
            }
            heroColors.Add(heroGreen);


            Animation heroPurple = new Animation();
            for (int i = 1; i <= 6; i++)
            {
                string path = "characters/Hero/purple/idle/left/" + i.ToString() + ".png";
                Bitmap frame = new Bitmap(path);
                heroPurple.frames.Add(frame);
            }
            heroColors.Add(heroPurple);


            Animation heroRed = new Animation();
            for (int i = 1; i <= 6; i++)
            {
                string path = "characters/Hero/red/idle/left/" + i.ToString() + ".png";
                Bitmap frame = new Bitmap(path);
                heroRed.frames.Add(frame);
            }
            heroColors.Add(heroRed);
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
            btn = new Button(ButtonsX, ButtonsY, w, h, "Controls");
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

                if (i != btns.Count - 1)
                {
                    btn.draw(button, G, f, bsh, isIt);
                }
            }

            Button startBtn = btns[btns.Count - 1];

            bool startSelected = false;

            if (currentButton == btns.Count - 1) startSelected = true;

            if (currentButton == 0 || currentButton == btns.Count - 1)
            {
                startBtn.draw(button, G, f, bsh, startSelected);
            }

            if (currentButton == 1)
            {
                if (IsSaveAvailable() == true)
                {
                    startBtn.draw(button, G, f, bsh, startSelected);
                }
            }

            loadScreen(G, borderX + 60, borderY + 160, borderW - (100), borderHeight - 60);
        }

        void loadScreen(Graphics G, int x, int y, int width, int height)
        {
            int screen = currentButton;

            if (currentButton == btns.Count - 1)
            {
                screen = lastMenuScreen;
            }

            Font titleFont = new Font("Comic Sans MS", 22, FontStyle.Bold);
            Font normalFont = new Font("Comic Sans MS", 14, FontStyle.Bold);
            Font smallFont = new Font("Comic Sans MS", 11, FontStyle.Bold);

            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush gold = new SolidBrush(Color.FromArgb(255, 220, 120));
            
            Bitmap slot = new Bitmap("ui/menu/slot.png");
            Bitmap selectedSlot = new Bitmap("ui/menu/slotSelected.png");

            Bitmap frameSelectA = new Bitmap("ui/menu/UI_TravelBook_FrameSelect01a.png");


            if (screen == 0)
            {
                drawNewGameScreen(G, x, y, width, height, titleFont, normalFont, smallFont, white, gold , slot , selectedSlot);
            }
            else if (screen == 1)
            {
                drawLoadGameScreen(G, x, y, width, height, titleFont, normalFont, smallFont, white, gold, frameSelectA, slot);
            }
            else if (screen == 2)
            {
                drawControlsScreen(G, x, y, width, height, titleFont, normalFont,smallFont, white, gold);
            }
            else if (screen == 3)
            {
                drawCreditsScreen(G, x, y, width, height, titleFont, normalFont, white, gold);
            }
        }
        
        bool IsSaveAvailable()
        {
            if(hero == null || hero.isDead == true)
            {
                return false;
            }

            return true;
        }

        void loadData()
        {

            load.loadLevel();
            levels.currentLevel = load.level;

            levels.initAll(this.ClientSize.Height);

            levels.loadLadders(ladders);
            levels.loadTiles(tiles);
            levels.loadEnemies(enemyController.enemies);
            levels.loadPlatforms(movingPlatforms);
            hero = load.load(hero, enemyController.enemies, this.ClientSize.Height);
        }    

        void startNewGame()
        {
            hero = new Hero(30, this.ClientSize.Height - 150 - 30, 150, 150, ChoiceIdx);

            levels.initAll(this.ClientSize.Height);

            levels.currentLevel = 0;
            levels.loadLadders(ladders);
            levels.loadTiles(tiles);
            levels.loadEnemies(enemyController.enemies);
            levels.loadPlatforms(movingPlatforms);

            hero.R.X = levels.getNewHeroX();
            hero.R.Y = levels.getNewHeroY();


        }

    }
}
    