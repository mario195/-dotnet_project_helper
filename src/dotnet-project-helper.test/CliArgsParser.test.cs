using System;
using Xunit;
using dotnet_project_helper.lib.Services;

namespace dotnet_project_helper.test
{
    public class CliArgsParserTest
    {
        string[] args;

        CliArgsParser parser;

        public CliArgsParserTest()
        {
            parser = new CliArgsParser();

            args = new[]{
                "-g",
                "-t",
                "-p",
                "~/test",
                "-a",
                "console",
                "-n",
                "new-app"
             };

            parser.Parse(args);
        }

        [Fact]
        public void ShouldReturnAppname()
        {
            var appname = args[7];

            var parsed_appname = parser.getAppName;

            Assert.Equal(parsed_appname, appname);
        }

        [Fact]
        public void ShouldReturnFullPath()
        {
            var path = args[3];

            var parsed_path = parser.getFullPath;

            Assert.Equal(parsed_path, path);
        }

        [Fact]
        public void ShouldReturnApptype()
        {
            var apptype = args[5];

            var parsed_apptype = parser.getAppType;

            Assert.Equal(parsed_apptype, apptype);
        }

        [Fact]
        public void TrueIfRepoShouldBeCreated()
        {
            var parsed_createRepo = parser.shouldCreateGitRepo;

            Assert.True(parsed_createRepo);
        }

        [Fact]
        public void TrueIfTestProjectShouldBeCreated()
        {
            var parsed_createTestProject = parser.shouldCreateTestProject;

            Assert.True(parsed_createTestProject);
        }
    }
}
