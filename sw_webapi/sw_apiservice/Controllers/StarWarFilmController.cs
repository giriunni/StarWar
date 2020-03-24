using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using sw_dataservice;

namespace sw_apiservice.Controllers
{
    public class StarWarFilmController : ApiController
    {
     
        public string GetLongestOpeningCrawlTitle()
        {
            string titleLongestOpeningCrawl = string.Empty;
            using (StarWarEntities starWarEntities = new StarWarEntities())
            {
                titleLongestOpeningCrawl = starWarEntities.films.OrderByDescending(f => f.opening_crawl.Length).Select(n => n.title).FirstOrDefault().ToString();
            }
            return titleLongestOpeningCrawl;
        }


        public string GetMostAppearedCharacter()
        {
            int mostAppearedCharaterID = 0;
            string mostAppearedCharaterName = string.Empty;
            using (StarWarEntities starWarEntities = new StarWarEntities())
            {           
                mostAppearedCharaterID = starWarEntities.people.Where(p => p.gender != "n/a").GroupBy(info => info.id)
                        .Select(group => new
                        {
                            p_Id = group.Key,
                            f_Count = group.Sum(t => t.films.Count())
                        })
                        .OrderByDescending(x => x.f_Count).Select(y=> y.p_Id).FirstOrDefault();

                mostAppearedCharaterName = starWarEntities.people.Where(p => p.id == mostAppearedCharaterID).Select(p => p.name).FirstOrDefault().ToString();               

            }
            return mostAppearedCharaterName;
        }

        public List<string> GetMostAppearedSpeciesWithCount()
        {
            List<string> mostAppearedSpeciesNameWithCount = new List<string>();
            int maxCount = 0;
            using (StarWarEntities starWarEntities = new StarWarEntities())
            {
                foreach(var mostAppearedSpeciesIDWithFilmCount in starWarEntities.species.GroupBy(info => info.id)
                         .Select(group => new
                         {
                             s_Id = group.Key,
                             f_Count = group.Sum(t => t.films.Count())
                         })
                         .OrderByDescending(x => x.f_Count).ToList())
                {
                    if (maxCount == 0 || maxCount == mostAppearedSpeciesIDWithFilmCount.f_Count)
                        maxCount = mostAppearedSpeciesIDWithFilmCount.f_Count;
                    else
                        break;
                    string speciesName = starWarEntities.species.Where(p => p.id == mostAppearedSpeciesIDWithFilmCount.s_Id).Select(p => p.name).FirstOrDefault().ToString();
                    mostAppearedSpeciesNameWithCount.Add(speciesName + " (" + mostAppearedSpeciesIDWithFilmCount.f_Count.ToString() + ")\n");
                }
            }
            return mostAppearedSpeciesNameWithCount;
        }

        public List<string> GetLargestNumberOfVehiclePilot()
        {
            List<string> largestNumberOfVehiclePilot = new List<string>();
            int maxCount = 0;
            using (StarWarEntities starWarEntities = new StarWarEntities())
            {
                foreach (var largestNumberPlanetIDWithPeopleCount in starWarEntities.planets.GroupBy(info => new { info.id, info.name })
                         .Select(group => new
                         {
                             pl_Id = group.Key.id,
                             pl_Name = group.Key.name,
                             ppl_Count = group.Sum(f => f.films.Sum(v => v.vehicles.Sum(p => p.people.Count())))
                         })
                         .OrderByDescending(x => x.ppl_Count))
                {
                    if (maxCount == 0 || maxCount == largestNumberPlanetIDWithPeopleCount.ppl_Count)
                        maxCount = largestNumberPlanetIDWithPeopleCount.ppl_Count;
                    else
                        break;

                    string itemValue1  = "Planet:" + largestNumberPlanetIDWithPeopleCount.pl_Name + " - Pilots: (" + largestNumberPlanetIDWithPeopleCount.ppl_Count.ToString() + ") ";
                    string itemValue2 = string.Empty;
                    
                    var peopleSpeciesName = starWarEntities.planets.Where(p => p.id == largestNumberPlanetIDWithPeopleCount.pl_Id).SelectMany(pl => pl.films.SelectMany(f => f.vehicles.SelectMany(v => v.people.SelectMany(p => p.species.Select(s => new { people_name = p.name, species_name = s.name }))))).ToList();
                    itemValue2 = string.Join(", ", peopleSpeciesName.Select(item => item.people_name + " - " + item.species_name));

                    largestNumberOfVehiclePilot.Add(itemValue1 + itemValue2 + "\n");
               }
            }
            return largestNumberOfVehiclePilot;
        }
    }
}
