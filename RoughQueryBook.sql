/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[created]
      ,[director]
      ,[edited]
      ,[episode_id]
      ,[opening_crawl]
      ,[producer]
      ,[release_date]
      ,[title]
  FROM [star-wars].[dbo].[films]



select top 1 [[title], MAX(LEN([opening_crawl])) AS [opening_crawl] FROM
[dbo].[films] GROUP BY [title]

SELECT TOP 1 [title] FROM
[dbo].[films] ORDER BY LEN([opening_crawl]) DESC

Sele
select people_id, Count(film_id) as film_count from [dbo].[films_characters] GROUP BY people_id order BY film_count desc 

Having MAX(film_id) > 0 
select people_id, film_id from [dbo].[films_characters] where people_id = 1
select * from [dbo].[people] where id in (2,
3,
10) and gender != 'n/a'

select * from [dbo].[people] where name = 'Yoda'
select * from [dbo].[people] where gender = 'n/a'


select * from [dbo].[species] where id in (1,
2)

select species_id, Count(film_id) as film_count from [dbo].[films_species] GROUP BY species_id order BY film_count desc 


What planet in Star Wars universe provided largest number of vehicle pilots?
You need to show the result as a list of items:
● name of the planet
● number of pilots from the planet
● name of each pilot and species they belong toPlanet: Earth - Pilots: (12) Han Solo - Human, Yoda - Yodi
Planet: Alderaan - Pilots: (6) Luke Skywalker - Human, Han Solo - Human

select * from [dbo].[planets]select * from [dbo].[vehicles]select * from [dbo].[starships]select * from [dbo].[vehicles_pilots]select * from dbo.species s where id in (13,
1,
5,
10,
32,
44,
11,
70,
11,
67,
79)v.id as vehical_id, ---Task #4  USE [star-wars]select pl.id as Planet_Id, pl.name , Count(vpl.people_id) as PilotCount from [dbo].[planets] pl, [dbo].[vehicles] v, [dbo].[films_planets] flpl, [dbo].[films_vehicles] flv, [dbo].[vehicles_pilots] vplwhere pl.id = flpl.planet_id and v.id = flv.vehicle_id and flpl.film_id = flv.film_id and v.id = vpl.vehicle_idGroup By pl.id, pl.nameorder by PilotCount desc--pl.id as Planet_Id, pl.name , select pl.id as Planet_Id, vpl.people_id, p.name, spl.species_id, s.name  from [dbo].[planets] pl, [dbo].[vehicles] v, [dbo].[films_planets] flpl, [dbo].[films_vehicles] flv, [dbo].[vehicles_pilots] vpl, [dbo].[species_people] spl, dbo.people p, dbo.species s where pl.id = flpl.planet_id and v.id = flv.vehicle_id and flpl.film_id = flv.film_id and v.id = vpl.vehicle_idand  vpl.people_id = spl.people_id and spl.species_id = s.id and vpl.people_id = p.idand pl.id IN (8,9,1)--Group By pl.id, pl.nameorder by pl.id