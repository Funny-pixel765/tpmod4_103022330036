using System;
using tpmod4_103022330036;

public class Program
{
    public static void Main()
    {
        // First part - kodePos
        Console.WriteLine("Nama kelurahan: ");
        Console.WriteLine(" ");
        foreach (kodePos.Kelurahan kelurahan in Enum.GetValues(typeof(kodePos.Kelurahan)))
        {
            string namaKel = kelurahan.ToString();
            Console.WriteLine($"{namaKel,-12} {kodePos.GetKodePos(kelurahan)}");
        }
        Console.WriteLine("\n");

        // Second part - DoorMachine
        DoorMachine door = new DoorMachine();

        // Display initial state
        Console.WriteLine("State awal:");
        door.DisplayStateMessage();

        Console.WriteLine("\nMembuka pintu:");
        door.ProcessTrigger(DoorTrigger.BUKA_PINTU);

        Console.WriteLine("\nMengunci pintu:");
        door.ProcessTrigger(DoorTrigger.KUNCI_PINTU);

        Console.WriteLine("\nMencoba trigger yang tidak valid:");
        // Try the same trigger again (which should not be valid now)
        door.ProcessTrigger(DoorTrigger.KUNCI_PINTU);

    }
}