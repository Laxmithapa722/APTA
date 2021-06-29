using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APTA.Data;
using APTA.Models;


namespace APTA.Data
{
    public class DbInitializer
    {
        public static void Initialize(ConferenceContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Members.
            if (context.Member.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
                new Member{FirstName="Ami",LastName="Woo",Phone=0411734656,Email="iamiwoo@gmail.com",Address="456 Lorensen Street",RegistrationDate=DateTime.Parse("2019-09-01")},
                new Member{FirstName="Arturo",LastName="Anand",Phone=0445677752,Email="arturo.ana@gmail.com",Address="11/34 Bourke Street",RegistrationDate=DateTime.Parse("2018-09-01")},
                new Member{FirstName="Carson",LastName="Alex",Phone=0411677722,Email="carson.alex@gmail.com",Address="220 Spencer Street",RegistrationDate=DateTime.Parse("2019-09-01")},
                new Member{FirstName="Gytis",LastName="Barz",Phone=0431666722,Email="gytis.barz@gmail.com",Address="55 Nicholson Street",RegistrationDate=DateTime.Parse("2017-09-01")},
                new Member{FirstName="Laura",LastName="Norman",Phone=0411645678,Email="laura.norman@gmail.com",Address="123 Elizabeth Street",RegistrationDate=DateTime.Parse("2018-09-01")},
                new Member{FirstName="Meredith",LastName="Alonso",Phone=0411673422,Email="mere.alonso@gmail.com",Address="200 Sringvale Street",RegistrationDate=DateTime.Parse("2017-09-01")},
                new Member{FirstName="Nino",LastName="Olivetto",Phone=0417363356,Email="nino.olivetto@gmail.com",Address="4545 Russell Street",RegistrationDate=DateTime.Parse("2019-09-01") },
                new Member{FirstName="Peggy",LastName="Justice",Phone=0411655522,Email="peg.justice@gmail.com",Address="4523 Lorimer Street",RegistrationDate=DateTime.Parse("2016-09-01")},
                new Member{FirstName="Yan",LastName="Li",Phone=0411348722,Email="yan.li@gmail.com",Address="234 Little Collin Street",RegistrationDate=DateTime.Parse("2017-09-01")}
            };
            foreach (Member m in members)
            {
                context.Member.Add(m);
            }
            context.SaveChanges();


            var organisers = new Organiser[]
            {
                new Organiser{OrganiserID=1,FirstName="Ami",LastName="Woo",Phone=0411734656,Email="iamiwoo@gmail.com",Sponsor="Lincon University"},
                new Organiser{OrganiserID=2,FirstName="Arturo",LastName="Anand",Phone=0445677752,Email="arturo.ana@gmail.com",Sponsor="Victoria University"},
                new Organiser{OrganiserID=3,FirstName="Carson",LastName="Alex",Phone=0411677722,Email="carson.alex@gmail.com",Sponsor="Monash University"},
                new Organiser{OrganiserID=4,FirstName="Gytis",LastName="Barz",Phone=0431666722,Email="gytis.barz@gmail.com",Sponsor="RMIT University" },
                new Organiser{OrganiserID=5,FirstName="Laura",LastName="Norman",Phone=0411645678,Email="laura.norman@gmail.com",Sponsor="Melbourne University"},
                new Organiser{OrganiserID=6,FirstName="Meredith",LastName="Alonso",Phone=0411673422,Email="mere.alonso@gmail.com",Sponsor="La Trobe University"},
                new Organiser{OrganiserID=7,FirstName="Nino",LastName="Olivetto",Phone=0417363356,Email="nino.olivetto@gmail.com",Sponsor="Sydney University"},
                new Organiser{OrganiserID=8,FirstName="Peggy",LastName="Justice",Phone=0411655522,Email="peg.justice@gmail.com",Sponsor=" Curtin University"},
                new Organiser{OrganiserID=9,FirstName="Yan",LastName="Li",Phone=0411348722,Email="yan.li@gmail.com",Sponsor="Southern University"}
            };
            foreach (Organiser o in organisers)
            {
                context.Organiser.Add(o);
            }
            context.SaveChanges();

            var conferences = new Conference[]
            {
                new Conference{ConferenceID=1,Title="APTA 2019",Date=DateTime.Parse("2019-07-01"),Location="Dang, Vietnam",OrganiserID=1},
                new Conference{ConferenceID=2,Title="APTA 2018",Date=DateTime.Parse("2018-07-03"),Location="Cebu, Philippines",OrganiserID=2},
                new Conference{ConferenceID=3,Title="APTA 2017",Date=DateTime.Parse("2017-06-18"),Location="Busan, Korea",OrganiserID=3},
                new Conference{ConferenceID=4,Title="APTA 2016",Date=DateTime.Parse("2016-06-01"),Location="Beijing, China",OrganiserID=4},
                new Conference{ConferenceID=5,Title="APTA 2015",Date=DateTime.Parse("2015-04-14"),Location="KualaLumpur, Malaysia",OrganiserID=5},
                new Conference{ConferenceID=6,Title="APTA 2014",Date=DateTime.Parse("2014-07-01"),Location="Ho chi minh, Vietnam",OrganiserID=6},
                new Conference{ConferenceID=7,Title="APTA 2013",Date=DateTime.Parse("2013-07-01"),Location="Bangkok, Thailand",OrganiserID=7},
                new Conference{ConferenceID=8,Title="APTA 2012",Date=DateTime.Parse("2012-06-26"),Location="Taipei, Taiwan",OrganiserID=8},
                new Conference{ConferenceID=9,Title="APTA 2011",Date=DateTime.Parse("2011-07-03"),Location="Seoul, Korea",OrganiserID=9}
            };
            foreach (Conference c in conferences)
            {
                context.Conference.Add(c);
            }
            context.SaveChanges();

            var speakers = new Speaker[]
            {
                new Speaker{SpeakerID=1,FirstName="Ami",LastName="Woo",Phone=0411734656,Email="iamiwoo@gmail.com",SpeechTime=DateTime.Parse("02:02:00"),ConferenceID=1},
                new Speaker{SpeakerID=2,FirstName="Arturo",LastName="Anand",Phone=0445677752,Email="arturo.ana@gmail.com",SpeechTime=DateTime.Parse("05:05:00"),ConferenceID=2},
                new Speaker{SpeakerID=3,FirstName="Carson",LastName="Alex",Phone=0411677722,Email="carson.alex@gmail.com",SpeechTime=DateTime.Parse("12:02:00"),ConferenceID=3},
                new Speaker{SpeakerID=4,FirstName="Gytis",LastName="Barz",Phone=0431666722,Email="gytis.barz@gmail.com",SpeechTime=DateTime.Parse("11:05:00"),ConferenceID=4},
                new Speaker{SpeakerID=5,FirstName="Laura",LastName="Norman",Phone=0411645678,Email="laura.norman@gmail.com",SpeechTime=DateTime.Parse("09:05:00"),ConferenceID=5},
                new Speaker{SpeakerID=6,FirstName="Meredith",LastName="Alonso",Phone=0411673422,Email="mere.alonso@gmail.com",SpeechTime=DateTime.Parse("03:05:00"),ConferenceID=6},
                new Speaker{SpeakerID=7,FirstName="Nino",LastName="Olivetto",Phone=0417363356,Email="nino.olivetto@gmail.com",SpeechTime=DateTime.Parse("07:06:00"),ConferenceID=7},
                new Speaker{SpeakerID=8,FirstName="Peggy",LastName="Justice",Phone=0411655522,Email="peg.justice@gmail.com",SpeechTime=DateTime.Parse("06:06:00"),ConferenceID=8},
                new Speaker{SpeakerID=9,FirstName="Yan",LastName="Li",Phone=0411348722,Email="yan.li@gmail.com",SpeechTime=DateTime.Parse("12:00:01"),ConferenceID=9}
            };
            foreach (Speaker s in speakers)
            {
                context.Speaker.Add(s);
            }
            context.SaveChanges();

            var registrations = new Registration[]
            {
                new Registration{MemberID=1,ConferenceID=1050},
                new Registration{MemberID=1,ConferenceID=4022},
                new Registration{MemberID=1,ConferenceID=4041},
                new Registration{MemberID=2,ConferenceID=1045},
                new Registration{MemberID=2,ConferenceID=3141},
                new Registration{MemberID=2,ConferenceID=2021},
                new Registration{MemberID=3,ConferenceID=1050},
                new Registration{MemberID=4,ConferenceID=1050},
                new Registration{MemberID=4,ConferenceID=4022},
            };
            foreach (Registration r in registrations)
            {
                context.Registration.Add(r);
            }
            context.SaveChanges();
        }

    }
}
