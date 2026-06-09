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

        Font f = new Font("System", 8f, FontStyle.Bold);

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

        public void save(Hero hero, List<Enemy> Enemies, levelController levels, int level)
        {
            saveLvl(level);
            saveHero(hero);
            saveEnemies(Enemies, levels);

        }
        public void autoSave(Hero hero, List<Enemy> Enemies, levelController levels, int level, Graphics g, int clientHeight)
        {
            if (timer < 20)
            {
                string txt = "Saving";
                if (idx % 4 == 1)
                {
                    txt += ".";
                }
                else if (idx % 4 == 2)
                {
                    txt += "..";
                }
                else if (idx % 4 == 3)
                {
                    txt += "...";
                }
                g.DrawString(txt, f, bigoutline, 12, clientHeight - 50);
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
                save(hero, Enemies, levels, level);
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


            for(int i =0; i< hero.inventory.potions.Count; i++)
            {
                string potion = "potion_" + hero.inventory.potions[i].type + ":" + hero.inventory.potions[i].count.ToString();
                sw.WriteLine(potion);
            }
            sw.Close();
        }

        void saveEnemies(List<Enemy> enemies, levelController levels)
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

            sw.WriteLine("BossCount:" + levels.levels.Count.ToString());
            for (int i = 0; i < levels.levels.Count; i++)
            {
                level lvl = levels.levels[i];

                if (lvl.Boss != null)
                {
                    sw.WriteLine("Boss" + i + "_X:" + lvl.Boss.R.X.ToString());
                    sw.WriteLine("Boss" + i + "_Y:" + lvl.Boss.R.Y.ToString());
                    sw.WriteLine("Boss" + i + "_HP:" + lvl.Boss.HP.HP.ToString());
                    sw.WriteLine("Boss" + i + "_isDead:" + boolToText(lvl.Boss.isDead));
                    sw.WriteLine("Boss" + i + "_startFight:" + boolToText(lvl.Boss.startFight));
                }
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

        public Hero load(Hero hero, List<Enemy> enemies, int clientHeight, levelController levels)
        {


            hero = loadHero(hero, clientHeight);

            loadEnemies(enemies, levels);
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
                    if (line[0] == 'p' && line[1] == 'o' && line[2] == 't' && line[3] == 'i' && line[4] == 'o'
                        && line[5] == 'n')
                    {
                        string type = "";
                        int count = 0;

                        int countidx = -1;
                        for (int i = 7; i < line.Length; i++)
                        {
                            if (line[i] == ':')
                            {
                                countidx = i + 1;
                                break;
                            }

                            type += line[i];

                        }

                        string ct = "";
                        for (int i = countidx; i < line.Length; i++)
                        {
                            ct += line[i];
                        }
                        count = Convert.ToInt32(ct);

                        hero.inventory.addPotionNum(type, count);
                    }
                    else
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
            }

            if (hero != null && hero.mana.regenRate == 0f)
            {
                hero.mana.regenRate = 0.5f;
            }

            sr.Close();
            return hero;
        }

        void loadEnemies(List<Enemy> enemies, levelController levels)
        {
            StreamReader sr = new StreamReader("Saves/Enemies.txt");

            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();

                if (line != null)
                {
                    string[] data = splitLine(line);
                    string variable = data[0];
                    string val = data[1];

                    if (variable != "EnemiesCount")
                    {
                        bool isEnemyLine = false;
                        if (variable.Length >= 5)
                        {
                            if (variable[0] == 'E' && variable[1] == 'n' && variable[2] == 'e' && variable[3] == 'm' && variable[4] == 'y')
                            {
                                isEnemyLine = true;
                            }
                        }

                        if (isEnemyLine == true)
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

                            if (underscorePos != -1)
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
                        else
                        {
                            bool isBossLine = false;
                            if (variable.Length >= 4)
                            {
                                if (variable[0] == 'B' && variable[1] == 'o' && variable[2] == 's' && variable[3] == 's')
                                {
                                    isBossLine = true;
                                }
                            }

                            if (isBossLine == true)
                            {
                                int underscorePos = -1;
                                for (int i = 4; i < variable.Length; i++)
                                {
                                    if (variable[i] == '_')
                                    {
                                        underscorePos = i;
                                        break;
                                    }
                                }

                                if (underscorePos != -1)
                                {
                                    string numStr = "";
                                    for (int i = 4; i < underscorePos; i++)
                                    {
                                        numStr += variable[i];
                                    }

                                    string property = "";
                                    for (int i = underscorePos + 1; i < variable.Length; i++)
                                    {
                                        property += variable[i];
                                    }

                                    int levelIndex = changeToInt(numStr);
                                    if (levelIndex >= 0 && levelIndex < levels.levels.Count)
                                    {
                                        boss lvlBoss = levels.levels[levelIndex].Boss;
                                        if (lvlBoss != null)
                                        {
                                            if (property == "X")
                                            {
                                                lvlBoss.R.X = changeToInt(val);
                                            }
                                            else if (property == "Y")
                                            {
                                                lvlBoss.R.Y = changeToInt(val);
                                            }
                                            else if (property == "HP")
                                            {
                                                lvlBoss.HP.HP = changeToInt(val);
                                            }
                                            else if (property == "isDead")
                                            {
                                                lvlBoss.isDead = changeBool(val);
                                            }
                                            else if (property == "startFight")
                                            {
                                                lvlBoss.startFight = changeBool(val);
                                            }
                                        }
                                    }
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


        Font heroFont = new Font("System", 9f, FontStyle.Bold);
        Font manaFont = new Font("System", 8f, FontStyle.Bold);
        Font normalFont = new Font("System", 8f, FontStyle.Bold);

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
                MessageBox.Show("Animation not found " + name);
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

        public void setOffset(int offsetX , int offsetY)
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
        }
        public void draw(Graphics g, rectF ownerR, float camX, float camY)
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
        public List<Enemy> singleTargetsHit = new List<Enemy>();
        public bool singleBossHit = false;
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

                if (dirX == 1f)
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


        public void moveFireball(List<tile> tiles, List<Enemy> enemies, boss currentBoss)
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
            else if (dirY < 0) this.rect.Y -= speed;


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
                        en.takeHit(damage, strong);
                        if (isItSingle == false)
                        {
                            finished = true;
                            return;
                        }
                    }
                }

            }

            if (currentBoss != null)
            {
                if (currentBoss.isDead == false)
                {
                    if (rect.X < currentBoss.R.X + currentBoss.R.Width &&
                        rect.X + rect.Width > currentBoss.R.X &&
                        rect.Y < currentBoss.R.Y + currentBoss.R.Height &&
                        rect.Y + rect.Height > currentBoss.R.Y)
                    {
                        currentBoss.takeHit(damage, strong);
                        if (isItSingle == false)
                        {
                            finished = true;
                            return;
                        }
                    }
                }
            }
        }

        public void moveSingleFireball(List<tile> tiles, List<Enemy> enemies, boss currentBoss)
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
                            bool alreadyHit = false;
                            for (int h = 0; h < singleTargetsHit.Count; h++)
                            {
                                if (singleTargetsHit[h] == en)
                                {
                                    alreadyHit = true;
                                }
                            }

                            if (alreadyHit == false)
                            {
                                en.takeHit(damage);
                                singleTargetsHit.Add(en);
                            }
                        }
                    }
                }

                if (currentBoss != null)
                {
                    if (currentBoss.isDead == false)
                    {
                        if (rect.X < currentBoss.R.X + currentBoss.R.Width &&
                            rect.X + rect.Width > currentBoss.R.X &&
                            rect.Y < currentBoss.R.Y + currentBoss.R.Height &&
                            rect.Y + rect.Height > currentBoss.R.Y)
                        {
                            if (singleBossHit == false)
                            {
                                currentBoss.takeHit(damage);
                                singleBossHit = true;
                            }
                        }
                    }
                }
            }
        }

        public void draw(Graphics g, float camX, float camY)
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

    public class Kamehameha
    {
        public bool active = false;

        public char dir = 'r';

        public float startX = 0f;
        public float startY = 0f;

        public float currentLength = 0f;
        public float maxLength = 0f;

        public float beamHeight = 16f;

        public string state = "done";

        public bool isFiring = false;
        public bool contracting = false;

        public int chargeTimer = 0;
        public int chargeMax = 15;

        public float expandSpeed = 60f;
        public float contractSpeed = 12f;

        public int tickCount = 0;
        public int maxTicks = 10;

        public int tickTimer = 0;
        public int tickDelay = 10;

        public int tickDamage = 3;

        public float circleRadius = 0f;
        public float maxCircleRadius = 16f;

        public int colorIdx = 0;

        void reset()
        {
            active = false;
            isFiring = false;
            contracting = false;
            state = "done";
            chargeTimer = 0;
            currentLength = 0f;
            tickCount = 0;
            tickTimer = 0;
            circleRadius = 0f;
        }

        public void stop()
        {
            reset();
        }

        bool overlapsBeamBand(rectF target)
        {
            float beamTop = startY - beamHeight / 2f;
            float beamBottom = startY + beamHeight / 2f;

            if (beamTop < target.Y + target.Height)
            {
                if (beamBottom > target.Y)
                {
                    return true;
                }
            }

            return false;
        }

        float getCollisionLimit(List<tile> tiles)
        {
            float collisionLimit = 100000f;

            if (tiles != null)
            {
                for (int i = 0; i < tiles.Count; i++)
                {
                    tile t = tiles[i];

                    if (t.interact == true && t.jumpThrough == false)
                    {
                        if (overlapsBeamBand(t.R) == true)
                        {
                            float tileDistance = 0f;

                            if (dir == 'r')
                            {
                                tileDistance = t.R.X - startX;
                            }
                            else
                            {
                                tileDistance = startX - (t.R.X + t.R.Width);
                            }

                            if (tileDistance < 0f)
                            {
                                tileDistance = 0f;
                            }

                            if (tileDistance < collisionLimit)
                            {
                                collisionLimit = tileDistance;
                            }
                        }
                    }
                }
            }

            return collisionLimit;
        }

        Color getOuterColor()
        {
            Color result;

            if (colorIdx == 0)
            {
                result = Color.FromArgb(0, 200, 255);
            }
            else if (colorIdx == 1)
            {
                result = Color.FromArgb(0, 255, 0);
            }
            else if (colorIdx == 2)
            {
                result = Color.FromArgb(200, 0, 255);
            }
            else
            {
                result = Color.FromArgb(255, 50, 0);
            }

            return result;
        }

        Color getInnerColor()
        {
            if (colorIdx == 0) return Color.Cyan;

            if (colorIdx == 1) return Color.Lime;

            if (colorIdx == 2) return Color.Magenta;

            return Color.OrangeRed;
        }

        public void activate(float heroX, float heroY, char facing, float screenWidth, int heroColorIdx)
        {
            active = true;

            dir = facing;

            startX = heroX;
            startY = heroY;

            maxLength = screenWidth;
            currentLength = 0f;

            state = "charging";

            isFiring = false;
            contracting = false;

            chargeTimer = 0;

            tickCount = 0;
            tickTimer = 0;

            circleRadius = 0f;

            colorIdx = heroColorIdx;
        }

        public void startContracting()
        {
            contracting = true;
        }

        void dealDamage(List<Enemy> enemies, boss currentBoss)
        {
            rectF beamRect = getBeamRect();

            if (enemies != null)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy e = enemies[i];

                    if (e.isDead == false)
                    {
                        if (beamRect.X < e.R.X + e.R.Width &&
                            beamRect.X + beamRect.Width > e.R.X &&
                            beamRect.Y < e.R.Y + e.R.Height &&
                            beamRect.Y + beamRect.Height > e.R.Y)
                        {
                            e.takeHit(tickDamage);
                        }
                    }
                }
            }

            if (currentBoss != null)
            {
                if (currentBoss.isDead == false)
                {
                    if (beamRect.X < currentBoss.R.X + currentBoss.R.Width &&
                        beamRect.X + beamRect.Width > currentBoss.R.X &&
                        beamRect.Y < currentBoss.R.Y + currentBoss.R.Height &&
                        beamRect.Y + beamRect.Height > currentBoss.R.Y)
                    {
                        currentBoss.takeHit(tickDamage);
                    }
                }
            }
        }

        public void update(Hero hero, List<Enemy> enemies, boss currentBoss, List<tile> tiles, float camX, float screenWidth)
        {
            if (active == false) return;

            dir = hero.facing;

            if (dir == 'r')
            {
                startX = hero.R.X + hero.R.Width;
            }
            else
            {
                startX = hero.R.X;
            }

            startY = hero.R.Y + hero.R.Height * 0.4f;

            if (hero.mana.mana <= 0f)
            {
                stop();
                return;
            }

            if (state == "charging")
            {
                hero.mana.use(1);

                if (hero.mana.mana <= 0f)
                {
                    stop();
                    return;
                }

                chargeTimer++;

                circleRadius = maxCircleRadius * chargeTimer / chargeMax;

                if (chargeTimer >= chargeMax)
                {
                    state = "firing";
                    isFiring = true;
                }
            }
            else if (isFiring == true)
            {
                hero.mana.use(1);

                if (hero.mana.mana <= 0f)
                {
                    stop();
                    return;
                }

                float collisionLimit = getCollisionLimit(tiles);

                if (currentLength < collisionLimit)
                {
                    currentLength += expandSpeed;
                }

                if (currentLength > collisionLimit)
                {
                    currentLength = collisionLimit;
                }

                tickTimer++;

                if (tickTimer >= tickDelay)
                {
                    tickTimer = 0;

                    tickCount++;

                    dealDamage(enemies, currentBoss);
                }
            }
        }

        public rectF getBeamRect()
        {
            if (dir == 'r')
            {
                return new rectF(startX, startY - beamHeight / 2f, currentLength, beamHeight);
            }
            else
            {
                return new rectF(startX - currentLength, startY - beamHeight / 2f, currentLength, beamHeight);
            }
        }

        public void draw(Graphics g, float camX, float camY)
        {
            if (active == false) return;

            float cx = startX - camX;
            float cy = startY - camY;

            if (state == "charging")
            {
                Pen p = new Pen(getInnerColor(), 3);

                g.DrawEllipse(p, cx - circleRadius, cy - circleRadius, circleRadius * 2, circleRadius * 2);

                SolidBrush bsh = new SolidBrush(getOuterColor());

                g.FillEllipse(bsh, cx - circleRadius, cy - circleRadius, circleRadius * 2, circleRadius * 2);
            }

            if (isFiring == true)
            {
                rectF beam = getBeamRect();

                float bx = beam.X - camX;
                float by = beam.Y - camY;

                float midY = by + beamHeight / 2f;
                float endX = bx + beam.Width;

                Pen outerPen = new Pen(getOuterColor(), beamHeight + 6);

                g.DrawLine(outerPen, bx, midY, endX, midY);

                Pen mainPen = new Pen(Color.White, beamHeight - 4);

                g.DrawLine(mainPen, bx, midY, endX, midY);

                Pen innerPen = new Pen(getInnerColor(), beamHeight / 3f);

                g.DrawLine(innerPen, bx, midY, endX, midY);
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

        public void draw(Graphics g, bool showRange, float camX, float camY)
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

    public class PotionStack
    {
        public string type;
        public int count;
        public PotionStack(string t, int c) { type = t; count = c; }
    }

    public class Inventory
    {
        

        public List<PotionStack> potions = new List<PotionStack>();

        public int getPotionCount(string type)
        {
            for (int i = 0; i < potions.Count; i++)
                if (potions[i].type == type) return potions[i].count;
            return 0;
        }

        public void addPotion(string type)
        {
            for (int i = 0; i < potions.Count; i++)
            {
                if (potions[i].type == type)
                {
                    potions[i].count++;
                    return;
                }
            }
            potions.Add(new PotionStack(type, 1));
        }


        public void addPotionNum(string type , int num)
        {
            for (int i = 0; i < potions.Count; i++)
            {
                if (potions[i].type == type)
                {
                    potions[i].count += num;
                    return;
                }
            }
            potions.Add(new PotionStack(type, num));
        }
        public void removePotion(string type)
        {
            for (int i = 0; i < potions.Count; i++)
            {
                if (potions[i].type == type)
                {
                    potions[i].count--;
                    if (potions[i].count <= 0) potions.RemoveAt(i);
                    return;
                }
            }
        }

        public Bitmap getPotionImage(string type)
        {
            if (type == "health") return potionImages[0];
            if (type == "mana") return potionImages[1];
            if (type == "golden") return potionImages[2];
            if (type == "suspicious") return potionImages[3];
            if (type == "largeHealth") return potionImages[4];
            if (type == "largeMana") return potionImages[5];
            return null;
        }

        public bool isOpen = false;
        public Bitmap[] panelImages;
        public Bitmap slotImg;
        public Bitmap slotSelectedImg;
        public Bitmap[] potionImages;
        public int[] quickSlotIndices = { -1, -1, -1, -1 };
        public int hoveredCol = -1;
        public int hoveredRow = -1;
        public float[] cellCX = { 14f, 41.5f, 58.5f, 75.5f, 93f };
        public float[] cellCY = { 14f, 31f, 48f, 65f, 93f };
        public float slotRenderSize = 40f;

        public void loadImages()
        {
            panelImages = new Bitmap[4];
            panelImages[0] = new Bitmap("ui/Inventory/BLUE.png");
            panelImages[1] = new Bitmap("ui/Inventory/GREEN.png");
            panelImages[2] = new Bitmap("ui/Inventory/PURPLE.png");
            panelImages[3] = new Bitmap("ui/Inventory/RED.png");
            slotImg = new Bitmap("ui/menu/slot.png");
            slotSelectedImg = new Bitmap("ui/menu/slotSelected.png");

            potionImages = new Bitmap[6];
            potionImages[0] = new Bitmap("Collectables/Potions/S_HP.png");
            potionImages[1] = new Bitmap("Collectables/Potions/S-MP.png");
            potionImages[2] = new Bitmap("Collectables/Potions/GoldenP.png");
            potionImages[3] = new Bitmap("Collectables/Potions/Suspiciousp.png");
            potionImages[4] = new Bitmap("Collectables/Potions/L-HP.png");
            potionImages[5] = new Bitmap("Collectables/Potions/L-MP.png");
        }

        public void updateHover(int mx, int my, Hero h, Form1 f)
        {
            hoveredCol = -1;
            hoveredRow = -1;
            float panX = f.getPanX();
            float panY = f.getPanY();
            for (int col = 0; col < 5; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    float sx = panX + cellCX[col] * 3f - slotRenderSize / 2f;
                    float sy = panY + cellCY[row] * 3f - slotRenderSize / 2f;
                    if (mx >= sx && mx <= sx + slotRenderSize && my >= sy && my <= sy + slotRenderSize)
                    {
                        hoveredCol = col;
                        hoveredRow = row;
                        return;
                    }
                }
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
        Animation healAnimation;
        Animation freezeAnimation;
        Animation blessedAnimation;
        Animation poisonBubbleAnimation;
        public int coins = 0;
        public float goldenEffectTimer = 0f;

        public AnimationController anim = new AnimationController();

        public Health HP = new Health(100, 100);
        public Mana mana = new Mana(100, 100);
        public Inventory inventory = new Inventory();
        public UIEntity UI = new UIEntity(20f, 20f, 236f, 26f, true, true);


        public List<vfx> vfxes = new List<vfx>();


        public bool isAttacking = false;
        public bool attackHasHit = false;
        public bool isCriticalAttack = false;

        public int attackHitFrame = 4; //first 4 frames in teh attack animation are normal
        public int attackComboExtraFrames = 2; // last 2 frames are extra whgen there is a combo
        public int criticalStrikeChancePercent = 15;
        public int criticalDamageMultiplierPercent = 175;
        public float attackMoveMultiplier = 0.55f;

        public char facing = 'r';

        public float attackRange = 80f;
        public float attackHeightScale = 1.2f;

        public List<Weapon> Weapons = new List<Weapon>();

        public int currentWeapon = 0;


        public List<Fireball> fireballs = new List<Fireball>();
        public Kamehameha kamehameha = new Kamehameha();
        public Random rnd = new Random();

        public bool isSpellCasting = false;
        public bool isShooting = false;
        public bool spellCastPaused = false;

        public float fireballManaCost = 7f;

        public int fireballSpawnDelay = 5;
        public int fireballSpawnTimer = 5;

        public float mouseX = 0f;
        public float mouseY = 0f;

        public bool isCastingAbility = false;
        public bool abilityFireballSpawned = false;
        public float abilityManaCost = 20f;
        public bool abilityKeyDown = false;
        public bool isDead = false;
        public int abilityCastTimer = 0;
        public int abilityCastTimeout = 180;

        public bool isLaserCasting = false;
        public bool isLaserCastFinishing = false;

        public bool isAbilityUnlocked = true;

        public bool isClimbing = false;
        public float climbSpeed = 8f;
        public char climbDir = ' ';
        public bool isClimbingMoving = false;
        public bool isDoingCombo = false;


        public bool isShielding = false;
        public bool shieldKeyHeld = false;
        public int shieldAnimFrame = 0; 
        public Animation shieldEffectAnimation;


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
                fireballs[i].draw(g, camX, camY);

                if (showRanges)
                {
                    Pen fbPen = new Pen(Color.Red, 1);
                    g.DrawRectangle(fbPen, fireballs[i].rect.X - camX, fireballs[i].rect.Y - camY, fireballs[i].rect.Width, fireballs[i].rect.Height);
                }
            }

            Bitmap frame;
            if (isShielding && anim.getCurrentAnimation().name == "shield_defence")
            {
                bool dirFacingL = false;
                if (facing == 'l') dirFacingL = true;
                
                Animation shieldAnim = anim.getCurrentAnimation();
                
                List<Bitmap> shieldFrames = shieldAnim.getFrames(dirFacingL);
                
                int lastFrame = shieldFrames.Count - 1;

                if (anim.currIdx >= lastFrame)
                {
                    frame = anim.playCurrentFrame(dirFacingL, true);
                }
                else
                {
                    frame = anim.playFrame(dirFacingL, true);
                }
            }
            else if (isLaserCasting)
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
            else if (isLaserCastFinishing)
            {
                if (facing == 'l')
                    frame = anim.playFrameOnce(true, true);
                else
                    frame = anim.playFrameOnce(false, true);
            }
            else if (isDead || isLanding || (isClimbing && !isClimbingMoving))
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

            if (goldenEffectTimer > 0)
            {
                goldenEffectTimer -= 1f;
                if (goldenEffectTimer <= 0)
                {
                    for (int i = vfxes.Count - 1; i >= 0; i--)
                    {
                        if (vfxes[i].name == "goldenEffect")
                        {
                            vfxes[i].finished = true;
                        }
                    }
                }
            }

            for (int i = vfxes.Count - 1; i >= 0; i--)
            {
                vfxes[i].draw(g, R, camX, camY);

                if (vfxes[i].finished)
                {
                    vfxes.RemoveAt(i);
                }
            }

            kamehameha.draw(g, camX, camY);

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

            healAnimation = new Animation();
            healAnimation.name = "heal";
            healAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {

                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/HealEffect/Frames/HealEffect_0" + i + ".png");
                else frame = new Bitmap("vfx/HealEffect/Frames/HealEffect_" + i + ".png");

                healAnimation.addFrame(frame, false, false);
            }

            shieldEffectAnimation = new Animation();
            shieldEffectAnimation.name = "shieldEffect";
            shieldEffectAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {
                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/ShieldEffect/Frames/ShieldEffect_0" + i + ".png");
                else frame = new Bitmap("vfx/ShieldEffect/Frames/ShieldEffect_" + i + ".png");

                shieldEffectAnimation.addFrame(frame, false, false);
            }

            freezeAnimation = new Animation();
            freezeAnimation.name = "freeze";
            freezeAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {
                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/FreezeEffect/Frames/FreezeEffect_0" + i + ".png");
                else frame = new Bitmap("vfx/FreezeEffect/Frames/FreezeEffect_" + i + ".png");
                freezeAnimation.addFrame(frame, false, false);
            }

            blessedAnimation = new Animation();
            blessedAnimation.name = "blessed";
            blessedAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {
                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/BlessedEffect/Frames/BlessedEffect_0" + i + ".png");
                else frame = new Bitmap("vfx/BlessedEffect/Frames/BlessedEffect_" + i + ".png");
                blessedAnimation.addFrame(frame, false, false);
            }

            poisonBubbleAnimation = new Animation();
            poisonBubbleAnimation.name = "poisonBubble";
            poisonBubbleAnimation.frameDelay = 0;

            for (int i = 0; i <= 15; i++)
            {
                Bitmap frame;
                if (i < 10) frame = new Bitmap("vfx/PoisonBubble/Frames/PoisonBubble_0" + i + ".png");
                else frame = new Bitmap("vfx/PoisonBubble/Frames/PoisonBubble_" + i + ".png");
                poisonBubbleAnimation.addFrame(frame, false, false);
            }
        }

        public void startShield()
        {
            if (isDead) return;
            if (isTakingDamage) return;
            if (isClimbing || isClimbingMoving) return;

            isAttacking = false;
            attackHasHit = false;
            isDoingCombo = false;
            isShooting = false;
            isCastingAbility = false;
            abilityFireballSpawned = false;
            stopLaserCast();

            shieldKeyHeld = true;

            if (!isShielding)
            {
                isShielding = true;
                createShieldVFX();
                anim.changeAnimation("shield_defence", -1);
                anim.restart();
                anim.currIdx = 0;
            }
        }

        public void stopShield()
        {
            shieldKeyHeld = false;
            isShielding = false;

            for (int i = vfxes.Count - 1; i >= 0; i--)
            {
                if (vfxes[i].name == "shieldEffect")
                {
                    vfxes.RemoveAt(i);
                }
            }
        }

        void createShieldVFX()
        {
            for (int i = vfxes.Count - 1; i >= 0; i--)
            {
                if (vfxes[i].name == "shieldEffect")
                    vfxes.RemoveAt(i);
            }

            vfx fx = new vfx();
            fx.name = "shieldEffect";
            fx.repeat = true;
            fx.anim.addAnim(shieldEffectAnimation);
            fx.anim.changeAnimation("shieldEffect", -1);

            fx.rect.Width = drawR.Width;
            fx.rect.Height = drawR.Height;
            fx.setOffset(0, 30);
            fx.followPlayer = true;

            vfxes.Add(fx);
        }

        public void updateShield()
        {
            if (!isShielding) return;

            isAttacking = false;
            isShooting = false;
            isCastingAbility = false;

            if (anim.getCurrentAnimation().name != "shield_defence")
            {
                anim.changeAnimation("shield_defence", -1);
                anim.restart();
                return;
            }

            Animation shieldAnim = anim.getCurrentAnimation();
            if (shieldAnim == null) return;

            bool dirFacingL = false;
            if (facing == 'l') dirFacingL = true;

            List<Bitmap> frames = shieldAnim.getFrames(dirFacingL);
            int lastFrame = frames.Count - 1;

            if (anim.currIdx >= lastFrame)
            {
                anim.currIdx = lastFrame;
                anim.frameDelayCount = 0;
            }
        }

        public int applyShieldDamage(int rawDamage)
        {
            if (!isShielding) return rawDamage;

            int perfectBlockRoll = rnd.Next(0, 100);
            if (perfectBlockRoll < 10)
            {
                return 0;
            }

            int blockPercent = rnd.Next(60, 99);
            int blocked = (rawDamage * blockPercent) / 100;
            int remaining = rawDamage - blocked;
            return remaining;
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

        public void collectDroppedPotions(List<DroppedPotion> droppedPotions)
        {
            for (int i = 0; i < droppedPotions.Count; i++)
            {
                DroppedPotion potion = droppedPotions[i];

                if (R.X < potion.R.X + potion.R.Width &&
                    R.X + R.Width > potion.R.X &&
                    R.Y < potion.R.Y + potion.R.Height &&
                    R.Y + R.Height > potion.R.Y)
                {
                    if (potion.potionType == "health" || potion.potionType == "mana" || potion.potionType == "golden" || potion.potionType == "suspicious" || potion.potionType == "largeHealth" || potion.potionType == "largeMana")
                    {
                        inventory.addPotion(potion.potionType);
                        droppedPotions.RemoveAt(i);
                    }
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

            if (isLaserCasting)
            {
                if (kamehameha.active == false)
                {
                    isLaserCasting = false;
                    isLaserCastFinishing = true;
                    if (anim.currIdx < 2)
                    {
                        anim.currIdx = 4;
                        anim.frameDelayCount = 0;
                    }
                    anim.changeAnimation("spell_cast", -1);
                    return;
                }

                anim.changeAnimation("spell_cast", -1);

                if (anim.currIdx < 2)
                {
                    anim.currIdx = 2;
                    anim.frameDelayCount = 0;
                }
                else if (anim.currIdx > 4)
                {
                    anim.currIdx = 2;
                    anim.frameDelayCount = 0;
                }

                return;
            }

            if (isLaserCastFinishing)
            {
                anim.changeAnimation("spell_cast", -1);

                Animation laserAnim = anim.getCurrentAnimation();
                if (laserAnim != null)
                {
                    bool dirFacingL = false;
                    if (facing == 'l')
                    {
                        dirFacingL = true;
                    }

                    List<Bitmap> laserFrames = laserAnim.getFrames(dirFacingL);
                    if (laserFrames.Count > 0 && anim.currIdx >= laserFrames.Count - 1)
                    {
                        isLaserCastFinishing = false;
                    }
                }

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

            if (isShielding)
            {
                updateShield();
                return;
            }

            if (isAttacking == true)
            {
                if (isCriticalAttack)
                {
                    anim.changeAnimation("critical_attack", -1);
                }
                else
                {
                    anim.changeAnimation("attack", -1);
                }
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


            if (isShielding)
            {
                amount = applyShieldDamage(amount);
                if (amount <= 0) return;
            }

            if (goldenEffectTimer > 0) amount = amount / 2;

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

        void forceStopAbilityCast()
        {
            isCastingAbility = false;
            abilityFireballSpawned = false;
            abilityCastTimer = 0;
            isLanding = false;
            wasGrounded = isGrounded;
            ySpeed = 0;
            isGrounded = true;
            updateAnimation();
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
            abilityCastTimer = 0;
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
            abilityCastTimer++;

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
                if (facing == 'l') dirFacingL = true;
                List<Bitmap> spellFrames = spellAnim.getFrames(dirFacingL);

                if (spellFrames.Count > 0)
                {
                    if (anim.currIdx >= spellFrames.Count - 1)
                    {
                        forceStopAbilityCast();
                    }
                }
                else
                {
                    if (abilityCastTimer >= abilityCastTimeout)
                    {
                        forceStopAbilityCast();
                    }
                }
            }
            else
            {
                if (abilityCastTimer >= abilityCastTimeout)
                {
                    forceStopAbilityCast();
                }
            }

            if (abilityCastTimer >= abilityCastTimeout)
            {
                forceStopAbilityCast();
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


        public void heal(int amount)
        {
            HP.heal(amount);
            createHealVFX();
        }
        void createHealVFX()
        {
            vfx fx = new vfx();

            fx.name = "heal";
            fx.anim.addAnim(healAnimation);
            fx.anim.changeAnimation("heal", -1);


            fx.rect.Width = drawR.Width;
            fx.rect.Height =drawR.Height;

            fx.setOffset(0, 30);

            fx.followPlayer = true;


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

            if (isDead)
            {
                return;
            }

            if (isCastingAbility)
            {
                if (abilityCastTimer >= abilityCastTimeout)
                {
                    forceStopAbilityCast();
                }
                else
                {
                    return;
                }
            }

            if (currentWeapon == 0)
            {
                swordLogic();
            }
            else if (currentWeapon == 1)
            {
                if (isAttacking)
                {
                    isAttacking = false;
                    attackHasHit = false;
                    isDoingCombo = false;
                }

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

        public void stopLaserCast()
        {
            isLaserCasting = false;
            isLaserCastFinishing = false;
            kamehameha.stop();
        }

        public void updateFireballCast(List<Enemy> enemies, boss currentBoss, List<tile> tiles)
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
                    fireballs[i].moveSingleFireball(tiles, enemies, currentBoss);
                else
                    fireballs[i].moveFireball(tiles, enemies, currentBoss);

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
                if (isCriticalAttack == false)
                {
                    isDoingCombo = true;
                }
                return;
            }

            isAttacking = true;
            attackHasHit = false;
            isDoingCombo = false;
            isCriticalAttack = false;
            isRunning = false;

            int critRoll = rnd.Next(0, 100);
            if (critRoll < criticalStrikeChancePercent)
            {
                isCriticalAttack = true;
                anim.changeAnimation("critical_attack", -1);
            }
            else
            {
                anim.changeAnimation("attack", -1);
            }

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

        public void updateAttack(List<Enemy> enemies, boss currentBoss)
        {
            if (isAttacking == false) return;

            if (isCriticalAttack)
            {
                anim.changeAnimation("critical_attack", -1);
            }
            else
            {
                anim.changeAnimation("attack", -1);
            }

            Animation attackAnim = anim.getCurrentAnimation();
            if (attackAnim == null) return;

            bool dirFacingL = false;
            if (facing == 'l') dirFacingL = true;
            List<Bitmap> attackFrames = attackAnim.getFrames(dirFacingL);

            int usableFrames = attackFrames.Count - attackComboExtraFrames;

            if (isCriticalAttack)
            {
                isDoingCombo = false;
                usableFrames = attackFrames.Count;
            }
            else if (isDoingCombo)
            {
                usableFrames = attackFrames.Count;
            }

            if (usableFrames <= 0)
            {
                usableFrames = attackFrames.Count;
            }

            if (anim.currIdx >= usableFrames - 1)
            {
                isAttacking = false;
                attackHasHit = false;
                isDoingCombo = false;
                isCriticalAttack = false;

                updateAnimation();
                return;
            }

            if (attackHasHit == false && anim.currIdx >= attackHitFrame - 1)
            {
                rectF hitBox = getAttackHitBox();
                int attackDamage = Weapons[currentWeapon].damage;
                if (goldenEffectTimer > 0) attackDamage = (attackDamage * 150) / 100;

                if (isDoingCombo)
                {
                    attackDamage = ( attackDamage * 125 ) / 100;
                }
                else if (isCriticalAttack)
                {
                    int criticalScaledDamage = attackDamage * criticalDamageMultiplierPercent;
                    attackDamage = criticalScaledDamage / 100;

                    if (criticalScaledDamage % 100 != 0)
                    {
                        attackDamage++;
                    }
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy en = enemies[i];

                    if (en.isDead == false)
                    {
                        if (hitBox.X <= en.R.X + en.R.Width && hitBox.X + hitBox.Width >= en.R.X &&
                            hitBox.Y <= en.R.Y + en.R.Height && hitBox.Y + hitBox.Height >= en.R.Y)
                        {
                            en.takeHit(attackDamage, isCriticalAttack);
                            // break;
                        }

                    }
                }

                if (currentBoss != null)
                {
                    if (currentBoss.isDead == false)
                    {
                        if (hitBox.X <= currentBoss.R.X + currentBoss.R.Width && hitBox.X + hitBox.Width >= currentBoss.R.X &&
                            hitBox.Y <= currentBoss.R.Y + currentBoss.R.Height && hitBox.Y + hitBox.Height >= currentBoss.R.Y)
                        {
                            currentBoss.takeHit(attackDamage, isCriticalAttack);
                        }
                    }
                }

                attackHasHit = true;
            }
        }

        //movement
        public void move(List<tile> tiles, List<Ladder> ladders, int width, List<MovingPlatform> movingPlatforms)
        {
            if (isDead == true)
            {
                moving = ' ';
                isAttacking = false;
                isShooting = false;
                isCastingAbility = false;

                Movement(tiles, ladders, movingPlatforms);
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

                Movement(tiles, ladders, movingPlatforms);
                updateAnimation();
                return;
            }
            if (kamehameha.active == true && kamehameha.contracting == false)
            {
                moving = ' ';
                isAttacking = false;
                isShooting = false;
                isCastingAbility = false;
                Movement(tiles, ladders, movingPlatforms);
                updateAnimation();
                return;
            }
            float moveSpeed = speed;
            if (goldenEffectTimer > 0) moveSpeed *= 1.3f;

            if (isShielding)
            {moveSpeed = 0;
            }

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


            if (R.X + xMove < 0)
            {
                R.X = 0;
            }
            if (R.X + R.Width + xMove > width)
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

            Movement(tiles, ladders, movingPlatforms);

            if (!isAttacking && !isAttacking)
                updateAnimation();
        }

        public void Movement(List<tile> tiles, List<Ladder> ladders, List<MovingPlatform> movingPlatforms)
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
                                    float prevBot = prevY + R.Height;

                                    if (prevBot > tileToCheck.R.Y && prevTop < tileToCheck.R.Y + tileToCheck.R.Height)
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
                    R.X < trav.rect.X + trav.rect.Width - 20 &&
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
                    R.X < trav.rect.X + trav.rect.Width - 20 &&
                    R.Y + R.Height >= trav.rect.Y - 2 &&
                    R.Y + R.Height <= trav.rect.Y + 5)
                {
                    if (R.Y + R.Height >= trav.rect.Y)
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
            if (isShielding) return;

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
                if (goldenEffectTimer > 0)
                    ySpeed = jumpPower * 1.2f;
                else
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
                    if (goldenEffectTimer > 0)
                        ySpeed = doubleJumpPower * 1.4f;
                    else
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

        public void restoreHealth(int amount)
        {
            HP.HP += amount;
            if (HP.HP > HP.maxHP) HP.HP = HP.maxHP;
            vfx fx = new vfx();
            fx.name = "healEffect";
            fx.repeat = false;
            fx.anim.addAnim(healAnimation);
            fx.anim.changeAnimation("heal", -1);
            fx.rect.Width = drawR.Width;
            fx.rect.Height = drawR.Height;
            fx.setOffset(0, 30);
            fx.followPlayer = true;
            vfxes.Add(fx);
        }

        public void restoreMana(int amount)
        {
            mana.mana += amount;
            if (mana.mana > mana.maxMana) mana.mana = mana.maxMana;
            vfx fx = new vfx();
            fx.name = "freezeEffect";
            fx.repeat = false;
            fx.anim.addAnim(freezeAnimation);
            fx.anim.changeAnimation("freeze", -1);
            fx.rect.Width = drawR.Width;
            fx.rect.Height = drawR.Height;
            fx.setOffset(0, 30);
            fx.followPlayer = true;
            vfxes.Add(fx);
        }

        public void useGoldenPotion()
        {
            goldenEffectTimer = rnd.Next(1200, 2401);
            vfx fx = new vfx();
            fx.name = "goldenEffect";
            fx.repeat = true;
            fx.anim.addAnim(blessedAnimation);
            fx.anim.changeAnimation("blessed", -1);
            fx.rect.Width = drawR.Width;
            fx.rect.Height = drawR.Height;
            fx.setOffset(0, 30);
            fx.followPlayer = true;
            vfxes.Add(fx);
        }

        public void useSuspiciousPotion()
        {
            HP.HP -= 20;
            if (HP.HP < 0) HP.HP = 0;
            vfx fx = new vfx();
            fx.name = "poisonBubble";
            fx.repeat = false;
            fx.anim.addAnim(poisonBubbleAnimation);
            fx.anim.changeAnimation("poisonBubble", -1);
            fx.rect.Width = drawR.Width;
            fx.rect.Height = drawR.Height;
            fx.setOffset(0, 30);
            fx.followPlayer = true;
            vfxes.Add(fx);
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

        public DroppedCoin(float x, float y, string type, int val)
        {
            string drawType = type;

            if (type == "copper")
            {
                if (val >= 1000)
                {
                    drawType = "gold";
                }
                else if (val >= 100)
                {
                    drawType = "silver";
                }
            }

            cointype = drawType;

            if (type == "gold")
            {
                coinvalue = val * 1000;
            }
            else if (type == "silver")
            {
                coinvalue = val * 100;
            }
            else
            {
                coinvalue = val;
            }

            R.X = x;
            R.Y = y;
            R.Width = 25;
            R.Height = 25;

            if (drawType == "copper")
            {
                for (int i = 1; i <= 7; i++)
                {
                    Bitmap img = new Bitmap("Collectables/Coins/Bronze/" + i.ToString() + ".png");
                    frames.Add(img);
                }
            }
            else if (drawType == "silver")
            {
                for (int i = 1; i <= 7; i++)
                {
                    Bitmap img = new Bitmap("Collectables/Coins/Silver/" + i.ToString() + ".png");
                    frames.Add(img);
                }
            }
            else if (drawType == "gold")
            {
                for (int i = 1; i <= 7; i++)
                {
                    Bitmap img = new Bitmap("Collectables/Coins/Gold/" + i.ToString() + ".png");
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

        public bool isOutOfMap(float worldWidth, float worldHeight)
        {
            if (R.X + R.Width < 0f)
            {
                return true;
            }

            if (R.X > worldWidth)
            {
                return true;
            }

            if (R.Y + R.Height < 0f)
            {
                return true;
            }

            if (R.Y > worldHeight)
            {
                return true;
            }

            return false;
        }

        public void draw(Graphics g, float camX, float camY)
        {
            if (frames.Count == 0)
            {
                return;
            }

            g.DrawImage(frames[currFrame], R.X - camX, R.Y - camY, R.Width, R.Height);

            updateAnimation();
        }
    }

    public class DroppedPotion
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
        public string potionType = "";

        public DroppedPotion(string type, float x, float y)
        {
            potionType = type;
            R.X = x;
            R.Y = y;
            R.Width = 24;
            R.Height = 24;

            string file = "";
            if (type == "health") file = "Collectables/Potions/S_HP.png";
            else if (type == "mana") file = "Collectables/Potions/S-MP.png";
            else if (type == "golden") file = "Collectables/Potions/GoldenP.png";
            else if (type == "suspicious") file = "Collectables/Potions/Suspiciousp.png";
            else if (type == "largeHealth") file = "Collectables/Potions/L-HP.png";
            else if (type == "largeMana") file = "Collectables/Potions/L-MP.png";

            if (System.IO.File.Exists(file))
            {
                frames.Add(new Bitmap(file));
            }
        }

        public void update(List<tile> tiles)
        {
            prevBottom = R.Y + R.Height;
            velocityY += gravity;
            if (velocityY > maxFallSpeed) velocityY = maxFallSpeed;

            R.Y += velocityY;

            for (int i = 0; i < tiles.Count; i++)
            {
                tile t = tiles[i];
                if (t.R.X + t.R.Width > R.X && t.R.X < R.X + R.Width)
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
                        bool overlappingY = R.Y + R.Height > t.R.Y && R.Y < t.R.Y + t.R.Height;
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

        public bool isOutOfMap(float worldWidth, float worldHeight)
        {
            return R.X + R.Width < 0f || R.X > worldWidth || R.Y + R.Height < 0f || R.Y > worldHeight;
        }

        public void draw(Graphics g, float camX, float camY)
        {
            if (frames.Count == 0) return;
            g.DrawImage(frames[currFrame], R.X - camX, R.Y - camY, R.Width, R.Height);
            frameDelayCount++;
            if (frameDelayCount >= frameDelay)
            {
                frameDelayCount = 0;
                currFrame++;
                if (currFrame >= frames.Count) currFrame = 0;
            }
        }
    }

    public class MagicianCharge
    {
        public rectF r = new rectF();
        public rectF drawR = new rectF();
        public char dir;

        public string type = "";
        public int speed = 16;
        public int damage = 20;
        public Animation anim = new Animation();
        public int AnimIdx = 0;
        public bool didHit = false;
        public bool hasFinished = false;

        public int travelledDist = 0;
        public int maxDist = 2000;

        int endRepeatIdx = 4; //index to stop repeating animation of moving
        int startRepeatIdx = 0;

        public bool hasLeft = false;
        public MagicianCharge(float x , float y , string type , char direction )
        {
            dir = direction;
            this.type = type;
            r.X = x;
            r.Width = 50;
            r.Height = 50;
            r.Y = y;

            if (type == "arrow")
            {
                string direc = "right";
                if (direction == 'l') direc = "left";

                damage = 15;
                speed = 40;
                for(int i =1; i<= 6; i++)
                {
                    string path = "Characters/Enemies/Magician/Charge_2/" + direc + "/Charge_2_" + i.ToString() + ".png";
                    anim.addFrame(new Bitmap(path) , false , false);
                }
            }
            else if(type == "sphere")
            {
                string direc = "right";
                if (direction == 'l') direc = "left";

                damage = 30;
                speed = 25;
                for (int i = 1; i <= 9; i++)
                {
                    string path = "Characters/Enemies/Magician/Charge_1/" + direc + "/Charge_1_" + i.ToString() + ".png";
                    anim.addFrame(new Bitmap(path), false, false);

                }
            }
        }

        public void moveCharge(Hero hero, List<tile> tiles)
        {
            if (didHit == true) return;

            if (dir == 'r')
            {
                this.r.X += speed;
            }
            else
            {
                this.r.X -= speed;
            }

            travelledDist += speed;

            if (travelledDist >= maxDist)
            {
                didHit = true;
                return;
            }

            if (travelledDist > 60)
            {
                hasLeft = true;
            }

            if (r.X < hero.R.X + hero.R.Width)
            {
                if (r.X + r.Width > hero.R.X)
                {
                    if (r.Y < hero.R.Y + hero.R.Height)
                    {
                        if (r.Y + r.Height > hero.R.Y)
                        {
                            hero.takeDamage(damage);
                            didHit = true;
                            return;
                        }
                    }
                }
            }

            if (hasLeft == true)
            {
                for (int t = 0; t < tiles.Count; t++)
                {
                    tile tl = tiles[t];

                    if (tl.interact == true)
                    {
                        if (tl.jumpThrough == false)
                        {
                            if (r.X < tl.R.X + tl.R.Width)
                            {
                                if (r.X + r.Width > tl.R.X)
                                {
                                    if (r.Y < tl.R.Y + tl.R.Height)
                                    {
                                        if (r.Y + r.Height > tl.R.Y)
                                        {
                                            didHit = true;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        public void updateDrawR()
        {
            drawR.Width = 68 * 2;
            drawR.Height = 128 * 2;
            drawR.X = r.X - (drawR.Width / 2) + (r.Width / 2);
            drawR.Y = r.Y - (drawR.Height / 2) + (r.Height / 2) ;
        }
        public void draw(Graphics g , bool showRange , float camX , float camY)
        {
            updateDrawR();

            if (showRange == true)
            {
                Pen pn = new Pen(Color.DarkMagenta, 2);
                g.DrawRectangle(pn, r.X - camX, r.Y - camY, r.Width, r.Height);
            }

            if (hasFinished == false)
            {
                Bitmap frame = anim.frames[AnimIdx];

                if (didHit == false)
                {
                    if (type == "arrow")
                    {
                        AnimIdx++;
                        if (AnimIdx == anim.frames.Count)
                        {
                            AnimIdx = 1;
                        }
                    }
                    if (type == "sphere")
                    {
                        AnimIdx++;
                        if (AnimIdx == endRepeatIdx + 1)
                        {
                            AnimIdx = startRepeatIdx;
                        }
                    }
                }
                else
                {
                    if (type == "arrow")
                    {
                        hasFinished = true;
                    }
                    if (type == "sphere")
                    {
                        if (AnimIdx < 5)
                        {
                            AnimIdx = 5;
                        }
                        else
                        {
                            AnimIdx++;
                            if (AnimIdx == anim.frames.Count - 1)
                            {
                                hasFinished = true;
                            }
                        }
                    }
                }

                g.DrawImage(frame, drawR.X - camX , drawR.Y - camY, drawR.Width, drawR.Height);
            }
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
        public string moveAnimName = "run";
        public string dieAnimName = "die";

        public bool attackDamageDone = false;
        public bool attackmode = false;

        public float attackrange = 65;
        public float attackdis = 200;

        public int summonSlot = -1;

        public float startX = 0f;
        public float patrolDistance = 200f;
        public float leftLimit = 0f;
        public float rightLimit = 0f;

        public bool isWaiting = true;
        public int waitTime = 0;
        public int waitingTimer = 60;

        public List<DamagePopup> damagePopups = new List<DamagePopup>();

        public int spawnX = 0;
        public int spawnY = 0;

        public bool CanSpawn = false;
        public bool spawn = false;

        public int spawnTime = 600;
        public int spawnrange = 600;
        public int originalMaxHP = 50;

        public bool coindropped = false;


        public bool isCharging = false;

        public float chargeSpeed = 22f;
        public AnimationController anim = new AnimationController();

        public string chargeType;
        public List<MagicianCharge> charges = new List<MagicianCharge>();

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

            if (enemyName == "summon")
            {
                anim.changeAnimation("summonIdle", -1);
            }
            else if (isSleeping)
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
                originalMaxHP = 50;

                string[] mushroomFolders = { "attack", "die", "hit", "idle", "run", "stun-attack" };
                int[] mushroomFrames = { 10, 15, 5, 7, 8, 24 };

                animFolders = mushroomFolders;
                animFrames = mushroomFrames;
            }
            else if (type == "bat")
            {


                drawR.X = R.X;
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
                originalMaxHP = 30;
                string[] batFolders = { "attack1", "attack2", "die", "hit", "idle", "run", "sleep", "wakeup" };
                int[] batFrames = { 8, 11, 12, 5, 9, 8, 3, 16 };

                animFolders = batFolders;
                animFrames = batFrames;
            }
            else if(type == "summon")
            {
                // , "summonAppear",
                //"summonDeath" , "summonIdle"

                drawR.X = R.X;
                drawR.Y = R.Y;
                drawR.Width = 110;
                drawR.Height = 110;

                enemyName = "summon";
                enemyFolder = "Reaper";
                attackanimname = "summonIdle";

                speed = 8f;
                gravity = 0f;
                max_speed = 20f;

                patrolDistance = 2000f;
                attackrange = 20f;
                attackdis = 2000f;

                isSleeping = false;
                isWakingUp = false;
                canMoveAfterWakeup = false;

                wakeupDistance = 2000f;
                spawnrange = 4000;
                spawnTime = 0;

                summonSlot = -1;

                
                HP = new Health(10, 10);
                originalMaxHP = 10;
                string[] batFolders = { "summonAppear", "summonDeath" , "summonIdle" };
                int[] batFrames = { 6 , 5 , 4};

                animFolders = batFolders;
                animFrames = batFrames;
            }
            else if (type == "sprout")
            {
                drawR.X = R.X;
                drawR.Y = R.Y;
                drawR.Width = R.Width * 1.5f;
                drawR.Height = R.Height * 1.5f;

                enemyName = "sprout";
                enemyFolder = "Sprout";
                attackanimname = "attack";
                moveAnimName = "move";
                dieAnimName = "idle";

                speed = 3f;
                gravity = 1.2f;
                max_speed = 25f;

                patrolDistance = 200f;
                attackrange = 55f;
                attackdis = 180f;
                isSleeping = false;
                isWakingUp = false;
                canMoveAfterWakeup = true;

                spawnrange = 600;
                spawnTime = 600;

                HP = new Health(30, 30);
                originalMaxHP = 30;

                string[] sproutFolders = { "attack", "hit", "idle", "move" };
                int[] sproutFrames = { 6, 5, 4, 5 };

                animFolders = sproutFolders;
                animFrames = sproutFrames;
            }

            else if (type == "horse")
            {
                drawR.X = R.X;
                drawR.Y = R.Y;
                drawR.Width = R.Width * 1.5f;
                drawR.Height = R.Height * 1.5f;

                enemyName = "horse";
                enemyFolder = "Horse";
                attackanimname = "";
                moveAnimName = "Run";
                dieAnimName = "Idle";

                speed = 14f;
                gravity = 1.2f;
                max_speed = 22f;

                patrolDistance = 200f;
                attackrange = 55f;
                attackdis = 180f;
                isSleeping = false;
                isWakingUp = false;
                canMoveAfterWakeup = true;

                spawnrange = 600;
                spawnTime = 600;

                HP = new Health(150, 150);
                originalMaxHP = 150;

                string[] sproutFolders = { "Run" , "idle" };
                int[] sproutFrames = { 3,4 };

                animFolders = sproutFolders;
                animFrames = sproutFrames;
            }
            else if (type == "magician")
            {
                drawR.X = R.X;
                drawR.Y = R.Y;
                drawR.Width = R.Width * 1.5f;
                drawR.Height = R.Height * 1.5f;

                enemyName = "magician";
                enemyFolder = "Magician";
                attackanimname = "Attack_1";
                moveAnimName = "Walk";
                dieAnimName = "Dead";
  
                speed = 5f;
                gravity = 1.2f;
                max_speed = 25f;

                patrolDistance = 200f;
                attackrange = 55f; 
                attackdis = 1000f;
                isSleeping = false;
                isWakingUp = false;
                canMoveAfterWakeup = true;

                spawnrange = 600;
                spawnTime = 600;

                HP = new Health(150, 150);
                originalMaxHP = 150;

                string[] MagicianFolders = { "Attack_1", "Attack_2" , "Magic_arrow" , "Magic_sphere",
                "Dead" , "hit" , "idle" , "Jump" , "Walk" , "Run"};

                int[] MagicianFrames = { 7, 9 , 6 , 16 , 4 , 4 , 8 , 8  , 7 , 8 };

                animFolders = MagicianFolders;
                animFrames = MagicianFrames;
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

                string[] directions = { "left", "right" };

                for (int d = 0; d < directions.Length; d++)
                {
                    bool isLeft = false;

                    if (directions[d] == "left")
                    {
                        isLeft = true;
                    }
                    if (enemyName == "summon")
                    {
                        string basePath = "Characters/Bosses/Reaper/" + directions[d] + "/" + animFolders[i] + "/";

                        for (int j = 0; j < animFrames[i]; j++)
                        {
                            Bitmap img = new Bitmap(basePath + j.ToString() + ".png");
                            a.addFrame(img, true, isLeft);
                        }
                    }
                    else if(enemyName == "magician")
                    {
                        string basePath = "Characters/Enemies/" + enemyFolder + "/" + animFolders[i] + "/" + directions[d] + "/";

                        for (int j = 1; j <= animFrames[i]; j++)
                        {
                            Bitmap img = new Bitmap(basePath + animFolders[i] + "_" + j.ToString() + ".png");
                            a.addFrame(img, true, isLeft);
                        }
                    }
                    else
                    {
                        string basePath = "Characters/Enemies/" + enemyFolder + "/" + animFolders[i] + "/" + directions[d] + "/";

                        for (int j = 1; j <= animFrames[i]; j++)
                        {
                            Bitmap img = new Bitmap(basePath + j.ToString() + ".png");
                            a.addFrame(img, true, isLeft);
                        }
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
                if (enemyName == "summon")
                {
                    anim.changeAnimation("summonDeath", -1);
                }
                else
                {
                    anim.changeAnimation(dieAnimName, -1);
                }
                return;
            }

            if (isTakingDamage)
            {
                if (enemyName == "summon")
                {
                    anim.changeAnimation("summonIdle", -1);
                }
                else
                {   
                    if(enemyType != "horse")
                        anim.changeAnimation("hit", -1);
                }
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

                if (enemyName != "magician")
                {
                    attackFrameTimer--;

                    if (attackFrameTimer <= 0)
                    {
                        isAttacking = false;
                        attackCooldown = 100;
                        anim.changeAnimation("idle", -1);
                        anim.restart();
                    }
                }

                return;
            }

            if (isWaiting)
            {
                if (waitTime >= waitingTimer)
                {
                    waitTime = 0;
                    anim.changeAnimation(moveAnimName, -1);
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
                anim.changeAnimation(moveAnimName, -1);
                return;
            }

            if (enemyName == "summon")
            {
                anim.changeAnimation("summonIdle", -1);
                return;
            }

            if (isAttacking)
            {
                anim.changeAnimation(attackanimname, -1);
                return;
            }
        }

        void addDamagePopup(int amount, bool isCritical)
        {
            if (amount <= 0)
            {
                return;
            }

            float popupX = R.X + (R.Width / 2f);
            float popupY = R.Y + (R.Height / 2f);

            damagePopups.Add(new DamagePopup("-" + amount.ToString(), popupX, popupY, Color.White, false));

            if (isCritical)
            {
                damagePopups.Add(new DamagePopup("Critical Strike", popupX, popupY - 18f, Color.Gold, true));
            }
        }

        void updateDamagePopups()
        {
            for (int i = damagePopups.Count - 1; i >= 0; i--)
            {
                damagePopups[i].Update();

                if (damagePopups[i].shouldRemove())
                {
                    damagePopups.RemoveAt(i);
                }
            }
        }

        void drawDamagePopups(Graphics g, float camX, float camY)
        {
            for (int i = 0; i < damagePopups.Count; i++)
            {
                damagePopups[i].Draw(g, camX, camY);
            }
        }

        public void takeHit(int amount, bool isCritical = false)
        {
            if (isDead == true)
            {
                return;
            }

            HP.damage(amount);
            addDamagePopup(amount, isCritical);

            isAttacking = false;
            attackmode = false;
            attackFrameTimer = 0;
            attackDamageDone = false;

            if (HP.getHP() <= 0)
            {
                if (enemyName == "magician")
                {
                    while (charges.Count > 0)
                    {
                        charges.RemoveAt(0);
                    }
                }

                isDead = true;
                isTakingDamage = false;

                deathTimer = 0;

                if (enemyName == "summon")
                {
                    anim.changeAnimation("summonDeath", -1);
                }
                else
                {
                    if (enemyName != "horse")
                    {
                        anim.changeAnimation(dieAnimName, -1);
                    }
                }

                anim.restart();
            }
            else
            {
                if (amount > 0)
                {
                    if (enemyName != "horse")
                    {
                        isTakingDamage = true;
                        damageTimer = 15;

                        if (enemyName == "summon")
                        {
                            anim.changeAnimation("summonIdle", -1);
                        }
                        else
                        {
                            anim.changeAnimation("hit", -1);
                        }

                        anim.restart();
                    }
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

        public void draw(Graphics g, bool showRanges, float camX, float camY)
        {
            if (spawn)
            {
                updateDamagePopups();
                drawR.X = R.X + (R.Width - drawR.Width) / 2f;
                drawR.Y = R.Y + (R.Height - drawR.Height);
                if (this.enemyType == "bat")
                {
                    drawR.Y = R.Y - 20;

                }
                if(enemyType == "magician")
                {
                    for(int i =0; i< charges.Count; i++)
                    {
                        if(charges[i].hasFinished == true)
                        {
                            charges.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            charges[i].draw(g, showRanges, camX, camY);
                        }
                    }
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

                drawDamagePopups(g, camX, camY);
            }
        }

        int calculateHowValue()
        {
            int minValue = HP.maxHP / 2;
            int maxValue = HP.maxHP + (HP.maxHP / 2);

            if (minValue < 1)
            {
                minValue = 1;
            }

            if (maxValue < minValue)
            {
                maxValue = minValue;
            }

            return rr.Next(minValue, maxValue + 1);
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

        float getDropX(int slot)
        {
            float spacing = 10f;
            if (slot == 0)
            {
                return 0f;
            }

            int step = (slot + 1) / 2;

            if (slot % 2 == 1)
            {
                return -spacing * step;
            }

            return spacing * step;
        }

        int addCoins(List<DroppedCoin> droppedCoins, string type, int count, float baseX, float baseY, int slot)
        {
            for (int i = 0; i < count; i++)
            {
                float x = baseX + getDropX(slot);
                DroppedCoin coin = new DroppedCoin(x, baseY, type, 1);
                droppedCoins.Add(coin);
                slot++;
            }

            return slot;
        }

        int addValueCoins(List<DroppedCoin> droppedCoins, float baseX, float baseY, int totalValue, int minCount, int maxCount, int slot)
        {
            int coinCount = rr.Next(minCount, maxCount + 1);

            if (coinCount < 1)
            {
                coinCount = 1;
            }

            if (coinCount > totalValue)
            {
                coinCount = totalValue;
            }

            int remaining = totalValue;

            for (int i = 0; i < coinCount; i++)
            {
                int coinsLeft = coinCount - i;
                int value = remaining;

                if (coinsLeft > 1)
                {
                    int target = remaining / coinsLeft;
                    int min = target / 2;
                    int max = target + target / 2;
                    int maxAllowed = remaining - (coinsLeft - 1);

                    if (min < 1)
                    {
                        min = 1;
                    }

                    if (remaining >= 100 && min < 100)
                    {
                        min = 100;
                    }

                    if (max > maxAllowed)
                    {
                        max = maxAllowed;
                    }

                    if (max < min)
                    {
                        max = min;
                    }

                    value = rr.Next(min, max + 1);

                    if (value > maxAllowed)
                    {
                        value = maxAllowed;
                    }
                }

                if (value < 1)
                {
                    value = 1;
                }

                float x = baseX + getDropX(slot);
                DroppedCoin coin = new DroppedCoin(x, baseY, "copper", value);
                droppedCoins.Add(coin);
                slot++;
                remaining -= value;
            }

            return slot;
        }

        public void dropCollectables(List<DroppedCoin> droppedCoins, List<DroppedPotion> droppedPotions)
        {
            if (coindropped == true)
            {
                return;
            }

            float baseX = R.X + (R.Width / 2f);
            float baseY = R.Y + (R.Height / 2f);
            int totalValue = calculateHowValue();
            int slot = 0;

            if (enemyName != "summon")
            {
                slot = addValueCoins(droppedCoins, baseX, baseY, totalValue, 1, 3, slot);
                coindropped = true;

                int[] weights = { 50, 25, 15, 10 };
                string[] potionNames = { "health", "mana", "golden", "suspicious" };
                int totalWeight = 0;
                for (int i = 0; i < weights.Length; i++) totalWeight += weights[i];
                int roll = rr.Next(0, totalWeight);
                string chosen = "";
                int cumulative = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    cumulative += weights[i];
                    if (roll < cumulative) { chosen = potionNames[i]; break; }
                }

                DroppedPotion potion = new DroppedPotion(chosen, baseX, baseY - 20);
                droppedPotions.Add(potion);
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

                HP.maxHP = originalMaxHP;
                HP.HP = HP.maxHP;

                anim.changeAnimation("idle", -1);
                anim.restart();
            }
        }

    }

    public class EnemyController
    {
        public List<Enemy> enemies = new List<Enemy>();

        public void Update(List<tile> tiles, Hero hero, List<DroppedCoin> droppedCoins, List<DroppedPotion> droppedPotions)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Enemy e = enemies[i];

                float distanceX;
                if (hero.R.X > e.R.X)
                    distanceX = hero.R.X - e.R.X;
                else
                    distanceX = e.R.X - hero.R.X;

                float distanceY;
                if (hero.R.Y > e.R.Y)
                    distanceY = hero.R.Y - e.R.Y;
                else
                    distanceY = e.R.Y - hero.R.Y;

                if (e.spawnrange >= distanceX && e.spawnrange >= distanceY)
                    e.spawn = true;

                if(e.enemyType == "horse" && e.HP.HP <= 0)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
                if (e.isDead)
                {
                    e.dropCollectables(droppedCoins, droppedPotions);
                    Animation currDead = e.anim.getCurrentAnimation();
                    if(e.CanSpawn == false)
                    {
                        enemies.RemoveAt(i);
                        i--;
                    }
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
            if (e.enemyName == "summon")
            {
                moveSummon(e, tiles, hero);
                return;
            }

            if (e.enemyName == "bat")
                moveFly(e, tiles, hero);
            else
                moveGround(e, tiles, hero);
        }

        void moveSummon(Enemy e, List<tile> tiles, Hero hero)
        {
            if (e.attackCooldown > 0)
            {
                e.attackCooldown--;
            }

            if (e.isDead || e.isTakingDamage)
            {
                e.applyPhysics(tiles);
                e.updateAnimation();
                return;
            }

            float heroCenterX = hero.R.X + hero.R.Width / 2f;
            float heroCenterY = hero.R.Y + hero.R.Height / 2f;

            int targetIndex = e.summonSlot;

            float targetOffsetX = 0f;
            float targetOffsetY = 0f;

            if (targetIndex == 0)
            {
                targetOffsetY = -hero.R.Height * 0.25f;
            }
            else if (targetIndex == 1)
            {
                targetOffsetX = -hero.R.Width * 0.35f;
            }
            else if (targetIndex == 2)
            {
                targetOffsetX = hero.R.Width * 0.35f;
            }
            else if (targetIndex == 3)
            {
                targetOffsetY = hero.R.Height * 0.25f;
            }

            float targetX = heroCenterX + targetOffsetX;
            float targetY = heroCenterY + targetOffsetY;

            float summonCenterX = e.R.X + e.R.Width / 2f;
            float summonCenterY = e.R.Y + e.R.Height / 2f;

            float moveX = 0f;
            float moveY = 0f;

            float deltaX = targetX - summonCenterX;
            if (deltaX >= 0f)
            {
                if (deltaX <= e.speed)
                {
                    moveX = deltaX;
                }
                else
                {
                    moveX = e.speed;
                }
            }
            else
            {
                deltaX = -deltaX;
                if (deltaX <= e.speed)
                {
                    moveX = -deltaX;
                }
                else
                {
                    moveX = -e.speed;
                }
            }

            float deltaY = targetY - summonCenterY;
            if (deltaY >= 0f)
            {
                if (deltaY <= e.speed)
                {
                    moveY = deltaY;
                }
                else
                {
                    moveY = e.speed;
                }
            }
            else
            {
                deltaY = -deltaY;
                if (deltaY <= e.speed)
                {
                    moveY = -deltaY;
                }
                else
                {
                    moveY = -e.speed;
                }
            }

            e.R.X += moveX;
            e.R.Y += moveY;

            if (moveX < 0f)
            {
                e.moving = 'l';
                e.facing = 'l';
            }
            else if (moveX > 0f)
            {
                e.moving = 'r';
                e.facing = 'r';
            }

            if (e.R.X < hero.R.X + hero.R.Width)
            {
                if (e.R.X + e.R.Width > hero.R.X)
                {
                    if (e.R.Y < hero.R.Y + hero.R.Height)
                    {
                        if (e.R.Y + e.R.Height > hero.R.Y)
                        {
                            if (e.attackCooldown <= 0)
                            {
                                if (!hero.isDead)
                                {
                                    hero.takeDamage(10);
                                    e.attackCooldown = 45;
                                }
                            }
                        }
                    }
                }
            }

            e.applyPhysics(tiles);
            e.updateAnimation();
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
                    e.anim.changeAnimation(e.moveAnimName, -1);
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
            if (e.enemyType == "horse")
            {
                if (e.isDead == true)
                {
                    e.applyPhysics(tiles);
                    return;
                }

                bool overlapX = false;
                bool overlapY = false;

                if (e.R.X < hero.R.X + hero.R.Width)
                {
                    if (e.R.X + e.R.Width > hero.R.X)
                    {
                        overlapX = true;
                    }
                }

                if (e.R.Y < hero.R.Y + hero.R.Height)
                {
                    if (e.R.Y + e.R.Height > hero.R.Y)
                    {
                        overlapY = true;
                    }
                }

                if (overlapX == true)
                {
                    if (overlapY == true)
                    {
                        if (e.attackCooldown <= 0)
                        {
                            if (hero.isDead == false)
                            {
                                hero.takeDamage(15);
                                e.attackCooldown = 60;
                            }
                        }
                    }
                }

                if (e.attackCooldown > 0)
                {
                    e.attackCooldown--;
                }

                float distX = 0f;
                float distY = 0f;

                if (e.R.X > hero.R.X)
                {
                    distX = e.R.X - hero.R.X;
                }
                else
                {
                    distX = hero.R.X - e.R.X;
                }

                if (e.R.Y > hero.R.Y)
                {
                    distY = e.R.Y - hero.R.Y;
                }
                else
                {
                    distY = hero.R.Y - e.R.Y;
                }

                bool heroIsClose = false;
                bool heroIsSameLevel = false;
                bool pathClear = false;

                if (distX <= 600)
                {
                    heroIsClose = true;
                }

                if (distY < 60)
                {
                    heroIsSameLevel = true;
                }

                if (e.isCharging == false)
                {
                    if (heroIsClose == true)
                    {
                        if (heroIsSameLevel == true)
                        {
                            float checkStep = 40f;
                            float startX = 0f;
                            float endX = 0f;

                            if (hero.R.X > e.R.X)
                            {
                                startX = e.R.X + e.R.Width;
                                endX = hero.R.X;
                            }
                            else
                            {
                                startX = hero.R.X + hero.R.Width;
                                endX = e.R.X;
                            }

                            bool blockedByWall = false;
                            bool hasGroundAlongPath = true;
                            float checkX = startX;

                            while (checkX < endX)
                            {
                                bool groundFoundAtStep = false;
                                bool wallFoundAtStep = false;

                                for (int i = 0; i < tiles.Count; i++)
                                {
                                    tile t = tiles[i];

                                    if (t.interact == true)
                                    {
                                        if (t.jumpThrough == false)
                                        {
                                            bool wallOverlapX = false;
                                            bool wallOverlapY = false;

                                            if (checkX + e.R.Width > t.R.X)
                                            {
                                                if (checkX < t.R.X + t.R.Width)
                                                {
                                                    wallOverlapX = true;
                                                }
                                            }

                                            if (e.R.Y + e.R.Height > t.R.Y)
                                            {
                                                if (e.R.Y < t.R.Y + t.R.Height)
                                                {
                                                    wallOverlapY = true;
                                                }
                                            }

                                            if (wallOverlapX == true)
                                            {
                                                if (wallOverlapY == true)
                                                {
                                                    wallFoundAtStep = true;
                                                }
                                            }
                                        }

                                        bool footOverlapX = false;
                                        bool groundOverlapY = false;

                                        if (checkX + e.R.Width > t.R.X)
                                        {
                                            if (checkX < t.R.X + t.R.Width)
                                            {
                                                footOverlapX = true;
                                            }
                                        }

                                        if (t.R.Y >= e.R.Y + e.R.Height - 4)
                                        {
                                            if (t.R.Y <= e.R.Y + e.R.Height + 4)
                                            {
                                                groundOverlapY = true;
                                            }
                                        }

                                        if (footOverlapX == true)
                                        {
                                            if (groundOverlapY == true)
                                            {
                                                groundFoundAtStep = true;
                                            }
                                        }
                                    }
                                }

                                if (wallFoundAtStep == true)
                                {
                                    blockedByWall = true;
                                    break;
                                }

                                if (groundFoundAtStep == false)
                                {
                                    hasGroundAlongPath = false;
                                    break;
                                }

                                checkX += checkStep;
                            }

                            if (blockedByWall == false)
                            {
                                if (hasGroundAlongPath == true)
                                {
                                    pathClear = true;
                                }
                            }
                        }
                    }
                }

                if (pathClear == true)
                {
                    if (e.isCharging == false)
                    {
                        e.isCharging = true;
                        e.isWaiting = false;
                        e.anim.changeAnimation("Run", -1);
                        e.anim.restart();

                        if (hero.R.X > e.R.X)
                        {
                            e.facing = 'r';
                            e.moving = 'r';
                        }
                        else
                        {
                            e.facing = 'l';
                            e.moving = 'l';
                        }
                    }
                }

                if (e.isCharging == true)
                {
                    float nextX = 0f;

                    if (e.facing == 'r')
                    {
                        nextX = e.R.X + e.chargeSpeed;
                    }
                    else
                    {
                        nextX = e.R.X - e.chargeSpeed;
                    }

                    bool hitWall = false;
                    bool groundAhead = false;

                    for (int i = 0; i < tiles.Count; i++)
                    {
                        tile t = tiles[i];

                        if (t.interact == true)
                        {
                            if (t.jumpThrough == false)
                            {
                                bool nextOverlapX = false;
                                bool currentOverlapY = false;

                                if (nextX + e.R.Width > t.R.X)
                                {
                                    if (nextX < t.R.X + t.R.Width)
                                    {
                                        nextOverlapX = true;
                                    }
                                }

                                if (e.R.Y + e.R.Height > t.R.Y)
                                {
                                    if (e.R.Y < t.R.Y + t.R.Height)
                                    {
                                        currentOverlapY = true;
                                    }
                                }

                                if (nextOverlapX == true)
                                {
                                    if (currentOverlapY == true)
                                    {
                                        hitWall = true;
                                    }
                                }
                            }

                            float groundCheckLeft = 0f;
                            float groundCheckRight = 0f;

                            if (e.facing == 'r')
                            {
                                groundCheckLeft = nextX + e.R.Width / 2f;
                                groundCheckRight = nextX + e.R.Width;
                            }
                            else
                            {
                                groundCheckLeft = nextX;
                                groundCheckRight = nextX + e.R.Width / 2f;
                            }

                            bool groundCheckX = false;
                            bool groundCheckY = false;

                            if (groundCheckRight > t.R.X)
                            {
                                if (groundCheckLeft < t.R.X + t.R.Width)
                                {
                                    groundCheckX = true;
                                }
                            }

                            if (t.R.Y >= e.R.Y + e.R.Height - 4)
                            {
                                if (t.R.Y <= e.R.Y + e.R.Height + 4)
                                {
                                    groundCheckY = true;
                                }
                            }

                            if (groundCheckX == true)
                            {
                                if (groundCheckY == true)
                                {
                                    groundAhead = true;
                                }
                            }
                        }
                    }

                    bool shouldStop = false;

                    if (hitWall == true)
                    {
                        shouldStop = true;
                    }

                    if (groundAhead == false)
                    {
                        shouldStop = true;
                    }

                    if (shouldStop == true)
                    {
                        e.isCharging = false;
                        e.isWaiting = true;
                        e.waitTime = 0;
                        e.anim.changeAnimation("idle", -1);
                        e.anim.restart();
                    }
                    else
                    {
                        e.R.X = nextX;
                    }

                    e.applyPhysics(tiles);
                    return;
                }

                if (e.isWaiting == true)
                {
                    e.waitTime++;

                    if (e.waitTime >= 30)
                    {
                        e.waitTime = 0;
                        e.isWaiting = false;

                        if (e.facing == 'l')
                        {
                            e.facing = 'r';
                            e.moving = 'r';
                        }
                        else
                        {
                            e.facing = 'l';
                            e.moving = 'l';
                        }

                        e.anim.changeAnimation("Run", -1);
                        e.anim.restart();
                    }
                    else
                    {
                        e.anim.changeAnimation("idle", -1);
                    }

                    e.applyPhysics(tiles);
                    return;
                }

                float patrolNextX = 0f;

                if (e.facing == 'r')
                {
                    patrolNextX = e.R.X + e.speed;
                }
                else
                {
                    patrolNextX = e.R.X - e.speed;
                }

                bool patrolHitWall = false;
                bool patrolGroundAhead = false;

                for (int i = 0; i < tiles.Count; i++)
                {
                    tile t = tiles[i];

                    if (t.interact == true)
                    {
                        if (t.jumpThrough == false)
                        {
                            bool nextOverlapX = false;
                            bool currentOverlapY = false;

                            if (patrolNextX + e.R.Width > t.R.X)
                            {
                                if (patrolNextX < t.R.X + t.R.Width)
                                {
                                    nextOverlapX = true;
                                }
                            }

                            if (e.R.Y + e.R.Height > t.R.Y)
                            {
                                if (e.R.Y < t.R.Y + t.R.Height)
                                {
                                    currentOverlapY = true;
                                }
                            }

                            if (nextOverlapX == true)
                            {
                                if (currentOverlapY == true)
                                {
                                    patrolHitWall = true;
                                }
                            }

                            float leadingX = 0f;

                            if (e.facing == 'r')
                            {
                                leadingX = patrolNextX + e.R.Width;
                            }
                            else
                            {
                                leadingX = patrolNextX;
                            }

                            bool footOverlapX = false;
                            bool footGroundY = false;

                            if (leadingX > t.R.X)
                            {
                                if (leadingX < t.R.X + t.R.Width)
                                {
                                    footOverlapX = true;
                                }
                            }

                            if (t.R.Y >= e.R.Y + e.R.Height - 4)
                            {
                                if (t.R.Y <= e.R.Y + e.R.Height + 8)
                                {
                                    footGroundY = true;
                                }
                            }

                            if (footOverlapX == true)
                            {
                                if (footGroundY == true)
                                {
                                    patrolGroundAhead = true;
                                }
                            }
                        }
                    }
                }

                bool patrolShouldTurn = false;

                if (patrolHitWall == true)
                {
                    patrolShouldTurn = true;
                }

                if (patrolGroundAhead == false)
                {
                    patrolShouldTurn = true;
                }

                if (patrolShouldTurn == true)
                {
                    e.isWaiting = true;
                    e.waitTime = 0;
                    e.anim.changeAnimation("idle", -1);
                    e.anim.restart();
                }
                else
                {
                    e.R.X = patrolNextX;
                    e.anim.changeAnimation("Run", -1);
                }

                e.applyPhysics(tiles);
                return;
            }
            if (e.enemyType == "magician")
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

                for (int c = e.charges.Count - 1; c >= 0; c--)
                {
                    e.charges[c].moveCharge(hero, tiles);
                    if (e.charges[c].hasFinished)
                    {
                        e.charges.RemoveAt(c);
                    }
                }

                if (e.isDead || e.isTakingDamage)
                {
                    e.applyPhysics(tiles);
                    e.updateAnimation();
                    return;
                }

                float distX = 0f;
                float distY = 0f;
                char direc = e.moving;

                if (e.R.X > hero.R.X)
                {
                    distX = e.R.X - hero.R.X;
                    direc = 'l';
                }
                else if (e.R.X < hero.R.X)
                {
                    distX = hero.R.X - e.R.X;
                    direc = 'r';
                }

                if (e.R.Y > hero.R.Y)
                    distY = e.R.Y - hero.R.Y;
                else if (hero.R.Y > e.R.Y)
                    distY = hero.R.Y - e.R.Y;

                bool isSameY = false;
                if (distY < 80)
                    isSameY = true;

                bool heroInRange = false;
                if (distX <= e.attackdis)
                {
                    if (isSameY)
                    {
                        if (!hero.isDead)
                        {
                            heroInRange = true;
                        }
                    }
                }

                if (heroInRange)
                {
                    e.attackmode = true;
                }
                else
                {
                    e.attackmode = false;
                    if (e.isAttacking)
                    {
                        e.isAttacking = false;
                        e.attackDamageDone = false;
                    }
                }

                if (e.attackmode)
                {
                    e.facing = direc;
                    e.moving = ' ';
                    e.isRunning = false;

                    if (e.isAttacking)
                    {
                        Animation currAnim = e.anim.getCurrentAnimation();
                        if (currAnim != null)
                        {
                            bool facingL = false;
                            if (e.facing == 'l')
                                facingL = true;

                            List<Bitmap> frames = currAnim.getFrames(facingL);
                            if (frames.Count > 0)
                            {
                                if (e.anim.currIdx >= frames.Count - 1)
                                {
                                    if (!e.attackDamageDone)
                                    {
                                        float spawnX = 0f;
                                        float spawnY = e.R.Y + e.R.Height / 2f - 32f;

                                        if (e.facing == 'l')
                                        {
                                            spawnX = e.R.X - 68;
                                        }
                                        else
                                        {
                                            spawnX = e.R.X + e.R.Width;
                                        }

                                        MagicianCharge charge = new MagicianCharge(spawnX, spawnY, e.chargeType, e.facing);
                                        e.charges.Add(charge);

                                        e.attackDamageDone = true;
                                    }

                                    e.isAttacking = false;
                                    e.attackCooldown = 90;
                                    e.anim.changeAnimation("idle", -1);
                                    e.anim.restart();
                                }
                            }
                        }

                        e.applyPhysics(tiles);
                        e.updateAnimation();
                        return;
                    }

                    Animation currIdleAnim = e.anim.getCurrentAnimation();
                    bool alreadyIdling = false;
                    if (currIdleAnim != null)
                    {
                        if (currIdleAnim.name == "idle")
                        {
                            alreadyIdling = true;
                        }
                    }

                    if (alreadyIdling == false)
                    {
                        e.anim.changeAnimation("idle", -1);
                        e.anim.restart();
                    }

                    if (e.attackCooldown <= 0)
                    {
                        if (!hero.isDead)
                        {
                            int rr = e.rr.Next(0, 2);

                            string animName = "";

                            if (rr == 0)
                            {
                                e.chargeType = "arrow";
                                animName = "Attack_1";
                                e.attackFrameTimer = 60;
                            }
                            else
                            {
                                e.chargeType = "sphere";
                                animName = "Magic_sphere";
                                e.attackFrameTimer = 120;
                            }

                            e.isAttacking = true;
                            e.attackDamageDone = false;
                            e.attackanimname = animName;
                            e.anim.changeAnimation(animName, -1);
                            e.anim.restart();
                        }
                    }

                    e.applyPhysics(tiles);
                    e.updateAnimation();
                    return;
                }

                if (e.isWaiting)
                {
                    e.waitTime++;

                    Animation currWaitAnim = e.anim.getCurrentAnimation();
                    bool alreadyIdleWait = false;
                    if (currWaitAnim != null)
                    {
                        if (currWaitAnim.name == "idle")
                        {
                            alreadyIdleWait = true;
                        }
                    }

                    if (alreadyIdleWait == false)
                    {
                        e.anim.changeAnimation("idle", -1);
                        e.anim.restart();
                    }

                    if (e.waitTime >= 60)
                    {
                        e.waitTime = 0;
                        e.isWaiting = false;

                        if (e.facing == 'l')
                        {
                            e.facing = 'r';
                            e.moving = 'r';
                        }
                        else
                        {
                            e.facing = 'l';
                            e.moving = 'l';
                        }

                        e.anim.changeAnimation(e.moveAnimName, -1);
                        e.anim.restart();
                    }

                    e.applyPhysics(tiles);
                    return;
                }

                float patrolNextX = 0f;
                if (e.facing == 'r')
                    patrolNextX = e.R.X + e.speed;
                else
                    patrolNextX = e.R.X - e.speed;

                bool patrolHitWall = false;
                bool patrolGroundAhead = false;

                for (int i = 0; i < tiles.Count; i++)
                {
                    tile t = tiles[i];

                    if (t.interact)
                    {
                        if (!t.jumpThrough)
                        {
                            bool nextOverlapX = false;
                            bool currentOverlapY = false;

                            if (patrolNextX + e.R.Width > t.R.X)
                            {
                                if (patrolNextX < t.R.X + t.R.Width)
                                {
                                    nextOverlapX = true;
                                }
                            }

                            if (e.R.Y + e.R.Height > t.R.Y)
                            {
                                if (e.R.Y < t.R.Y + t.R.Height)
                                {
                                    currentOverlapY = true;
                                }
                            }

                            if (nextOverlapX)
                            {
                                if (currentOverlapY)
                                {
                                    patrolHitWall = true;
                                }
                            }

                            float leadingX = 0f;
                            if (e.facing == 'r')
                                leadingX = patrolNextX + e.R.Width;
                            else
                                leadingX = patrolNextX;

                            bool footOverlapX = false;
                            bool footGroundY = false;

                            if (leadingX > t.R.X)
                            {
                                if (leadingX < t.R.X + t.R.Width)
                                {
                                    footOverlapX = true;
                                }
                            }

                            if (t.R.Y >= e.R.Y + e.R.Height - 4)
                            {
                                if (t.R.Y <= e.R.Y + e.R.Height + 8)
                                {
                                    footGroundY = true;
                                }
                            }

                            if (footOverlapX)
                            {
                                if (footGroundY)
                                {
                                    patrolGroundAhead = true;
                                }
                            }
                        }
                    }
                }

                if (patrolHitWall)
                {
                    e.isWaiting = true;
                    e.waitTime = 0;
                    e.anim.changeAnimation("idle", -1);
                    e.anim.restart();
                }
                else if (!patrolGroundAhead)
                {
                    e.isWaiting = true;
                    e.waitTime = 0;
                    e.anim.changeAnimation("idle", -1);
                    e.anim.restart();
                }
                else
                {
                    e.R.X = patrolNextX;

                    Animation currWalkAnim = e.anim.getCurrentAnimation();
                    bool alreadyWalking = false;
                    if (currWalkAnim != null)
                    {
                        if (currWalkAnim.name == e.moveAnimName)
                        {
                            alreadyWalking = true;
                        }
                    }

                    if (alreadyWalking == false)
                    {
                        e.anim.changeAnimation(e.moveAnimName, -1);
                        e.anim.restart();
                    }
                }

                e.applyPhysics(tiles);
                e.updateAnimation();
                return;
            }


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

                    e.anim.changeAnimation(e.moveAnimName, -1);
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
                    e.anim.changeAnimation(e.moveAnimName, -1);
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

        public void makeItDamage(int dmg, int cooldown)
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
        public void draw(Graphics g, float camX, float camY, bool ShowRanges)
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

            if (ShowRanges == true)
            {
                Pen green = new Pen(Color.Brown, 3);
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

        public void init(int x, int y, int width, int height, bool showColor)
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
        public boss Boss;
        public Teleporter teleporter;
        public Bitmap background;
        public int worldWidth = 0;
        public int worldHeight = 0;
        public bool isVoidLevel = false;
        public string displayName = "";

        public float startHeroX;
        public float startHeroY;

        public level(Bitmap bk, int width, int height, float startHeroX, float startHeroY)
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

        public void addBoss(boss bossEnemy)
        {
            Boss = bossEnemy;
        }
    }

    public class levelController
    {
        public List<level> levels = new List<level>();
        public int currentLevel = -1;

        public levelController(int height, int width)
        {
            initLevelData(height, width);
            initAll(height, width);
        }

        public void initLevelData(int height, int width)
        {

            //level 1 (idx 0)
            Bitmap background = new Bitmap("Backgrounds/Forest.png");
            int worldWidth = background.Width * 2;
            int worldHeight = height;

            float startHeroX = 30;
            float startHeroY = height - 150 - 30;

            level lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, false, "Forest");
            levels.Add(lvl);

            background = new Bitmap("Backgrounds/shop.png");
            worldWidth = width;
            worldHeight = height;

            startHeroX = 100;
            startHeroY = worldHeight - 120;

            lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, true, "Rest");
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

            lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, true, "Rest");
            levels.Add(lvl);


            background = new Bitmap("Backgrounds/BossArena.png");
            worldWidth = background.Width * 2;
            worldHeight = background.Height * 2;

            startHeroX = 100;
            startHeroY = 808 - 100;

            lvl = new level(background, worldWidth, worldHeight, startHeroX, startHeroY, false, "Boss Room");
            levels.Add(lvl);

            initTeleporters();
        }

        public void initTeleporters()
        {
            level lvl = levels[0];

            lvl.teleporter = new Teleporter(0, lvl.worldWidth - 300, lvl.worldHeight - 180, 140, 140, 300, 100, false);

            lvl = levels[1];
            lvl.teleporter = new Teleporter(2, lvl.worldWidth - 250, lvl.worldHeight - 200, 175, 175, 0, 100, false);
            lvl.teleporter.isUnlocked = true;
            lvl.teleporter.requiredCoins = 0;

            lvl = levels[2];
            lvl.teleporter = new Teleporter(1, lvl.worldWidth - 300, lvl.worldHeight - 90 - 175, 175, 175, 300, 100, false);

            lvl = levels[3];
            lvl.teleporter = new Teleporter(2, lvl.worldWidth - 250, lvl.worldHeight - 200, 175, 175, 0, 100, true);
            lvl.teleporter.isUnlocked = true;
            lvl.teleporter.requiredCoins = 0;



        }
        public void initAll(int height, int width)
        {
            removeAllFromLevels();
            initTiles(height);
            initLadders(height);
            initEnemies(height);
            initPlatforms();
            initBosses(width, height);

        }

        void initBosses(int clientWidth, int height)
        {
            float ground0 = height - 30 - 150;
            float ground2 = levels[2].worldHeight - 112 - 170;

            int minW = 288, minH = 160;

            levels[0].addBoss(new boss("Minatour", levels[0].worldWidth - 800, levels[0].worldHeight - minH - 30, minW, minH, 420, clientWidth));
            levels[1].Boss = null;
            levels[2].addBoss(new boss("Reaper", levels[2].worldWidth - 850, ground2, 190, 170, 520, clientWidth));
            levels[3].Boss = null;
            levels[4].addBoss(new boss("Aegis", levels[4].worldWidth / 2 - 140, 808 - 250 , 220, 250, 900, clientWidth));
        }

        void removeAllFromLevels()
        {
            for (int i = 0; i < levels.Count; i++) {

                while (levels[i].enemies.Count > 0) {
                    levels[i].enemies.RemoveAt(0);
                }
                while (levels[i].ladders.Count > 0) {
                    levels[i].ladders.RemoveAt(0);
                }
                while (levels[i].tiles.Count > 0) {
                    levels[i].tiles.RemoveAt(0);
                }
                while (levels[i].movingPlatforms.Count > 0)
                {
                    levels[i].movingPlatforms.RemoveAt(0);
                }

            }
        }

        void initLadders(int height)
        {
            initLadders0(height);
            initLadders2();


        }
        void initLadders2()
        {
            Ladder ladder;

            ladder = new Ladder(1916, 645, 330, true);

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

        int getAboveGroundLoc(int enemyH, int Height)
        {
            return Height - 30 - enemyH;
        }

        void initEnemies(int height)
        {
            Enemy en;

            // Mushroom size
            int mushroomW = 90;
            int mushroomH = 70;
            int mushroomY = getAboveGroundLoc(mushroomH, height);

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

            en = new Enemy(levels[0].worldWidth - 300, levels[0].worldHeight - 180, 90, 70, "mushroom");
            en.CanSpawn = true;
            en.spawn = true;
            levels[0].enemies.Add(en);

            int sproutW = 90;
            int sproutH = 70;
            int sproutY = getAboveGroundLoc(sproutH, height);

            en = new Enemy(1400, sproutY, sproutW, sproutH, "sprout");
            en.CanSpawn = false;
            en.spawn = true;
            levels[0].enemies.Add(en);


            en = new Enemy(205, 646 - 120, 200, 120, "horse");
            en.CanSpawn = false;
            en.spawn = true;
            levels[2].enemies.Add(en);

            en = new Enemy(3490, 319 - 120, 200, 120, "horse");
            en.CanSpawn = false;
            en.spawn = true;
            levels[2].enemies.Add(en);


            en = new Enemy(1500, 320 - 110, 110, 110, "magician");
            en.CanSpawn = true;
            en.spawn = true;
            levels[2].enemies.Add(en);



            en = new Enemy(3520, 647 - 110, 110, 110, "magician");
            en.CanSpawn = true;
            en.spawn = true;
            levels[2].enemies.Add(en);
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
            initTilesLevel4();
        }

        void initTilesLevel4()
        {
            tile pnn = new tile();
            pnn.interact = true;
            pnn.init(0, 806, levels[4].worldWidth, 30, false);
            levels[4].tiles.Add(pnn);
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
            pnn.init(0, height - 112, 2067, 30, false);
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
            pnn.init(1235, 917, 127, 54, false);
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
            pnn.init(0, height - 30, levels[0].worldWidth, 30, true);
            pnn.changeColor(Color.Black);
            levels[0].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = true;
            pnn.init(300, height - 150, 200, 20, true);
            pnn.changeColor(Color.Black);
            levels[0].tiles.Add(pnn);

            pnn = new tile();
            pnn.interact = true;
            pnn.jumpThrough = false;
            pnn.clr = Color.DarkRed;
            pnn.init(600, height - 250, 200, 30, true);
            pnn.changeColor(Color.Red);

            levels[0].tiles.Add(pnn);
        }

        public void loadLadders(List<Ladder> ladders)
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

        public void loadEnemies(List<Enemy> enemies)
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

        public void loadTiles(List<tile> tiles)
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
        public void removeAll(List<Enemy> enemies, List<Ladder> ladders, List<tile> tiles, List<DroppedCoin> coins, List<DroppedPotion> potions)
        {
            while (potions.Count > 0)
            {
                potions.RemoveAt(0);
            }

            while (coins.Count > 0)
            {
                coins.RemoveAt(0);
            }

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

            for (int i = 0; i < curLvl.enemies.Count; i++)
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
        public void nextLevel(Hero hero, List<Enemy> enemies, List<Ladder> ladders, List<tile> tiles, List<DroppedCoin> coins, List<DroppedPotion> potions, List<MovingPlatform> movingPlatforms)
        {
            if (currentLevel < levels.Count - 1)
            {
                currentLevel++;
                if (hero != null)
                {
                    hero.stopLaserCast();
                }
                removeAll(enemies, ladders, tiles, coins, potions);
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

        public boss getCurrentBoss()
        {
            if (currentLevel < 0 || currentLevel >= levels.Count)
            {
                return null;
            }

            return levels[currentLevel].Boss;
        }

        public bool currentBossIsAlive()
        {
            boss currentBoss = getCurrentBoss();
            if (currentBoss == null)
            {
                return false;
            }

            if (currentBoss.isDead == false)
            {
                return true;
            }

            return false;
        }

        public bool currentBossIsAegisDead()
        {
            boss currentBoss = getCurrentBoss();
            if (currentBoss == null)
            {
                return false;
            }

            if (currentBoss.name == "Aegis")
            {
                if (currentBoss.isDead)
                {
                    return true;
                }
            }

            return false;
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
        public bool isBoss = false;
        public Bitmap bossIcon;

        public Teleporter(int level, int x, int y, int w, int h, int coins, int range, bool bossRoom)
        {
            this.level = level;
            rect.X = x;
            rect.Y = y;
            rect.Width = w;
            rect.Height = h;

            requiredCoins = coins;
            this.range = range;

            this.isBoss = bossRoom;
            if (isBoss == true)
            {
                bossIcon = new Bitmap("Teleporters/BossIcon.png");
            }
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
                    if (i < 10)
                    {
                        numbers += "0";
                    }
                    numbers += i.ToString();
                    Bitmap frame = new Bitmap("Teleporters/Key/sprite_" + numbers + ".png");
                    Animation.addFrame(frame, false, false);
                }
                loopIt = false;
            }
            else if (level == 2) {

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
            if (this.loopIt == true)
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
                if (isUnlocked == false)
                {
                    return Animation.frames[0];
                }
                else
                {
                    if (currF < Animation.frames.Count - 1)
                    {
                        if (currF == Animation.frames.Count / 4)
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
            if (loopIt == false && isUnlocked == true && currF < Animation.frames.Count - 1)
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
        public void draw(Graphics g, Hero hero, bool showRange, float camX, float camY, bool bossLocked)
        {
            checkHero(hero);
            if (isBoss == true)
            {
                int width = 100;
                int height = 80;
                g.DrawImage(bossIcon, rect.X - camX + rect.Width / 2 - width / 2, rect.Y - camY - height, width, height);

            }
            g.DrawImage(getFrame(), rect.X - camX, rect.Y - camY, rect.Width, rect.Height);

            if (showRange == true)
            {
                Pen red = new Pen(Color.Red);
                g.DrawRectangle(red, rect.X - range - camX, rect.Y - range - camY, range * 2 + rect.Width, range + rect.Height);
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

                Font font = new Font("System", 12, FontStyle.Bold);
                SolidBrush textBrush = new SolidBrush(Color.Black);

                string text = "Press Q to unlock!";
                if (bossLocked == true)
                {
                    text = "Kill Boss First";
                }
                else if (hero.coins < this.requiredCoins && isUnlocked == false)
                {
                    text = "You need " + (requiredCoins - hero.coins).ToString() + " Coins!";
                }
                else if (isUnlocked == true)
                {
                    text = "Unlocked! Press Q";
                }
                g.DrawString(text, font, textBrush, positionButtonX, positionButtonY + 10);
            }

        }
    }

    public class bossUI{
        public rect rect = new rect();
        Bitmap bg = new Bitmap("ui/bossHP/health_under.png");
        Bitmap bar = new Bitmap("ui/bossHP/bar.png");
        Bitmap name = null;

        public string Bname;

        public bossUI(string bname , int ClientWidth)
        {
            int width = 400;
            int height = 150;

            rect.X = ClientWidth / 2 - width / 2;
            rect.Y = 50;
            rect.Width = width;
            rect.Height = height;

            this.Bname = bname;
            string path = "ui/bossHP/" + Bname + ".png";

            this.name = new Bitmap(path);
        }

        public void draw(Graphics g , int HP , int maxHP)
        {
            g.DrawImage(bg, rect.X, rect.Y, rect.Width, rect.Height);

           

            int barStart = rect.X + 20;
            int barMaxW = rect.Width - 38;
            int barH = rect.Height;
            int barY = rect.Y + (rect.Height - barH) / 2;

            int drawW = 0;
            int srcW = 0;

            if (maxHP > 0)
            {
                int currentHP = HP;
                if (currentHP < 0) currentHP = 0;
                if (currentHP > maxHP) currentHP = maxHP;

                drawW = barMaxW * currentHP / maxHP;
                srcW = bar.Width * currentHP / maxHP;
            }

            if (drawW > 0)
            {
                Rectangle dstRect = new Rectangle(barStart, barY, drawW, barH);
                Rectangle srcRect = new Rectangle(0, 0, srcW, bar.Height);
                g.DrawImage(bar, dstRect, srcRect, GraphicsUnit.Pixel);
            }

            if (name != null)
            {
                int w = 200 , h = 80;
               
                if(Bname == "Minatour")
                {
                    w = 300;
                    h = 130;
                }

                int nameX = rect.X + (rect.Width - w) / 2;
                int nameY = rect.Y + rect.Height / 2 - h / 2 - 5;
                if (Bname == "Minatour") nameY += 5;

                g.DrawImage(name, nameX, nameY, w, h);
            }
        }
    }

    public class DamagePopup
    {
        public string text;
        public float x;
        public float y;
        public Color color;
        public float speed;
        public int maxTime;
        public int timer;
        public bool isCritical;

        public DamagePopup(string text, float x, float y, Color color, bool isCritical)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.color = color;
            this.isCritical = isCritical;

            if (isCritical)
            {
                this.speed = 1.75f;
                this.maxTime = 32;
            }
            else
            {
                this.speed = 1.35f;
                this.maxTime = 26;
            }

            this.timer = 0;
        }

        public void Update()
        {
            y -= speed;
            timer++;
        }

        public bool shouldRemove()
        {
            if (timer >= maxTime)
            {
                return true;
            }

            return false;
        }

        public void Draw(Graphics g, float camX, float camY)
        {
            float drawX = x - camX - (text.Length*7 / 2);
            float drawY = y - camY - 8;
            Font font;

            if (isCritical)
            {
                font = new Font("System", 10, FontStyle.Bold);
            }
            else
            {
                font = new Font("System", 9, FontStyle.Bold);
            }

            SolidBrush outlineBrush = new SolidBrush(Color.Black);
            SolidBrush fillBrush = new SolidBrush(color);

            g.DrawString(text, font, outlineBrush, drawX + 1f, drawY + 1f);
            g.DrawString(text, font, fillBrush, drawX, drawY);
        }
    }


    public class AegisAbility
    {
        public string type;
        public rectF R = new rectF();

        public Bitmap img;

        public bool isDone = false;

        public float fullHeight = 0f;
        public float revealAmount = 0f;
        public float riseSpeed = 12f;

        // 0 = rising, 1:staying, 2 :sinking
        public int phase = 0;

        public int stayTimer = 0;
        public int stayDuration = 90;

        public float voidSpeed = 8f;
        public int escapeTimer = 0;
        public int escapeMax = 180;

        public int pulseTimer = 0;
        public int pulseDirection = 1;
        public float pulseSize = 0f;

        public int hitCooldown = 0;
        public AegisAbility(string type, float x, float groundY, Bitmap img)
        {
            this.type = type;

            this.img = new Bitmap(img);
            this.img.MakeTransparent(this.img.GetPixel(0, 0));

            fullHeight = img.Height;

            R.Width = img.Width;
            R.Height = img.Height;
            R.X = x;
            R.Y = groundY - R.Height;
        }
    }

    public class boss {
        public string name;
        public bool startFight = false;
        public rectF R = new rectF();
        public rectF drawR = new rectF();
        public bossUI bossUI;

        public float speed = 4f;
        public char moving = 'l';
        public char facing = 'l';

        public float velocityY = 0f;
        public float gravity = 1.2f;
        public float max_speed = 25f;

        public bool isGrounded = false;
        public bool wasGrounded = false;

        public Health HP;

        public bool isTakingDamage = false;
        public bool isAttacking = false;
        public bool isWakingUp = false;
        public bool isDead = false;
        public bool attackDamageDone = false;
        public bool coindropped = false;

        public List<DamagePopup> damagePopups = new List<DamagePopup>();

        public float wakeupDistance = 400f;
        public float attackDistance = 120f;
        public float attackRange = 90f;

        public string movingDir = "none";
        public float targetX = 0f;
        public float targetY = 0f;
        public bool hasTarget = false;
        public int reaperCloseDelayTimer = 0;
        public int reaperCloseDelayMax = 20;
        public int summonTick = 0;
        public int summonGap = 360;
        public int summonAnimTimer = 0;

        public Random rr = new Random();

        public int damageTimer = 0;

        public int attackTimer = 0;
        public int attackCooldown = 0;
        public int attackFrameTimer = 0;
        public int deathTimer = 0;

        public int spinTimer = 0;
        public int spinCooldown = 120;
        public int spinChance = 100;
        public bool doSpin = false;
        int spinDamageInterval = 3;
        int spinDamageTimer = 0;
        public float normalSpeed = 0f;

        public AnimationController anim = new AnimationController();


        Bitmap aegisHand1 = null;
        Bitmap aegisHand2 = null;
        Bitmap aegisHand3 = null;
        Bitmap aegisHand4 = null;
        Bitmap aegisTentacle = null;
        Bitmap aegisVoidCircle = null;

        int aegisAbilityCooldown = 0;
        int aegisAbilityCooldownMax = 120;
        public List<AegisAbility> aegisAbilities = new List<AegisAbility>();

        public boss(string name, float x , float y , float width , float height , int maxHP , int clientWidth)
        {
            R.X = x;
            R.Y = y;
            R.Width = width;
            R.Height = height;

            this.HP = new Health(maxHP, maxHP);

            this.name = name;
            if (name == "Aegis")
            {
                drawR.Width = width;
                drawR.Height = height;
                speed = 0f;
                wakeupDistance = 900f;
                attackDistance = 240f;
                attackRange = 160f;
            }
            else if (name == "Minatour")
            {
                drawR.Width = width * 1.15f;
                drawR.Height = height * 1.15f;
                speed = 3.5f;
                wakeupDistance = 700f;
                attackDistance = 80f;
                attackRange = 95f;
            }
            else
            {
                drawR.Width = width * 1.1f;
                drawR.Height = height * 1.1f;
                speed = 4f;
                wakeupDistance = 800f;
                attackDistance = 150f;
                attackRange = 100f;
            }

            bossUI = new bossUI(name , clientWidth);

            initAnimations(name);
            anim.changeAnimation("idle", -1);
            updateDrawR();
        }

        void loadAegisImgs()
        {
            if (aegisHand1 != null)
            {
                return;
            }

            string folder = "Characters/Bosses/Aegis/abilities/";

            aegisHand1 = new Bitmap(folder + "Hand1.png");
            aegisHand2 = new Bitmap(folder + "Hand2.png");
            aegisHand3 = new Bitmap(folder + "Hand3.png");
            aegisHand4 = new Bitmap(folder + "Hand4.png");
            aegisTentacle = new Bitmap(folder + "Tenticle.png");
            aegisVoidCircle = new Bitmap(folder + "voidCircle.png");
        }
        void initAnimations(string name)
        {
            string folder = "Characters/Bosses/" + name;

            if(name == "Aegis")
            {
                Animation aegis = new Animation();
                aegis.name = "idle";
                for(int i =0; i < 15; i++)
                {
                    string curr = folder+ "/" + i.ToString() + ".png";
                    aegis.frames.Add(new Bitmap(curr));
                    
                }

                anim.addAnim(aegis);
            }
            else if (name == "Minatour")
            {
                string[] folders =
                {
                    "atk_1", "idle" , "walk"
                };
                int[] numFrames =
                {
                    16,16,12
                };

                for(int i =0; i < folders.Length; i++)
                {
                    Animation animation = new Animation();
                    animation.name = folders[i];

                    for(int j = 0; j < numFrames[i]; j++)
                    {
                        string curr = folder + "/left/" + animation.name + "/" + j.ToString() + ".png";
                        animation.leftFrames.Add(new Bitmap(curr));
                    }

                    for (int j = 0; j < numFrames[i]; j++)
                    {
                        string curr = folder + "/right/" + animation.name + "/" + j.ToString() + ".png";
                        animation.rightFrames.Add(new Bitmap(curr));
                    }
                    anim.addAnim(animation);

                }
            }
            else if(name == "Reaper")
            {
                string[] folders =
                {
                    "attacking" , "death" , "idle",
                    "skill1" , "summon"
                };

                int[] numFrames =
                {
                    13, 18, 8 , 12, 5
                };

                for (int i = 0; i < folders.Length; i++)
                {
                    Animation animation = new Animation();
                    animation.name = folders[i];

                    for (int j = 0; j < numFrames[i]; j++)
                    {
                        string curr = folder + "/left/" + animation.name + "/" + j.ToString() + ".png";
                        animation.leftFrames.Add(new Bitmap(curr));
                    }

                    for (int j = 0; j < numFrames[i]; j++)
                    {
                        string curr = folder + "/right/" + animation.name + "/" + j.ToString() + ".png";
                        animation.rightFrames.Add(new Bitmap(curr));
                    }
                    anim.addAnim(animation);

                }
            }
        }

        void updateDrawR()
        {
            if (name == "Minatour")
            {
                drawR.Width = R.Width * 2;
                drawR.Height = R.Height * 2;
                drawR.X = R.X + (R.Width - drawR.Width) / 2f;
                drawR.Y = R.Y - 130;
            }
            else if(name == "Reaper")
            {
                drawR.Width = (R.Width *2);
                drawR.Height = (R.Height * 2);
                drawR.X = R.X + (R.Width - drawR.Width) / 2f;
                drawR.Y = R.Y - 50;
                if (doSpin == false)
                {
                    speed = 10f;
                }
                else speed = 18;
            }
            else if(name == "Aegis")
            {
                drawR.Width = R.Width * 2;
                drawR.Height = R.Height * 2;
                drawR.X = R.X + (R.Width - drawR.Width) / 2f;
                drawR.Y = R.Y - 130;
            }

        }

        void addDamagePopup(int amount, bool isCritical)
        {
            if (amount <= 0)
            {
                return;
            }

            float popupX = R.X + (R.Width / 2f);
            float popupY = R.Y + (R.Height / 2f);

            damagePopups.Add(new DamagePopup("-" + amount.ToString(), popupX, popupY, Color.White, false));

            if (isCritical)
            {
                damagePopups.Add(new DamagePopup("Critical Strike", popupX, popupY - 18f, Color.Gold, true));
            }
        }

        void updateDamagePopups()
        {
            for (int i = damagePopups.Count - 1; i >= 0; i--)
            {
                damagePopups[i].Update();

                if (damagePopups[i].shouldRemove())
                {
                    damagePopups.RemoveAt(i);
                }
            }
        }

        void drawDamagePopups(Graphics g, float camX, float camY)
        {
            for (int i = 0; i < damagePopups.Count; i++)
            {
                damagePopups[i].Draw(g, camX, camY);
            }
        }

        public void takeHit(int amount, bool isCritical = false)
        {
            if (isDead)
            {
                return;
            }

            /*if (isTakingDamage)
            {
                return;
            }*/

            startFight = true;
            hasTarget = false;
            movingDir = "none";

            HP.damage(amount);
            addDamagePopup(amount, isCritical);
            isAttacking = false;
            attackFrameTimer = 0;
            attackCooldown = 40;

            if (HP.getHP() <= 0)
            {
                isDead = true;
                isTakingDamage = false;
                deathTimer = 0;

                if (name == "Reaper")
                {
                    anim.changeAnimation("death", -1);
                    anim.restart();
                }

                return;
            }

            damageTimer = 20;
            anim.restart();
        }

        void spawnAegisAbility(Hero hero, float worldWidth)
        {
            loadAegisImgs();

            int rand = rr.Next(0, 3);

            if (rand == 0)
            {
                int count = rr.Next(2, 5);

                for (int i = 0; i < count; i++)
                {
                    int handRoll = rr.Next(0, 4);
                    Bitmap src = aegisHand1;

                    if (handRoll == 1)
                    {
                        src = aegisHand2;
                    }
                    else if (handRoll == 2)
                    {
                        src = aegisHand3;
                    }
                    else if (handRoll == 3)
                    {
                        src = aegisHand4;
                    }

                    float spawnX = rr.Next(0, (int)(worldWidth - src.Width));
                    float groundY = hero.R.Y + hero.R.Height;

                    AegisAbility ability = new AegisAbility("hand", spawnX, groundY, src);
                    ability.stayDuration = 90;
                    ability.riseSpeed = 9f;
                    aegisAbilities.Add(ability);
                }
            }
            else if (rand == 1)
            {
                float spawnX = hero.R.X + hero.R.Width / 2f - aegisTentacle.Width / 2f;
                float groundY = hero.R.Y + hero.R.Height;

                AegisAbility ability = new AegisAbility("tentacle", spawnX, groundY, aegisTentacle);
                ability.stayDuration = 120;
                ability.riseSpeed = 12f;
                aegisAbilities.Add(ability);
            }
            else if (rand == 2)
            {
                float spawnX = R.X + R.Width / 2f - aegisVoidCircle.Width / 2f;
                float spawnY = R.Y + R.Height / 2f - aegisVoidCircle.Height / 2f;

                AegisAbility ability = new AegisAbility("voidCircle", spawnX, spawnY + aegisVoidCircle.Height, aegisVoidCircle);
                ability.R.Y = spawnY;
                ability.escapeMax = 260;
                ability.voidSpeed = 18f;
                aegisAbilities.Add(ability);
            }
        }

        void updateAegisAbilities(Hero hero)
        {
            for (int i = aegisAbilities.Count - 1; i >= 0; i--)
            {
                AegisAbility a = aegisAbilities[i];

                if (a.isDone == true)
                {
                    aegisAbilities.RemoveAt(i);
                }
                else
                {

                    if (a.type == "voidCircle")
                    {
                        updateVoidCircle(a, hero);
                    }
                    else
                    {
                        updateRisingAbility(a, hero);
                    }
                }
                
            }
        }

        void updateRisingAbility(AegisAbility a, Hero hero)
        {
            if (a.hitCooldown > 0)
            {
                a.hitCooldown--;
            }

            if (a.revealAmount > 0f)
            {
                float visibleTop = (a.R.Y + a.R.Height) - a.revealAmount;
                float visibleBottom = a.R.Y + a.R.Height;

                if (a.R.X < hero.R.X + hero.R.Width)
                {
                    if (a.R.X + a.R.Width > hero.R.X)
                    {
                        if (visibleTop < hero.R.Y + hero.R.Height)
                        {
                            if (visibleBottom > hero.R.Y)
                            {
                                if (a.hitCooldown <= 0)
                                {
                                    if (hero.isDead == false)
                                    {
                                        if (a.revealAmount >= a.fullHeight / 4)
                                        {
                                            hero.takeDamage(10);
                                            a.hitCooldown = 30;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (a.phase == 0)
            {
                a.revealAmount += a.riseSpeed;

                if (a.revealAmount >= a.fullHeight)
                {
                    a.revealAmount = a.fullHeight;
                    a.phase = 1;
                    a.stayTimer = 0;
                }
            }
            else if (a.phase == 1)
            {
                a.stayTimer++;

                if (a.stayTimer >= a.stayDuration)
                {
                    a.phase = 2;
                }
            }
            else if (a.phase == 2)
            {
                a.revealAmount -= a.riseSpeed;

                if (a.revealAmount <= 0f)
                {
                    a.revealAmount = 0f;
                    a.isDone = true;
                }
            }
        }

        void updateVoidCircle(AegisAbility a, Hero hero)
        {
            a.pulseTimer += a.pulseDirection;

            if (a.pulseTimer >= 12)
            {
                a.pulseTimer = 12;
                a.pulseDirection = -1;
            }
            else if (a.pulseTimer <= -12)
            {
                a.pulseTimer = -12;
                a.pulseDirection = 1;
            }

            a.pulseSize = a.pulseTimer;

            float heroCX = hero.R.X + hero.R.Width / 2f;
            float heroCY = hero.R.Y + hero.R.Height / 2f;
            float myCX = a.R.X + a.R.Width / 2f;
            float myCY = a.R.Y + a.R.Height / 2f;

            float diffX = heroCX - myCX;
            float diffY = heroCY - myCY;

            float diffXnew = diffX;
            float diffYnew = diffY;

            if (diffXnew < 0f)
            {
                diffXnew = -diffX;
            }

            if (diffYnew < 0f)
            {
                diffYnew = -diffY;
            }

            float dist = diffXnew + diffYnew;

            if (dist > 800f)
            {
                a.escapeTimer++;

                if (a.escapeTimer >= a.escapeMax)
                {
                    a.isDone = true;
                    return;
                }
            }
            else
            {
                a.escapeTimer = 0;
            }

            if (dist > 0f)
            {
                float stepX = 0f;
                float stepY = 0f;

                if (diffXnew > 0f)
                {
                    stepX = (diffX / dist) * a.voidSpeed;
                }

                if (diffYnew > 0f)
                {
                    stepY = (diffY / dist) * a.voidSpeed;
                }

                a.R.X += stepX;
                a.R.Y += stepY;
            }

            bool overlapX = false;
            bool overlapY = false;

            if (a.R.X < hero.R.X + hero.R.Width)
            {
                if (a.R.X + a.R.Width > hero.R.X)
                {
                    overlapX = true;
                }
            }

            if (a.R.Y < hero.R.Y + hero.R.Height)
            {
                if (a.R.Y + a.R.Height > hero.R.Y)
                {
                    overlapY = true;
                }
            }

            if (overlapX == true)
            {
                if (overlapY == true)
                {
                    if (hero.isDead == false)
                    {
                        hero.takeDamage(8);
                        a.isDone = true;
                    }
                }
            }
        }

        void drawAegisAbilities(Graphics g, float camX, float camY, bool showRanges)
        {
            for (int i = 0; i < aegisAbilities.Count; i++)
            {
                AegisAbility a = aegisAbilities[i];

                if (a.type == "voidCircle")
                {
                    float pulse = a.pulseSize;

                    float size = 120f;
                    float drawW = size + pulse;
                    float drawH = size + pulse;
                    float drawX = a.R.X + a.R.Width / 2f - drawW / 2f;
                    float drawY = a.R.Y + a.R.Height / 2f - drawH / 2f;

                    g.DrawImage(
                        a.img,
                        new Rectangle((int)(drawX - camX), (int)(drawY - camY), (int)drawW, (int)drawH),
                        new Rectangle(0, 0, a.img.Width, a.img.Height),
                        GraphicsUnit.Pixel
                    );

                    if (showRanges)
                    {
                        Pen pn = new Pen(Color.Cyan, 2);

                        g.DrawRectangle(pn, drawX - camX, drawY - camY, drawW, drawH);
                    }
                }
                else
                {
                    float revealAmount = a.revealAmount;

                    if (revealAmount > 0f)
                    {
                        int srcH = (int)revealAmount;
                        float dstH = revealAmount;
                        float dstY = (a.R.Y + a.R.Height) - dstH;

                        g.DrawImage(
                            a.img,
                            new Rectangle((int)(a.R.X - camX), (int)(dstY - camY), (int)a.R.Width, (int)dstH),
                            new Rectangle(0, 0, a.img.Width, srcH),
                            GraphicsUnit.Pixel
                        );

                        if (showRanges)
                        {
                            Pen lime = new Pen(Color.Lime, 2);
                            Pen red = new Pen(Color.Red, 2);

                            float visibleTop = (a.R.Y + a.R.Height) - revealAmount;
                            g.DrawRectangle(lime, a.R.X - camX, visibleTop - camY, a.R.Width, revealAmount);

                            g.DrawRectangle(red, a.R.X - camX, a.R.Y - camY, a.R.Width, a.R.Height);
                        }
                    }
                }
            }
        }


        void updateAegis(Hero hero, float worldWidth)
        {
            if (startFight == false)
            {
                anim.changeAnimation("idle", -1);
                return;
            }

            updateAegisAbilities(hero);

            if (aegisAbilityCooldown > 0)
            {
                aegisAbilityCooldown--;
            }
            else
            {
                int spawnOneOrMore = rr.Next(0, 4);

                int ctSpawn= -1;
                if(spawnOneOrMore < 3)
                {
                    ctSpawn = 1;
                }
                else
                {
                    ctSpawn = rr.Next(1, 6);
                }

                for (int i = 0; i < ctSpawn; i++)
                {
                    spawnAegisAbility(hero, worldWidth);
                }
                aegisAbilityCooldown = aegisAbilityCooldownMax;
            }

            anim.changeAnimation("idle", -1);
        }
        public void Update(Hero hero, float worldWidth, float worldHeight, List<Enemy> enemies)
        {
            updateDrawR();

            updateFightStart(hero);

            if (attackCooldown > 0)
            {
                attackCooldown--;
            }

            if (isDead)
            {
                deathTimer++;

                if (name == "Reaper")
                {
                    anim.changeAnimation("death", -1);
                }

                return;
            }

            if (isTakingDamage)
            {
                damageTimer--;
                if (damageTimer <= 0)
                {
                    isTakingDamage = false;
                }
                updateIdleAnimation();
                return;
            }

            if (name == "Aegis")
            {
                updateAegis(hero , worldWidth);
                return;
            }

            if (name == "Minatour")
            {
                updateMinatour(hero, worldWidth);
                return;
            }

            if (name == "Reaper")
            {
                updateReaper(hero, worldWidth, worldHeight, enemies);
                return;
            }

            updateIdleAnimation();
        }

        void updateFightStart(Hero hero)
        {
            if (startFight == true)
            {
                return;
            }

            float distanceX = 0;
            if (hero.R.X > R.X)
            {
                distanceX = hero.R.X - R.X;
            }
            else
            {
                distanceX = R.X - hero.R.X;
            }

            float distanceY = 0;
            if (hero.R.Y > R.Y)
            {
                distanceY = hero.R.Y - R.Y;
            }
            else
            {
                distanceY = R.Y - hero.R.Y;
            }

            if (distanceX <= 200)
            {
                if (distanceY <= 200)
                {
                    startFight = true;
                }
            }
        }

        void updateIdleAnimation()
        {
            anim.changeAnimation("idle", -1);
        }

        void updateMinatour(Hero hero, float worldWidth)
        {
            if (startFight == false)
            {
                anim.changeAnimation("idle", -1);
                return;
            }

            if (isAttacking)
            {
                attackFrameTimer--;

                if (attackFrameTimer <= 0)
                {
                    isAttacking = false;
                    attackDamageDone = false;
                    attackCooldown = 80;
                }
                else
                {
                    if (anim.currIdx >= 4 && attackDamageDone == false)
                    {
                        hero.takeDamage(20);
                        attackDamageDone = true;
                    }
                }

                return;
            }

            float distanceX = 0;
            float distanceY = 0;
            if (hero.R.X > R.X)
            {
                distanceX = hero.R.X - R.X;
                moving = 'r';
                facing = 'r';
            }
            else
            {
                distanceX = R.X - hero.R.X;
                moving = 'l';
                facing = 'l';
            }

            if (hero.R.Y > R.Y)
            {
                distanceY = hero.R.Y - R.Y;
            }
            else
            {
                distanceY = R.Y - hero.R.Y;
            }

            bool inRange = distanceX <= attackDistance && distanceY <= attackDistance;

            if (inRange)
            {
                if (attackCooldown <= 0)
                {
                    isAttacking = true;
                    attackDamageDone = false;
                    attackFrameTimer = 18;
                    anim.changeAnimation("atk_1", -1);
                    anim.restart();
                }
                else
                {
                    anim.changeAnimation("idle", -1);
                }
                return;
            }

            if (distanceX > attackDistance)
            {
                if (moving == 'l')
                {
                    R.X -= speed;

                    if (R.X < 0)
                    {
                        R.X = 0;
                    }
                }
                else
                {
                    R.X += speed;

                    if (R.X + R.Width > worldWidth)
                    {
                        R.X = worldWidth - R.Width;
                    }
                }

                anim.changeAnimation("walk", -1);
            }
            else
            {
                anim.changeAnimation("idle", -1);
            }
        }

        void updateReaper(Hero hero, float worldWidth, float worldHeight, List<Enemy> enemies)
        {
            if (startFight == false)
            {
                anim.changeAnimation("idle", -1);
                summonTick = 0;
                summonAnimTimer = 0;
                return;
            }

            if (summonAnimTimer > 0)
            {
                summonAnimTimer--;
                anim.changeAnimation("summon", -1);
                return;
            }

            summonTick++;
            if (summonTick >= summonGap)
            {
                summonTick = 0;
                anim.changeAnimation("summon", -1);
                anim.restart();
                summonAnimTimer = 40;
                spawnSummons(hero, enemies, worldWidth, worldHeight);
                return;
            }

            if (isAttacking)
            {
                attackFrameTimer--;

                if (attackFrameTimer <= 0)
                {
                    isAttacking = false;
                    attackDamageDone = false;
                    attackCooldown = 80;

                    if (doSpin)
                    {
                        doSpin = false;
                        spinDamageTimer = 0;
                    }
                }
                else
                {
                    if (doSpin)
                    {
                        saveReaperTarget(hero);
                        moveReaperTowardsTarget(hero, worldWidth, worldHeight);

                        spinDamageTimer++;
                        if (spinDamageTimer >= spinDamageInterval)
                        {
                            spinDamageTimer = 0;

                            bool spinHit = false;
                            if (R.X <= hero.R.X + hero.R.Width &&
                                R.X + R.Width >= hero.R.X &&
                                R.Y <= hero.R.Y + hero.R.Height &&
                                R.Y + R.Height >= hero.R.Y)
                            {
                                spinHit = true;
                            }

                            if (spinHit)
                            {
                                hero.takeDamage(20);
                            }
                        }
                    }
                    else
                    {
                        if (anim.currIdx >= 8 && attackDamageDone == false)
                        {
                            bool canHit1 = false;
                            if (R.X <= hero.R.X + hero.R.Width &&
                                R.X + R.Width >= hero.R.X &&
                                R.Y <= hero.R.Y + hero.R.Height &&
                                R.Y + R.Height >= hero.R.Y)
                            {
                                canHit1 = true;
                            }

                            if (canHit1 == true)
                            {
                                hero.takeDamage(15);
                            }
                            attackDamageDone = true;
                        }
                        else if (anim.currIdx == 2)
                        {
                            bool canHit1 = false;
                            if (R.X <= hero.R.X + hero.R.Width &&
                                R.X + R.Width >= hero.R.X &&
                                R.Y <= hero.R.Y + hero.R.Height &&
                                R.Y + R.Height >= hero.R.Y)
                            {
                                canHit1 = true;
                            }

                            if (canHit1 == true)
                            {
                                hero.takeDamage(10);
                            }
                        }
                    }
                }

                return;
            }

            bool canHit = false;
            if(R.X <= hero.R.X + hero.R.Width &&
                R.X + R.Width >= hero.R.X &&
                R.Y <= hero.R.Y + hero.R.Height &&
                R.Y + R.Height >= hero.R.Y)
            {
                canHit = true;
            }

            bool isClose = false;
            int gap = 200;
            if (R.X <= hero.R.X + hero.R.Width  + gap &&
                R.X + R.Width + gap >= hero.R.X &&
                R.Y <= hero.R.Y + hero.R.Height + gap &&
                R.Y + R.Height + gap  >= hero.R.Y)
            {
                isClose = true;
            }
            if (doSpin == false)
            {
                spinTimer++;
            }
            if(isClose == true)
            {
                if (spinTimer >= spinCooldown)
                {
                    spinTimer = 0;
                    if (rr.Next(0, 100) <= spinChance)
                    {
                        doSpin = true;
                        isAttacking = true;

                        attackCooldown = 80;
                        attackDamageDone = false;
                        attackFrameTimer = 11;
                        anim.changeAnimation("skill1", -1);
                        anim.restart();
                    }
                    return;
                }
            }

            if (canHit == true)
            {
                if (attackCooldown <= 0)
                {
                    isAttacking = true;
                    attackDamageDone = false;
                    attackFrameTimer = 13;
                    anim.changeAnimation("attacking", -1);
                    anim.restart();
                }
                else
                {
                    anim.changeAnimation("idle", -1);
                }
                return;
            }

            float heroCenterX = hero.R.X + hero.R.Width / 2f;
            float heroCenterY = hero.R.Y + hero.R.Height / 2f;
            float reaperCenterX = R.X + R.Width / 2f;
            float reaperCenterY = R.Y + R.Height / 2f;

            float distanceX = heroCenterX - reaperCenterX;
            float distanceY = heroCenterY - reaperCenterY;

            if (distanceX < 0f)
            {
                distanceX = -distanceX;
            }

            if (distanceY < 0f)
            {
                distanceY = -distanceY;
            }

            if (distanceX <= 120f && distanceY <= 120f)
            {
                if (reaperCloseDelayTimer <= 0)
                {
                    reaperCloseDelayTimer = reaperCloseDelayMax;
                }
            }

            if (reaperCloseDelayTimer > 0)
            {
                reaperCloseDelayTimer--;
                anim.changeAnimation("idle", -1);
                return;
            }

            if (hasTarget == false)
            {
                saveReaperTarget(hero);
            }
            else if (shouldRetargetReaper(hero))
            {
                saveReaperTarget(hero);
            }

            moveReaperTowardsTarget(hero, worldWidth, worldHeight);

            if (reaperReachedTarget() == true)
            {
                hasTarget = false;
                saveReaperTarget(hero);
            }

            anim.changeAnimation("idle", -1);
        }

        void spawnSummons(Hero hero, List<Enemy> enemies, float worldWidth, float worldHeight)
        {
            int summonCount = rr.Next(2, 5);
            List<int> slots = new List<int>();
            slots.Add(0);
            slots.Add(1);
            slots.Add(2);
            slots.Add(3);

            int bossCenterX = Convert.ToInt32(R.X + R.Width / 2f);
            int bossCenterY = Convert.ToInt32(R.Y + R.Height / 2f);

            for (int i = 0; i < summonCount; i++)
            {
                int slotIndex = rr.Next(0, slots.Count);
                int targetIndex = slots[slotIndex];
                slots.RemoveAt(slotIndex);

                int summonWidth = 70;
                int summonHeight = 70;

                int spawnX = 0;
                int spawnY = 0;

                if (targetIndex == 0)
                {
                    spawnX = bossCenterX - summonWidth / 2;
                    spawnY = Convert.ToInt32(R.Y) - summonHeight - 30;
                }
                else if (targetIndex == 1)
                {
                    spawnX = Convert.ToInt32(R.X) - summonWidth - 30;
                    spawnY = bossCenterY - summonHeight / 2;
                }
                else if (targetIndex == 2)
                {
                    spawnX = Convert.ToInt32(R.X + R.Width) + 30;
                    spawnY = bossCenterY - summonHeight / 2;
                }
                else if (targetIndex == 3)
                {
                    spawnX = bossCenterX - summonWidth / 2;
                    spawnY = Convert.ToInt32(R.Y + R.Height) + 30;
                }

                if (spawnX < 0)
                {
                    spawnX = 0;
                }
                else if (spawnX + summonWidth > worldWidth)
                {
                    spawnX = Convert.ToInt32(worldWidth) - summonWidth;
                }

                if (spawnY < 0)
                {
                    spawnY = 0;
                }
                else if (spawnY + summonHeight > worldHeight)
                {
                    spawnY = Convert.ToInt32(worldHeight) - summonHeight;
                }

                Enemy summon = new Enemy(spawnX, spawnY, summonWidth, summonHeight, "summon");
                summon.spawn = true;
                summon.spawnrange = 4000;
                summon.CanSpawn = false;
                summon.spawnTime = 0;
                summon.isWaiting = false;
                summon.isRunning = false;
                summon.isAttacking = false;
                summon.isTakingDamage = false;
                summon.isDead = false;
                summon.attackCooldown = rr.Next(10, 30);
                summon.summonSlot = targetIndex;
                summon.velocityY = 0f;
                summon.isGrounded = true;
                summon.wasGrounded = true;

                if (targetIndex == 0)
                {
                    summon.facing = 'l';
                    summon.moving = ' ';
                }
                else if (targetIndex == 1)
                {
                    summon.facing = 'r';
                    summon.moving = 'r';
                }
                else if (targetIndex == 2)
                {
                    summon.facing = 'l';
                    summon.moving = 'l';
                }
                else if (targetIndex == 3)
                {
                    summon.facing = 'l';
                    summon.moving = ' ';
                }

                enemies.Add(summon);
            }
        }

        bool shouldRetargetReaper(Hero hero)
        {
            float heroCenterX = hero.R.X + hero.R.Width / 2f;
            float heroCenterY = hero.R.Y + hero.R.Height / 2f;
            float reaperCenterX = R.X + R.Width / 2f;
            float reaperCenterY = R.Y + R.Height / 2f;

            float diffX = heroCenterX - reaperCenterX;
            float diffY = heroCenterY - reaperCenterY;

            if (diffX < 0f)
            {
                diffX = -diffX;
            }

            if (diffY < 0f)
            {
                diffY = -diffY;
            }

            if (diffX > 200f)
            {
                return true;
            }

            if (diffY > 200f)
            {
                return true;
            }

            return false;
        }

        void saveReaperTarget(Hero hero)
        {
            float heroCenterX = hero.R.X + hero.R.Width / 2f;
            float heroCenterY = hero.R.Y + hero.R.Height / 2f;

            targetX = heroCenterX - R.Width / 2f;
            targetY = heroCenterY - R.Height / 2f - 50f;
            hasTarget = true;

            float diffX = targetX - R.X;
            float diffY = targetY - R.Y;

            if (diffX < 0f)
            {
                if (diffY < 0f)
                {
                    movingDir = "upLeft";
                }
                else if (diffY > 0f)
                {
                    movingDir = "downLeft";
                }
                else
                {
                    movingDir = "left";
                }

                moving = 'l';
                facing = 'l';
            }
            else if (diffX > 0f)
            {
                if (diffY < 0f)
                {
                    movingDir = "upRight";
                }
                else if (diffY > 0f)
                {
                    movingDir = "downRight";
                }
                else
                {
                    movingDir = "right";
                }

                moving = 'r';
                facing = 'r';
            }
            else
            {
                if (diffY < 0f)
                {
                    movingDir = "up";
                }
                else if (diffY > 0f)
                {
                    movingDir = "down";
                }
                else
                {
                    movingDir = "none";
                }
            }
        }

        void moveReaperTowardsTarget(Hero hero, float worldWidth, float worldHeight)
        {
            float step = speed;
            float diagonalStep = speed;

            float moveX = 0f;
            float moveY = 0f;
            float remainingX = targetX - R.X;
            float remainingY = targetY - R.Y;

            if (remainingX < 0f)
            {
                remainingX = -remainingX;
            }

            if (remainingY < 0f)
            {
                remainingY = -remainingY;
            }

            if (movingDir == "left")
            {
                if (remainingX < step)
                {
                    moveX = -remainingX;
                }
                else
                {
                    moveX = -step;
                }
            }
            else if (movingDir == "right")
            {
                if (remainingX < step)
                {
                    moveX = remainingX;
                }
                else
                {
                    moveX = step;
                }
            }
            else if (movingDir == "up")
            {
                if (remainingY < step)
                {
                    moveY = -remainingY;
                }
                else
                {
                    moveY = -step;
                }
            }
            else if (movingDir == "down")
            {
                if (remainingY < step)
                {
                    moveY = remainingY;
                }
                else
                {
                    moveY = step;
                }
            }
            else if (movingDir == "upLeft")
            {
                if (remainingX < diagonalStep)
                {
                    moveX = -remainingX;
                }
                else
                {
                    moveX = -diagonalStep;
                }

                if (remainingY < diagonalStep)
                {
                    moveY = -remainingY;
                }
                else
                {
                    moveY = -diagonalStep;
                }
            }
            else if (movingDir == "upRight")
            {
                if (remainingX < diagonalStep)
                {
                    moveX = remainingX;
                }
                else
                {
                    moveX = diagonalStep;
                }

                if (remainingY < diagonalStep)
                {
                    moveY = -remainingY;
                }
                else
                {
                    moveY = -diagonalStep;
                }
            }
            else if (movingDir == "downLeft")
            {
                if (remainingX < diagonalStep)
                {
                    moveX = -remainingX;
                }
                else
                {
                    moveX = -diagonalStep;
                }

                if (remainingY < diagonalStep)
                {
                    moveY = remainingY;
                }
                else
                {
                    moveY = diagonalStep;
                }
            }
            else if (movingDir == "downRight")
            {
                if (remainingX < diagonalStep)
                {
                    moveX = remainingX;
                }
                else
                {
                    moveX = diagonalStep;
                }

                if (remainingY < diagonalStep)
                {
                    moveY = remainingY;
                }
                else
                {
                    moveY = diagonalStep;
                }
            }

            float nextX = R.X + moveX;
            float nextY = R.Y + moveY;

            if (nextX < 0f)
            {
                nextX = 0f;
            }
            else if (nextX + R.Width > worldWidth)
            {
                nextX = worldWidth - R.Width;
            }

            if (nextY < 0f)
            {
                nextY = 0f;
            }
            else if (nextY + R.Height > worldHeight)
            {
                nextY = worldHeight - R.Height;
            }

            R.X = nextX;
            R.Y = nextY;

            updateDrawR();
        }

        bool reaperReachedTarget()
        {
            float diffX = R.X - targetX;
            float diffY = R.Y - targetY;

            if (diffX < 0f)
            {
                diffX = -diffX;
            }

            if (diffY < 0f)
            {
                diffY = -diffY;
            }

            if (diffX <= speed)
            {
                if (diffY <= speed)
                {
                    return true;
                }
            }

            return false;
        }

        int calculateHowValue()
        {
            int minValue = HP.maxHP / 2;
            int maxValue = HP.maxHP + (HP.maxHP / 2);

            if (minValue < 1)
            {
                minValue = 1;
            }

            if (maxValue < minValue)
            {
                maxValue = minValue;
            }

            return rr.Next(minValue, maxValue + 1);
        }

        int[] calculateHowManyCoins()
        {
            int[] coins = { 0, 0, 0 };
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

        float getDropX(int slot)
        {
            float spacing = 8f;
            if (slot == 0)
            {
                return 0f;
            }

            int step = (slot + 1) / 2;

            if (slot % 2 == 1)
            {
                return -spacing * step;
            }

            return spacing * step;
        }

        int addCoins(List<DroppedCoin> droppedCoins, string type, int count, float baseX, float baseY, int slot)
        {
            for (int i = 0; i < count; i++)
            {
                float x = baseX + getDropX(slot);
                DroppedCoin coin = new DroppedCoin(x, baseY, type, 1);
                droppedCoins.Add(coin);
                slot++;
            }

            return slot;
        }

        int addValueCoins(List<DroppedCoin> droppedCoins, float baseX, float baseY, int totalValue, int minCount, int maxCount, int slot)
        {
            int coinCount = rr.Next(minCount, maxCount + 1);

            if (coinCount < 1)
            {
                coinCount = 1;
            }

            if (coinCount > totalValue)
            {
                coinCount = totalValue;
            }

            int remaining = totalValue;

            for (int i = 0; i < coinCount; i++)
            {
                int coinsLeft = coinCount - i;
                int value = remaining;

                if (coinsLeft > 1)
                {
                    int target = remaining / coinsLeft;
                    int min = target / 2;
                    int max = target + target / 2;
                    int maxAllowed = remaining - (coinsLeft - 1);

                    if (min < 1)
                    {
                        min = 1;
                    }

                    if (remaining >= 100 && min < 100)
                    {
                        min = 100;
                    }

                    if (max > maxAllowed)
                    {
                        max = maxAllowed;
                    }

                    if (max < min)
                    {
                        max = min;
                    }

                    value = rr.Next(min, max + 1);

                    if (value > maxAllowed)
                    {
                        value = maxAllowed;
                    }
                }

                if (value < 1)
                {
                    value = 1;
                }

                float x = baseX + getDropX(slot);
                DroppedCoin coin = new DroppedCoin(x, baseY, "copper", value);
                droppedCoins.Add(coin);
                slot++;
                remaining -= value;
            }

            return slot;
        }

        public void dropCollectables(List<DroppedCoin> droppedCoins, List<DroppedPotion> droppedPotions)
        {
            if (coindropped == true)
            {
                return;
            }

            float baseX = R.X + (R.Width / 2f);
            float baseY = R.Y + (R.Height / 2f);
            int slot = 0;

            int totalValue = calculateHowValue();
            slot = addValueCoins(droppedCoins, baseX, baseY, totalValue, 2, 4, slot);

            coindropped = true;

            if (name == "Minatour")
            {
                int healthCount = rr.Next(1, 3);
                int manaCount = rr.Next(1, 3);

                for (int i = 0; i < healthCount; i++)
                {
                    DroppedPotion potion = new DroppedPotion("largeHealth", baseX + (i * 25) - 12, baseY - 20);
                    droppedPotions.Add(potion);
                }

                for (int i = 0; i < manaCount; i++)
                {
                    DroppedPotion potion = new DroppedPotion("largeMana", baseX + (i * 25) - 12, baseY - 40);
                    droppedPotions.Add(potion);
                }

                if (rr.Next(0, 100) < 20)
                {
                    DroppedPotion potion = new DroppedPotion("golden", baseX, baseY - 60);
                    droppedPotions.Add(potion);
                }
            }
            else
            {
                int[] rate = { 50, 25, 15, 10 };
                string[] potionNames = { "health", "mana", "golden", "suspicious" };
                int totalrate = 0;
                for (int i = 0; i < rate.Length; i++)
                {
                    totalrate += rate[i];
                }
                int roll = rr.Next(0, totalrate);
                int cumulative = 0;
                for (int i = 0; i < rate.Length; i++)
                {
                    cumulative += rate[i];
                    if (roll < cumulative) { string chosen = potionNames[i]; DroppedPotion potion = new DroppedPotion(chosen, baseX, baseY - 20); droppedPotions.Add(potion); break; }
                }
            }
        }

        public void Draw(Graphics g, bool showRanges, float camX, float camY)
        {
            updateDrawR();
            updateDamagePopups();

            if (isDead)
            {
                if (name != "Reaper")
                {
                    drawDamagePopups(g, camX, camY);
                    return;
                }

                Animation deathAnim = anim.getCurrentAnimation();
                if (deathAnim != null)
                {
                    List<Bitmap> deathFrames = deathAnim.getFrames(moving == 'l');
                    if (deathFrames.Count > 0 && deathTimer > deathFrames.Count * deathAnim.frameDelay)
                    {
                        return;
                    }
                }
            }

            Bitmap frame;

            if (isDead)
            {
                if (name == "Reaper")
                {
                    if (moving == 'l')
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
                    frame = null;
                }
            }
            else if (isTakingDamage)
            {
                if (moving == 'l')
                {
                    frame = anim.playFrameOnce(true, true);
                }
                else
                {
                    frame = anim.playFrameOnce(false, true);
                }
            }
            else if (isAttacking)
            {
                if (moving == 'l')
                {
                    frame = anim.playFrameOnce(true, true);
                }
                else
                {
                    frame = anim.playFrameOnce(false, true);
                }
            }
            else if (isWakingUp)
            {
                if (moving == 'l')
                {
                    frame = anim.playFrameOnce(true, true);
                }
                else
                {
                    frame = anim.playFrameOnce(false, true);
                }
            }
            else if (name == "Aegis")
            {
                frame = anim.playFrame(false, false);
            }
            else if (moving == 'l')
            {
                frame = anim.playFrame(true, true);
            }
            else
            {
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


            }
            if (name == "Aegis")
            {
                drawAegisAbilities(g, camX, camY , showRanges);
            }

            if (startFight == true && !isDead)
            {
                bossUI.draw(g, HP.HP, HP.maxHP);
            }

            drawDamagePopups(g, camX, camY);
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

        List<Button> WinBtns = new List<Button>();
        int currWinBtn = 0;
        bool isWinScreenShown = false;

        bool showRanges = false;
        Bitmap off; 
        Random RR = new Random();

        bool isLevelIntroVisible = false;
        int levelIntroTimer = 0;
        int levelIntroTimerMax = 10;
        int levelIntroNumber = 1;
        bool isVictory = false;

        float camX = 0;
        float camY = 0;


        levelController levels;

        Hero hero;
        EnemyController enemyController = new EnemyController();
        List<tile> tiles = new List<tile>();
        List<Ladder> ladders = new List<Ladder>();
        List<DroppedCoin> droppedCoins = new List<DroppedCoin>();
        List<DroppedPotion> droppedPotions = new List<DroppedPotion>();
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
                        save.save(hero, enemyController.enemies , levels, levels.currentLevel);
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
            else if (isWinScreenShown == true)
            {
                for (int i = 0; i < WinBtns.Count; i++)
                {
                    Button btn = WinBtns[i];
                    if (e.X > btn.rect.X && e.X < btn.rect.X + btn.rect.Width
                                && e.Y > btn.rect.Y && e.Y < btn.rect.Y + btn.rect.Height)
                    {
                        currWinBtn = i;
                        manageWinScreen();
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

                if (hero.inventory.isOpen)
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

                if (hero.inventory.isOpen)
                {
                    hero.inventory.updateHover(e.X, e.Y, hero, this);
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

            if (e.KeyCode == Keys.F)
            {
                hero.stopShield();
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                hero.isRunning = false;
            }

            if (e.KeyCode == Keys.R)
            {
                hero.kamehameha.stop();
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
                            save.save(hero, enemyController.enemies , levels, levels.currentLevel);

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
                else if (isWinScreenShown == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        manageWinScreen();
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
                        if (levels.currentLevel < levels.levels.Count - 1)
                        {
                            if (levels.levels[levels.currentLevel].teleporter.isHeroInRange == true)
                            {
                                 if (e.KeyCode == Keys.Q && !IsBossGateActive())
                                 {
                                     int oldLevel = levels.currentLevel;
                                     levels.nextLevel(hero, enemyController.enemies, ladders, tiles, droppedCoins, droppedPotions, movingPlatforms);

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

                    if (e.KeyCode == Keys.I)
                    {
                        hero.inventory.isOpen = !hero.inventory.isOpen;
                        return;
                    }
                    if (hero.inventory.isOpen)
                    {
                        if (e.KeyCode == Keys.Escape)
                        {
                            hero.inventory.isOpen = false;
                        }
                        return;
                    }

                    if (e.KeyCode == Keys.Escape)
                    {
                        isGamePaused = true;
                        pauseGame();
                    }
                    if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && hero.isDead == false)
                    {
                        if (hero.kamehameha.active == true)
                        {
                            hero.facing = 'r';
                        }
                        else if (hero.R.X + hero.R.Width < levels.levels[levels.currentLevel].worldWidth)
                        {
                            hero.moving = 'r';
                            hero.facing = 'r';
                        }
                    }
                    if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && hero.isDead == false)
                    {
                        if (hero.kamehameha.active == true)
                        {
                            hero.facing = 'l';
                        }
                        else if (hero.R.X > 0)
                        {
                            hero.moving = 'l';
                            hero.facing = 'l';
                        }
                    }
                    if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                    {
                        hero.checkUnder(tiles, ladders);
                    }
                    if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && hero.kamehameha.active == false)
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

                    if (e.KeyCode == Keys.ShiftKey && hero.isAttacking == false && hero.kamehameha.active == false)
                    {
                        hero.isRunning = true;
                    }


                    if (e.KeyCode == Keys.P)
                    {
                        if (showRanges == true) showRanges = false;
                        else showRanges = true;
                    }

                    if(e.KeyCode == Keys.F)
                    {
                        hero.startShield();
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
                        else if (hero.kamehameha.active == false)
                        {
                            if (hero.mana.mana > 0f)
                            {
                                hero.isLaserCasting = true;
                                hero.isLaserCastFinishing = false;

                                float startX = 0f;
                                if (hero.facing == 'r')
                                {
                                    startX = hero.R.X + hero.R.Width;
                                }
                                else
                                {
                                    startX = hero.R.X;
                                }

                                float startY = hero.R.Y + hero.R.Height * 0.4f;
                                hero.kamehameha.activate(startX, startY, hero.facing, this.ClientSize.Width, hero.ColorIdx);
                            }
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

                    if(e.KeyCode == Keys.H && hero.inventory.getPotionCount("health") > 0)
                    {
                        if (hero.HP.HP < hero.HP.maxHP)
                        {
                            hero.restoreHealth(30);
                            hero.inventory.removePotion("health");
                        }
                    }
                    if(e.KeyCode == Keys.M && hero.inventory.getPotionCount("mana") > 0)
                    {
                        if (hero.mana.mana < hero.mana.maxMana)
                        {
                            hero.restoreMana(30);
                            hero.inventory.removePotion("mana");
                        }
                    }
                    if(e.KeyCode == Keys.D4 && hero.inventory.getPotionCount("golden") > 0)
                    {
                        hero.useGoldenPotion();
                        hero.inventory.removePotion("golden");
                    }
                    if(e.KeyCode == Keys.D5 && hero.inventory.getPotionCount("suspicious") > 0)
                    {
                        hero.useSuspiciousPotion();
                        hero.inventory.removePotion("suspicious");
                    }
                    if (levels.currentLevel < levels.levels.Count - 1)
                    {
                        if (levels.levels[levels.currentLevel].teleporter.isHeroInRange == true)
                        {
                            if (e.KeyCode == Keys.Q && !IsBossGateActive())
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
                                     levels.nextLevel(hero, enemyController.enemies, ladders, tiles, droppedCoins, droppedPotions, movingPlatforms);

                                     if (levels.currentLevel != oldLevel)
                                    {
                                        hero.R.X = levels.getNewHeroX();
                                        hero.R.Y = levels.getNewHeroY();
                                        startLevelIntro();
                                    }
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

                if (hero.inventory.isOpen)
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

                        if (levels.currentLevel >= 0 && levels.currentLevel < levels.levels.Count)
                        {
                            if (droppedCoins[i].isOutOfMap(levels.levels[levels.currentLevel].worldWidth, levels.levels[levels.currentLevel].worldHeight))
                            {
                                hero.coins += droppedCoins[i].coinvalue;
                                droppedCoins.RemoveAt(i);
                                i--;
                            }
                        }
                    }

                    for (int i = 0; i < droppedPotions.Count; i++)
                    {
                        droppedPotions[i].update(tiles);

                        if (levels.currentLevel >= 0 && levels.currentLevel < levels.levels.Count)
                        {
                            if (droppedPotions[i].isOutOfMap(levels.levels[levels.currentLevel].worldWidth, levels.levels[levels.currentLevel].worldHeight))
                            {
                                droppedPotions.RemoveAt(i);
                                i--;
                            }
                        }
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

                    boss currentBoss = levels.getCurrentBoss();

                    if (hero.currentWeapon == 0)
                    {
                        hero.updateAttack(enemyController.enemies, currentBoss);
                    }

                    for (int i = 0; i < movingPlatforms.Count; i++)
                    {
                        movingPlatforms[i].move();
                    }

                    hero.move(tiles, ladders, levels.levels[levels.currentLevel].worldWidth , movingPlatforms);
                    hero.collectDroppedCoins(droppedCoins);
                    hero.collectDroppedPotions(droppedPotions);

                    hero.updateFireballCast(enemyController.enemies, currentBoss, tiles);
                    hero.updateSingleFireballAbility(enemyController.enemies, tiles);
                    hero.kamehameha.update(hero, enemyController.enemies, currentBoss, tiles, camX, this.ClientSize.Width);

                    hero.mana.tick();

                    if (currentBoss != null)
                    {
                        if (levels.currentLevel >= 0 && levels.currentLevel < levels.levels.Count)
                        {
                            currentBoss.Update(hero, levels.levels[levels.currentLevel].worldWidth, levels.levels[levels.currentLevel].worldHeight, enemyController.enemies);
                        }

                        if (currentBoss.isDead == true && currentBoss.coindropped == false)
                        {
                            currentBoss.dropCollectables(droppedCoins, droppedPotions);
                        }

                        if (currentBoss.name == "Aegis" && currentBoss.isDead && isVictory == false)
                        {
                            isVictory = true;
                            isWinScreenShown = true;
                            currWinBtn = 0;
                            winBtns();
                            timer.Stop();
                            drawDubb(this.CreateGraphics());
                            return;
                        }
                    }
                    enemyController.Update(tiles, hero, droppedCoins, droppedPotions);
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

            hero.inventory.loadImages();

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
                else if (isWinScreenShown == true)
                {
                    WinScreen(g);
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


                    if (levels.currentLevel < levels.levels.Count - 1)
                    {
                        levels.levels[levels.currentLevel].teleporter.draw(g, hero, showRanges, camX, camY, IsBossGateActive());
                    }

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
                    for (int i = 0; i < droppedPotions.Count; i++)
                    {
                        droppedPotions[i].draw(g, camX, camY);
                    }
                    for (int i = 0; i < movingPlatforms.Count; i++)
                    {
                        movingPlatforms[i].draw(g, camX);
                    }

                    boss currentBoss = levels.getCurrentBoss();
                    if (currentBoss != null)
                    {
                        currentBoss.Draw(g, showRanges, camX, camY);
                    }

                    hero.Draw(g, showRanges, camX, camY);

                    if (hero.inventory.isOpen)
                    {
                        drawInventory(g);
                    }

                    save.autoSave(hero, enemyController.enemies, levels, levels.currentLevel, g, this.ClientSize.Height);
                    
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

        public float getPanX() { return (this.ClientSize.Width - 330f) / 2f; }
        public float getPanY() { return (this.ClientSize.Height - 315f) / 2f; }

        void drawInventory(Graphics g)
        {
            float panX = getPanX();
            float panY = getPanY();

            SolidBrush overlay = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            g.FillRectangle(overlay, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            Bitmap panel = hero.inventory.panelImages[hero.ColorIdx];
            g.DrawImage(panel, panX, panY, 330f, 315f);

            for (int col = 0; col < 5; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    float sx = panX + hero.inventory.cellCX[col] * 3f - hero.inventory.slotRenderSize / 2f;
                    float sy = panY + hero.inventory.cellCY[row] * 3f - hero.inventory.slotRenderSize / 2f;

                    Image slotToDraw = hero.inventory.slotImg;
                    if ((col == hero.inventory.hoveredCol && row == hero.inventory.hoveredRow) || (col == 0 && row < hero.Weapons.Count && row == hero.currentWeapon))
                        slotToDraw = hero.inventory.slotSelectedImg;

                    g.DrawImage(slotToDraw, sx, sy, hero.inventory.slotRenderSize, hero.inventory.slotRenderSize);

                    if (col == 0 && row < 4)
                    {
                        if (row < hero.Weapons.Count)
                        {
                            float imgSize = hero.inventory.slotRenderSize - 8f;
                            float ix = sx + (hero.inventory.slotRenderSize - imgSize) / 2f;
                            float iy = sy + (hero.inventory.slotRenderSize - imgSize) / 2f;
                            g.DrawImage(hero.Weapons[row].UIImage, ix, iy, imgSize, imgSize);
                        }
                    }
                    else if (col >= 1 && row <= 1)
                    {
                        int pi = (row * 4) + (col - 1);
                        if (pi < hero.inventory.potions.Count)
                        {
                            string ptype = hero.inventory.potions[pi].type;
                            int count = hero.inventory.potions[pi].count;
                            Bitmap pImg = hero.inventory.getPotionImage(ptype);
                            if (pImg != null && count > 0)
                            {
                                float imgSize = hero.inventory.slotRenderSize - 6f;
                                float ix = sx + (hero.inventory.slotRenderSize - imgSize) / 2f;
                                float iy = sy + (hero.inventory.slotRenderSize - imgSize) / 2f;
                                g.DrawImage(pImg, ix, iy, imgSize, imgSize);

                                string countStr = count.ToString();
                                Font cntFont = new Font("System", 10, FontStyle.Bold);
                                Brush cntBrush = new SolidBrush(Color.White);
                                float tx = sx + hero.inventory.slotRenderSize - g.MeasureString(countStr, cntFont).Width - 2f;
                                float ty = sy + hero.inventory.slotRenderSize - g.MeasureString(countStr, cntFont).Height - 1f;
                                g.DrawString(countStr, cntFont, cntBrush, tx, ty);
                            }
                        }
                    }
                    else if (row == 4)
                    {
                        if (col == 0)
                        {
                            if (hero.Weapons.Count > 0)
                            {
                                float imgSize = hero.inventory.slotRenderSize - 8f;
                                float ix = sx + (hero.inventory.slotRenderSize - imgSize) / 2f;
                                float iy = sy + (hero.inventory.slotRenderSize - imgSize) / 2f;
                                g.DrawImage(hero.Weapons[hero.currentWeapon].UIImage, ix, iy, imgSize, imgSize);
                            }
                        }
                        else
                        {
                            int qi = col - 1;
                            if (qi < hero.inventory.quickSlotIndices.Length)
                            {
                                int wi = hero.inventory.quickSlotIndices[qi];
                                if (wi >= 0 && wi < hero.Weapons.Count)
                                {
                                    float imgSize = hero.inventory.slotRenderSize - 8f;
                                    float ix = sx + (hero.inventory.slotRenderSize - imgSize) / 2f;
                                    float iy = sy + (hero.inventory.slotRenderSize - imgSize) / 2f;
                                    g.DrawImage(hero.Weapons[wi].UIImage, ix, iy, imgSize, imgSize);
                                }
                            }
                        }
                    }
                }
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
                while(hero.fireballs.Count > 0){
                    hero.fireballs.RemoveAt(0);
                }
                hero.isCastingAbility = false;
                hero.abilityFireballSpawned = false;
            }

            for (int i = 0; i < enemyController.enemies.Count; i++)
            {
                while (enemyController.enemies[i].charges.Count > 0)
                {
                    enemyController.enemies[i].charges.RemoveAt(0);
                }
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


            textY += 35;

            G.DrawString("F -> Shielding", smallFont, white, x + 70, textY);


            textY += 35;

            G.DrawString("R -> Lazer shooting", smallFont, white, x + 70, textY);
        }

        void drawCreditsScreen(Graphics G, int x, int y, int width, int height, Font titleFont, Font normalFont, SolidBrush white, SolidBrush gold)
        {
            G.DrawString("Credits", titleFont, gold, x + 20, y + 10);


            G.DrawString("Arcane", new Font("System", 28, FontStyle.Bold), gold, x + 50, y + 110);

            G.DrawString("Developed By:", normalFont, white, x + 50, y + 190);

            G.DrawString("Kareem Ahmed Taha - 254914", normalFont, gold, x + 70, y + 250);

            G.DrawString("Mostafa Mohamed Saeed - 254595", normalFont, gold, x + 70, y + 300);

            Font smallFont = new Font("System", 9, FontStyle.Italic);
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
            isVictory = false;
            isWinScreenShown = false;

            while (WinBtns.Count > 0)
            {
                WinBtns.RemoveAt(0);
            }

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
            isWinScreenShown = false;
            hasStarted = false;
            while (GameOverBtns.Count > 0)
            {
                GameOverBtns.RemoveAt(0);
            }
            while (WinBtns.Count > 0)
            {
                WinBtns.RemoveAt(0);
            }
            currGameOverBtn = 0;
            currWinBtn = 0;
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

        void manageWinScreen()
        {
            isWinScreenShown = false;
            isGameOverScreenShown = false;
            isVictory = false;
            hasStarted = false;

            while (WinBtns.Count > 0)
            {
                WinBtns.RemoveAt(0);
            }
            while (GameOverBtns.Count > 0)
            {
                GameOverBtns.RemoveAt(0);
            }

            currWinBtn = 0;
            currGameOverBtn = 0;
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
                save.save(hero, enemyController.enemies , levels, levels.currentLevel);
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
            Font titleFont = new Font("System", 22, FontStyle.Bold);
            Font normalFont = new Font("System", 14, FontStyle.Bold);
            Font smallFont = new Font("System", 11, FontStyle.Bold);

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

        void winBtns()
        {
            while (WinBtns.Count > 0)
            {
                WinBtns.RemoveAt(0);
            }

            int w = 300, h = 60;

            int ButtonsY = 280;
            int ButtonsX = (this.ClientSize.Width / 2) - w / 2;

            Button btn = new Button(ButtonsX, ButtonsY, w, h, "Main Menu");
            WinBtns.Add(btn);
        }

        void GameOverScreen(Graphics g)
        {
            Font titleFont = new Font("System", 28, FontStyle.Bold);
            Font normalFont = new Font("System", 14, FontStyle.Bold);

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

        void WinScreen(Graphics g)
        {
            Font titleFont = new Font("System", 28, FontStyle.Bold);
            Font normalFont = new Font("System", 14, FontStyle.Bold);

            SolidBrush background = new SolidBrush(Color.FromArgb(0, 0, 0));
            g.FillRectangle(background, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            SolidBrush white = new SolidBrush(Color.White);
            SolidBrush gold = new SolidBrush(Color.Gold);

            int X = this.ClientSize.Width / 2;
            int Y = 100;
            string winText = "YOU WIN";
            g.DrawString(winText, titleFont, gold, X - 95, Y);

            for (int i = 0; i < WinBtns.Count; i++)
            {
                bool isIt = false;

                if (i == currWinBtn)
                {
                    isIt = true;
                }

                Button btn = WinBtns[i];

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

        bool IsBossGateActive()
        {
            boss currentBoss = levels.getCurrentBoss();
            if (currentBoss == null)
            {
                return false;
            }

            if (currentBoss.isDead == false)
            {
                return true;
            }

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
    int spacing = 20;
    int pad = 20;

    G.DrawImage(menuImgs[0],
        new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height),
        new Rectangle(0, 0, menuImgs[0].Width, menuImgs[0].Height),
        GraphicsUnit.Pixel);

    G.DrawImage(menuImgs[1],
        new Rectangle(spacing, spacing, this.ClientSize.Width / 2 - spacing, this.ClientSize.Height - spacing * 2),
        new Rectangle(0, 0, menuImgs[1].Width, menuImgs[1].Height),
        GraphicsUnit.Pixel);

    G.DrawImage(menuImgs[2],
        new Rectangle(this.ClientSize.Width / 2, spacing, this.ClientSize.Width / 2 - spacing, this.ClientSize.Height - spacing * 2),
        new Rectangle(0, 0, menuImgs[2].Width, menuImgs[2].Height),
        GraphicsUnit.Pixel);

    int borderW = this.ClientSize.Width / 2 - pad * 2;
    int borderHeight = this.ClientSize.Height - spacing * 2 - pad * 2 - 5;

    G.DrawImage(menuImgs[4],
        new Rectangle(pad + 5, spacing + pad / 2, borderW, borderHeight),
        new Rectangle(0, 0, menuImgs[4].Width, menuImgs[4].Height),
        GraphicsUnit.Pixel);

    G.DrawImage(menuImgs[3],
        new Rectangle(spacing + 20, spacing + 20, this.ClientSize.Width / 2 - spacing - 50, 400),
        new Rectangle(0, 0, menuImgs[3].Width, menuImgs[3].Height),
        GraphicsUnit.Pixel);

    int borderX = this.ClientSize.Width / 2 + pad;
    int borderY = spacing + pad / 2;

    G.DrawImage(menuImgs[4],
        new Rectangle(borderX, borderY, borderW, borderHeight),
        new Rectangle(0, 0, menuImgs[4].Width, menuImgs[4].Height),
        GraphicsUnit.Pixel);

    int iconW = 100;

    G.DrawImage(menuImgs[5],
        new Rectangle(borderX + 60, borderY + 60, iconW, iconW),
        new Rectangle(0, 0, menuImgs[5].Width, menuImgs[5].Height),
        GraphicsUnit.Pixel);

    Font f = new Font("System", 18, FontStyle.Bold);
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

            Font titleFont = new Font("System", 22, FontStyle.Bold);
            Font normalFont = new Font("System", 14, FontStyle.Bold);
            Font smallFont = new Font("System", 11, FontStyle.Bold);

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
            isVictory = false;
            isWinScreenShown = false;

            load.loadLevel();
            levels.currentLevel = load.level;

            levels.initAll(this.ClientSize.Height, this.ClientSize.Width);

            levels.loadLadders(ladders);
            levels.loadTiles(tiles);
            levels.loadEnemies(enemyController.enemies);
            levels.loadPlatforms(movingPlatforms);
            hero = load.load(hero, enemyController.enemies, this.ClientSize.Height, levels);
        }    

        void startNewGame()
        {
            isVictory = false;
            isWinScreenShown = false;
            hero = new Hero(30, this.ClientSize.Height - 150 - 30, 150, 150, ChoiceIdx);

            hero.inventory.loadImages();

            levels.initAll(this.ClientSize.Height, this.ClientSize.Width);

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
    