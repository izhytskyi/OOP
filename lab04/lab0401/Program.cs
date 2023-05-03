using System;

public class Planet
{
    private string name;
    private int continentsCount;

    public Planet(string name)
    {
        this.name = name;
    }

    public void AddContinent(Continent continent)
    {
        continentsCount++;
        Console.WriteLine($"Added continent {continent.Name} to planet {name}");
    }

    public void PrintContinents()
    {
        Console.WriteLine($"Planet {name} has {continentsCount} continents:");
    }

    public override string ToString()
    {
        return name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Planet planet = (Planet)obj;
        return name.Equals(planet.name) && continentsCount == planet.continentsCount;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode() ^ continentsCount.GetHashCode();
    }
}

public class Continent
{
    private string name;

    public Continent(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }

    public override string ToString()
    {
        return name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Continent continent = (Continent)obj;
        return name.Equals(continent.name);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

public class Ocean
{
    private string name;

    public Ocean(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }

    public override string ToString()
    {
        return name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Ocean ocean = (Ocean)obj;
        return name.Equals(ocean.name);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

public class Island
{
    private string name;

    public Island(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
    }

    public override string ToString()
    {
        return name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Island island = (Island)obj;
        return name.Equals(island.name);
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Planet earth = new Planet("Earth");

        Continent asia = new Continent("Asia");
        earth.AddContinent(asia);

        Continent europe = new Continent("Europe");
        earth.AddContinent(europe);

        Ocean pacific = new Ocean("Pacific");
        Island hawaii = new Island("Hawaii");

        Console.WriteLine($"Created {earth}, {asia}, {europe}, {pacific}, {hawaii}");
        earth.PrintContinents();
    }
}
