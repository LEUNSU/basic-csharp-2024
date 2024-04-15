using System.Net.Http.Headers;

namespace ex13_linqs
{
    class Profile
    {
        private int age;
        public string Name { get; set; } // 자동 프로퍼티
        public int Height { get; set; } // 키에 -21억부터 +21억
        public int Age
        {
            get => age;
            set
            {
                if (value >= 0 && value < 200) { age = value; }
                else { age = 20; } // 잘못 넣었으면 20으로 fix
            }
        }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ 테스트!");

            Profile[] arrProfiles =
            {
                new Profile { Name = "정우성", Height = 186, Age = 49 },
                new Profile { Name = "이정재", Height = 184, Age = 49 },
                new Profile { Name = "김태희", Height = 158, Age = 46 },
                new Profile { Name = "전지현", Height = 172, Age = 44 },
                new Profile { Name = "이문세", Height = 180, Age = 45 },
                new Profile { Name = "장원영", Height = 165, Age = 24 },
                new Profile { Name = "RM", Height = 175, Age = 29 },
            };

            Product[] arrProducts =
            {
                new Product { Title = "비트", Star = "정우성"},
                new Product { Title = "오징어게임", Star = "이정재"},
                new Product { Title = "도둑들", Star = "전지현"},
                new Product { Title = "다이너마이트", Star = "RM"},
                new Product { Title = "Solo 예찬", Star = "이문세"}
            };


            // LINQ 미사용하면
            List<Profile> profiles = new List<Profile>();
            foreach (var profile in arrProfiles)
            {
                if (profile.Height < 175)
                    profiles.Add(profile);
            }

            profiles.Sort(
                (profile1, profile2) =>
                {
                    return profile1.Height - profile2.Height;
                });
            foreach (var profile in profiles)
            {
                Console.WriteLine($"{profile.Name}({profile.Age}세), {profile.Height}cm");
            } // LINQ 사용하지 않으면 15줄 코딩

            // LINQ 사용하면
            Console.WriteLine("LINQ 사용");

            var profiles2 = from profile in arrProfiles
                            where profile.Height <175
                            orderby profile.Height
                            select profile;

            foreach (var profile in profiles2)
            {
                Console.WriteLine($"{profile.Name}({profile.Age}세), {profile.Height}cm");
            } // LINQ 사용하면 8줄 코딩

            // LINQ 기본
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n descending // 내림차순으로 해서
                         select n;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // group by - DB의 group by처럼 집계함수가 필요하진 않음
            var groupProfiles = from p in arrProfiles
                                orderby p.Height ascending
                                group p by p.Height < 175 into g
                                select new {GroupKey = g.Key, Profiles = g};

            foreach (var group in groupProfiles)
            {
                Console.WriteLine($"- 175cm 미만? : {group.GroupKey}");

                foreach (var profile in group.Profiles)
                {
                    Console.WriteLine($">>> {profile.Name}({profile.Age}세) {profile.Height}cm");
                }
            }

            // LINQ JOIN
            var innerJoinResult = from pf in arrProfiles
                                  join pr in arrProducts
                                  on pf.Name equals pr.Star
                                  select new
                                  {
                                      Name = pf.Name,
                                      Work = pr.Title,
                                      Height = pf.Height,
                                      Age = pf.Age
                                  };

            Console.WriteLine("내부조인 결과");
            foreach (var item in innerJoinResult)
            {
                Console.WriteLine($"작품 : {item.Work} / 이름 : {item.Name} / 나이 {item.Age}");   
            }

            var outerJoinResult = from pf in arrProfiles
                                  join pr in arrProducts
                                  on pf.Name equals pr.Star
                                  into ps // 외부 조인시 내부조인 LINQ에 추가되는 부분
                                  from pr in ps.DefaultIfEmpty(new Product() { Title = "작품없음" })
                                  select new
                                  {
                                      Name = pf.Name,
                                      Work = pr.Title,
                                      Height = pf.Height,
                                      Age = pf.Age
                                  };

            Console.WriteLine("외부조인 결과");
            foreach (var item in outerJoinResult)
            {
                Console.WriteLine($"작품 : {item.Work} / 이름 : {item.Name} / 나이 {item.Age}");   
            }
        }   
    }
}
