using DungeonCrawler;

LevelData level = new LevelData();
level.Load("Level1.txt");

Player player = new Player(level.PlayerStartX, level.PlayerStartY);

HashSet<LevelElement> seenWalls = new HashSet<LevelElement>();

while (player.HP >0)
{
    Console.Clear();

    foreach (LevelElement element in level.Elements)
    {
        double dist = Math.Sqrt(Math.Pow(element.X - player.X, 2) + Math.Pow(element.Y - player.Y, 2));

        if (element is Wall)
        {
            if (dist <= 5) seenWalls.Add(element);
            if (seenWalls.Contains(element)) element.Draw();
        }
        else if (dist <= 5)
        {
            element.Draw();
        }
    }

    player.Draw();

    Console.SetCursorPosition(0, 20);
    Console.WriteLine("HP: " + player.HP);

    ConsoleKey key = Console.ReadKey(true).Key;

    int dx = 0;
    int dy = 0;

    if (key == ConsoleKey.Escape)
    {
        break;
    }
    else if (key == ConsoleKey.UpArrow)
    {
        dy = -1;
    }
    else if (key == ConsoleKey.DownArrow)
    {
        dy = 1;
    }
    else if (key == ConsoleKey.RightArrow)
    {
        dx = 1;
    }
    else if (key == ConsoleKey.LeftArrow)
    {
        dx = -1;
    }

    LevelElement? target = level.GetElementAt(player.X + dx, player.Y + dy);

    if (target == null)
    {
        player.X += dx;
        player.Y += dy;
    }
    else if (target is Enemy enemy)
    {
        enemy.HP -= Dice.Damage(player.AttackDice, enemy.DefenceDice);
        if (enemy.HP > 0)
        {
            player.HP -= Dice.Damage(enemy.AttackDice, player.DefenceDice);
        }
    }
    foreach (LevelElement element in level.Elements.ToList())
    {

        if (element is Enemy e)
        {
            e.Update(level, player);
        }
    }

    level.Elements.RemoveAll(x => x is Enemy en && en.HP <= 0);

}

Console.Clear();
Console.WriteLine("Game over");

