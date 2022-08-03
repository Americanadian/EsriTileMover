using System;
public class Platformer
{
    private List<Object> tiles;
    private object position = -1;
    private int last = -1;

    public Platformer(int numberOfTiles, int position)
    {
        if ((position < 0) || (position >= numberOfTiles))
        {
            throw new ArgumentOutOfRangeException("position must be between 0 and " + numberOfTiles);
        }

        tiles = new List<Object>(numberOfTiles);
        for (int i = 0; i < numberOfTiles; i++)
        {
            tiles.Add(i);
        }

        //this.Position = position;
        this.position = position;
    }

    public void JumpLeft()
    {
        int temp = (int)this.position;

        tiles.Remove(this.position);

        try
        {
            this.position = (int)tiles[temp - 2];
        }
        catch
        {
            try
            {
                this.position = (int)tiles[temp - 1];
            }
            catch
            {
                try
                {
                    this.position = (int)tiles[temp];
                }
                catch
                {
                    this.position = -1;
                    this.last = temp;
                }
            }
        }
    }

    public void JumpRight()
    {
        int temp = (int)this.position;

        tiles.Remove(this.position);


        try
        {
            this.position = (int)tiles[temp + 2];
        }
        catch
        {
            try
            {
                this.position = (int)tiles[temp + 1];
            }
            catch
            {
                try
                {
                    this.position = (int)tiles[temp];
                }
                catch
                {
                    this.position = -2;
                    this.last = temp;
                }
            }
        }
    }

    public Object Position
    {
        get
        {
            if ((int)this.position == -1)
            {
                this.position = this.last;
                return "No more moves left...";
            }
            else if ((int)this.position == -2)
            {
                this.position = this.last;
                return "No more moves right...";
            }
            return this.position;
        }
        set
        {
            this.position = value;
        }
    }
    
    public static void Main(string[] args)
    {
        Platformer platformer = new Platformer(6, 5);
        Console.WriteLine(platformer.Position); // should print 5

        platformer.JumpLeft();
        Console.WriteLine(platformer.Position); // should print 3

        platformer.JumpRight();
        Console.WriteLine(platformer.Position); // should print 4

        platformer.JumpLeft();
        Console.WriteLine(platformer.Position); // should print 2

        platformer.JumpLeft();
        Console.WriteLine(platformer.Position); // should print 0

        platformer.JumpRight();
        Console.WriteLine(platformer.Position); // should print 1

        platformer.JumpRight();
        Console.WriteLine(platformer.Position); // should print "No more moves right"

        platformer.JumpRight();
        Console.WriteLine(platformer.Position); // should print "No more moves right"

        platformer.JumpLeft();
        Console.WriteLine(platformer.Position); // should print "No more moves left"

        Console.ReadKey();
    }
}