namespace cs690_final_project_source;

public class Ingredient
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

    public static string SubstitutionDelete(string toSub_selection, string sub_selection)
    {
        Storage.ReadSubstitutions();

        var entry = Storage.substitutions.Find(n => n.toSub.name == toSub_selection || n.sub.name == sub_selection);

        Storage.substitutions.Remove(entry);

        return Storage.WriteSubstitutions();
    }
}
