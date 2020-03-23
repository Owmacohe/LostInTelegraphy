/*
 Game made by: Owen Hellum @ Concordia University
 Project for my COMS 360 and LING 300 classes

 Check out the documentation here: https://bit.ly/LostInTelegraphy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperMessages : MonoBehaviour
{
    public static string[] casualMessages = new string[] {
        "Remember to buy apples when you're out",
        "Can you send me a list of your favourite songs?",
        "Please come see me in my office this Tuesday",
        "When will you be visiting next?",
        "I hope you and your family are doing well",
        "How can I contact your work?",
        "The price of cheese at the store has gone up",
        "Could I come by and borrow some sugar tomorrow?"
    };

    public static string[] seriousMessages = new string[] {
        "The next union meeting is tomorrow evening",
        "Have you been going to church lately?",
        "I'm not really a fan of the new government",
        "How many job notices do you intend to put up?",
        "I suggest you invest in coal industry stock",
        "Has your new factory job been keeping you busy?",
        "I would like to register in the journalism class",
        "How many times have I told you not to let your kid cross my lawn?"
    };

    public static string[] direMessages = new string[] {
        "The embassy is the next target, be prepared",
        "How many of the 'goods' were you able to secure?",
        "The bar down the street just opened up its first womens' only evening",
        "Where will the opposition party be having its headquarters?",
        "I'll be putting on my first counter-culture art show tomorrow",
        "I wonder if other countries have similar problems?",
        "It's very important to be an armed citizen",
        "When do you have time to organize the next protest?"
    };

    public static string[,] synonyms = new string[,]
    {
        //casual synonyms
        {
            "buy",

            "bribe",
            "corrupt",
            "aquire",
            "bargain",
            "steal",
            "purchase"
        },
        {
            "out",

            "away",
            "knocked out",
            "stunned",
            "prohibited",
            "taboo",
            "extinct"
        },
        {
            "send",

            "mail",
            "post",
            "commit",
            "broadcast",
            "transmit",
            "transport"
        },
        {
            "favourite",

            "best-loved",
            "favored",
            "preferent",
            "preferred",
            "darling",
            "deary",
        },
        {
            "see",

            "realize",
            "understand",
            "envision",
            "fancy",
            "picture",
            "visualize"
        },
        {
            "office",

            "berth",
            "billet",
            "place",
            "position",
            "post",
            "situation",
        },
        {
            "hope",

            "go for",
            "desire",
            "trust",
            "promise",
            "bob hope",
            "wish"
        },
        {
            "family",

            "crime syndicate",
            "mob",
            "syndicate",
            "kin",
            "kinsperson",
            "fellowship",
        },
        {
            "contact",

            "reach",
            "get through",
            "reach",
            "touch",
            "adjoin",
            "meet"

        },
        {
            "work?",

            "chore?",
            "task?",
            "caper?",
            "speculate?",
            "business?",
            "line?"
        },
        {
            "price",

            "cost",
            "toll",
            "value",
            "worth",
            "damage",
            "terms"
        },
        {
            "store",

            "memory board",
            "storage",
            "depot",
            "entrepot",
            "storehouse",
            "shop",
        },
        {
            "come",

            "make out",
            "fall",
            "arrive",
            "get",
            "retrace",
            "follow"
        },
        {
            "borrow",

            "adopt",
            "take over",
            "take up",
            "accumulate",
            "share",
            "use"
        },

        //serious synonyms
        {
            "union",

            "pairing",
            "counterculture",
            "join",
            "sum",
            "brotherhood",
            "cast"
        },
        {
            "evening",

            "sunset",
            "midnight",
            "late afternoon",
            "morrow",
            "dinnertime",
            "supper"
        },
        {
            "going",

            "departure",
            "going away",
            "leaving",
            "exit",
            "expiration",
            "passing"
        },
        {
            "church",

            "confession",
            "ceremony",
            "mosque",
            "synagogue",
            "duty",
            "prayer"
        },
        {
            "fan",

            "rooter",
            "supporter",
            "winnow",
            "buff",
            "devotee",
            "lover"
        },
        {
            "government",

            "administration",
            "governance",
            "governing",
            "government activity",
            "authorities",
            "regime"
        },
        {
            "job",

            "line",
            "toil",
            "occupation",
            "task",
            "subcontract",
            "problem"
        },
        {
            "put",

            "assign",
            "cast",
            "couch",
            "frame",
            "redact",
            "arrange"
        },
        {
            "invest",

            "enthrone",
            "enpower",
            "induct",
            "seat",
            "commit",
            "place"
        },
        {
            "stock",

            "pocket",
            "stockpile",
            "support",
            "bonds",
            "existance",
            "fund"
        },
        {
            "factory",

            "manufactory",
            "creation",
            "mill",
            "production",
            "assembly",
            "service"
        },
        {
            "busy?",

            "interfering?",
            "meddlesome?",
            "meddling?",
            "engaged?",
            "occupied?",
            "fussy?"
        },
        {
            "register",

            "record",
            "show",
            "file",
            "cross-file",
            "enroll",
            "inquire"
        },
        {
            "class",

            "course",
            "form",
            "grade",
            "category",
            "family",
            "division"
        },
        {
            "kid",

            "minor",
            "nestling",
            "nipper",
            "shaver",
            "tike",
            "tiddler"
        },
        {
            "cross",

            "intersect",
            "pass",
            "trample",
            "run over",
            "use",
            "mess up"
        },

        //dire synonyms
        {
            "embassy",

            "hall",
            "government",
            "political building",
            "opposition",
            "diplomatic house",
            "safe area"
        },
        {
            "target",

            "fair game",
            "prey",
            "quarry",
            "mark",
            "direct",
            "place"
        },
        {
            "'goods'",

            "resources",
            "drugs",
            "supplies",
            "aid",
            "packages",
            "targets"
        },
        {
            "secure",

            "enforce",
            "plug",
            "stop up",
            "assure",
            "ensure",
            "guarantee"
        },
        {
            "bar",

            "hangout",
            "place",
            "barroom",
            "ginmill",
            "saloon",
            "taproom"
        },
        {
            "only",

            "exclusive",
            "solely",
            "basicly",
            "just",
            "merely",
            "simply"
        },
        {
            "opposition",

            "enemy",
            "confrontation",
            "foeman",
            "resistance",
            "opponent",
            "opposite"
        },
        {
            "headquarters",

            "central office",
            "home base",
            "home office",
            "main office",
            "base",
            "meeting place"
        },
        {
            "counter-culture",

            "opposition",
            "violent",
            "pushback",
            "revolutionary",
            "anti-capitalist",
            "social"
        },
        {
            "show",

            "demonstation",
            "performance",
            "display",
            "demo",
            "demonstrate",
            "exhibit"
        },
        {
            "countries",

            "lands",
            "states",
            "body politics",
            "commonwealths",
            "nations",
            "areas"
        },
        {
            "problems?",

            "troubles?",
            "jobs?",
            "issues?",
            "duties?",
            "values?",
            "annoyances?"
        },
        {
            "important",

            "authoritative",
            "of import",
            "significant",
            "crucial",
            "dire",
            "vital"
        },
        {
            "armed",

            "powerful",
            "dangerous",
            "prepared",
            "safe",
            "ready",
            "weaponized"
        },
        {
            "organize",

            "direct",
            "engineer",
            "mastermind",
            "orchestrate",
            "organise",
            "unionise"
        },
        {
            "protest?",

            "dissent?",
            "objection?",
            "resist?",
            "demonstration?",
            "scheme?",
            "manifestation?"
        }
    };

    public static string[] randomWords = new string[]
    {
        "now",
        "cut",
        "hurried",
        "have",
        "everything",
        "dollar",
        "die",
        "answer",
        "mental",
        "underline",
        "hunt",
        "mission",
        "sale",
        "radio",
        "bridge",
        "outside",
        "hot",
        "west",
        "force",
        "hundred",
        "shinning",
        "kind",
        "concerned",
        "slip",
        "musical",
        "cast",
        "dried",
        "area",
        "ocean",
        "drawn",
        "poet",
        "signal",
        "immediately",
        "lose",
        "heart",
        "trail",
        "catch",
        "made",
        "for",
        "police",
        "chance",
        "or",
        "my",
        "note",
        "crew",
        "world",
        "noise",
        "chief",
        "tonight",
        "wire",
        "as",
        "bone",
        "concerned",
        "birthday",
        "powder",
        "especially",
        "anyone",
        "chamber",
        "clear",
        "gentle",
        "pack",
        "railroad",
        "cut",
        "build",
        "tiny",
        "deal",
        "probably",
        "exercise",
        "inch",
        "bigger",
        "instant",
        "butter",
        "has",
        "equally",
        "test",
        "fix",
        "structure",
        "furniture",
        "taste",
        "voice",
        "guess",
        "everything",
        "round",
        "lady",
        "camp",
        "accurate",
        "nice",
        "garage",
        "horn",
        "away",
        "muscle",
        "flies",
        "gather",
        "due",
        "may",
        "page",
        "ship",
        "explanation",
        "sit",
        "successful"
    };

    public static string getRandomWord()
    {
        return randomWords[Random.Range(0, randomWords.Length)];
    }
}
