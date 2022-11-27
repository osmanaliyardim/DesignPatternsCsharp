/// <summary>
/// This real-world code demonstrates 
/// the creation of different animal worlds 
/// for a computer game using different factories. 
/// Although the animals created by the Continent factories are different, 
/// the interactions among the animals remain the same.
/// </summary>

ContinentFactory contFactory1 = new AfricaFactory();
AnimalWorld world1 = new AnimalWorld(contFactory1);
world1.RunFoodChain();

ContinentFactory contFactory2 = new AmericaFactory();
AnimalWorld world2 = new AnimalWorld(contFactory2);
world2.RunFoodChain();

Console.ReadLine();

abstract class ContinentFactory
{
    public abstract Herbivore CreateHerbivore();

    public abstract Carnivore CreateCarnivore();
}

class AfricaFactory : ContinentFactory
{
    public override Carnivore CreateCarnivore()
    {
        return new Lion();
    }

    public override Herbivore CreateHerbivore()
    {
        return new Gazelle();
    }
}

class AmericaFactory : ContinentFactory
{
    public override Carnivore CreateCarnivore()
    {
        return new Wolf();
    }

    public override Herbivore CreateHerbivore()
    {
        return new Bison();
    }
}

abstract class Herbivore
{
}

abstract class Carnivore
{
    public abstract void Eat(Herbivore herbivore);
}

class Gazelle : Herbivore
{
}

class Lion : Carnivore
{
    public override void Eat(Herbivore herbivore)
    {
        Console.WriteLine(this.GetType().Name + 
            " eats " 
            + herbivore.GetType().Name);
    }
}

class Bison : Herbivore
{
}

class Wolf : Carnivore
{
    public override void Eat(Herbivore herbivore)
    {
        Console.WriteLine(this.GetType().Name + 
            " eats " +
            herbivore.GetType().Name);
    }
}

class AnimalWorld
{
    private Herbivore _herbivore;
    private Carnivore _carnivore;

    public AnimalWorld(ContinentFactory _continentFactory)
    {
        _herbivore = _continentFactory.CreateHerbivore();
        _carnivore = _continentFactory.CreateCarnivore();
    }

    public void RunFoodChain()
    {
        _carnivore.Eat(_herbivore);
    }
}