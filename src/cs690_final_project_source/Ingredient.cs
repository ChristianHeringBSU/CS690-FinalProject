namespace cs690_final_project_source;

using Spectre.Console;

class Ingredient
{
    public struct Substitution
    {
        public Inventory.Ingredient toSub { get; set; }
        public Inventory.Ingredient sub { get; set; }
    }

    public static string SubstitutionAdd(Substitution entry)
    {
        Storage.ReadSubstitutions();

        Storage.substitutions.Add(entry);

        return Storage.WriteSubstitutions();
    }

    public static string SubstitutionDelete(string selection)
    {
        Storage.ReadSubstitutions();

        var entry = Storage.substitutions[Convert.ToInt32(selection)];

        Storage.substitutions.Remove(entry);

        return Storage.WriteSubstitutions();
    }
}
