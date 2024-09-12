namespace EierfarmBl; // File-scoped namespace

public class Ei
{
    // Konstruktor (Snippet ctor)
    public Ei(IEileger mutter)
    {
        Random random = new Random();
        this.Gewicht = random.Next(45, 81); // Ei-Gewicht zwischen 45g und 80g
        this.Farbe = (EiFarbe)random.Next(3); // Direct-Cast - liefert Exception, wenn Cast fehlschlägt!
        // this.Farbe = (EiFarbe)42;

        this.Mutter = mutter;
    }

    public IEileger Mutter { get; set; }

    // Full-qualified Property (propfull)
    // Backing Field für die Gewicht-Property
    private double _gewicht = 23;

    // Öffentlicher Teil der Gewicht-Property
    public double Gewicht
    {
        // Accessoren
        get { return _gewicht; } // var g = ei.Gewicht;
        set
        {
            if (value <= 0) return;
            _gewicht = value;
        } // ei.Gewicht = 42;
    }

    // Auto-Property (Snippet prop)
    // Eigenschaft mit einem automatisch (durch den Compiler) generiertem Backing Field
    public Guid Id { get; set; } = Guid.NewGuid(); // Auto-Property-Initializer (wird vor(!) dem Konstruktor ausgeführt)

    public DateTime Legedatum { get; set; } = DateTime.Now;

    public EiFarbe Farbe { get; set; }


}

public enum EiFarbe
{
    Hell,
    Dunkel,
    Gruen
}