using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2EAD2.Controllers
{
    public class InitializeDb
    {
        public static void Initialize(MovieContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any movies.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie() { Title = "Inception", Genre = "Science Fiction/Thriller", Description="Dom Cobb (Leonardo DiCaprio) is a thief with the rare ability to enter people's dreams and steal their secrets from their subconscious.", Year = "2010" },
            new Movie() { Title = "The butterfly Effect", Genre = "Science Fiction/Thriller", Description="College student Evan Treborn (Ashton Kutcher) is afflicted with headaches so painful that he frequently blacks out.", Year = "2004" },
            new Movie() { Title = "Looper", Genre = "Drama/Thriller", Description="In a future society, time-travel exists, but it's only available to those with the means to pay for it on the black market.", Year = "2012" },
            new Movie() { Title = "Pulp Fiction", Genre = "Drama/Crime", Description="Vincent Vega (John Travolta) and Jules Winnfield (Samuel L. Jackson) are hitmen with a penchant for philosophical discussions.", Year = "1994"  },
            new Movie() { Title = "Bohemian Rhapsody", Genre = "Drama/Biography", Description="Bohemian Rhapsody is a foot-stomping celebration of Queen, their music and their extraordinary lead singer Freddie Mercury. ", Year = "2018" },
            new Movie() { Title = "Jumper", Genre = "Adaptation/Thriller", Description="Aimless David Rice (Hayden Christensen) has the ability to instantly transport himself to any place he can imagine.", Year = "2008" },
            new Movie() { Title = "Django Unchained", Genre = "Drama/Blaxploitation", Description="Two years before the Civil War, Django (Jamie Foxx), a slave, finds himself accompanying an unorthodox German bounty hunter named Dr. King Schultz (Christoph Waltz) on a mission to capture the vicious Brittle brothers.", Year = "2012" },
            new Movie() { Title = "Kingsman: The Secret Service", Genre = "Crime/Science Fiction", Description="Gary Eggsy Unwin (Taron Egerton), whose late father secretly worked for a spy organization, lives in a South London housing estate and seems headed for a life behind bars.", Year = "2014" },
            new Movie() { Title = "A Star Is Born", Genre = "Drama/Romance", Description="Seasoned musician Jackson Maine discovers -- and falls in love with -- struggling artist Ally. She has just about given up on her dream to make it big as a singer until Jackson coaxes her into the spotlight.", Year = "2018" },
            new Movie() { Title = "A Million Ways to Die in the West", Genre = "Romance/Comedy", Description="Mild-mannered sheep farmer Albert Stark (Seth MacFarlane) feels certain that the Western frontier is trying to kill him, then he loses his girlfriend, Louise (Amanda Seyfried), to the town's most successful businessman.", Year = "2014" },
            new Movie() { Title = "Hancock", Genre = "Fantasy/Crime", Description="A scruffy superhero named Hancock (Will Smith) protects the citizens of Los Angeles but leaves horrendous collateral damage in the wake of every well-intentioned feat. ", Year = "2008" },
            new Movie() { Title = "Shrek", Genre = "Fantasy/Adventure", Description="Once upon a time, in a far away swamp, there lived an ogre named Shrek (Mike Myers) whose precious solitude is suddenly shattered by an invasion of annoying fairy tale characters.", Year = "2001" },
            new Movie() { Title = "Deadpool", Genre = "Science Fiction/Action", Description="Wade Wilson (Ryan Reynolds) is a former Special Forces operative who now works as a mercenary. His world comes crashing down when evil scientist Ajax (Ed Skrein) tortures, disfigures and transforms him into Deadpool.", Year = "2016" },
            new Movie() { Title = "The Hangover", Genre = "Comedy", Description="Two days before his wedding, Doug (Justin Bartha) and three friends (Bradley Cooper, Ed Helms, Zach Galifianakis) drive to Las Vegas for a wild and memorable stag party.", Year = "2009" },
            new Movie() { Title = "American Pie", Genre = "Romance/Comedy", Description="A riotous and raunchy exploration of the most eagerly anticipated -- and most humiliating -- rite of adulthood, known as losing one's virginity. In this hilarious lesson in life, love and libido, a group of friends, fed up with their well-deserved reputations as sexual no-hitters, decide to take action.", Year = "1999" },
            new Movie() { Title = "Beetlejuice", Genre = "Fantasy/Horror", Description="After Barbara (Geena Davis) and Adam Maitland (Alec Baldwin) die in a car accident, they find themselves stuck haunting their country residence, unable to leave the house.", Year = "1988" },
            };
            foreach (Movie s in movies)
            {
                context.Movies.Add(s);
            }
            context.SaveChanges();
            
           
        }
    }
}
