using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategorizeBankStatements;

public static class Categorizer
{
    public static Dictionary<string, List<string>> CategoryKeywords { get; set; } = new Dictionary<string, List<string>>
        {
            { "Fuel", new List<string> { "gas", "station", "petrol", "shell", "husky", "petro", "mobil", "chevron", "texaco" } },
            { "Food & Dining", new List<string> { "restaurant", "dining", "eatery", "cafe", "mcdonalds", "starbucks", "kfc", "subway", "chipotle", "grocery", "supermarket", "costco", "safeway", "superstore" } },
            { "Transportation", new List<string> { "uber", "lyft", "taxi", "bus", "subway", "metro", "train", "airline", "air canada", "westjet", "flair", "fuel", "toll" } },
            { "Utilities", new List<string> { "electric", "electricity", "gas", "water", "bill", "utility", "utilities", "internet", "telus", "rogers", "bell", "koodo", "fido", "virgin", "mobile" } },
            { "Shopping", new List<string> { "amazon", "ebay", "walmart", "target", "best buy", "shopping", "retail", "store", "purchase" } },
            { "Entertainment", new List<string> { "cinema", "movie", "netflix", "hulu", "spotify", "concert", "ticket", "event", "theater", "amusement" } },
            { "Health & Fitness", new List<string> { "gym", "fitness", "doctor", "hospital", "clinic", "pharmacy", "health", "wellness", "yoga", "dental" } },
            { "Personal Care", new List<string> { "salon", "spa", "haircut", "beauty", "cosmetics", "sephora", "skincare", "nails" } },
            { "Travel", new List<string> { "hotel", "motel", "airbnb", "booking", "reservation", "car rental", "hertz", "enterprise", "Aavis", "travel", "trip", "vacation" } },
            { "Financial Services", new List<string> { "bank", "atm", "withdrawal", "deposit", "transfer", "interest", "fee", "charge", "loan", "mortgage", "credit card" } },
            { "Education", new List<string> { "tuition", "school", "college", "university", "books", "supplies", "course", "class" } },
            { "Other", new List<string> { "charity", "donation", "gift", "insurance", "tax", "cra", "subscription", "membership" } }
        };

    public static (string, string) CategorizeTransaction(ThisBank transaction)
    {
        var description = transaction.Description1 + " " + transaction.Description2;
        var category = "Other";

        foreach (var categoryKeywords in CategoryKeywords)
        {
            if (categoryKeywords.Value.Any(keyword => description.Contains(keyword)))
            {
                category = categoryKeywords.Key;
                break;
            }
        }

        return (description, category);
    }
}
