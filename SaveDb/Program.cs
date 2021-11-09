﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using RemTestSys.Domain;
using RemTestSys.Domain.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace SaveDb
{
    class Program
    {
        static Test[] tests;
        static Question[] questions;
        static Group[] groups;
        static TextAnswer[] textAnswers;
        static OneOfFourVariantsAnswer[] oneOfFourVariantsAnswers;
        static AccessToTestForGroup[] accessToTestForGroups;

        static string remoteString;
        static string localString;
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Enter local conString>>");
            localString = Console.ReadLine();

            Console.WriteLine("Enter remote conString>>");
            remoteString = Console.ReadLine();

            Console.WriteLine("Enter command>>");
            string command = Console.ReadLine();
            switch (command)
            {
                case "fromRemToLocal": await FromRemoteToLocal(remoteString, localString);break;
            }
        }

        private static async Task FromRemoteToLocal(string remote, string local)
        {
            await LoadDb(remote);
            await SaveDb(local);
        }

        private static async Task SaveDb(string connectionString)
        {
            ResetIds();

            DbContextOptionsBuilder<AppDbContext> optsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optsBuilder.UseSqlServer(connectionString);
            using (AppDbContext context = new AppDbContext(optsBuilder.Options))
            {
                context.Groups.AddRange(groups);
                context.Tests.AddRange(tests);
                context.Questions.AddRange(questions);
                context.TextAnswers.AddRange(textAnswers);
                context.OneVariantAnswers.AddRange(oneOfFourVariantsAnswers);
                context.AccessesToTestForGroup.AddRange(accessToTestForGroups);
                await context.SaveChangesAsync();
            }
            Console.WriteLine("Saving done");
        }

        private static async Task LoadDb(string connectionString)
        {
            DbContextOptionsBuilder<AppDbContext> optsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optsBuilder.UseSqlServer(connectionString);
            using (AppDbContext context = new AppDbContext(optsBuilder.Options))
            {
                tests = await context.Tests.ToArrayAsync();
                questions = await context.Questions.ToArrayAsync();
                groups = await context.Groups.ToArrayAsync();
                textAnswers = await context.TextAnswers.ToArrayAsync();
                oneOfFourVariantsAnswers = await context.OneVariantAnswers.ToArrayAsync();
                accessToTestForGroups = await context.AccessesToTestForGroup.ToArrayAsync();
            }
            Console.WriteLine("Loading done");
        }

        private static void ResetIds()
        {
            groups.ToList().ForEach(g => g.Id = 0);
            tests.ToList().ForEach(t => t.Id = 0);
            questions.ToList().ForEach(q => q.Id = 0);
            textAnswers.ToList().ForEach(ta => ta.Id = 0);
            oneOfFourVariantsAnswers.ToList().ForEach(oa => oa.Id = 0);
            accessToTestForGroups.ToList().ForEach(a => a.Id = 0);
        }
    }
}