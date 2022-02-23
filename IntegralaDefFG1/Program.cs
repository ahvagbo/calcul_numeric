// O sa facem un pic de diagnostica, ca sa analizam aflarea ariei
using System.Diagnostics;

// De mentionat ca metodele de mai jos se aplica doar
// la functiile de gradul I

// Metoda separarii figurilor
float AriaDeSubGrafic_1(Func<float, float> f, float a, float b)
{
#if DEBUG
    Debug.WriteLine("Calcularea integralei definite - metoda separarii figurilor");
#endif

    float u = Math.Abs(b - a);              // Aflam "inaltimea"

#if DEBUG
    Debug.WriteLine($"u = {u}");
#endif

    float dL = u; float dl = f(a);          // Aflam lungimea si latimea dreptunghiului
    float c1 = u; float c2 = f(b) - f(a);   // Aflam catelele triunghiului dreptunghic

#if DEBUG
    Debug.WriteLine($"Dreptunghiul:");
    Debug.WriteLine($"latimea = {dL}, lungimea = {dl}");

    Debug.WriteLine("Triunghiul dreptunghic:");
    Debug.WriteLine($"cateta 1 = {c1}, cateta 2 = {c2}");
#endif

    float D = dl * dL;                      // Aflam aria dreptunghiului
    float T = (c1 * c2) / 2;                // Aflam aria triunghiului dreptunghic

#if DEBUG
    Debug.WriteLine("Ariile figurilor:");
    Debug.WriteLine($"Dreptunghiul = {D}, triunghiul dreptunghic = {T}");
#endif

    return D + T;                           // Se returneaza aria totala de sub grafic
}

// Metoda trapezului dreptunghic
float AriaDeSubGrafic_2(Func<float, float> f, float a, float b)
{
#if DEBUG
    Debug.WriteLine("Calcularea integralei definite - metoda trapezului dreptunghic");
#endif

    float h = Math.Abs(b - a);  // Aflam inaltimea trapezului

#if DEBUG
    Debug.WriteLine($"inaltimea trapezului = {h}");
#endif

    float b1 = f(a);            // Aflam baza mica a trapezului
    float b2 = f(b);            // Aflam baza mare a trapezului

#if DEBUG
    Debug.WriteLine($"baza mica = {b1}");
    Debug.WriteLine($"baza mare = {b2}");
#endif

    // Folosim formula ariei trapezului
    return ((b1 + b2) / 2) * h; // Aflam aria totala de sub grafic
}

Func<float, float> f1 = (x) => 2 * x;
Func<float, float> f2 = (x) => x + 4;
Func<float, float> f3 = (x) => 2 * x + 1;
Func<float, float> f4 = (x) => 3 * x + 5;
Func<float, float> f5 = (x) => 10 * x + 3;

float a, b;
Console.WriteLine("Sa se introduca valorile a si b: ");

Console.Write("a = ");
a = float.Parse(Console.ReadLine()!);

Console.Write("b = ");
b = float.Parse(Console.ReadLine()!);

Console.WriteLine();

Console.WriteLine($"integrala de la {a} la {b} din f(x) = 2x");
Console.WriteLine($"metoda separarii figurilor = {AriaDeSubGrafic_1(f1, a, b)}");
Console.WriteLine($"metoda trapezului dreptunghic = {AriaDeSubGrafic_2(f1, a, b)}");

Console.WriteLine();

Console.WriteLine($"integrala de la {a} la {b} din f(x) = x + 4");
Console.WriteLine($"metoda separarii figurilor = {AriaDeSubGrafic_1(f2, a, b)}");
Console.WriteLine($"metoda trapezului dreptunghic = {AriaDeSubGrafic_2(f2, a, b)}");

Console.WriteLine();

Console.WriteLine($"integrala de la {a} la {b} din f(x) = 2x + 1");
Console.WriteLine($"metoda separarii figurilor = {AriaDeSubGrafic_1(f3, a, b)}");
Console.WriteLine($"metoda trapezului dreptunghic = {AriaDeSubGrafic_2(f3, a, b)}");

Console.WriteLine();

Console.WriteLine($"integrala de la {a} la {b} din f(x) = 3x + 5");
Console.WriteLine($"metoda separarii figurilor = {AriaDeSubGrafic_1(f4, a, b)}");
Console.WriteLine($"metoda trapezului dreptunghic = {AriaDeSubGrafic_2(f4, a, b)}");

Console.WriteLine();

Console.WriteLine($"integrala de la {a} la {b} din f(x) = 10x + 3");
Console.WriteLine($"metoda separarii figurilor = {AriaDeSubGrafic_1(f5, a, b)}");
Console.WriteLine($"metoda trapezului dreptunghic = {AriaDeSubGrafic_2(f5, a, b)}");

Console.ReadKey();
